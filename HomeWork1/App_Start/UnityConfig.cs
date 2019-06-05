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
            container.RegisterType<IRepository<v_�Ȥ����>, BaseRepository<v_�Ȥ����>>();
            container.RegisterType<IRepository<v_�Ȥ����>, BaseRepository<v_�Ȥ����>>();
            container.RegisterType<IRepository<�Ȥ���>, BaseRepository<�Ȥ���>>();
            container.RegisterType<IRepository<�Ȥ�Ȧ��T>, BaseRepository<�Ȥ�Ȧ��T>>();
            container.RegisterType<IRepository<�Ȥ��p���H>, BaseRepository<�Ȥ��p���H>>();

            container.RegisterType<Iv_�Ȥ����Service, v_�Ȥ����Service>();
            container.RegisterType<Iv_�Ȥ����Service, v_�Ȥ����Service>();
            container.RegisterType<I�Ȥ���Service, �Ȥ���Service>();
            container.RegisterType<I�Ȥ�Ȧ��TService, �Ȥ�Ȧ��TService>();
            container.RegisterType<I�Ȥ��p���HService, �Ȥ��p���HService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}