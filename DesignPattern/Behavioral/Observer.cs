public interface IObserver
{
    void Update(Order order);
}

public interface IOrderSubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

// ENUM trạng thái đơn hàng
public enum OrderStatus
{
    Created,
    Processing,
    Shipped,
    Delivered,
    Cancelled
}

// Publisher (Subject)
public class Order : IOrderSubject
{
    private List<IObserver> _observers = new List<IObserver>();
    public OrderStatus Status { get; private set; }

    public string OrderId { get; }

    public Order(string orderId)
    {
        OrderId = orderId;
        Status = OrderStatus.Created;
    }

    public void Attach(IObserver observer)
    {
        Console.WriteLine($"[Order {OrderId}] Gắn Observer: {observer.GetType().Name}");
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
        Console.WriteLine($"[Order {OrderId}] Gỡ Observer: {observer.GetType().Name}");
    }

    public void Notify()
    {
        Console.WriteLine($"\n[Order {OrderId}] Trạng thái mới: {Status} => Gửi thông báo cho các bộ phận:");
        foreach (var observer in _observers)
        {
            observer.Update(this);
        }
    }

    // Hàm thay đổi trạng thái đơn hàng
    public void ChangeStatus(OrderStatus newStatus)
    {
        Console.WriteLine($"\n[Order {OrderId}] Đổi trạng thái từ {Status} => {newStatus}");
        Status = newStatus;
        Notify();
    }
}

// Concrete Observers
public class WarehouseDepartment : IObserver
{
    public void Update(Order order)
    {
        if (order.Status == OrderStatus.Processing)
        {
            Console.WriteLine("Kho: Chuẩn bị sách để đóng gói.");
        }
    }
}

public class ShippingDepartment : IObserver
{
    public void Update(Order order)
    {
        if (order.Status == OrderStatus.Shipped)
        {
            Console.WriteLine("Giao hàng: Đã nhận đơn và đang giao.");
        }
        else if (order.Status == OrderStatus.Delivered)
        {
            Console.WriteLine("Giao hàng: Đơn đã giao thành công.");
        }
    }
}

public class CustomerNotification : IObserver
{
    public void Update(Order order)
    {
        Console.WriteLine($"Khách hàng: Bạn nhận được cập nhật đơn hàng [{order.OrderId}] => {order.Status}");
    }
}
