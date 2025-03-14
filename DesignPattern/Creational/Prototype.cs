using System;

public class ThongTinID
{
    public int MaSo;

    public ThongTinID(int maSo)
    {
        this.MaSo = maSo;
    }
}
public class Nguoi
{
    public int Tuoi;
    public DateTime NgaySinh;
    public string Ten;
    public ThongTinID ThongTinID;

    public Nguoi ShallowCopy()
    {
        return (Nguoi)this.MemberwiseClone();
    }

    public Nguoi DeepCopy()
    {
        Nguoi banSao = (Nguoi)this.MemberwiseClone();
        banSao.ThongTinID = new ThongTinID(ThongTinID.MaSo);
        banSao.Ten = String.Copy(Ten);
        return banSao;
    }
}

public static class HienThiThongTin
{
    public static void HienThiThongTinNguoiDung(Nguoi nguoi)
    {
        Console.WriteLine("      Tên: {0}, Tuổi: {1}, Ngày Sinh: {2:dd/MM/yyyy}",
            nguoi.Ten, nguoi.Tuoi, nguoi.NgaySinh);
        Console.WriteLine("      Mã số ID: {0}", nguoi.ThongTinID.MaSo);
    }
}
