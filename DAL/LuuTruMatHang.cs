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
    public class LuuTruMatHang : ILuuTruMatHang
    {
        public List<MatHang> DocDanhSachMatHang()
        {
            var myDir = Environment.CurrentDirectory;
            StreamReader reader = new StreamReader($"{myDir}\\DS_MatHang.json");
            string jsonString = reader.ReadToEnd();
            reader.Close();

            var result = JsonConvert.DeserializeObject<List<MatHang>>(jsonString);
            return result;
        }
        public void LuuTruDanhSachMatHang(List<MatHang> mh)
        {
            var myDir = Environment.CurrentDirectory;
            StreamWriter writer = new StreamWriter($"{myDir}\\DS_MatHang.json");

            string jsonString = JsonConvert.SerializeObject(mh);
            writer.Write(jsonString);

            writer.Close();

        }
        public bool LuuMatHang(MatHang mh)
        {
            var ds = DocDanhSachMatHang();
            foreach(MatHang h in ds)
            {
                if(h.MaMH == mh.MaMH)
                {
                    return false;
                }
            }
            ds.Add(mh);
            LuuTruDanhSachMatHang(ds);
            return true;
        }

        public List<MatHang> TimKiem(string tuKhoa, string theLoai )
        {
            var dsmh = DocDanhSachMatHang();
            var result = new List<MatHang>();
            foreach(MatHang mh in dsmh)
            {
                if(theLoai == "MaMatHang" && mh.MaMH.Contains(tuKhoa))
                {
                    result.Add(mh);
                }
                else if (theLoai == "TenMatHang" && mh.TenMH.Contains(tuKhoa))
                {
                    result.Add(mh);
                }
                else if (theLoai == "LoaiHang" && mh.LoaiHang.Contains(tuKhoa))
                {
                    result.Add(mh);
                }
                else if (theLoai == "CtySX" && mh.CtySX.Contains(tuKhoa))
                {
                    result.Add(mh);
                }
                else if (mh.TenMH.Contains(tuKhoa))
                {
                    result.Add(mh);
                }


            }
            return result;
        }
        public bool XoaMatHang(string Id)
        {
            var ds = DocDanhSachMatHang();
            for(int i = 0; i < ds.Count; i++)
            {
                if(ds[i].MaMH == Id)
                {
                    ds.RemoveAt(i);
                    LuuTruDanhSachMatHang(ds);
                    return true;
                }
            }
            return false;
        }
        public bool SuaMatHang(MatHang mh)
        {
            var ds = DocDanhSachMatHang();
            for (int i = 0; i<ds.Count;i++)
            {
                if(ds[i].MaMH == mh.MaMH)
                {
                    ds[i] = mh;
                    LuuTruDanhSachMatHang(ds);
                    return true;
                }
            }
            return false;
        }


    }
}
