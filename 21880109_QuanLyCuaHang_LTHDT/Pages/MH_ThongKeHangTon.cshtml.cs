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
    public class MH_ThongKeHangTonModel : PageModel
    {
        private IXuLyLoaiHang xuLyLoaiHang;
        private IXuLyMatHang xuLyMatHang;
        private IXuLyHoaDon xuLyHoaDon;
        public int TongTonKho { get; set; }
        public List<LoaiHang> dslh { get; set; }
        public List<MatHang> dsHangTonTheoLoai { get; set; }
        public int[] soLuongNhap { get; set; }
        public int[] soLuongBan { get; set; }
        public int[] soLuongTonKho { get; set; }
        [BindProperty]
        public string LoaiHang { get; set; }
        public void OnGet()
        {
            TongTonKho = 0;
            dslh = xuLyLoaiHang.DocDanhSachLoaiHang();
            dsHangTonTheoLoai = xuLyMatHang.TimKiemHangTonTheoLoai(string.Empty);
            soLuongNhap = new int[dsHangTonTheoLoai.Count];   
            soLuongBan = new int[dsHangTonTheoLoai.Count];   
            soLuongTonKho = new int[dsHangTonTheoLoai.Count];  

            for (int i = 0; i < dsHangTonTheoLoai.Count; i++)
            {
                soLuongNhap[i] = xuLyHoaDon.TongSoLuongNhap(dsHangTonTheoLoai[i].MaMH);
                soLuongBan[i] = xuLyHoaDon.TongSoLuongBan(dsHangTonTheoLoai[i].MaMH);
                soLuongTonKho[i] = soLuongNhap[i] - soLuongBan[i];
                TongTonKho += soLuongTonKho[i];
            }

        }
        public void OnPost()
        {
            TongTonKho = 0;
            dslh = xuLyLoaiHang.DocDanhSachLoaiHang();
            dsHangTonTheoLoai = xuLyMatHang.TimKiemHangTonTheoLoai(LoaiHang);
            soLuongNhap = new int[dsHangTonTheoLoai.Count];  
            soLuongBan = new int[dsHangTonTheoLoai.Count];   
            soLuongTonKho = new int[dsHangTonTheoLoai.Count];

            for (int i = 0; i < dsHangTonTheoLoai.Count; i++)
            {
                soLuongNhap[i] = xuLyHoaDon.TongSoLuongNhap(dsHangTonTheoLoai[i].MaMH);
                soLuongBan[i] = xuLyHoaDon.TongSoLuongBan(dsHangTonTheoLoai[i].MaMH);
                soLuongTonKho[i] = soLuongNhap[i] - soLuongBan[i];
                TongTonKho += soLuongTonKho[i];
            }
        }
        public MH_ThongKeHangTonModel()
        {
            xuLyLoaiHang = new XuLyLoaiHang();
            xuLyMatHang = new XuLyMatHang();
            xuLyHoaDon = new XuLyHoaDon();
        }
    }
}
