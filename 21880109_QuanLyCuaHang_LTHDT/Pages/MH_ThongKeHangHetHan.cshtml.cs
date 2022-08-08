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
    public class MH_ThongKeHangHetHanModel : PageModel
    {
        private IXuLyMatHang xuLyMatHang;
        private IXuLyHoaDon xuLyHoaDon;
        public List<MatHang> dsmhHetHan { get; set; }
        public int[] soLuongTonKho { get; set; }
        public void OnGet()
        {
            dsmhHetHan = xuLyMatHang.ThongKeHetHan();
            int[] soLuongNhap = new int[dsmhHetHan.Count];
            int[] soLuongBan = new int[dsmhHetHan.Count];
            soLuongTonKho = new int[dsmhHetHan.Count];
            for (int i = 0; i < dsmhHetHan.Count; i++)
            {
                soLuongNhap[i] = xuLyHoaDon.TongSoLuongNhap(dsmhHetHan[i].MaMH);
                soLuongBan[i] = xuLyHoaDon.TongSoLuongBan(dsmhHetHan[i].MaMH);
                soLuongTonKho[i] = soLuongNhap[i] - soLuongBan[i];
            }
        }
        public MH_ThongKeHangHetHanModel()
        {
            xuLyMatHang = new XuLyMatHang();
            xuLyHoaDon = new XuLyHoaDon();
        }
    }
}
