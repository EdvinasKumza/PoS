using PoS.Data;
using PoS.Services.GenericServices;
using WebApplication1.Models;
using PoS.Dtos.Order;
using PoS.Dtos.OrderItem;
using PoS.Repositories.OrderRepository;
using PoS.Repositories.ProductRepository;
using PoS.Repositories.ServiceRepository;
using PoS.Repositories.DiscountRepository;
using PoS.Repositories.LoyaltyProgramRepository;

namespace PoS.Services.OrderServices;

public class OrderService: IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly IServiceRepository _serviceRepository;
    private readonly IDiscountRepository _discountRepository;
    private readonly ILoyaltyProgramRepository _loyaltyProgramRepository;


    public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, IServiceRepository serviceRepository, IDiscountRepository discountRepository, ILoyaltyProgramRepository loyaltyProgramRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _serviceRepository = serviceRepository;
        _discountRepository = discountRepository;
        _loyaltyProgramRepository = loyaltyProgramRepository;
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

    public Order AddItemToOrder(string orderId, OrderItemDto newItemDto)
    {
        var order = _orderRepository.GetById(orderId);

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
        var order = _orderRepository.GetById(orderId);

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

        // Check if customer has enough points
        if (order.Customer.LoyaltyPoints >= loyaltyProgram.PointRequired)
        {
            // Deduct points and apply loyalty reward
            order.Customer.LoyaltyPoints -= loyaltyProgram.PointRequired;
            // You can add specific logic here to apply the loyalty reward

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
        order.TotalAmount += tipAmount;

        _orderRepository.Update(order);

        return order;
    }

}