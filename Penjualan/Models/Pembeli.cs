//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Penjualan.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pembeli
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string JenisKelamin { get; set; }
        public string TTL { get; set; }
    
        public virtual KategoriPembeli KategoriPembeli { get; set; }
    }
}
