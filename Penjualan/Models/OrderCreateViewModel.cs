using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Penjualan.Models
{
    public class OrderCreateViewModel
    {
        public int Id { get; set; }
        public int Total { get; set; }
        public List<string> BarangList { get; set; }
        public List<SelectListItem> BarangDropDownList { get; set; }
        public Barang Barang { get; set; }
    }
}
