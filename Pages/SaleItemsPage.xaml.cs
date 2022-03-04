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
	/// Логика взаимодействия для SaleItems.xaml
	/// </summary>
	public partial class SaleItems : Page
	{
		public SaleItems()
		{
			InitializeComponent();
		}

		private void BtnEdit_Click(object sender, RoutedEventArgs e)
		{
			Manager.Navigate(new SaleItemsEditPage((sender as Button)?.DataContext as SaleItem));
		}

		private void BtnDelete_Click(object sender, RoutedEventArgs e)
		{
			var saleItemsForRemoving = DGridSaleItems.SelectedItems.Cast<SaleItem>().ToList();
			if (MessageBox.Show($"Вы точно хотите удалить следующие {saleItemsForRemoving.Count()} элементов?", "Внимание",
				    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No) return;
			ComputerEntities.GetContext().SaleItems.RemoveRange(saleItemsForRemoving);
			ComputerEntities.GetContext().SaveChanges();
			MessageBox.Show("Данные удалены!");
			DGridSaleItems.ItemsSource = ComputerEntities.GetContext().SaleItems.ToList();
		}

		private void BtnAdd_Click(object sender, RoutedEventArgs e)
		{
			Manager.Navigate(new SaleItemsEditPage());
		}

		private void CbSort_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var list = DGridSaleItems.ItemsSource.Cast<SaleItem>();
			var enumerable = new List<SaleItem>();
			switch (CbSort.SelectedItem.ToString())
			{
				case "Товар":
					enumerable = list.OrderBy(x => x.Item.Title).ToList();
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
			DGridSaleItems.ItemsSource = enumerable;
		}

		private void CbFilter_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			DGridSaleItems.ItemsSource = ComputerEntities.GetContext().SaleItems
				.Where(x => x.Item.Manufacture.Title == CbFilter.SelectedItem.ToString()).ToList();
		}

		private void TbSearch_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			var searchText = TbSearch.Text.ToLower();
			var saleItems = new List<SaleItem>();
			ComputerEntities.GetContext().SaleItems.ToList().ForEach(x =>
			{
				if (x.Item.Title.ToLower().Contains(searchText) ||
				    x.Item.Manufacture.Title.ToLower().Contains(searchText) ||
				    x.Customer.Fullname.ToLower().Contains(searchText) || x.Seller.Fullname.ToLower().Contains(searchText))
					saleItems.Add(x);
			});
			DGridSaleItems.ItemsSource = saleItems;
		}

		private void SaleItems_OnLoaded(object sender, RoutedEventArgs e)
		{
			DGridSaleItems.ItemsSource = ComputerEntities.GetContext().SaleItems.ToList();
			CbSort.ItemsSource = DGridSaleItems.Columns.Select(x => x.Header).ToList();
			CbFilter.ItemsSource = ComputerEntities.GetContext().SaleItems.GroupBy(x => x.Item.Manufacture).Select(x => x.Key)
				.ToList();

			BtnDelete.Visibility = Data.IsManager() ? Visibility.Visible : Visibility.Collapsed;
		}
	}
}
