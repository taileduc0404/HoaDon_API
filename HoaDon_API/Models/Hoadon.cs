using System;
using System.Collections.Generic;

#nullable disable

namespace HoaDon_API.Models
{
    public partial class Hoadon
    {
        public Hoadon()
        {
            Chitiethoadons = new HashSet<Chitiethoadon>();
        }

        public string Sohd { get; set; }
        public DateTime? Ngaylaphd { get; set; }
        public string Tenkh { get; set; }

        public virtual ICollection<Chitiethoadon> Chitiethoadons { get; set; }
    }
}
