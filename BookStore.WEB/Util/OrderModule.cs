using BookStore.BLL.Interface;
using BookStore.BLL.Services;
using System.Web.Mvc;
using Ninject.Modules;

namespace BookStore.WEB.Util
{
    public class OrderModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IOrderService>().To<OrderService>();
        }
    }
}