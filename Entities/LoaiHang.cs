using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class LoaiHang
    {
        public string MaLoaiHang { get; set; }
        public string TenLoaiHang { get; set; }
        public LoaiHang()
        {

        }
        public LoaiHang(string maLH, string tenLH)
        {
            if(string.IsNullOrWhiteSpace(maLH)||
               string.IsNullOrWhiteSpace(tenLH))
            {
                throw new Exception("Loai hang khong hop le"); 
            }
            this.MaLoaiHang = maLH;
            this.TenLoaiHang = tenLH;
        }
    }
}
