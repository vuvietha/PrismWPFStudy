using DevExpress.Mvvm.Native;
using DevExpress.Xpf.Editors;
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

namespace UserModule.ViewModels
{
    public class UserListViewModel : BindableBase
    {
        private readonly IUserService _userService;
        private readonly IApplicationCommands _applicationCommands;
        public DelegateCommand SaveUsersCommand { get; }
        public DelegateCommand GetUsersCommand  { get; private set; }
        public DelegateCommand DeleteUsersCommand { get; private set; }
        public DelegateCommand<EditValueChangingEventArgs> ListUserEditValueChanging { get; }

        private ObservableCollection<User> _selectedUsers;
        public ObservableCollection<User> SelectedUsers
        {
            get => _selectedUsers;
            set => SetProperty(ref _selectedUsers, value);
        }

        private ObservableCollection<bool> _isDelete;
        public ObservableCollection<bool> IsDelete
        {
            get => _isDelete;
            set => SetProperty(ref _isDelete, value);
        }
        private bool _isDeleteAll;
        public bool IsDeleteAll
        {
            get => _isDeleteAll;
            set => SetProperty(ref _isDeleteAll, value);
        }

        private ObservableCollection<User> _listUser;
        public ObservableCollection<User> ListUser
        {
            get => _listUser;
            set => SetProperty(ref _listUser, value);
        }
        private ObservableCollection<User> _listUpdateUser;
        public ObservableCollection<User> ListUpdateUser
        {
            get => _listUpdateUser;
            set => SetProperty(ref _listUpdateUser, value);
        }
        private ObservableCollection<User> _listAddUser;
        public ObservableCollection<User> ListAddUser
        {
            get => _listAddUser;
            set => SetProperty(ref _listAddUser, value);
        }
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }

        }
        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get { return _users; }
            set { SetProperty(ref _users, value); }
        }
        public UserListViewModel(IUserService userService, IApplicationCommands applicationCommand)
        {
            _userService = userService;
            GetUsersCommand = new DelegateCommand(GetUsers, CanExcuteGetUsers);
            DeleteUsersCommand = new DelegateCommand(DeleteUsers);
            SaveUsersCommand = new DelegateCommand(SaveUser);
            _applicationCommands = applicationCommand;
            _applicationCommands.CompositeCommand.RegisterCommand(GetUsersCommand);
            _applicationCommands.DeleteCommand.RegisterCommand(DeleteUsersCommand);
            SelectedUsers = new ObservableCollection<User>();
            SelectedUsers.CollectionChanged += SelectedUsers_CollectionChanged;
            ListUser = new ObservableCollection<User>();
            ListUpdateUser = new ObservableCollection<User>();
            ListAddUser = new ObservableCollection<User>();
            ListUserEditValueChanging = new DelegateCommand<EditValueChangingEventArgs>(e => { ListUser.Add(e.NewValue as User); });

        }
        private void RefeshListUser()
        {
            ListUser = _userService.GetAllUser().ToObservableCollection();
        }
        private void SelectedUsers_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            DeleteUsersCommand.RaiseCanExecuteChanged();
        }


        private void GetUsers()
        {
            Users = _userService.GetAllUser().ToObservableCollection();
        }
        private bool CanExcuteGetUsers()
        {
            return true;
        }
        private void SaveUsers(List<User> users)
        {
            Users = _userService.GetAllUser().ToObservableCollection();
        }
        private void DeleteUser(User user)
        {
            Users = _userService.DeleteUser(user).ToObservableCollection();
        }
        private bool CanExcuteDeleteUser()
        {
            return SelectedUsers != null && SelectedUsers.Count > 0;
        }
        private void DeleteUsers()
        {
            if (SelectedUsers.Count == 0) return;
            Users = _userService.DeleteUsers(SelectedUsers.ToList()).ToObservableCollection();
        }
        private void SaveUser()
        {
            //var validator = GetInstance("ExamPartTableView");
            //var response = validator.IsValid();

            //if (!response.Status)
            //{
            //    return;
            //}

            foreach (var item in ListUser)
            {

                if (item.IsUpdate == true && item.IsNew != -1)
                {
                    ListUpdateUser.Add(item);
                    item.IsUpdate = false;
                }

                if (item.IsNew == -1)
                {
                    
                    ListAddUser.Add(item);

                    item.IsNew = 1;
                    item.IsUpdate = false;
                }
            }
            if (ListUpdateUser.Count > 0)
            {
                UpdateUser();
            }

            if (ListAddUser.Count > 0)
            {
                CreateUser();
            }
            ListUser = new ObservableCollection<User>();

        }

        private  void UpdateUser()
        {
           Users = _userService.UpdateUsers(ListUpdateUser.ToList()).ToObservableCollection();
           ListUpdateUser = new ObservableCollection<User>();
        }

        private void CreateUser()
        {
            Users = _userService.SaveUsers(ListAddUser.ToList()).ToObservableCollection(); ;
            ListAddUser= new ObservableCollection<User>();
        }
        private void FocusGrid()
        {
            if (ListUser == null) return;
            if (!ListUser.Any(s => s.IsUpdate == true || s.IsNew == -1)) return;        
            SaveUser();
            
        }
    }
}
