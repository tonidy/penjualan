using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Penjualan.Models
{
	public class PembeliEditViewModels
	{
		public int Id { get; set; }
		public string Nama { get; set; }
		public string JenisKelamin { get; set; }
		public DateTime TTL { get; set; }

		public bool IsFemale { get; set; }

		public int KategoriPembeli { get; set; }
		public List<SelectListItem> KategoriPembeliList {get;set;}
		}
}