using Computer.Classes;
using Computer.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Computer.Pages
{
	/// <summary>
	/// Логика взаимодействия для Reg.xaml
	/// </summary>
	public partial class Reg : Page
	{
		public Reg()
		{
			InitializeComponent();
		}

		private void BtnReg_OnClick(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(TbLogin.Text) || string.IsNullOrWhiteSpace(PbPassword.Password))
			{
				MessageBox.Show("Заполните все поля!");
				return;
			}
			if (ComputerEntities.GetContext().Users.Any(x => x.Login == TbLogin.Text))
				MessageBox.Show("Такой пользователь уже существует!");
			else
			{
				ComputerEntities.GetContext().Users.Add(new User()
				{
					Login = TbLogin.Text,
					Password = PbPassword.Password,
				});
				ComputerEntities.GetContext().SaveChanges();
				MessageBox.Show("Вы успешно зарегистрировались!");
				Manager.GoBack();
			}
		}
	}
}
