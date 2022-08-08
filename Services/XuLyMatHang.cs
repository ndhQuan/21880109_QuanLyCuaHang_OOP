using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;

namespace Services
{
    public class XuLyMatHang : IXuLyMatHang
    {
        private ILuuTruMatHang luuTruMatHang;
        public XuLyMatHang()
        {
            luuTruMatHang = new LuuTruMatHang();
        }
        public List<MatHang> TimKiem(string TuKhoa, string theLoai)
        {
            try
            {
                if(TuKhoa == null)
                {
                    TuKhoa = string.Empty;
                }
                return luuTruMatHang.TimKiem(TuKhoa, theLoai);
            }
            catch
            {
                return new List<MatHang>();
            }
        }
        public bool ThemMatHang(MatHang mh)
        {
            if (string.IsNullOrWhiteSpace(mh.TenMH) ||
                string.IsNullOrWhiteSpace(mh.MaMH) ||
                string.IsNullOrWhiteSpace(mh.HanDung) ||
                string.IsNullOrWhiteSpace(mh.CtySX) ||
                string.IsNullOrWhiteSpace(mh.NgaySX) ||
                string.IsNullOrWhiteSpace(mh.LoaiHang) ||
                mh.Gia <= 0)
            {
                return false;
            }

            return luuTruMatHang.LuuMatHang(mh);
        }
        public List<MatHang> DocDanhSachMatHang()
        {
            return luuTruMatHang.DocDanhSachMatHang();
        }
        public bool XoaMatHang(string Id)
        {
            return luuTruMatHang.XoaMatHang(Id);
        }
        public bool SuaMatHang(string Id, string TenMatHang, string HanDung, string CtySX, string NgaySX, string LoaiHang, int Gia)
        {
            if (string.IsNullOrWhiteSpace(TenMatHang) ||
                string.IsNullOrWhiteSpace(Id) ||
                string.IsNullOrWhiteSpace(HanDung) ||
                string.IsNullOrWhiteSpace(CtySX) ||
                string.IsNullOrWhiteSpace(NgaySX) ||
                string.IsNullOrWhiteSpace(LoaiHang) ||
                Gia <= 0)
            {
                return false;
            }

            List<MatHang> dsmh = luuTruMatHang.DocDanhSachMatHang();
            foreach(MatHang m in dsmh)
            {
                if (m.MaMH == Id)
                {
                    MatHang mhMoi = new MatHang(Id, TenMatHang, LoaiHang, HanDung, CtySX, NgaySX, Gia);
                    return luuTruMatHang.SuaMatHang(mhMoi);
                }

            }
            return false;
        }
        public string ThemTenMatHang(string MaMatHang)
        {

            List<MatHang> dsmh = luuTruMatHang.DocDanhSachMatHang();
            foreach (MatHang h in dsmh)
            {
                if (h.MaMH == MaMatHang)
                {
                    return h.TenMH;
                }
            }
            return string.Empty;
        }
        public int ThemDonGiaMatHang(string MaMatHang)
        {
            List<MatHang> dsmh = luuTruMatHang.DocDanhSachMatHang();
            for (int i = 0; i < dsmh.Count; i++)
            {
                if (MaMatHang == dsmh[i].MaMH)
                {
                    return dsmh[i].Gia;
                }
            }
            return 0;

        }
        public List<MatHang> TimKiemHangTonTheoLoai(string LoaiHang)
        {
            if (LoaiHang == null) LoaiHang = string.Empty;
            List<MatHang> dsmh = luuTruMatHang.DocDanhSachMatHang();
            List<MatHang> dsTonTheoLoai = new List<MatHang>();
            foreach (MatHang mh in dsmh)
            {
                if (mh.LoaiHang.Contains(LoaiHang))
                {
                    dsTonTheoLoai.Add(mh);
                }
            }
            return dsTonTheoLoai;
        }
        public static DateTime convertToDateTime(string time)
        {
            string[] m = time.Split("-", StringSplitOptions.RemoveEmptyEntries);
            int year = int.Parse(m[0]);
            int month = int.Parse(m[1]);
            int day = int.Parse(m[2]);
            DateTime t = new DateTime(year, month, day);
            return t;
        }

        public List<MatHang> ThongKeHetHan()
        {
            List<MatHang> dsmh = luuTruMatHang.DocDanhSachMatHang();
            List<MatHang> danhSachHetHan = new List<MatHang>();
            for (int i = 0; i < dsmh.Count; i++)
            {
                DateTime NgayHetHan = convertToDateTime(dsmh[i].HanDung);
                int compare = DateTime.Compare(DateTime.Now, NgayHetHan);
                if (compare >= 0)
                {
                    danhSachHetHan.Add(dsmh[i]);
                }
            }
            return danhSachHetHan;

        }

    }
}
