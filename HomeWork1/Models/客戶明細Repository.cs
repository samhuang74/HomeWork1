using System;
using System.Linq;
using System.Collections.Generic;
	
namespace HomeWork1.Models
{   
	public  class 客戶明細Repository : EFRepository<客戶明細>, I客戶明細Repository
	{

	}

	public  interface I客戶明細Repository : IRepository<客戶明細>
	{

	}
}