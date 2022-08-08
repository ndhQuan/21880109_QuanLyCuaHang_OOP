using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;
using System.IO;
using Newtonsoft.Json;

namespace DAL
{
    public class LuuTruLoaiHang : ILuuTruLoaiHang
    {
        public List<LoaiHang> DocDanhSachLoaiHang()
        {
            var myDir = Environment.CurrentDirectory;
            StreamReader reader = new StreamReader($"{myDir}\\DS_LoaiHang.json");
            string jsonString = reader.ReadToEnd();
            reader.Close();

            var result = JsonConvert.DeserializeObject<List<LoaiHang>>(jsonString);
            return result;
        }
        public void LuuTruDanhSachLoaiHang(List<LoaiHang> lh)
        {
            var myDir = Environment.CurrentDirectory;
            StreamWriter writer = new StreamWriter($"{myDir}\\DS_LoaiHang.json");

            string jsonString = JsonConvert.SerializeObject(lh);
            writer.Write(jsonString);

            writer.Close();

        }
        public bool LuuLoaiHang(LoaiHang lh)
        {
            var ds = DocDanhSachLoaiHang();
            foreach (LoaiHang h in ds)
            {
                if (h.MaLoaiHang == lh.MaLoaiHang)
                {
                    return false;
                }
            }
            ds.Add(lh);
            LuuTruDanhSachLoaiHang(ds);
            return true;
        }

        public List<LoaiHang> TimKiem(string tuKhoa, string theLoai)
        {
            var dslh = DocDanhSachLoaiHang();
            var result = new List<LoaiHang>();
            foreach (LoaiHang lh in dslh)
            {
                if (theLoai == "MaLoaiHang" && lh.MaLoaiHang.Contains(tuKhoa))
                {
                    result.Add(lh);
                }
                else if (theLoai == "TenLoaiHang" && lh.TenLoaiHang.Contains(tuKhoa))
                {
                    result.Add(lh);
                }
                else if (lh.TenLoaiHang.Contains(tuKhoa))
                {
                    result.Add(lh);
                }
            }
            return result;

        }
        public bool SuaLoaiHang(string id, string tenLoaiHang)
        {
            List<LoaiHang> dslh = DocDanhSachLoaiHang();
            for(int i = 0; i < dslh.Count; i++)
            {
                if(dslh[i].MaLoaiHang == id)
                {
                    dslh[i] = new LoaiHang(id, tenLoaiHang);
                    LuuTruDanhSachLoaiHang(dslh);
                    return true;
                }
            }
            return false;
        }
        public bool XoaLoaiHang(string id)
        {
            List<LoaiHang> dslh = DocDanhSachLoaiHang();
            for(int i = 0; i < dslh.Count; i++)
            {
                if(dslh[i].MaLoaiHang == id)
                {
                    dslh.RemoveAt(i);
                    LuuTruDanhSachLoaiHang(dslh);
                    return true;
                }
            }
            return false;
        }
        public bool ThemLoaiHang(LoaiHang lhMoi)
        {
            List<LoaiHang> dslh = DocDanhSachLoaiHang();
            foreach(LoaiHang h in dslh)
            {
                if(h.MaLoaiHang == lhMoi.MaLoaiHang)
                {
                    return false;
                }
            }
            dslh.Add(lhMoi);
            LuuTruDanhSachLoaiHang(dslh);
            return true;
        }

    }
}
