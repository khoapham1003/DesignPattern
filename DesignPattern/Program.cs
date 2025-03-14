using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Program
    {
            static void Main(string[] args)
            {
            Console.OutputEncoding = System.Text.Encoding.UTF8;


            /*
            #region Adapter
            var usbCCharger = new USBTypeCCharger();

            Console.WriteLine("\nDùng đầu sạc Type C với Adapter cho điện thoại cổng Lightning:");
            LightningPhone iphone = new LightningPhone(new USBTypeCToLightningAdapter(usbCCharger));
            iphone.ChargePhone();

            Console.WriteLine("\nDùng đầu sạc Type C với Adapter cho điện thoại cổng Micro-USB:");
            MicroUSBPhone androidOld = new MicroUSBPhone(new USBTypeCToMicroUSBAdapter(usbCCharger));
            androidOld.ChargePhone();

            Console.WriteLine("Dùng đầu sạc Type C cho điện thoại cổng Type C:");
            TypeCPhone androidNew = new TypeCPhone(usbCCharger);
            androidNew.ChargePhone();
            #endregion
            */
            
            /*
            #region Builder

            var quanLy = new QuanLyBuaAn();

            var builderTruyenThong = new BuaAnTruyenThongBuilder();
            quanLy.BuaAnBuilder = builderTruyenThong;

            Console.WriteLine("Bữa ăn truyền thống:");
            quanLy.XayDungBuaAnDayDu();
            Console.WriteLine(builderTruyenThong.LayBuaAn().HienThiBuaAn());


            var builderChay = new BuaAnChayBuilder();
            quanLy.BuaAnBuilder = builderChay;

            Console.WriteLine("Bữa ăn chay:");
            quanLy.XayDungBuaAnDayDu();
            Console.WriteLine(builderChay.LayBuaAn().HienThiBuaAn());


            var builderCaoCap = new BuaAnCaoCapBuilder();
            quanLy.BuaAnBuilder = builderCaoCap;

            Console.WriteLine("Bữa ăn cao cấp:");
            quanLy.XayDungBuaAnCaoCap();
            Console.WriteLine(builderCaoCap.LayBuaAn().HienThiBuaAn());
            #endregion

            */

            
            #region Composite
            KhachHangComposite client = new KhachHangComposite();

            //Tạo 1 thành phần  - 1 lá
            La la = new La();


            Console.WriteLine("Khách hàng: Tôi có một thành phần đơn lẻ:");
            client.XuLy(la);



            //Tạo 1 Thành phần hợp thành - 1 cây(1 hợp thành) chứa 2 nhánh,
            //                   Trong đó: 1 nhánh(1 hợp thành) chứa 2 lá
            //                          và 1 nhánh(1 hợp thành) chứa 1 lá
            HopThanh cay = new HopThanh();
            HopThanh nhanh1 = new HopThanh();
            nhanh1.Them(new La());
            nhanh1.Them(new La());
            HopThanh nhanh2 = new HopThanh();
            nhanh2.Them(new La());
            cay.Them(nhanh1);
            cay.Them(nhanh2);


            // Khách hàng chỉ giao tiêp với Thành phần thông qua Client
            Console.WriteLine("Khách hàng: Bây giờ tôi có một cây hợp thành:");
            client.XuLy(cay);

            Console.WriteLine("Khách hàng: Tôi có thể quản lý cây mà không cần " +
                "kiểm tra từng thành phần là lá hay cây hay nhánh:");
            client.XuLyCay(cay, la);

            #endregion
            

            /*
            #region Prototype
            Nguoi nguoi1 = new Nguoi();
            nguoi1.Tuoi = 42;
            nguoi1.NgaySinh = Convert.ToDateTime("1977-01-01");
            nguoi1.Ten = "Nguyen Van A";
            nguoi1.ThongTinID = new ThongTinID(1234);

            // Thực hiện sao chép nông
            Nguoi nguoi2 = nguoi1.ShallowCopy();
            // Thực hiện sao chép sâu
            Nguoi nguoi3 = nguoi1.DeepCopy();

            // Hiển thị giá trị ban đầu
            Console.WriteLine("Giá trị ban đầu của nguoi1, nguoi2, nguoi3:");
            Console.WriteLine("   nguoi1:");
            HienThiThongTin.HienThiThongTinNguoiDung(nguoi1);
            Console.WriteLine("   nguoi2:");
            HienThiThongTin.HienThiThongTinNguoiDung(nguoi2);
            Console.WriteLine("   nguoi3:");
            HienThiThongTin.HienThiThongTinNguoiDung(nguoi3);

            // Thay đổi thuộc tính của nguoi1
            nguoi1.Tuoi = 32;
            nguoi1.NgaySinh = Convert.ToDateTime("1990-01-01");
            nguoi1.Ten = "Tran Van B";
            nguoi1.ThongTinID.MaSo = 5678;

            Console.WriteLine("\nGiá trị sau khi thay đổi nguoi1:");
            Console.WriteLine("   nguoi1:");
            HienThiThongTin.HienThiThongTinNguoiDung(nguoi1);
            Console.WriteLine("   nguoi2 (bị ảnh hưởng do shallow copy):");
            HienThiThongTin.HienThiThongTinNguoiDung(nguoi2);
            Console.WriteLine("   nguoi3 (không bị ảnh hưởng do deep copy):");
            HienThiThongTin.HienThiThongTinNguoiDung(nguoi3);
            #endregion
            */
        }
    }
}
