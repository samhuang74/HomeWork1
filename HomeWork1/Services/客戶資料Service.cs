using System;
using System.Linq;
using System.Collections.Generic;
using Repositories;
using Utils;
using HomeWork1.Models;

namespace HomeWork1.Services
{
    public interface I客戶資料Service
    {
        void Create(客戶資料 entity);

        void Update(int id, 客戶資料 entity);

        void Delete(int id);

        客戶資料 Read(int id);

        IQueryable<客戶資料> Reads();
    }

    public class 客戶資料Service : I客戶資料Service
    {
        IRepository<客戶資料> _客戶資料Repository;

        public 客戶資料Service(IRepository<客戶資料> 客戶資料Repository)
        {
            _客戶資料Repository = 客戶資料Repository;
        }

        public void Create(客戶資料 entity)
        {
            _客戶資料Repository.Create(entity);
            _客戶資料Repository.SaveChanges();
        }

        public void Update(int id, 客戶資料 entity)
        {
            客戶資料 dbEntity = Read(id);
            if( null != dbEntity )
            {
                ObjectUtils.CloneObject(entity, dbEntity);
                _客戶資料Repository.Update(dbEntity);
                _客戶資料Repository.SaveChanges();
            }
            else
            {
                //TODO:丟出錯誤訊息
            }
        }

        public void Delete(int id)
        {
            客戶資料 dbEntity = Read(id);
            if (null != dbEntity)
            {
                _客戶資料Repository.Delete(dbEntity);
                _客戶資料Repository.SaveChanges();
            }
            else
            {
                //TODO:丟出錯誤訊息
            }
        }

        public 客戶資料 Read(int id)
        {
            return _客戶資料Repository.Read(a => a.Id == id);
        }


        public IQueryable<客戶資料> Reads()
        {
            return _客戶資料Repository.Reads();
        }

        ///// <summary>
        ///// 撈出未刪除的資料
        ///// </summary>
        ///// <returns></returns>
        //public 客戶資料 ReadNotDelete(int id)
        //{
        //    return _客戶資料Repository.Read(a => a.Id == id && !a.是否已刪除);
        //}

        ///// <summary>
        ///// 更新沒有被刪除的資料
        ///// 
        ///// </summary>
        ///// <param name="entity"></param>
        //public void UpdateNotDelete(客戶資料 entity)
        //{
        //    if (null != ReadNotDelete(entity.Id))
        //    {
        //        _客戶資料Repository.Update(entity);
        //        _客戶資料Repository.SaveChanges();
        //    }
        //}

        ///// <summary>
        ///// 撈出未刪除的資料
        ///// </summary>
        ///// <returns></returns>
        //public IQueryable<客戶資料> ReadAllNotDelete()
        //{
        //    return _客戶資料Repository.Reads(a => !a.是否已刪除);
        //}

        //public void UpdateToDelete(int id)
        //{
        //    客戶資料 entity = ReadNotDelete(id);
        //    if (null != entity)
        //    {
        //        entity.是否已刪除 = true;
        //        _客戶資料Repository.Update(entity);
        //        _客戶資料Repository.SaveChanges();
        //    }
        //}
    }
}


