using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace HomeWork1.Models
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{
        /// <summary>
        /// 撈出位刪除的資料
        /// </summary>
        /// <returns></returns>
        public IQueryable<客戶聯絡人> ReadAllNotDelete()
        {
            return All().Where(a => !a.是否已刪除);
        }

        public override void Delete(客戶聯絡人 entity)
        {
            entity.是否已刪除 = true;
            UnitOfWork.Context.Entry(entity).State = EntityState.Modified;
            //UnitOfWork.Commit();
        }

        /// <summary>
        /// 撈出未刪除的資料
        /// </summary>
        /// <returns></returns>
        public 客戶聯絡人 ReadNotDelete(int id)
        {
            return All().Where(a => a.Id == id && !a.是否已刪除).FirstOrDefault();
        }

        /// <summary>
        /// 更新沒有被刪除的資料
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void UpdateNotDelete(客戶聯絡人 entity)
        {
            if (null != ReadNotDelete(entity.Id))
            {
                UnitOfWork.Context.Entry(entity).State = EntityState.Modified;
                //UnitOfWork.Commit();
            }
        }

    }

    public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{
        IQueryable<客戶聯絡人> ReadAllNotDelete();
        void UpdateNotDelete(客戶聯絡人 entity);
        客戶聯絡人 ReadNotDelete(int id);

    }
}