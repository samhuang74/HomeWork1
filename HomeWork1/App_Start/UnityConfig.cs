using HomeWork1.Models;
using HomeWork1.Services;
using Repositories;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace HomeWork1
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IRepository<v_客戶分類>, BaseRepository<v_客戶分類>>();
            container.RegisterType<IRepository<v_客戶明細>, BaseRepository<v_客戶明細>>();
            container.RegisterType<IRepository<客戶資料>, BaseRepository<客戶資料>>();
            container.RegisterType<IRepository<客戶銀行資訊>, BaseRepository<客戶銀行資訊>>();
            container.RegisterType<IRepository<客戶聯絡人>, BaseRepository<客戶聯絡人>>();

            container.RegisterType<Iv_客戶分類Service, v_客戶分類Service>();
            container.RegisterType<Iv_客戶明細Service, v_客戶明細Service>();
            container.RegisterType<I客戶資料Service, 客戶資料Service>();
            container.RegisterType<I客戶銀行資訊Service, 客戶銀行資訊Service>();
            container.RegisterType<I客戶聯絡人Service, 客戶聯絡人Service>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}