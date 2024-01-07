using PoS.Data;
using PoS.Services.GenericServices;
using WebApplication1.Models;
using PoS.Dtos.Order;
using PoS.Dtos.OrderItem;
using PoS.Repositories.OrderRepository;
using PoS.Repositories.ProductRepository;
using PoS.Repositories.ServiceRepository;

namespace PoS.Services.OrderServices;

public class OrderService: IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly IServiceRepository _serviceRepository;

    public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, IServiceRepository serviceRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _serviceRepository = serviceRepository;
    }

    private List<OrderItem> MapOrderItems(List<OrderItemDto> orderItemDtos)
    {
        var orderItems = new List<OrderItem>();

        foreach (var item in orderItemDtos)
        {
            OrderItem orderItem;

            if (!string.IsNullOrEmpty(item.ProductId))
            {
                var product = _productRepository.GetById(item.ProductId);
                orderItem = new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    TotalPrice = product.Price * item.Quantity
                };
            }
            else if (!string.IsNullOrEmpty(item.ServiceId))
            {
                var service = _serviceRepository.GetById(item.ServiceId);
                orderItem = new OrderItem
                {
                    ServiceId = item.ServiceId,
                    Quantity = item.Quantity,
                    TotalPrice = service.Price * item.Quantity
                };
            }
            else
            {
                break; 
            }

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
}