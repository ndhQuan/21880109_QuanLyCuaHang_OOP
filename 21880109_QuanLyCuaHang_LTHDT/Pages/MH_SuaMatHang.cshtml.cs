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
    public class MH_SuaMatHangModel : PageModel
    {
        private IXuLyLoaiHang xuLyLoaiHang;
        private IXuLyMatHang xuLyMatHang;
        public List<LoaiHang> dsLoaiHang;
        public MatHang matHang;
        public string Chuoi { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        [BindProperty]
        public string TenMatHang { get; set; }
        [BindProperty]
        public string HanDung { get; set; }
        [BindProperty]
        public string CtySX { get; set; }
        [BindProperty]
        public string NgaySX { get; set; }
        [BindProperty]
        public string LoaiHang { get; set; }
        [BindProperty]
        public int Gia { get; set; }

        public void OnGet()
        {
            dsLoaiHang = xuLyLoaiHang.DocDanhSachLoaiHang();
            List<MatHang> dsMatHang = xuLyMatHang.DocDanhSachMatHang();
            foreach (MatHang mh in dsMatHang)
            {
                if (mh.MaMH == Id)
                {
                    matHang = mh;
                }
            }
            if (matHang == null)
            {
                Chuoi = "Khong tim thay san pham";
            }
        }
        public void OnPost()
        {
            bool kq = xuLyMatHang.SuaMatHang(Id, TenMatHang, HanDung, CtySX, NgaySX, LoaiHang, Gia);
            Chuoi = $"Ket qua la {kq}";
        }
        public MH_SuaMatHangModel()
        {
            xuLyLoaiHang = new XuLyLoaiHang();
            xuLyMatHang = new XuLyMatHang();
        }
    }
}
