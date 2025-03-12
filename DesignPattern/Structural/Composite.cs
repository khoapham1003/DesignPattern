using System;
using System.Collections.Generic;

// Lớp thành phần cơ sở
abstract class ThanhPhan
{
    public abstract string ThucHien();
    public virtual void Them(ThanhPhan tp) { throw new NotImplementedException(); }
    public virtual void Xoa(ThanhPhan tp) { throw new NotImplementedException(); }
    public virtual bool LaHopThanh() { return true; }
}

// Thành phần lá (đơn lẻ)
class La : ThanhPhan
{
    public override string ThucHien()
    {
        return "Lá";
    }
    public override bool LaHopThanh()
    {
        return false;
    }
}

// Thành phần hợp thành (có thể chứa thành phần khác)
class HopThanh : ThanhPhan
{
    private List<ThanhPhan> thanhPhans = new List<ThanhPhan>();

    public override void Them(ThanhPhan tp)
    {
        thanhPhans.Add(tp);
    }

    public override void Xoa(ThanhPhan tp)
    {
        thanhPhans.Remove(tp);
    }

    public override string ThucHien()
    {
        string ketQua = "Nhánh(";
        for (int i = 0; i < thanhPhans.Count; i++)
        {
            ketQua += thanhPhans[i].ThucHien();
            if (i < thanhPhans.Count - 1)
            {
                ketQua += "+";
            }
        }
        return ketQua + ")";
    }
}

// Lớp khách hàng
class KhachHang
{
    public void XuLy(ThanhPhan tp)
    {
        Console.WriteLine($"KẾT QUẢ: {tp.ThucHien()}\n");
    }
    public void XuLyCay(ThanhPhan tp1, ThanhPhan tp2)
    {
        if (tp1.LaHopThanh())
        {
            tp1.Them(tp2);
        }
        Console.WriteLine($"KẾT QUẢ: {tp1.ThucHien()}");
    }
}
