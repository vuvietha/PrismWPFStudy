using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismWPF.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserModule.ViewModels;
using UserModule.Views;

namespace UserModule
{
    public class UserModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            IRegion region = regionManager.Regions["UserListRegion"];
            //region.Add(containerProvider.Resolve<UserListView>());
            var tabA = containerProvider.Resolve<UserListView>();
            SetTitle(tabA, "TabA");
            region.Add(tabA);

            var tabB = containerProvider.Resolve<UserListView>();
            SetTitle(tabB, "TabB");
            region.Add(tabB);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IUserService, UserService>();
        }
        private void SetTitle(UserListView tab, string title)
        {
            (tab.DataContext as UserListViewModel).Title = title;
        }
    }
}
