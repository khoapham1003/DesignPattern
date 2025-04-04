using System;

class OrderContext
{
    private OrderState _state;

    public OrderContext(OrderState state)
    {
        ChangeState(state);
    }

    public void ChangeState(OrderState state)
    {
        Console.WriteLine($"==>OrderContext: Chuyển sang trạng thái {state.GetType().Name}.");
        this._state = state;
        this._state.SetContext(this); 
    }

    // Các hành động mà trạng thái có thể thực hiện
    public void ProcessOrder() => _state.ProcessOrder(this);
    public void ShipOrder() => _state.ShipOrder(this);
    public void DeliverOrder() => _state.DeliverOrder(this);
    public void CompleteOrder() => _state.CompleteOrder(this);
    public void CancelOrder() => _state.CancelOrder(this);
}

interface OrderState
{
    void SetContext(OrderContext context);
    void ProcessOrder(OrderContext context);
    void ShipOrder(OrderContext context);
    void DeliverOrder(OrderContext context);
    void CompleteOrder(OrderContext context);
    void CancelOrder(OrderContext context);
}

class PendingState : OrderState
{
    private OrderContext _context;

    public void SetContext(OrderContext context)
    {
        _context = context;
    }

    public void ProcessOrder(OrderContext context)
    {
        Console.WriteLine("PendingState: Đơn hàng đang chờ xác nhận.");
        Console.WriteLine("PendingState: Đơn hàng đã được xác nhận, chuyển sang trạng thái Processing.");
        context.ChangeState(new ProcessingState());
    }

    public void ShipOrder(OrderContext context)
    {
        Console.WriteLine("PendingState: Không thể giao hàng khi đơn hàng chưa được xử lý.");
    }

    public void DeliverOrder(OrderContext context)
    {
        Console.WriteLine("PendingState: Không thể giao hàng khi đơn hàng chưa được xử lý.");
    }

    public void CompleteOrder(OrderContext context)
    {
        Console.WriteLine("PendingState: Không thể hoàn thành đơn hàng khi chưa xử lý.");
    }

    public void CancelOrder(OrderContext context)
    {
        Console.WriteLine("PendingState: Đơn hàng đã bị hủy.");
        context.ChangeState(new CanceledState());
    }
}

class ProcessingState : OrderState
{
    private OrderContext _context;

    public void SetContext(OrderContext context)
    {
        _context = context;
    }

    public void ProcessOrder(OrderContext context)
    {
        Console.WriteLine("ProcessingState: Đơn hàng đang được xử lý.");
    }

    public void ShipOrder(OrderContext context)
    {
        Console.WriteLine("ProcessingState: Đơn hàng đã sẵn sàng để giao đến kho.");
        context.ChangeState(new ShippedState());
    }

    public void DeliverOrder(OrderContext context)
    {
        Console.WriteLine("ProcessingState: Không thể giao hàng khi đơn chưa được vận chuyển.");
    }

    public void CompleteOrder(OrderContext context)
    {
        Console.WriteLine("ProcessingState: Không thể hoàn thành đơn hàng khi chưa giao.");
    }

    public void CancelOrder(OrderContext context)
    {
        Console.WriteLine("ProcessingState: Đơn hàng đã bị hủy.");
        context.ChangeState(new CanceledState());
    }
}

class ShippedState : OrderState
{
    private OrderContext _context;

    public void SetContext(OrderContext context)
    {
        _context = context;
    }

    public void ProcessOrder(OrderContext context)
    {
        Console.WriteLine("ShippedState: Đơn hàng đã được vận chuyển, không thể xử lý lại.");
    }

    public void ShipOrder(OrderContext context)
    {
        Console.WriteLine("ShippedState: Không thể giao hàng khi đơn chưa đến nơi.");
    }

    public void DeliverOrder(OrderContext context)
    {
        Console.WriteLine("ShippedState: Đơn hàng đã được gửi đi.");
        context.ChangeState(new CompletedState());
    }

    public void CompleteOrder(OrderContext context)
    {
        Console.WriteLine("ShippedState: Đơn hàng chưa giao xong, không thể hoàn thành.");
    }

    public void CancelOrder(OrderContext context)
    {
        Console.WriteLine("ShippedState: Đơn hàng đang vận chuyển, không thể hủy.");
    }
}

class CompletedState : OrderState
{
    private OrderContext _context;

    public void SetContext(OrderContext context)
    {
        _context = context;
    }

    public void ProcessOrder(OrderContext context)
    {
        Console.WriteLine("CompletedState: Đơn hàng đã hoàn thành, không thể xử lý lại.");
    }

    public void ShipOrder(OrderContext context)
    {
        Console.WriteLine("CompletedState: Đơn hàng đã hoàn thành, không thể giao lại.");
    }

    public void DeliverOrder(OrderContext context)
    {
        Console.WriteLine("CompletedState: Đơn hàng đã hoàn thành.");
    }

    public void CompleteOrder(OrderContext context)
    {
        Console.WriteLine("CompletedState: Đơn hàng đã hoàn thành.");
    }

    public void CancelOrder(OrderContext context)
    {
        Console.WriteLine("CompletedState: Đơn hàng đã hoàn thành, không thể hủy.");
    }
}

class CanceledState : OrderState
{
    private OrderContext _context;

    public void SetContext(OrderContext context)
    {
        _context = context;
    }

    public void ProcessOrder(OrderContext context)
    {
        Console.WriteLine("CanceledState: Đơn hàng đã bị hủy, không thể xử lý.");
    }

    public void ShipOrder(OrderContext context)
    {
        Console.WriteLine("CanceledState: Đơn hàng đã bị hủy, không thể giao.");
    }

    public void DeliverOrder(OrderContext context)
    {
        Console.WriteLine("CanceledState: Đơn hàng đã bị hủy, không thể giao.");
    }

    public void CompleteOrder(OrderContext context)
    {
        Console.WriteLine("CanceledState: Đơn hàng đã bị hủy, không thể hoàn thành.");
    }

    public void CancelOrder(OrderContext context)
    {
        Console.WriteLine("CanceledState: Đơn hàng đã bị hủy.");
    }
}