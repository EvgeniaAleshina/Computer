using System.Collections.Generic;
using Computer.Classes;
using Computer.Entity;
using Computer.Pages.EditPages;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Computer.Pages
{
	/// <summary>
	/// Логика взаимодействия для SaleServicePage.xaml
	/// </summary>
	public partial class SaleServicePage : Page
	{
		public SaleServicePage()
		{
			InitializeComponent();
		}

		private void BtnEdit_Click(object sender, RoutedEventArgs e)
		{
			Manager.Navigate(new SaleServiceEditPage((sender as Button)?.DataContext as SaleService));
		}

		private void BtnDelete_Click(object sender, RoutedEventArgs e)
		{
			var saleServicesForRemoving = DGridSaleServices.SelectedItems.Cast<SaleService>().ToList();
			if (MessageBox.Show($"Вы точно хотите удалить следующие {saleServicesForRemoving.Count()} элементов?", "Внимание",
				    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No) return;
			ComputerEntities.GetContext().SaleServices.RemoveRange(saleServicesForRemoving);
			ComputerEntities.GetContext().SaveChanges();
			MessageBox.Show("Данные удалены!");
			DGridSaleServices.ItemsSource = ComputerEntities.GetContext().SaleServices.ToList();
		}

		private void BtnAdd_Click(object sender, RoutedEventArgs e)
		{
			Manager.Navigate(new SaleServiceEditPage());
		}

		private void CbSort_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var list = DGridSaleServices.ItemsSource.Cast<SaleService>();
			var enumerable = new List<SaleService>();
			switch (CbSort.SelectedItem.ToString())
			{
				case "Комплектующие":
					enumerable = list.OrderBy(x => x.Service.Title).ToList();
					break;
				case "Продавец":
					enumerable = list.OrderBy(x => x.Seller.Fullname).ToList();
					break;
				case "Покупатель":
					enumerable = list.OrderBy(x => x.Customer.Fullname).ToList();
					break;
				case "Дата покупки":
					enumerable = list.OrderBy(x => x.Date).ToList();
					break;
				case "Сумма":
					enumerable = list.OrderBy(x => x.Sum).ToList();
					break;
			}
			DGridSaleServices.ItemsSource = enumerable;
		}

		private void TbSearch_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			var searchText = TbSearch.Text.ToLower();
			var saleServices = new List<SaleService>();
			ComputerEntities.GetContext().SaleServices.ToList().ForEach(x =>
			{
				if (x.Service.Title.ToLower().Contains(searchText) ||
				    x.Customer.Fullname.ToLower().Contains(searchText) ||
				    x.Seller.Fullname.ToLower().Contains(searchText))
					saleServices.Add(x);
			});
			DGridSaleServices.ItemsSource = saleServices;
		}

		private void UseService_OnLoaded(object sender, RoutedEventArgs e)
		{
			DGridSaleServices.ItemsSource = ComputerEntities.GetContext().SaleServices.ToList();
			CbSort.ItemsSource = DGridSaleServices.Columns.Select(x => x.Header).ToList();

			BtnDelete.Visibility = Data.IsManager() ? Visibility.Visible : Visibility.Collapsed;
		}
	}
}
