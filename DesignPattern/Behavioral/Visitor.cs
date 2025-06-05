


// Interface Element: Thiết bị
public interface IThietBi
{
    string Ten { get; }
    void ChapNhan(IKiemTra nguoiKiemTra);
}

// Concrete Element: Máy in
public class MayIn : IThietBi
{
    public string Ten => "Máy In Canon LBP2900";
    public bool CoGiay { get; set; } = true;
    public bool CoKetNoiMang { get; set; } = true;
    public string PhanMem => "Driver Canon LBP 2900";

    public void ChapNhan(IKiemTra nguoiKiemTra)
    {
        nguoiKiemTra.KiemTraMayIn(this);
    }
    public string InThu() => (CoGiay && CoKetNoiMang)?"In được.":"In k được";
}

// Concrete Element: Máy Fax
public class MayFax : IThietBi
{
    public string Ten => "Máy Fax Canon L295";
    public bool CoGiay { get; set; } = true;
    public bool CoDuongTruyenTot { get; set; } = false;
    public string PhanMem => "Driver Canon FAX-L295";

    public void ChapNhan(IKiemTra nguoiKiemTra)
    {
        nguoiKiemTra.KiemTraMayFax(this);
    }
    public string GuiFaxThu() => (CoGiay && CoDuongTruyenTot)?"Gửi fax qua được.":"Gửi k được";
}

// Interface Visitor: Người kiểm tra/visit
public interface IKiemTra
{
    void KiemTraMayIn(MayIn mayIn);
    void KiemTraMayFax(MayFax fax);
}

// Concrete Visitor: Kỹ sư kiểm tra phần cứng
public class KySuPhanCung : IKiemTra
{
    public void KiemTraMayIn(MayIn mayIn)
    {
        Console.WriteLine(
            $"[Phần cứng] {mayIn.Ten}: " +
            $"{(mayIn.CoGiay ? "Còn giấy" : "Hết giấy")}, " +
            $"{(mayIn.CoKetNoiMang ? "Kết nối mạng OK" : "Mất kết nối")}");
    }
    public void KiemTraMayFax(MayFax fax)
    {
        Console.WriteLine(
            $"[Phần cứng] {fax.Ten}: " +
            $"{(fax.CoGiay ? "Còn giấy" : "Hết giấy")}, " +
            $"{(fax.CoDuongTruyenTot ? "Đường truyền ổn" : "Lỗi đường truyền")}");
    }
}
// Concrete Visitor: Kỹ sư kiểm tra phần mềm
public class KySuPhanMem : IKiemTra
{
    public void KiemTraMayIn(MayIn mayIn)
    {
        Console.WriteLine($"[Phần mềm] {mayIn.Ten}: Đang dùng {mayIn.PhanMem} – Phân tích log OK.");
    }
    public void KiemTraMayFax(MayFax fax)
    {
        Console.WriteLine($"[Phần mềm] {fax.Ten}: Hệ điều hành {fax.PhanMem} – Không phát hiện lỗi.");
    }
}
// Concrete Visitor: Nhân viên văn phòng (người sử dụng thiết bị)
public class NhanVienVanPhong : IKiemTra
{
    public void KiemTraMayIn(MayIn mayIn)
    {
        Console.WriteLine($"[Người dùng] {mayIn.Ten}: {mayIn.InThu()}");
    }
    public void KiemTraMayFax(MayFax fax)
    {
        Console.WriteLine($"[Người dùng] {fax.Ten}: {fax.GuiFaxThu()}");
    }
}

// Client: Quản lý danh sách và thực hiện kiểm tra
public class QuanLyThietBi
{
    public static void ThucHienKiemTra(List<IThietBi> thietBis, IKiemTra nguoiKiemTra)
    {
        foreach (var tb in thietBis)
        {
            tb.ChapNhan(nguoiKiemTra);
        }
    }
}