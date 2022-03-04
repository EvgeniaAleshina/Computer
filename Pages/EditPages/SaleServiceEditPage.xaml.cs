using Computer.Classes;
using Computer.Entity;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Computer.Pages.EditPages
{
	/// <summary>
	/// Логика взаимодействия для SaleServiceEditPage.xaml
	/// </summary>
	public partial class SaleServiceEditPage : Page
	{
		private readonly SaleService _currentSaleService;
		public SaleServiceEditPage()
		{
			InitializeComponent();
			_currentSaleService = new SaleService();
			_currentSaleService.Date = GetDate(_currentSaleService.Date);
			DataContext = _currentSaleService;
		}
		public SaleServiceEditPage(SaleService selectedSaleService)
		{
			InitializeComponent();
			_currentSaleService = selectedSaleService;
			DataContext = _currentSaleService;
		}
		private void GetComboBox()
		{
			CbServices.ItemsSource = ComputerEntities.GetContext().Services.ToList();
			CbCustomer.ItemsSource = ComputerEntities.GetContext().Customers.ToList();
			CbSeller.ItemsSource = Data.IsSeller() ? ComputerEntities.GetContext().Sellers.Where(x => x.UserID == Data.UserID).ToList() : ComputerEntities.GetContext().Sellers.ToList();
		}
		private static DateTime GetDate(DateTime date)
		{
			return date == new DateTime(1, 1, 1) ? DateTime.Now : date;
		}
		private void GetSum()
		{
			if (CbServices.SelectedItem == null) return;
			var cost = ((Item)CbServices.SelectedItem).Cost;
			TbSum.Text = cost.ToString();
			_currentSaleService.Sum = cost;
		}
		private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
		{
			if (CbServices.SelectedItem == null || CbSeller.SelectedItem == null || CbCustomer.SelectedItem == null)
			{
				MessageBox.Show("Заполните все поля!");
				return;
			}
			if (!ComputerEntities.GetContext().SaleServices.Any(x =>
				    x.Date == _currentSaleService.Date && x.IDService == _currentSaleService.IDService &&
				    x.IDCustomer == _currentSaleService.IDCustomer))
				ComputerEntities.GetContext().SaleServices.Add(_currentSaleService);
			ComputerEntities.GetContext().SaveChanges();
			MessageBox.Show("Заказ успешно сформирован");
			Manager.GoBack();
		}

		private void CbServices_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			GetSum();
		}

		private void UseServiceEditPage_OnLoaded(object sender, RoutedEventArgs e)
		{
			GetComboBox();
			if (Data.IsSeller()) CbSeller.SelectedIndex = 0;
		}
	}
}
