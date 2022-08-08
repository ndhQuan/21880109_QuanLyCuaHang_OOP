using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities;
using Services;

namespace _21880109_QuanLyCuaHang_LTHDT.Pages
{
    public class MH_XoaLoaiHangModel : PageModel
    {
        public string Chuoi { get; set; }
        public IXuLyLoaiHang xuLyLoaiHang;
        public LoaiHang loaiHang;
        public List<string> HoaDonChuaMatHang { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }


        public void OnGet()
        {
            List<LoaiHang> dsLoaiHang = xuLyLoaiHang.DocDanhSachLoaiHang();
            foreach (LoaiHang mh in dsLoaiHang)
            {
                if (mh.MaLoaiHang == Id)
                {
                    loaiHang = mh;
                }
            }
            if (loaiHang == null)
            {
                Chuoi = "Khong tim thay san pham";
            }
        }
        public void OnPost()
        {
            bool kq = xuLyLoaiHang.XoaLoaiHang(Id);
            if (kq)
            {
                Chuoi = "Xoa mat hang thanh cong";
            }
            else Chuoi = "Khong xoa duoc mat hang";

        }
    }
}
