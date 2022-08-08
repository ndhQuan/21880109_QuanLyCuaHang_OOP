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
    public class MH_SuaLoaiHangModel : PageModel
    {
        private IXuLyLoaiHang xuLyLoaiHang;
        public string Chuoi { get; set; }
        public LoaiHang LoaiHang;
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        [BindProperty]
        public string TenLoaiHang { get; set; }

        public void OnGet()
        {
            List<LoaiHang> dsLoaiHang = xuLyLoaiHang.DocDanhSachLoaiHang();
            foreach (LoaiHang lh in dsLoaiHang)
            {
                if (lh.MaLoaiHang == Id)
                {
                    LoaiHang = lh;
                }
            }
            if (LoaiHang == null)
            {
                Chuoi = "Khong tim thay san pham";
            }

        }
        public void OnPost()
        {
            bool kq = xuLyLoaiHang.SuaLoaiHang(Id, TenLoaiHang);
            Chuoi = $"Ket qua la {kq}";
            Response.Redirect("/MH_DanhSachLoaiHang");

        }
        public MH_SuaLoaiHangModel()
        {
            xuLyLoaiHang = new XuLyLoaiHang();
        }
    }
}
