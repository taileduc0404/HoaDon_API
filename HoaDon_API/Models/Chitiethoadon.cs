using System;
using System.Collections.Generic;

#nullable disable

namespace HoaDon_API.Models
{
    public partial class Chitiethoadon
    {
        public string Sohd { get; set; }
        public string Mahang { get; set; }
        public double? Dongia { get; set; }
        public int? Soluong { get; set; }

        public virtual Hanghoa MahangNavigation { get; set; }
        public virtual Hoadon SohdNavigation { get; set; }
    }
}
