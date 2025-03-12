using System;
using System.Collections.Generic;

// Builder Interface: Định nghĩa các bước xây dựng bữa ăn
public interface IMealBuilder
{
    void BuildKhaiVi();  // Món khai vị (chỉ dùng trong Builder nâng cao)
    void BuildMonChinh();
    void BuildThucUong();
    void BuildTrangMieng();
    void BuildQuaTangKem();  // Quà tặng kèm (chỉ dùng trong Builder nâng cao)
}

// Product: Đại diện cho bữa ăn được xây dựng
public class BuaAn
{
    private List<string> _monAn = new List<string>();
    public void ThemMon(string mon) => _monAn.Add(mon);
    public string HienThiBuaAn() => "Bữa ăn gồm có: " + string.Join(", ", _monAn) + "\n";
}

// Concrete Builder 1: Bữa ăn truyền thống Việt Nam
public class BuaAnTruyenThongBuilder : IMealBuilder
{
    private BuaAn _buaAn = new BuaAn();

    public BuaAnTruyenThongBuilder() => this.Reset();
    public void Reset() => this._buaAn = new BuaAn();
    public void BuildMonChinh() => this._buaAn.ThemMon("Phở bò");
    public void BuildThucUong() => this._buaAn.ThemMon("Cà phê sữa");
    public void BuildTrangMieng() => this._buaAn.ThemMon("Chè bưởi");
    public void BuildKhaiVi() { }  // Không có 
    public void BuildQuaTangKem() { }  // Không có 

    public BuaAn LayBuaAn()
    {
        BuaAn ketQua = this._buaAn;
        this.Reset();
        return ketQua;
    }
}

// Concrete Builder 2: Bữa ăn chay
public class BuaAnChayBuilder : IMealBuilder
{
    private BuaAn _buaAn = new BuaAn();

    public BuaAnChayBuilder() => this.Reset();
    public void Reset() => this._buaAn = new BuaAn();
    public void BuildMonChinh() => this._buaAn.ThemMon("Bún xào chay");
    public void BuildThucUong() => this._buaAn.ThemMon("Nước ép cam");
    public void BuildTrangMieng() => this._buaAn.ThemMon("Chè bưởi");
    public void BuildKhaiVi() { }  // Không có 
    public void BuildQuaTangKem() { }  // Không có 
    public BuaAn LayBuaAn()
    {
        BuaAn ketQua = this._buaAn;
        this.Reset();
        return ketQua;
    }
}

// Concrete Builder 3: Bữa ăn cao cấp
public class BuaAnCaoCapBuilder : IMealBuilder
{
    private BuaAn _buaAn = new BuaAn();
    public BuaAnCaoCapBuilder() => this.Reset();
    public void Reset() => this._buaAn = new BuaAn();
    public void BuildKhaiVi() => this._buaAn.ThemMon("Gỏi cuốn tôm thịt");
    public void BuildMonChinh() => this._buaAn.ThemMon("Bò bít tết sốt tiêu đen");
    public void BuildThucUong() => this._buaAn.ThemMon("Rượu vang đỏ");
    public void BuildTrangMieng() => this._buaAn.ThemMon("Bánh mousse dâu tây");
    public void BuildQuaTangKem() => this._buaAn.ThemMon("Ly trà thảo mộc lưu niệm");

    public BuaAn LayBuaAn()
    {
        BuaAn ketQua = this._buaAn;
        this.Reset();
        return ketQua;
    }
}


// Director: Quản lý quy trình xây dựng bữa ăn theo công thức có sẵn
public class QuanLyBuaAn
{
    private IMealBuilder _buaAnBuilder;

    public IMealBuilder BuaAnBuilder { set => _buaAnBuilder = value; }

    public void XayDungBuaAnDonGian()
    {
        _buaAnBuilder.BuildMonChinh();
    }

    public void XayDungBuaAnDayDu()
    {
        _buaAnBuilder.BuildMonChinh();
        _buaAnBuilder.BuildThucUong();
        _buaAnBuilder.BuildTrangMieng();
    }

    public void XayDungBuaAnCaoCap()
    {
        _buaAnBuilder.BuildKhaiVi();
        _buaAnBuilder.BuildMonChinh();
        _buaAnBuilder.BuildThucUong();
        _buaAnBuilder.BuildTrangMieng();
        _buaAnBuilder.BuildQuaTangKem();
    }
}
