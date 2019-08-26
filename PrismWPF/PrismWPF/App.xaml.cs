using CommonModule;
using OrderModule;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using PrismWPF.Command;
using PrismWPF.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PrismWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();        
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();

        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule<UserModule.UserModule>();
            moduleCatalog.AddModule<CommonModule.CommonModule>();
            moduleCatalog.AddModule<OrderModule.OrderModule>();

        }
    }
}
