﻿
using Record_Book_MVVM.Models;
using Record_Book_MVVM.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Record_Book_MVVM.Views
{
	public partial class Main : Window
	{
		public Main()
		{
			InitializeComponent();
			MainViewModel mainViewModel = new MainViewModel();
			this.DataContext = mainViewModel;
		}

		private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

			UserList.Items.Filter = FilterMethod;


		}

		private bool FilterMethod(object obj)
		{
			var user = (User)obj;

			return user.Name.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase);


		}
        private void UserListViewItem_DoubleClick(object sender, RoutedEventArgs e)
        {
            if (UserList.SelectedItem is User selectedUser)
            {
                MainViewModel mainViewModel = DataContext as MainViewModel;
                mainViewModel.SelectedUser = selectedUser;

                AddUserViewModel addUserViewModel = new AddUserViewModel();
                addUserViewModel.SetUser(mainViewModel.SelectedUser);

                AddUser addUserWin = new AddUser();
                addUserWin.Owner = this;
                addUserWin.DataContext = addUserViewModel;
                addUserWin.WindowStartupLocation = WindowStartupLocation.CenterOwner;
				addUserWin.ShowDialog();
            }
        }
    }
}
