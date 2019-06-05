using System;
using System.Linq;
using System.Collections.Generic;
using Repositories;
using HomeWork1.Models;

namespace HomeWork1.Services
{
    public interface Iv_客戶分類Service
    {
        IQueryable<v_客戶分類> Reads();
    }

    public class v_客戶分類Service : Iv_客戶分類Service
    {
        IRepository<v_客戶分類> _v_客戶分類Repository;

        public v_客戶分類Service(IRepository<v_客戶分類> v_客戶分類Repository)
        {
            _v_客戶分類Repository = v_客戶分類Repository;
        }

        public IQueryable<v_客戶分類> Reads()
        {
            return _v_客戶分類Repository.Reads();
        }
    }
}