using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Newtonsoft.Json;

namespace DAL
{
    public class LuuTruHoaDon : ILuuTruHoaDon
    {

        public bool LuuHoaDonNhapHang(HoaDon h)
        {
            List<HoaDon> danhSachHoaDon = DocDanhSachHoaDonNhapHang();
            foreach(HoaDon hoaDon in danhSachHoaDon)
            {
                if(hoaDon.MaHoaDon == h.MaHoaDon)
                {
                    return false;
                }
            }
            danhSachHoaDon.Add(h);
            LuuDanhSachHoaDonNhapHang(danhSachHoaDon);
            return true;
        }
        public List<HoaDon> DocDanhSachHoaDonNhapHang()
        {
            string myDir = Environment.CurrentDirectory;
            StreamReader reader = new StreamReader($"{myDir}\\DS_HoaDonNhapHang.json");
            string jsonString = reader.ReadToEnd();
            reader.Close();

            List<HoaDon> danhSachHoaDon = JsonConvert.DeserializeObject<List<HoaDon>>(jsonString);
            return danhSachHoaDon;
        }
        public bool LuuDanhSachHoaDonNhapHang(List<HoaDon> dsHoaDon)
        {
            string myDir = Environment.CurrentDirectory;
            StreamWriter writer = new StreamWriter($"{myDir}\\DS_HoaDonNhapHang.json");

            string jsonString = JsonConvert.SerializeObject(dsHoaDon);
            writer.Write(jsonString);
            writer.Close();
            return true;
        }

        public List<HoaDon> TimKiemHoaDonNhap(string tuKhoa, string Target)
        {
            var dshd = DocDanhSachHoaDonNhapHang();
            var result = new List<HoaDon>();
            foreach (HoaDon hd in dshd)
            {
                if (Target == "MaHoaDon" && hd.MaHoaDon.Contains(tuKhoa))
                {
                    result.Add(hd);
                }
                else if (Target == "NgayTao" && hd.NgayTaoHoaDon.Contains(tuKhoa))
                {
                    result.Add(hd);
                }
                else if (hd.MaHoaDon.Contains(tuKhoa))
                {
                    result.Add(hd);
                }

            }
            return result;
        }

        public bool LuuHoaDonBanHang(HoaDon h)
        {
            List<HoaDon> danhSachHoaDon = DocDanhSachHoaDonBanHang();
            foreach (HoaDon hoaDon in danhSachHoaDon)
            {
                if (hoaDon.MaHoaDon == h.MaHoaDon)
                {
                    return false;
                }
            }
            danhSachHoaDon.Add(h);
            LuuDanhSachHoaDonBanHang(danhSachHoaDon);
            return true;
        }

        public List<HoaDon> DocDanhSachHoaDonBanHang()
        {
            string myDir = Environment.CurrentDirectory;
            StreamReader reader = new StreamReader($"{myDir}\\DS_HoaDonBanHang.json");
            string jsonString = reader.ReadToEnd();
            reader.Close();

            List<HoaDon> danhSachHoaDon = JsonConvert.DeserializeObject<List<HoaDon>>(jsonString);
            return danhSachHoaDon;
        }
        public bool LuuDanhSachHoaDonBanHang(List<HoaDon> dsHoaDon)
        {
            string myDir = Environment.CurrentDirectory;
            StreamWriter writer = new StreamWriter($"{myDir}\\DS_HoaDonBanHang.json");

            string jsonString = JsonConvert.SerializeObject(dsHoaDon);
            writer.Write(jsonString);
            writer.Close();
            return true;
        }

        public List<HoaDon> TimKiemHoaDonBan(string tuKhoa, string Target)
        {
            var dshdb = DocDanhSachHoaDonBanHang();
            var result = new List<HoaDon>();
            foreach (HoaDon hd in dshdb)
            {
                if (Target == "MaHoaDon" && hd.MaHoaDon.Contains(tuKhoa))
                {
                    result.Add(hd);
                }
                else if (Target == "NgayTao" && hd.NgayTaoHoaDon.Contains(tuKhoa))
                {
                    result.Add(hd);
                }
                else if (hd.MaHoaDon.Contains(tuKhoa))
                {
                    result.Add(hd);
                }

            }
            return result;

        }
        public bool SuaHoaDonNhap(HoaDon h)
        {
            List<HoaDon> dshdn = DocDanhSachHoaDonNhapHang();
            for (int i = 0; i < dshdn.Count; i++)
            {
                if (dshdn[i].MaHoaDon == h.MaHoaDon)
                {
                    dshdn[i] = h;
                    LuuDanhSachHoaDonNhapHang(dshdn);
                    return true;
                }
            }
            return false;

        }
        public bool SuaHoaDonBan(HoaDon h)
        {
            List<HoaDon> dshdb = DocDanhSachHoaDonBanHang();
            for (int i = 0; i < dshdb.Count; i++)
            {
                if (dshdb[i].MaHoaDon == h.MaHoaDon)
                {
                    dshdb[i] = h;
                    LuuDanhSachHoaDonBanHang(dshdb);
                    return true;
                }
            }
            return false;

        }

    }
}
