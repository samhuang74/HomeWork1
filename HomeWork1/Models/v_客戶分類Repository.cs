using System;
using System.Linq;
using System.Collections.Generic;
	
namespace HomeWork1.Models
{   
	public  class v_客戶分類Repository : EFRepository<v_客戶分類>, Iv_客戶分類Repository
	{

	}

	public  interface Iv_客戶分類Repository : IRepository<v_客戶分類>
	{

	}
}