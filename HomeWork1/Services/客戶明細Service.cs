using System;
using System.Linq;
using System.Collections.Generic;
using Repositories;
using HomeWork1.Models;

namespace HomeWork1.Services
{
    public interface Iv_客戶明細Service
    {
        IQueryable<v_客戶明細> Reads();
    }

    public  class v_客戶明細Service : Iv_客戶明細Service
    {
        IRepository<v_客戶明細> _v_客戶明細Repository;

        public v_客戶明細Service(IRepository<v_客戶明細> v_客戶明細Repository)
        {
            _v_客戶明細Repository = v_客戶明細Repository;
        }

        public IQueryable<v_客戶明細> Reads()
        {
            return _v_客戶明細Repository.Reads();
        }

    }
}