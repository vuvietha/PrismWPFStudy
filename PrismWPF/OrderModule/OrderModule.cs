using OrderModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismWPF.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderModule
{
    public class OrderModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            IRegion region = regionManager.Regions["OrderListRegion"];
            //region.Add(containerProvider.Resolve<UserListView>());
            var order = containerProvider.Resolve<OrderListView>();            
            region.Add(order);        
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IOrderService, OrderService>();

        }
    }
}
