using System;

namespace Entities
{
    public class MatHang
    {
        public string MaMH { get; set; }
        public string TenMH { get; set; }
        public string HanDung { get; set; }
        public string CtySX { get; set; }
        public string NgaySX { get; set; }
        public string LoaiHang { get; set; }
        public int Gia { get; set; }
        public MatHang()
        {

        }
        public MatHang(string maMH, string tenMH, string loaiHang, string hanDung, string ctySX, string ngaySX,  int Gia)
        {
            if (string.IsNullOrWhiteSpace(maMH) ||
                string.IsNullOrWhiteSpace(tenMH) ||
                string.IsNullOrWhiteSpace(loaiHang) ||
                string.IsNullOrWhiteSpace(hanDung) ||
                string.IsNullOrWhiteSpace(hanDung) ||
                string.IsNullOrWhiteSpace(ctySX) ||
                Gia < 0)
            {
                throw new Exception("Mat hang khong hop le");
            }
            this.MaMH = maMH;
            this.TenMH = tenMH;
            this.LoaiHang = loaiHang;
            this.HanDung = hanDung;
            this.CtySX = ctySX;
            this.NgaySX = ngaySX;
            this.Gia = Gia;
        }


    }
}
