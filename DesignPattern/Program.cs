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

        Begin:
            int nhom = 0;
            try
            {
                Console.WriteLine("\n\t1.Creational Patterns");
                Console.WriteLine("\t2.Strutural Patterns");
                Console.WriteLine("\t3.Behavioral Patterns\n");
            LoopGroup: Console.Write("--->Choose pattern group:");
                int.TryParse(Console.ReadLine(), out nhom);

                switch (nhom)
                {
                    case 1:
                        #region Creational Pattern
                        Console.WriteLine("\n\t1.Singleton");
                        Console.WriteLine("\t2.Factory Method");
                        Console.WriteLine("\t3.Abstract Factory");
                        Console.WriteLine("\t4.Builder");
                        Console.WriteLine("\t5.Prototype");
                        #endregion
                        break;
                    case 2:
                        #region Structural Pattern
                        Console.WriteLine("\n\t1.Adapter");
                        Console.WriteLine("\t2.Composite");
                        Console.WriteLine("\t3.Decorator");
                        Console.WriteLine("\t4.Bridge");
                        Console.WriteLine("\t5.Facade");
                        Console.WriteLine("\t6.Flyweight");
                        Console.WriteLine("\t7.Proxy");
                        #endregion
                        break;
                    case 3:
                        #region Behavioral Pattern
                        Console.WriteLine("\n\t1.State");
                        Console.WriteLine("\t2.Command");
                        Console.WriteLine("\t3.Visitor");
                        Console.WriteLine("\t4.Mediator");
                        Console.WriteLine("\t5.Memento");
                        Console.WriteLine("\t6.Observer");
                        Console.WriteLine("\t7.Chain of Responsibility");
                        Console.WriteLine("\t8.Strategy");
                        Console.WriteLine("\t9.Template Method");
                        Console.WriteLine("\t10.Iterator");
                        #endregion
                        break;
                    default:
                        goto LoopGroup;
                }

                int loai = 0;
            LoopPattern: Console.Write("\n--->Choose pattern:");
                int.TryParse(Console.ReadLine(), out loai);
                switch (nhom)
                {
                    //Createional
                    case 1:
                        switch (loai)
                        {
                            case 0:
                                goto LoopGroup;
                            case 1:
                                #region Singleton

                                #endregion
                                break;
                            case 2:
                                #region Factory Method

                                #endregion
                                break;
                            case 3:
                                #region Abstract Factory

                                #endregion
                                break;
                            case 4:
                                #region Builder

                                Console.WriteLine("***Builder");

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
                                break;
                            case 5:
                                #region Prototype

                                Console.WriteLine("***Prototype");

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

                                Console.ReadLine();
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
                                break;
                            default:
                                goto LoopPattern;
                        }
                        break;
                    //Structural
                    case 2:
                        switch (loai)
                        {
                            case 0:
                                goto LoopGroup;
                            case 1:
                                #region Adapter
                                Console.WriteLine("***Adapter");

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
                                break;
                            case 2:
                                #region Composite
                                Console.WriteLine("***Composite");

                                KhachHangComposite clientComposite = new KhachHangComposite();

                                //Tạo 1 thành phần  - 1 lá
                                La la = new La();

                                Console.WriteLine("Khách hàng: Tôi có một thành phần đơn lẻ:");
                                clientComposite.XuLy(la);

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
                                clientComposite.XuLy(cay);

                                Console.WriteLine("Khách hàng: Tôi có thể quản lý cây mà không cần " +
                                    "kiểm tra từng thành phần là lá hay cây hay nhánh:");
                                clientComposite.XuLyCay(cay, la);


                                #endregion
                                break;
                            case 3:
                                #region Decorator
                                ClientDecorator client = new ClientDecorator();

                                // Cà phê cơ bản
                                ThucUong caPhe = new CaPhe();
                                client.ClientAdd(caPhe);

                                // Thêm trân châu vào cà phê
                                ThucUong caPheTranChau = new ToppingTranChau(caPhe);
                                client.ClientAdd(caPheTranChau);

                                // Thêm thạch cà phê và kem sữa vào cà phê
                                ThucUong caPheFull = new ToppingKemSua(new ToppingThachCafe(caPhe));
                                client.ClientAdd(caPheFull);

                                // Trà sữa cơ bản
                                ThucUong traSua = new TraSua();
                                client.ClientAdd(traSua);

                                // Trà sữa với siro đào và đường đen
                                ThucUong traSuaDacBiet = new ToppingDuongDen(new ToppingSiroDao(traSua));
                                client.ClientAdd(traSuaDacBiet);
                                #endregion
                                break;
                            case 4:
                                #region Bridge
                                Console.WriteLine("***Bridge");
                                ClientBridge clientBridge = new ClientBridge();
                                clientBridge.MoApp();
                                Console.ReadLine();
                                #endregion
                                break;
                            case 5:
                                #region Facade
                                BookingFacade bookingFacade = new BookingFacade();
                                bookingFacade.BookTicket("Hà Nội", "TP. Hồ Chí Minh", DateTime.Now.AddDays(7), "0909-0909-0909-0909", "customer@email.com");
                                #endregion
                                break;
                            case 6:
                                #region Flyweight
                                FlyweightFactory factory = new FlyweightFactory();

                                ContextDPFlyweight context1 = new ContextDPFlyweight(factory, "SUV", "Toyota", "Màu Đỏ_Biển Số 123XYZ");
                                ContextDPFlyweight context2 = new ContextDPFlyweight(factory, "SUV", "Toyota", "Màu Xanh_Biển Số 456ABC");
                                ContextDPFlyweight context3 = new ContextDPFlyweight(factory, "Sedan", "Honda", "Màu Đen_Biển Số 101GHI");
                                ContextDPFlyweight context4 = new ContextDPFlyweight(factory, "SUV", "Ford", "Màu Đỏ_Biển Số 555JKL");
                                ContextDPFlyweight context5 = new ContextDPFlyweight(factory, "Sedan", "Toyota", "Màu Xám_Biển Số 999PQR");

                                Console.WriteLine("\n=== Hiển thị các Context ===");
                                context1.Operation();
                                context2.Operation();
                                context3.Operation();
                                context4.Operation();
                                context5.Operation();

                                factory.ListFlyweights();
                                Console.ReadLine();

                                #endregion
                                break;
                            case 7:
                                #region Proxy

                                DocumentProxy proxy = new DocumentProxy("Đây là nội dung tài liệu bảo mật.");

                                ClientDPProxy client1 = new ClientDPProxy(proxy);
                                client1.RequestView("admin");

                                ClientDPProxy client2 = new ClientDPProxy(proxy);
                                client2.RequestView("guest");

                                client1.RequestView("admin");

                                ClientDPProxy client3 = new ClientDPProxy(proxy);
                                client3.RequestView("manager");
                                client3.RequestView("manager");
                                client3.RequestView("manager");

                                #endregion
                                break;
                            default:
                                goto LoopPattern;
                        }
                        break;
                    //Behavioral
                    case 3:
                        switch (loai)
                        {
                            case 0:
                                goto LoopGroup;
                            case 1:
                                #region State
                                // Đơn suôn sẻ
                                Console.WriteLine("Đơn hàng 1:");
                                var contextOrder1 = new OrderContext(new PendingState());
                                Console.ReadLine();
                                contextOrder1.ProcessOrder();
                                Console.ReadLine();
                                contextOrder1.ShipOrder();
                                Console.ReadLine();
                                contextOrder1.DeliverOrder();
                                Console.ReadLine();
                                contextOrder1.CompleteOrder();
                                Console.ReadLine();
                                contextOrder1.CancelOrder();
                                Console.ReadLine();

                                // Đơn bị hủy khi đang process
                                Console.WriteLine("Đơn hàng 2:");
                                var contextOrder2 = new OrderContext(new PendingState());
                                Console.ReadLine();
                                contextOrder2.ProcessOrder();
                                Console.ReadLine();
                                contextOrder2.CancelOrder();
                                Console.ReadLine();

                                // Đơn hàng chưa được xử lý nhưng thử giao
                                Console.WriteLine("Đơn hàng 3:");
                                var contextOrder3 = new OrderContext(new PendingState());
                                Console.ReadLine();
                                contextOrder3.ShipOrder();
                                Console.ReadLine();
                                contextOrder3.ProcessOrder();
                                Console.ReadLine();
                                contextOrder3.ShipOrder();
                                Console.ReadLine();
                                contextOrder3.DeliverOrder();
                                Console.ReadLine();
                                contextOrder3.CompleteOrder();
                                Console.ReadLine();
                                #endregion
                                break;
                            case 2:
                                #region Command
                                var accK = new Account("Khoa", 1900);
                                var accT = new Account("Tien", 2000);

                                var bank = new BankSystem();
                                Console.WriteLine("=== Đăng nhập các kiểu vào tài khoản ===");

                                Console.ReadLine();
                                var deposit = new DepositCommand(accK, 300);
                                
                                bank.SetCommand(deposit);
                                bank.ExecuteCommand();

                                Console.ReadLine();
                                var withdrawfail = new WithdrawCommand(accK, 3000);
                                
                                bank.SetCommand(withdrawfail);
                                bank.ExecuteCommand();

                                Console.ReadLine();
                                var withdrawsuccess = new WithdrawCommand(accK, 1500);
                                
                                bank.SetCommand(withdrawsuccess);
                                bank.ExecuteCommand();

                                Console.ReadLine();
                                var transfer = new TransferCommand(accK, accT, 300);
                                
                                bank.SetCommand(transfer);
                                bank.ExecuteCommand();
                                
                                
                                
                                #endregion
                                break;
                            case 3:
                                #region Visitor

                                var danhSachThietBi = new List<IThietBi>
                                {new MayIn(),new MayFax()};
                                
                                Console.ReadLine();
                                Console.WriteLine("=== KSPC kiểm tra phần cứng ===");
                                QuanLyThietBi.ThucHienKiemTra(danhSachThietBi, new KySuPhanCung());

                                Console.ReadLine();
                                Console.WriteLine("\n=== KSPM kiểm tra phần mềm ===");
                                QuanLyThietBi.ThucHienKiemTra(danhSachThietBi, new KySuPhanMem());

                                Console.ReadLine();
                                Console.WriteLine("\n=== NVVP sử dụng ===");
                                QuanLyThietBi.ThucHienKiemTra(danhSachThietBi, new NhanVienVanPhong());

                                #endregion
                                break;
                            case 4:
                                #region Mediator
                                #endregion
                                break;
                            case 5:
                                #region Memento
                                #endregion
                                break;
                            case 6:
                                #region 

                                #endregion
                                break;
                            case 7:
                                #region 
                                #endregion
                                break;
                            default:
                                goto LoopPattern;
                        }
                        break;
                    //Choose again
                    default:
                        break;
                }
                Console.WriteLine(".");
                if (Console.ReadLine() == " ") goto Begin;
            }
            catch (Exception ex)
            { Console.WriteLine(ex); }
        }
    }
}
