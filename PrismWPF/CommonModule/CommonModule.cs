using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace CommonModule
{
    public class CommonModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            IRegion region = regionManager.Regions["ToolbarRegion"];
            //region.Add(containerProvider.Resolve<UserListView>());
            var toolbar = containerProvider.Resolve<Toolbar>();
            region.Add(toolbar);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
