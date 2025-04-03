// Subsystem 1: Xử lý đặt chuyến bay
using System.Globalization;

public class FlightService
{
    public bool CheckAvailability(string from, string to, DateTime date)
    {
        Console.WriteLine($"Kiểm tra chuyến bay từ {from} đến {to} vào ngày {date.ToShortDateString()}...");
        return true; // Auto có chuyến bay
    }

    public string BookFlight(string from, string to, DateTime date)
    {
        Console.WriteLine($"Đã đặt chuyến bay từ {from} đến {to} vào ngày {date.ToShortDateString()}.");
        Console.ReadLine();
        return "Mã vé: FL12345";
    }
}

// Subsystem 2: Xử lý thanh toán
public class PaymentService
{
    public bool ProcessPayment(string cardNumber, double amount)
    {
        Console.WriteLine($"Xử lý thanh toán {amount.ToString("C", new CultureInfo("vi-VN"))} bằng thẻ {cardNumber}...");
        Console.ReadLine();
        return true; // Auto thanh toán thành công
    }
}

// Subsystem 3: Gửi email xác nhận
public class EmailService
{
    public void SendConfirmation(string email, string ticketInfo)
    {
        Console.WriteLine($"Gửi email xác nhận đến {email} với thông tin: {ticketInfo}");
        Console.ReadLine();
    }
}

// Facade: Giao diện để đặt vé đơn giản
public class BookingFacade
{
    private FlightService _flightService;
    private PaymentService _paymentService;
    private EmailService _emailService;

    public BookingFacade()
    {
        _flightService = new FlightService();
        _paymentService = new PaymentService();
        _emailService = new EmailService();
    }

    public void BookTicket(string from, string to, DateTime date, string cardNumber, string email)
    {
        Console.WriteLine("Bắt đầu quá trình đặt vé...\n");
        Console.ReadLine();

        if (_flightService.CheckAvailability(from, to, date))
        {
            Console.WriteLine("\nCó chuyến bay.");
        Console.ReadLine();
            string ticketInfo = _flightService.BookFlight(from, to, date);

            if (_paymentService.ProcessPayment(cardNumber, 1500000)) 
            {
                _emailService.SendConfirmation(email, ticketInfo);
                Console.WriteLine("\nĐặt vé thành công!\n");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("\nThanh toán thất bại. Hủy đặt vé.");
                Console.ReadLine();
            }
        }
        else
        {
            Console.WriteLine("\nKhông có chuyến bay nào khả dụng.");
            Console.ReadLine();
        }
    }
}