    class QuanLyGiaoDich
    {
        private string _state;

        public QuanLyGiaoDich(string trangThai)
        {
            this._state = trangThai;
            Console.WriteLine("QuanLyGiaoDich: Trạng thái ban đầu của giao dịch là: " + trangThai);
        }

        // Chức năng xử lý giao dịch có thể làm thay đổi trạng thái của nó
        public void XulyGiaoDich()
        {
            Console.WriteLine("QuanLyGiaoDich: Đang xử lý giao dịch...");
            this._state = this.TaoChuoiNgauNhien(30);
            Console.WriteLine($"QuanLyGiaoDich: Và trạng thái của giao dịch đã thay đổi thành: {_state}");
        }

        private string TaoChuoiNgauNhien(int doDai = 10)
        {
            string kyTuDuocPhep = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string ketQua = string.Empty;

            while (doDai > 0)
            {
                ketQua += kyTuDuocPhep[new Random().Next(0, kyTuDuocPhep.Length)];

                Thread.Sleep(12);

                doDai--;
            }

            return ketQua;
        }

        // Lưu lại trạng thái hiện tại vào Memento
        public ITransactionMemento LuuLai()
        {
            return new TransactionMemento(this._state);
        }

        // Phục hồi trạng thái giao dịch từ Memento
        public void PhucHoi(ITransactionMemento memento)
        {
            if (!(memento is TransactionMemento))
            {
                throw new Exception("Lớp memento không hợp lệ: " + memento.ToString());
            }

            this._state = memento.LayTrangThai();
            Console.Write($"QuanLyGiaoDich: Trạng thái của giao dịch đã thay đổi thành: {_state}");
        }
    }

    // Memento Interface
    public interface ITransactionMemento
    {
        string LayTen();

        string LayTrangThai();

        DateTime LayNgayTao();
    }

    // Memento
    class TransactionMemento : ITransactionMemento
    {
        private string _trangThai;

        private DateTime _ngayTao;

        public TransactionMemento(string trangThai)
        {
            this._trangThai = trangThai;
            this._ngayTao = DateTime.Now;
        }

        public string LayTrangThai()
        {
            return this._trangThai;
        }

        public string LayTen()
        {
            return $"{this._ngayTao} / ({this._trangThai.Substring(0, 9)})...";
        }

        public DateTime LayNgayTao()
        {
            return this._ngayTao;
        }
    }

    // Caretaker
    class QuanLyLichSu
    {
        private List<ITransactionMemento> _mementos = new List<ITransactionMemento>();

        private QuanLyGiaoDich _quanLyGiaoDich;

        public QuanLyLichSu(QuanLyGiaoDich quanLyGiaoDich)
        {
            this._quanLyGiaoDich = quanLyGiaoDich;
        }

        public void LuuTru()
        {
            Console.WriteLine("\nQuanLyLichSu: Đang lưu lại trạng thái giao dịch...");
            this._mementos.Add(this._quanLyGiaoDich.LuuLai());
        }

        public void HoanTac()
        {
            if (this._mementos.Count == 0)
            {
                return;
            }

            var memento = this._mementos.Last();
            this._mementos.Remove(memento);

            Console.WriteLine("QuanLyLichSu: Đang phục hồi trạng thái giao dịch từ: " + memento.LayTen());

            try
            {
                this._quanLyGiaoDich.PhucHoi(memento);
            }
            catch (Exception)
            {
                this.HoanTac();
            }
        }

        public void XemLichSu()
        {
            Console.WriteLine("QuanLyLichSu: Danh sách các giao dịch đã lưu:");

            foreach (var memento in this._mementos)
            {
                Console.WriteLine(memento.LayTen());
            }
        }
    }
