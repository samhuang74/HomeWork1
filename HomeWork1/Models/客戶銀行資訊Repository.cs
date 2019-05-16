using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace HomeWork1.Models
{   
	public  class 客戶銀行資訊Repository : EFRepository<客戶銀行資訊>, I客戶銀行資訊Repository
	{
        /// <summary>
        /// 撈出位刪除的資料
        /// </summary>
        /// <returns></returns>
        public IQueryable<客戶銀行資訊> ReadAllNotDelete()
        {
            return All().Where(a => !a.是否已刪除);
        }

        public override void Delete(客戶銀行資訊 entity)
        {
            entity.是否已刪除 = true;
            UnitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// 更新沒有被刪除的資料
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void UpdateNotDelete(客戶銀行資訊 entity)
        {
            if (null != ReadNotDelete(entity.Id))
            {
                UnitOfWork.Context.Entry(entity).State = EntityState.Modified;
            }
        }

        /// <summary>
        /// 撈出未刪除的資料
        /// </summary>
        /// <returns></returns>
        public 客戶銀行資訊 ReadNotDelete(int id)
        {
            return All().Where(a => a.Id == id && !a.是否已刪除).FirstOrDefault();
        }

    }

    public  interface I客戶銀行資訊Repository : IRepository<客戶銀行資訊>
	{
        IQueryable<客戶銀行資訊> ReadAllNotDelete();
        void UpdateNotDelete(客戶銀行資訊 entity);
        客戶銀行資訊 ReadNotDelete(int id);

    }
}