using Computer.Classes;
using Computer.Entity;
using System.Windows;
using System.Windows.Controls;

namespace Computer.Pages.EditPages
{
	/// <summary>
	/// Логика взаимодействия для ManufactureEditPage.xaml
	/// </summary>
	public partial class ManufactureEditPage : Page
	{
		private readonly Manufacture _currentManufacture;
		public ManufactureEditPage()
		{
			InitializeComponent();
			_currentManufacture = new Manufacture();
			DataContext = _currentManufacture;
		}

		public ManufactureEditPage(Manufacture selectedManufacture)
		{
			InitializeComponent();
			_currentManufacture = selectedManufacture;
			DataContext = _currentManufacture;
		}

		private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(TbTitle.Text))
			{
				MessageBox.Show("Заполните все поля!");
				return;
			}

			if (_currentManufacture.ID == 0) ComputerEntities.GetContext().Manufactures.Add(_currentManufacture);
			ComputerEntities.GetContext().SaveChanges();
			MessageBox.Show("Производитель успешно добавлен");
			Manager.GoBack();
		}
	}
}
