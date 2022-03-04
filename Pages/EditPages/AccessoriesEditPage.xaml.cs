using Computer.Classes;
using Computer.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Computer.Pages.EditPages
{
	/// <summary>
	/// Логика взаимодействия для AccessoriesEditPage.xaml
	/// </summary>
	public partial class AccessoriesEditPage : Page
	{
		private readonly Accessory _currentAccessory;
		public AccessoriesEditPage()
		{
			InitializeComponent();
			_currentAccessory = new Accessory();
			DataContext = _currentAccessory;
			GetComboBox();
		}
		public AccessoriesEditPage(Accessory accessory)
		{
			InitializeComponent();
			_currentAccessory = accessory;
			DataContext = _currentAccessory;
			GetComboBox();
		}

		private void GetComboBox()
		{
			CbManufacture.ItemsSource = ComputerEntities.GetContext().Manufactures.ToList();
		}
		private void BtnAdd_Click(object sender, RoutedEventArgs e)
		{
			_currentAccessory.Title = TbTitle.Text;
			_currentAccessory.Cost = decimal.Parse(TbCost.Text);
			_currentAccessory.IDManufacture = ((Manufacture) CbManufacture.SelectedItem).ID;
			if (_currentAccessory.ID == 0) ComputerEntities.GetContext().Accessories.Add(_currentAccessory);
			ComputerEntities.GetContext().SaveChanges();
			MessageBox.Show("Комплектующие успешно добавлены!");
			Manager.GoBack();
		}
	}
}
