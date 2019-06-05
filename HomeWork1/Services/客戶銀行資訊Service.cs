using System;
using System.Linq;
using System.Collections.Generic;
using Repositories;
using HomeWork1.Models;

namespace HomeWork1.Services
{
    public interface I客戶銀行資訊Service
    {
        void Create(客戶銀行資訊 entity);

        IQueryable<客戶銀行資訊> Reads();
        客戶銀行資訊 Read(int id);
        void Update(客戶銀行資訊 entity);
        void Delete(int id);
    }

    public class 客戶銀行資訊Service : I客戶銀行資訊Service
    {
        IRepository<客戶銀行資訊> _客戶銀行資訊Repository;

        public 客戶銀行資訊Service(IRepository<客戶銀行資訊> 客戶銀行資訊Repository)
        {
            _客戶銀行資訊Repository = 客戶銀行資訊Repository;
        }

        public void Create(客戶銀行資訊 entity)
        {
            _客戶銀行資訊Repository.Create(entity);
            _客戶銀行資訊Repository.SaveChanges();
        }

        /// <summary>
        /// 撈出位刪除的資料
        /// </summary>
        /// <returns></returns>
        public IQueryable<客戶銀行資訊> Reads()
        {
            return _客戶銀行資訊Repository.Reads();
        }

        public void Delete(int id)
        {
            客戶銀行資訊 entity = Read(id);
            if (null != entity)
            {
                entity.是否已刪除 = true;
                _客戶銀行資訊Repository.Delete(entity);
                _客戶銀行資訊Repository.SaveChanges();
            }
        }

        /// <summary>
        /// 更新沒有被刪除的資料
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Update(客戶銀行資訊 entity)
        {
            if (null != Read(entity.Id))
            {
                _客戶銀行資訊Repository.Update(entity);
                _客戶銀行資訊Repository.SaveChanges();
            }
        }

        /// <summary>
        /// 撈出未刪除的資料
        /// </summary>
        /// <returns></returns>
        public 客戶銀行資訊 Read(int id)
        {
            return _客戶銀行資訊Repository.Reads(a => a.Id == id).FirstOrDefault();
        }
    }
}