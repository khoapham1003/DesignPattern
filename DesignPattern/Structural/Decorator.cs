using System;

namespace DecoratorPatternVietnam
{
    // Component: Định nghĩa interface chung cho đồ uống
    public abstract class ThucUong
    {
        public abstract string MoTa();
        public abstract double Gia();
    }

    // ConcreteComponent: Cà phê đen
    class CaPhe : ThucUong
    {
        public override string MoTa() => "Cà phê đen";
        public override double Gia() => 20000;
    }

    // ConcreteComponent: Trà sữa truyền thống
    class TraSua : ThucUong
    {
        public override string MoTa() => "Trà sữa truyền thống";
        public override double Gia() => 25000;
    }

    // Decorator: Topping chung
    abstract class TrangTriThucUong : ThucUong
    {
        protected ThucUong _thucUong;
        public TrangTriThucUong(ThucUong thucUong) { this._thucUong = thucUong; }
        public override string MoTa() => _thucUong.MoTa();
        public override double Gia() => _thucUong.Gia();
    }

    // ConcreteDecorator: Topping trân châu
    class ToppingTranChau : TrangTriThucUong
    {
        public ToppingTranChau(ThucUong thucUong) : base(thucUong) { }
        public override string MoTa() => $"{_thucUong.MoTa()} + Trân Châu";
        public override double Gia() => _thucUong.Gia() + 5000;
    }

    // ConcreteDecorator: Topping kem sữa
    class ToppingKemSua : TrangTriThucUong
    {
        public ToppingKemSua(ThucUong thucUong) : base(thucUong) { }
        public override string MoTa() => $"{_thucUong.MoTa()} + Kem Sữa";
        public override double Gia() => _thucUong.Gia() + 7000;
    }

    // ConcreteDecorator: Topping siro đào
    class ToppingSiroDao : TrangTriThucUong
    {
        public ToppingSiroDao(ThucUong thucUong) : base(thucUong) { }
        public override string MoTa() => $"{_thucUong.MoTa()} + Siro Đào";
        public override double Gia() => _thucUong.Gia() + 6000;
    }

    // ConcreteDecorator: Topping thạch cà phê
    class ToppingThachCafe : TrangTriThucUong
    {
        public ToppingThachCafe(ThucUong thucUong) : base(thucUong) { }
        public override string MoTa() => $"{_thucUong.MoTa()} + Thạch Cà Phê";
        public override double Gia() => _thucUong.Gia() + 8000;
    }

    // ConcreteDecorator: Topping đường đen
    class ToppingDuongDen : TrangTriThucUong
    {
        public ToppingDuongDen(ThucUong thucUong) : base(thucUong) { }
        public override string MoTa() => $"{_thucUong.MoTa()} + Đường Đen";
        public override double Gia() => _thucUong.Gia() + 4000;
    }

    // Client
    public class ClientDecorator
    {
        public void ClientAdd(ThucUong thucUong)
        {
            Console.WriteLine($"Món: {thucUong.MoTa()} - Giá: {thucUong.Gia()} VNĐ");
        }
    }
}
