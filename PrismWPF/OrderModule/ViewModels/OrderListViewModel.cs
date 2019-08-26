using DevExpress.Mvvm.Native;
using Prism.Commands;
using Prism.Mvvm;
using PrismWPF.Command;
using PrismWPF.Data.Models;
using PrismWPF.Data.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderModule.ViewModels
{
    public class OrderListViewModel : BindableBase
    {
        private readonly IOrderService _orderService;
        private readonly IApplicationCommands _applicationCommands;

        public DelegateCommand GetOrdersCommand { get; private set; }
        //public DelegateCommand<List<User>> SaveUsersCommand { get; private set; }
        public DelegateCommand<List<Order>> SaveOrdersCommand { get; private set; }
        public DelegateCommand DeleteOrdersCommand { get; private set; }
        private ObservableCollection<Order> _selectedOrders;
        public ObservableCollection<Order> SelectedOrders
        {
            get => _selectedOrders;
            set => SetProperty(ref _selectedOrders, value);
        }



        public OrderListViewModel(IOrderService orderService, IApplicationCommands applicationCommand)
        {
            _orderService = orderService;
            GetOrdersCommand = new DelegateCommand(GetOrders, CanExcuteGetOrders);
            DeleteOrdersCommand = new DelegateCommand(DeleteOrders);
            _applicationCommands = applicationCommand;
            _applicationCommands.CompositeCommand.RegisterCommand(GetOrdersCommand);
            _applicationCommands.DeleteCommand.RegisterCommand(DeleteOrdersCommand);
            SelectedOrders = new ObservableCollection<Order>();
            SelectedOrders.CollectionChanged += SelectedOrders_CollectionChanged;

        }

        private void SelectedOrders_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            DeleteOrdersCommand.RaiseCanExecuteChanged();
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }

        }
        private ObservableCollection<Order> _orders;
        public ObservableCollection<Order> Orders
        {
            get { return _orders; }
            set { SetProperty(ref _orders, value); }
        }
        private void GetOrders()
        {
            Orders = _orderService.GetAllOrder().ToObservableCollection();
        }
        private bool CanExcuteGetOrders()
        {
            return true;
        }
        private void SaveOrders(List<User> users)
        {
        }
        private void DeleteUser(Order order)
        {
            Orders = _orderService.DeleteOrder(order).ToObservableCollection();
        }
        private bool CanExcuteDeleteOrder()
        {
            return SelectedOrders != null && SelectedOrders.Count > 0;
        }
        private void DeleteOrders()
        {
            if (SelectedOrders.Count == 0) return;
            Orders = _orderService.DeleteOrders(SelectedOrders.ToList()).ToObservableCollection();
        }
    }
}
