using System;
using System.Collections.Generic;

#nullable disable

namespace WebSonASP.Models
{
    public partial class Loaison
    {
        public Loaison()
        {
            Mausons = new HashSet<Mauson>();
        }

        public string Maloai { get; set; }
        public string Tenloai { get; set; }

        public virtual ICollection<Mauson> Mausons { get; set; }
    }
}
