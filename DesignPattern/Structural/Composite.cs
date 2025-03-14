using System;
using System.Collections.Generic;

// Component
abstract class ThanhPhan
{
    public abstract string Execute();
    public virtual void Them(ThanhPhan tp) { throw new NotImplementedException(); }
    public virtual void Xoa(ThanhPhan tp) { throw new NotImplementedException(); }
    public virtual bool IsHopThanh() { return true; }
}

// Leaf - Thành phần là 1 Leaf
class La : ThanhPhan
{
    public override string Execute()
    {
        return "Lá";
    }
    public override bool IsHopThanh()
    {
        return false;
    }
}

// Composite - Thành phần chứa nhiều Leaf/Thành phần khác
class HopThanh : ThanhPhan
{
    private List<ThanhPhan> thanhPhans = new List<ThanhPhan>();

    public override string Execute()
    {
        string ketQua = "Nhánh(";
        for (int i = 0; i < thanhPhans.Count; i++)
        {
            ketQua += thanhPhans[i].Execute();
            if (i < thanhPhans.Count - 1)
            {
                ketQua += "+";
            }
        }
        return ketQua + ")";
    }

    public override void Them(ThanhPhan tp)
    {
        thanhPhans.Add(tp);
    }

    public override void Xoa(ThanhPhan tp)
    {
        thanhPhans.Remove(tp);
    }
}

// Lớp khách hàng Client
class KhachHangComposite
{
    public void XuLy(ThanhPhan tp)
    {
        //Đưa ra trạng thái của tp hiện tại
        Console.WriteLine($"KẾT QUẢ: {tp.Execute()}\n");
    }
    public void XuLyCay(ThanhPhan tp1, ThanhPhan tp2)
    {
        if (tp1.IsHopThanh())
        {
            tp1.Them(tp2);
            Console.WriteLine($"KẾT QUẢ: {tp1.Execute()}");
        }
        else if (tp2.IsHopThanh())
        {
            tp2.Them(tp1);
            Console.WriteLine($"KẾT QUẢ: {tp2.Execute()}");
        }
        else
        {
            Console.WriteLine("LỖI: Không thể thêm thành phần vào một Lá!");
        }

    }
}
