using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Penjualan.Models
{
    public class CreateViewModel
    {
        public bool IsFemale { get; set; }
        public int Id { get; set; }
        public string Nama { get; set; }
        public string JenisKelamin { get; set; }
        public string TTL { get; set; }

        public List<SelectListItem> ListKategoriPembeli { get; set; }
        public int KategoriPembeli { get; set; }
    
    }
}