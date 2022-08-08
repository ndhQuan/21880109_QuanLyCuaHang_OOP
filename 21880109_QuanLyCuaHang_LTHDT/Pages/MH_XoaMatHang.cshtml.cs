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
    public class MH_XoaMatHangModel : PageModel
    {
        public string Chuoi { get; set; }
        public IXuLyMatHang xuLyMatHang;
        public MatHang matHang;
        public List<string> HoaDonChuaMatHang { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }


        public void OnGet()
        {
            List<MatHang> dsMatHang = xuLyMatHang.DocDanhSachMatHang();
            foreach(MatHang mh in dsMatHang)
            {
                if(mh.MaMH == Id)
                {
                    matHang = mh;
                }
            }
            if(matHang == null)
            {
                Chuoi = "Khong tim thay san pham";
            }
        }
        public void OnPost()
        {
            bool kq = xuLyMatHang.XoaMatHang(Id);
            if (kq)
            {
                Chuoi = "Xoa mat hang thanh cong";
            }
            else Chuoi = "Khong xoa duoc mat hang";

        }
        public MH_XoaMatHangModel()
        {
            xuLyMatHang = new XuLyMatHang();
        }
    }
}
