using System;
using System.Linq;
using System.Collections.Generic;
using Repositories;
using HomeWork1.Models;
using Utils;

namespace HomeWork1.Services
{
    public interface I客戶聯絡人Service
    {
        IQueryable<客戶聯絡人> Reads();

        客戶聯絡人 Read(int id);

        void Update(int id, 客戶聯絡人 entity);

        void Delete(int id);

        客戶聯絡人 IsEmail重複(int 客戶Id, int? 客戶聯絡人Id, String 客戶聯絡人Email);
    }

    public class 客戶聯絡人Service : I客戶聯絡人Service
    {
        IRepository<客戶聯絡人> _客戶聯絡人Repository;

        public 客戶聯絡人Service(IRepository<客戶聯絡人> 客戶聯絡人Repository)
        {
            _客戶聯絡人Repository = 客戶聯絡人Repository;
        }

        public IQueryable<客戶聯絡人> Reads()
        {
            return _客戶聯絡人Repository.Reads();
        }

        public void Update(int id, 客戶聯絡人 entity)
        {
            客戶聯絡人 dbEntity = Read(id);
            if (null != dbEntity)
            {
                ObjectUtils.CloneObject(entity, dbEntity);
                _客戶聯絡人Repository.Update(dbEntity);
                _客戶聯絡人Repository.SaveChanges();
            }
            else
            {
                //TODO:丟出錯誤訊息
            }
        }

        public 客戶聯絡人 Read(int id)
        {
            return _客戶聯絡人Repository.Read(a => a.Id == id);
        }

        public void Delete(int id)
        {
            客戶聯絡人 dbEntity = Read(id);
            if (null != dbEntity)
            {
                _客戶聯絡人Repository.Delete(dbEntity);
                _客戶聯絡人Repository.SaveChanges();
            }
            else
            {
                //TODO:丟出錯誤訊息
            }
        }

        public 客戶聯絡人 IsEmail重複(int 客戶Id, int? 客戶聯絡人Id, String 客戶聯絡人Email)
        {
            客戶聯絡人 re = null;

            if (!String.IsNullOrEmpty(客戶聯絡人Email))
            {
                var 客戶聯絡人 = _客戶聯絡人Repository.Reads().Where(a => a.客戶Id == 客戶Id && a.Email.Equals(客戶聯絡人Email));

                if (null != 客戶聯絡人)
                {
                    re = 客戶聯絡人.Where(a => a.Id != 客戶聯絡人Id).FirstOrDefault();
                }
            }

            return re;
        }

    }
}


