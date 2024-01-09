using PoS.Data;
using PoS.Services.GenericServices;
using WebApplication1.Models;
using PoS.Dtos.Order;
using PoS.Dtos.OrderItem;
using PoS.Dtos.Payment;
using PoS.Repositories.OrderRepository;
using PoS.Repositories.ProductRepository;
using PoS.Repositories.ServiceRepository;
using PoS.Repositories.DiscountRepository;
using PoS.Repositories.LoyaltyProgramRepository;
using PoS.Repositories.CustomerRepository;
using PoS.Services.PaymentServices;

namespace PoS.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly ILoyaltyProgramRepository _loyaltyProgramRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IPaymentService _paymentService;


        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository,
            IServiceRepository serviceRepository, IDiscountRepository discountRepository, ILoyaltyProgramRepository loyaltyProgramRepository,
            ICustomerRepository customerRepository, IPaymentService paymentService)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _serviceRepository = serviceRepository;
            _discountRepository = discountRepository;
            _loyaltyProgramRepository = loyaltyProgramRepository;
            _customerRepository = customerRepository;
            _paymentService = paymentService;
        }

        private OrderItem CreateOrderItemFromDto(OrderItemDto newItemDto)
        {
            OrderItem newItem;

            if (!string.IsNullOrEmpty(newItemDto.ProductId))
            {
                var product = _productRepository.GetById(newItemDto.ProductId);

                if (product == null)
                {
                    throw new InvalidOperationException("Product not found.");
                }

                newItem = new OrderItem
                {
                    ProductId = newItemDto.ProductId,
                    Quantity = newItemDto.Quantity,
                    TotalPrice = product.Price * newItemDto.Quantity
                };
            }
            else if (!string.IsNullOrEmpty(newItemDto.ServiceId))
            {
                var service = _serviceRepository.GetById(newItemDto.ServiceId);

                if (service == null)
                {
                    throw new InvalidOperationException("Service not found.");
                }

                newItem = new OrderItem
                {
                    ServiceId = newItemDto.ServiceId,
                    Quantity = newItemDto.Quantity,
                    TotalPrice = service.Price * newItemDto.Quantity
                };
            }
            else
            {
                throw new ArgumentException("ProductId or ServiceId must be provided.");
            }

            return newItem;
        }

        private List<OrderItem> MapOrderItems(List<OrderItemDto> orderItemDtos)
        {
            var orderItems = new List<OrderItem>();

            foreach (var item in orderItemDtos)
            {
                var orderItem = CreateOrderItemFromDto(item);

                orderItems.Add(orderItem);
            }

            return orderItems;
        }

        public Order Create(CreateOrderDto createOrderDto)
        {
            var order = new Order
            {
                CustomerId = createOrderDto.CustomerId,
                TenantId = createOrderDto.TenantId,
                PlacedBy = createOrderDto.PlacedBy
            };

            var orderItems = MapOrderItems(createOrderDto.Items);

            if (createOrderDto.Items.Count != orderItems.Count)
            {
                throw new InvalidOperationException("One or more items or services were not found.");
            }

            foreach (var orderItem in orderItems)
            {
                order.Items.Add(orderItem);
                order.TotalAmount += orderItem.TotalPrice;
            }

            _orderRepository.Create(order);

            return order;
        }
        public Order CreateFromBooking(CreateOrderDto createOrderDto)
        {
            var order = new Order
            {
                CustomerId = createOrderDto.CustomerId,
                TenantId = createOrderDto.TenantId,
                PlacedBy = createOrderDto.PlacedBy,
                Date = DateTime.Now,
                TotalAmount = createOrderDto.TotalAmount,
                DiscountApplied = createOrderDto.DiscountApplied,
                Status = createOrderDto.Status,
                Tips = createOrderDto.Tips,
                TotalFee = createOrderDto.TotalFee,
            };

            var orderItems = MapOrderItems(createOrderDto.Items);

            if (createOrderDto.Items.Count != orderItems.Count)
            {
                throw new InvalidOperationException("One or more items or services were not found.");
            }

            foreach (var orderItem in orderItems)
            {
                order.Items.Add(orderItem);
                order.TotalAmount += orderItem.TotalPrice;
            }

            _orderRepository.Create(order);

            return order;
        }

        public Order AddItemToOrder(string orderId, OrderItemDto newItemDto)
        {
            var order = _orderRepository.GetByIdWithItems(orderId);

            if (order == null)
            {
                throw new InvalidOperationException("Order not found.");
            }

            var newItem = CreateOrderItemFromDto(newItemDto);

            order.Items.Add(newItem);
            order.TotalAmount += newItem.TotalPrice;

            _orderRepository.Update(order);

            return order;
        }

        public Order RemoveItemFromOrder(string orderId, string orderItemId)
        {
            var order = _orderRepository.GetByIdWithItems(orderId);

            if (order == null)
            {
                throw new InvalidOperationException("Order not found.");
            }

            var itemToRemove = order.Items.FirstOrDefault(item => item.OrderItemId == orderItemId);

            if (itemToRemove == null)
            {
                throw new InvalidOperationException("Item not found in the order.");
            }

            order.TotalAmount -= itemToRemove.TotalPrice;
            order.Items.Remove(itemToRemove);

            _orderRepository.Update(order);

            return order;
        }
        public Order ApplyDiscount(string orderId, string discountId)
        {
            var order = _orderRepository.GetById(orderId);

            if (order == null)
            {
                throw new InvalidOperationException("Order not found.");
            }

            var discount = _discountRepository.GetById(discountId);

            if (discount == null)
            {
                throw new InvalidOperationException("Discount not found.");
            }

            // Apply discount to order
            order.DiscountApplied += discount.AmountOff;
            order.TotalAmount -= discount.AmountOff;

            _orderRepository.Update(order);

            return order;
        }

        public Order ApplyLoyaltyProgram(string orderId, string loyaltyProgramId)
        {
            var order = _orderRepository.GetById(orderId);

            if (order == null)
            {
                throw new InvalidOperationException("Order not found.");
            }

            var loyaltyProgram = _loyaltyProgramRepository.GetById(loyaltyProgramId);

            if (loyaltyProgram == null)
            {
                throw new InvalidOperationException("Loyalty program not found.");
            }

            var customer = _customerRepository.GetById(order.CustomerId);

            // Check if customer has enough points
            if (customer.LoyaltyPoints >= loyaltyProgram.PointRequired)
            {
                // Deduct points and apply loyalty reward
                order.Customer.LoyaltyPoints -= loyaltyProgram.PointRequired;
                order.TotalAmount -= loyaltyProgram.Reward;
                order.DiscountApplied += loyaltyProgram.Reward;
                _orderRepository.Update(order);
            }
            else
            {
                throw new InvalidOperationException("Insufficient loyalty points.");
            }

            return order;
        }

        public Order AddTip(string orderId, decimal tipAmount)
        {
            var order = _orderRepository.GetById(orderId);

            if (order == null)
            {
                throw new InvalidOperationException("Order not found.");
            }

            // Add tip to order
            order.Tips += tipAmount;

            _orderRepository.Update(order);

            return order;
        }

        public Order ProcessPayment(string orderId, CreatePaymentDto createPaymentDto)
        {
            var order = _orderRepository.GetById(orderId);

            if (order == null)
            {
                throw new InvalidOperationException("Order not found.");
            }

            if (order.Status != "Pending")
            {
                throw new InvalidOperationException("Unable to process payment for this order - it's already paid.");
            }

            _paymentService.ProcessPayment(order, createPaymentDto);

            order.Status = "Paid";

            _orderRepository.Update(order);

            return order;
        }

        public OrderReceiptDto GetReceipt(string orderId)
        {
            var order = _orderRepository.GetByIdWithItems(orderId);

            if (order == null)
            {
                throw new InvalidOperationException("Order not found.");
            }

            decimal totalItemPrice = 0;
            var receiptItems = new List<OrderReceiptItemDto>();
            
            foreach (var orderItem in order.Items)
            {
                totalItemPrice += orderItem.TotalPrice;
                var receiptItem = new OrderReceiptItemDto
                {
                    ItemId = orderItem.OrderItemId,
                    Quantity = orderItem.Quantity,
                    UnitPrice = orderItem.TotalPrice / orderItem.Quantity,
                    TotalPrice = orderItem.TotalPrice
                };
                receiptItems.Add(receiptItem);
            };

            var orderReceipt = new OrderReceiptDto
            {
                OrderId = order.OrderId,
                Date = order.Date,
                TotalAmountWithTips = order.TotalAmount + order.Tips,
                TotalAmount = order.TotalAmount,
                TotalItemPrice = totalItemPrice,
                DiscountApplied = order.DiscountApplied,
                Tips = order.Tips,
                Status = order.Status,
                Items = receiptItems
            };

            return orderReceipt;
        }
    }
}