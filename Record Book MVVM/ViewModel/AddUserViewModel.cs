using Record_Book_MVVM.Commands;
using Record_Book_MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Record_Book_MVVM.ViewModel
{
	public class AddUserViewModel
	{

		public ICommand AddUserCommand { get; set; }

		public string? Name { get; set; }
		public string? Email { get; set; }

		public AddUserViewModel()
		{
			AddUserCommand = new RelayCommand(AddUser, CanAddUser);


		}

		private bool CanAddUser(object obj)
		{
			return true;
		}

		private void AddUser(object obj)
		{
            User existingUser = UserManager.GetUserByName(Name);

            if (existingUser == null)
            {
                // Если пользователя с таким именем нет, добавляем нового пользователя
                UserManager.AddUser(new User() { Name = Name, Email = Email });
            }
            else
            {
                // Если пользователь существует, обновляем его данные
                existingUser.Name = Name;
                existingUser.Email = Email;

                // Можно также вывести сообщение об успешном обновлении
                MessageBox.Show("Данные пользователя обновлены.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
		public void SetUser(User user)
    {
        Name = user?.Name;
        Email = user?.Email;
    }
	}
}
