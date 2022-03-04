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
	/// Логика взаимодействия для SaleAccessories.xaml
	/// </summary>
	public partial class SaleAccessoriesPage : Page
	{
		public SaleAccessoriesPage()
		{
			InitializeComponent();
		}

		private void BtnEdit_Click(object sender, RoutedEventArgs e)
		{
			Manager.Navigate(new SaleAccessoriesEditPage((sender as Button)?.DataContext as SaleAccessory));
		}

		private void BtnDelete_Click(object sender, RoutedEventArgs e)
		{
			var saleAccessoryForRemoving = DGridSaleAccessories.SelectedItems.Cast<SaleAccessory>().ToList();
			if (MessageBox.Show($"Вы точно хотите удалить следующие {saleAccessoryForRemoving.Count()} элементов?",
						"Внимание",
						MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No) return;
			ComputerEntities.GetContext().SaleAccessories.RemoveRange(saleAccessoryForRemoving);
			ComputerEntities.GetContext().SaveChanges();
			MessageBox.Show("Данные удалены!");
			DGridSaleAccessories.ItemsSource = ComputerEntities.GetContext().SaleAccessories.ToList();
		}

		private void BtnAdd_Click(object sender, RoutedEventArgs e)
		{
			Manager.Navigate(new SaleAccessoriesEditPage());
		}

		private void CbSort_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var list = DGridSaleAccessories.ItemsSource.Cast<SaleAccessory>();
			var enumerable = new List<SaleAccessory>();
			switch (CbSort.SelectedItem.ToString())
			{
				case "Комплектующие":
					enumerable = list.OrderBy(x => x.Accessory.Title).ToList();
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
				case "Количество":
					enumerable = list.OrderBy(x => x.Count).ToList();
					break;
				case "Сумма":
					enumerable = list.OrderBy(x => x.Sum).ToList();
					break;
			}
			DGridSaleAccessories.ItemsSource = enumerable;
		}

		private void CbFilter_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			DGridSaleAccessories.ItemsSource = ComputerEntities.GetContext().SaleAccessories
				.Where(x => x.Accessory.Manufacture.Title == CbFilter.SelectedItem.ToString()).ToList();
		}

		private void TbSearch_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			var searchText = TbSearch.Text.ToLower();
			var saleAccessories = new List<SaleAccessory>();
			ComputerEntities.GetContext().SaleAccessories.ToList().ForEach(x =>
			{
				if (x.Accessory.Title.ToLower().Contains(searchText) ||
				    x.Accessory.Manufacture.Title.ToLower().Contains(searchText) ||
				    x.Customer.Fullname.ToLower().Contains(searchText) ||
				    x.Seller.Fullname.ToLower().Contains(searchText))
					saleAccessories.Add(x);
			});
			DGridSaleAccessories.ItemsSource = saleAccessories;
		}

		private void SaleAccessoriesPage_OnLoaded(object sender, RoutedEventArgs e)
		{
			DGridSaleAccessories.ItemsSource = ComputerEntities.GetContext().SaleAccessories.ToList();
			CbFilter.ItemsSource = ComputerEntities.GetContext().SaleAccessories.GroupBy(x => x.Accessory.Manufacture.Title)
				.Select(x => x.Key).ToList();
			CbSort.ItemsSource = DGridSaleAccessories.Columns.Select(x => x.Header).ToList();
			BtnDelete.Visibility = Data.IsManager() ? Visibility.Visible : Visibility.Collapsed;
		}
	}
}
