using Computer.Classes;
using Computer.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Computer.Pages
{
	/// <summary>
	/// Логика взаимодействия для Auth.xaml
	/// </summary>
	public partial class Auth : Page
	{
		public Auth()
		{
			InitializeComponent();
		}

		private void BtnEnter_OnClick(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(TbLogin.Text) || string.IsNullOrWhiteSpace(PbPassword.Password))
			{
				MessageBox.Show("Заполните все поля!");
				return;
			}

			if (ComputerEntities.GetContext().Users.Any(x => x.Login == TbLogin.Text))
			{
				var user = ComputerEntities.GetContext().Users.First(x => x.Login == TbLogin.Text);
				if (user.Password == PbPassword.Password)
				{
					Data.Access = user.Access;
					Data.UserID = user.ID;
					Manager.Navigate(new MenuPage());
				}
				else MessageBox.Show("Пароль не верный!");
			}
			else MessageBox.Show("Такого пользователя не существует!");
		}

		private void BtnRegMove_OnClick(object sender, RoutedEventArgs e)
		{
			Manager.Navigate(new Reg());
		}
	}
}
