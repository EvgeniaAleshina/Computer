using Computer.Classes;
using Computer.Entity;
using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Computer.Pages.EditPages
{
	/// <summary>
	/// Логика взаимодействия для SaleItemsEditPage.xaml
	/// </summary>
	public partial class SaleItemsEditPage : Page
	{
		private readonly SaleItem _currentSaleItem;
		public SaleItemsEditPage()
		{
			InitializeComponent();
			_currentSaleItem = new SaleItem();
			_currentSaleItem.Date = GetDate(_currentSaleItem.Date);
			DataContext = _currentSaleItem;
			GetComboBox();
		}
		public SaleItemsEditPage(SaleItem selectedSaleItem)
		{
			InitializeComponent();
			_currentSaleItem = selectedSaleItem;
			DataContext = _currentSaleItem;
			GetComboBox();
		}
		private static DateTime GetDate(DateTime date)
		{
			return date == new DateTime(1, 1, 1) ? DateTime.Now : date;
		}
		private void CbItems_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			GetSum();
		}
		private void GetComboBox()
		{
			CbItems.ItemsSource = ComputerEntities.GetContext().Items.ToList();
			CbCustomer.ItemsSource = ComputerEntities.GetContext().Customers.ToList();
			CbSeller.ItemsSource = Data.IsSeller() ? ComputerEntities.GetContext().Sellers.Where(x => x.UserID == Data.UserID).ToList() : ComputerEntities.GetContext().Sellers.ToList();
		}
		private void GetSum()
		{
			if (CbItems.SelectedItem == null || string.IsNullOrWhiteSpace(TbCount.Text)) return;
			var cost = ((Item)CbItems.SelectedItem).Cost;
			var count = int.TryParse(TbCount.Text, out _) ? int.Parse(TbCount.Text) : 0;

			var sum = cost * count;
			var listSum = sum.ToString(CultureInfo.InvariantCulture).ToList().Select(item => item == Data.SeparatorChangeForDecimal ? Data.SeparatorForDecimal : item).ToList();
			TbSum.Text = string.Join("", listSum);
			_currentSaleItem.Sum = decimal.Parse(TbSum.Text);
		}

		private void TbCount_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			GetSum();
		}

		private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
		{
			if (CbItems.SelectedItem == null || CbSeller.SelectedItem == null || CbCustomer.SelectedItem == null ||
			    string.IsNullOrWhiteSpace(TbCount.Text))
			{
				MessageBox.Show("Заполните все поля!");
				return;
			}

			if (!ComputerEntities.GetContext().SaleItems.Any(x =>
				    x.Date == _currentSaleItem.Date && x.IDItem == _currentSaleItem.IDItem &&
				    x.IDCustomer == _currentSaleItem.IDCustomer))
				ComputerEntities.GetContext().SaleItems.Add(_currentSaleItem);
			ComputerEntities.GetContext().SaveChanges();
			MessageBox.Show("Заказ успешно сформирован");
			Manager.GoBack();
		}

		private void SaleItemsEditPage_OnLoaded(object sender, RoutedEventArgs e)
		{
			if (Data.IsSeller()) CbSeller.SelectedIndex = 0;
		}
	}
}
