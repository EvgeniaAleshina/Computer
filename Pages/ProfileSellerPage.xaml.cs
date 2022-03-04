using Computer.Classes;
using Computer.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Computer.Pages
{
	/// <summary>
	/// Логика взаимодействия для ProfileSellerPage.xaml
	/// </summary>
	public partial class ProfileSellerPage : Page
	{
		private readonly Seller _currentSeller;
		public ProfileSellerPage()
		{
			InitializeComponent();
			_currentSeller = ComputerEntities.GetContext().Sellers.Any(x => x.UserID == Data.UserID) ? ComputerEntities.GetContext().Sellers.First(x => x.UserID == Data.UserID) : new Seller();

			DataContext = _currentSeller;
		}

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			// Проверка на пустоту
			if (string.IsNullOrWhiteSpace(TbSurname.Text) || string.IsNullOrWhiteSpace(TbFirstname.Text) ||
			    string.IsNullOrWhiteSpace(TbPatronymic.Text))
			{
				MessageBox.Show("Заполните данные: Фамилия, Имя, Отчество!");
				return;
			}

			if (_currentSeller.ID == 0)
			{
				_currentSeller.UserID = Data.UserID;
				ComputerEntities.GetContext().Sellers.Add(_currentSeller);
			}

			ComputerEntities.GetContext().SaveChanges();
			MessageBox.Show("Данные успешно сохранены!");
			Manager.GoBack();
		}
	}
}
