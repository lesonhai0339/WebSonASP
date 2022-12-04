using System;
using System.Collections.Generic;

#nullable disable

namespace WebSonASP.Models
{
    public partial class Mauson
    {
        public string Mason { get; set; }
        public string Tenmau { get; set; }
        public string Maloai { get; set; }

        public virtual Loaison MaloaiNavigation { get; set; }
    }
}
