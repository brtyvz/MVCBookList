//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookApplication.Models.Entitiy
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TBLBOOKS
    {
        public int BOOKID { get; set; }
        [Required]
        public string BOOKNAME { get; set; }
        public string BOOKISBN { get; set; }
        public Nullable<short> BOOKCATEGORY { get; set; }
        public string BOOKAUTHOR { get; set; }
    
        public virtual TBLCATEGORIES TBLCATEGORIES { get; set; }
    }
}
