public class SupportRequest
{
    public string CustomerId { get; set; }
    public string OS { get; set; }
    public string Problem { get; set; }

    public SupportRequest(string customerId, string os, string problem)
    {
        CustomerId = customerId;
        OS = os;
        Problem = problem;
    }
}

public interface ISupportHandler
{
    ISupportHandler SetNext(ISupportHandler handler);
    string Handle(SupportRequest request);
}

public abstract class SupportHandler : ISupportHandler
{
    private ISupportHandler _nextHandler;

    public ISupportHandler SetNext(ISupportHandler handler)
    {
        _nextHandler = handler;
        return handler;
    }

    public virtual string Handle(SupportRequest request)
    {
        return _nextHandler?.Handle(request);
    }
}

public class Verifier : SupportHandler
{
    private HashSet<string> validIds = new() { "KH001", "KH002", "KHVIP" };

    public override string Handle(SupportRequest request)
    {
        if (!validIds.Contains(request.CustomerId))
        {
            return "[Verifier] Mã khách hàng không hợp lệ. Vui lòng kiểm tra lại.";
        }
        Console.WriteLine("[Verifier] Xác thực thành công.");
        return base.Handle(request);
    }
}

public class AutoResponder : SupportHandler
{
    public override string Handle(SupportRequest request)
    {
        Console.WriteLine("[Robot] \"Bạn có thể thử các cách sau: khởi động lại, kiểm tra kết nối...\"");
        return base.Handle(request);
    }
}

public class CallCenterOperator : SupportHandler
{
    public override string Handle(SupportRequest request)
    {
        Console.WriteLine("[Tổng đài viên] \"Bạn đã cắm thiết bị đúng cổng chưa?\"");
        return base.Handle(request);
    }
}

public class LinuxEngineer : SupportHandler
{
    public override string Handle(SupportRequest request)
    {
        if (request.OS == "Linux" && request.Problem.Contains("không nhận"))
        {
            return "[Linux Engineer] Cài driver tại linux-support.com/drivers";
        }
        return base.Handle(request);
    }
}

public class WindowsEngineer : SupportHandler
{
    public override string Handle(SupportRequest request)
    {
        if (request.OS == "Windows" && request.Problem.Contains("không nhận"))
        {
            return "[Windows Engineer] Vào Device Manager để cập nhật driver.";
        }
        return base.Handle(request);
    }
}

public class Client
{
    public static void GoiHoTro(ISupportHandler handler, SupportRequest request)
    {
        Console.WriteLine($"Gọi hỗ trợ cho khách hàng {request.CustomerId} - OS: {request.OS} - Vấn đề: {request.Problem}\n");

        var result = handler.Handle(request);

        Console.WriteLine(result != null
            ? $"Kết quả: {result}"
            : "Không ai xử lý được yêu cầu.");
    }
}
