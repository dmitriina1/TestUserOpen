using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Record_Book_MVVM.Commands;
using Record_Book_MVVM.Models;
using Record_Book_MVVM.Views;

namespace Record_Book_MVVM.ViewModel
{
	public class MainViewModel
	{
		public ObservableCollection<User> Users { get; set; }


		public ICommand ShowWindowCommand { get; set; }



		public MainViewModel()
		{
			Users = UserManager.GetUsers();

			ShowWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);

		}

		private bool CanShowWindow(object obj)
		{
			return true;
		}

		private void ShowWindow(object obj)
		{
			var mainWindow = obj as Window;

			AddUser addUserWin = new AddUser();
			addUserWin.Owner = mainWindow;
			addUserWin.WindowStartupLocation = WindowStartupLocation.CenterOwner;
			addUserWin.ShowDialog();


		}
        private User _selectedUser;
        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void RemoveSelectedUser(User user)
        {
            if (MessageBox.Show($"Вы уверены, что хотите удалить пользователя {user.Name}?", "Удаление пользователя", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                // Удаление пользователя из коллекции и обновление представления
                Users.Remove(user);
            }
        }
    }
}
