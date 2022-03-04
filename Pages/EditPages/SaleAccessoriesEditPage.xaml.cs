using Computer.Classes;
using Computer.Entity;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DateTime = System.DateTime;

namespace Computer.Pages.EditPages
{
	/// <summary>
	/// Логика взаимодействия для SaleAccessoriesEditPage.xaml
	/// </summary>
	public partial class SaleAccessoriesEditPage : Page
	{
		private readonly SaleAccessory _currentSaleAccessory;
		public SaleAccessoriesEditPage()
		{
			InitializeComponent();
			_currentSaleAccessory = new SaleAccessory();
			_currentSaleAccessory.Date = GetDate(_currentSaleAccessory.Date);
			DataContext = _currentSaleAccessory;
			GetComboBox();
		}
		public SaleAccessoriesEditPage(SaleAccessory selectedSaleAccessory)
		{
			InitializeComponent();
			_currentSaleAccessory = selectedSaleAccessory;
			DataContext = _currentSaleAccessory;
			GetComboBox();
		}

		private static DateTime GetDate(DateTime date)
		{
			return date == new DateTime(1, 1, 1) ? DateTime.Now : date;
		}
		private void CbAccessories_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			GetSum();
		}

		private void GetComboBox()
		{
			CbAccessories.ItemsSource = ComputerEntities.GetContext().Accessories.ToList();
			CbCustomer.ItemsSource = ComputerEntities.GetContext().Customers.ToList();
			CbSeller.ItemsSource = Data.IsSeller() ? ComputerEntities.GetContext().Sellers.Where(x => x.UserID == Data.UserID).ToList() : ComputerEntities.GetContext().Sellers.ToList();
		}
		private void GetSum()
		{
			if (CbAccessories.SelectedItem == null || string.IsNullOrWhiteSpace(TbCount.Text)) return;
			var cost = ((Accessory)CbAccessories.SelectedItem).Cost;
			var count = int.TryParse(TbCount.Text, out _) ? int.Parse(TbCount.Text) : 0;

			var sum = cost * count;
			var listSum = sum.ToString(CultureInfo.InvariantCulture).ToList().Select(item => item == Data.SeparatorChangeForDecimal ? Data.SeparatorForDecimal : item).ToList();
			TbSum.Text = string.Join("", listSum);
			_currentSaleAccessory.Sum = decimal.Parse(TbSum.Text);
		}
		private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
		{
			if (CbAccessories.SelectedItem == null || CbSeller.SelectedItem == null || CbCustomer.SelectedItem == null ||
			    string.IsNullOrWhiteSpace(TbCount.Text))
			{
				MessageBox.Show("Заполните все поля!");
					return;
			}
			
			if (!ComputerEntities.GetContext().SaleAccessories.Any(x =>
				    x.Date == _currentSaleAccessory.Date && x.IDAccessories == _currentSaleAccessory.IDAccessories &&
				    x.IDCustomer == _currentSaleAccessory.IDCustomer))
				ComputerEntities.GetContext().SaleAccessories.Add(_currentSaleAccessory);
			ComputerEntities.GetContext().SaveChanges();
			MessageBox.Show("Заказ успешно сформирован");
			Manager.GoBack();
		}

		private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			GetSum();
		}

		private void SaleAccessoriesEditPage_OnLoaded(object sender, RoutedEventArgs e)
		{
			if (Data.IsSeller()) CbSeller.SelectedIndex = 0;
		}
	}
}
