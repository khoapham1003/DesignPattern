// Abstraction
abstract class LoaiThongBao
{
    protected INenTangHienThi _nenTangHienThi;

    public LoaiThongBao(INenTangHienThi nenTang)
    {
        this._nenTangHienThi = nenTang;
    }

    public abstract void GuiThongBao(string noiDung);
}

// Refined Abstraction
class ThongBaoCanhBao : LoaiThongBao
{
    public ThongBaoCanhBao(INenTangHienThi nenTang) : base(nenTang) { }

    public override void GuiThongBao(string noiDung)
    {
        Console.WriteLine("Gửi CẢNH BÁO:");
        _nenTangHienThi.HienThiThongBao(noiDung);
    }
}

// Refined Abstraction
class ThongBaoLoi : LoaiThongBao
{
    public ThongBaoLoi(INenTangHienThi nenTang) : base(nenTang) { }

    public override void GuiThongBao(string noiDung)
    {
        Console.WriteLine("Gửi LỖI:");
        _nenTangHienThi.HienThiThongBao(noiDung);
    }
}

// Implementation
public interface INenTangHienThi
{
    void HienThiThongBao(string noiDung);
}

// Concrete Implementation
class HienThiMayTinh : INenTangHienThi
{
    public void HienThiThongBao(string noiDung)
    {
        Console.WriteLine($"[MÁY TÍNH] {noiDung}");
    }
}

// Concrete Implementation
class HienThiDienThoai : INenTangHienThi
{
    public void HienThiThongBao(string noiDung)
    {
        Console.WriteLine($"[ĐIỆN THOẠI] {noiDung}");
    }
}

// Lớp Client
class ClientBridge
{
    public void MoApp()
    {
        // Gửi thông báo cảnh báo trên máy tính
        LoaiThongBao canhBaoMayTinh = new ThongBaoCanhBao(new HienThiMayTinh());
        canhBaoMayTinh.GuiThongBao("Hệ thống sắp bảo trì!");

        Console.WriteLine();

        // Gửi thông báo lỗi trên điện thoại
        LoaiThongBao loiDienThoai = new ThongBaoLoi(new HienThiDienThoai());
        loiDienThoai.GuiThongBao("Ứng dụng bị lỗi kết nối!");
    }
}