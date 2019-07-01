namespace HomeWork1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(v_客戶明細MetaData))]
    public partial class v_客戶明細
    {
    }
    
    public partial class v_客戶明細MetaData
    {
        [Required]
        public int Id { get; set; }

        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        [Display(Name = "ClientName", ResourceType = typeof(HomeWork1.I18N.Resource))]
        public string 客戶名稱 { get; set; }

        
        [Display(Name = "ContactPersonCount", ResourceType = typeof(HomeWork1.I18N.Resource))]
        public Nullable<int> 聯絡人數量 { get; set; }

        [Display(Name = "BankAccountCount", ResourceType = typeof(HomeWork1.I18N.Resource))]
        public Nullable<int> 銀行帳戶數量 { get; set; }
    }
}
