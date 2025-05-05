    // Mediator Interface
    public interface IMediator
    {
        void Notify(object sender, string action);
    }

    // Mediator 
    public class Mediator : IMediator
    {
        public SinhVien SinhVien { get; set; }
        public GiaoVien GiaoVien { get; set; }
        public PhongThietBi PhongThietBi { get; set; }
        public PhongHoc PhongHoc { get; set; }

        public void Notify(object sender, string action)
        {
            if (action == "MuonRemote")
            {
                PhongThietBi.CapPhatRemote();
                Console.WriteLine("Mediator: Thiết bị đã được cấp. Bật phòng học.");
                PhongHoc.BatPhongHoc();
                GiaoVien.BatDauDay();
            }
            else if (action == "VaoLop")
            {
                Console.WriteLine("Mediator: Kiểm tra tình trạng phòng...");
                if (PhongHoc.SanSangGiangDay())
                {
                    GiaoVien.BatDauDay();
                }
                else
                {
                    Console.WriteLine("Mediator: Phòng chưa sẵn sàng. Sinh viên cần mượn remote từ phòng thiết bị.");
                }
            }
        }
    }

    // Component: Sinh viên
    public class SinhVien
    {
        private IMediator _mediator;

        public SinhVien(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void VaoLop()
        {
            Console.WriteLine("Sinh viên: Em đã vào lớp.");
            _mediator.Notify(this, "VaoLop");
        }

        public void MuonRemote()
        {
            Console.WriteLine("Sinh viên: Em cần mượn remote để bật máy lạnh và máy chiếu.");
            _mediator.Notify(this, "MuonRemote");
        }
    }

    // Component: Giáo viên
    public class GiaoVien
    {
        private IMediator _mediator;

        public GiaoVien(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void BatDauDay()
        {
            Console.WriteLine("Giáo viên: Phòng sẵn sàng. Bắt đầu giảng bài.");
        }
    }

    // Component: Phòng thiết bị
    public class PhongThietBi
    {
        public void CapPhatRemote()
        {
            Console.WriteLine("Phòng thiết bị: Remote đã được cấp cho sinh viên.");
        }
    }

    // Component: Phòng học
    public class PhongHoc
    {
        private bool _daBat = false;

        public void BatPhongHoc()
        {
            _daBat = true;
            Console.WriteLine("Phòng học: Máy lạnh và máy chiếu đã bật.");
        }

        public bool SanSangGiangDay()
        {
            return _daBat;
        }
    }
