using Computer.Classes;
using Computer.Entity;
using Computer.Pages.EditPages;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Computer.Pages
{
	/// <summary>
	/// Логика взаимодействия для ItemsPage.xaml
	/// </summary>
	public partial class ItemsPage : Page
	{
		public ItemsPage() => InitializeComponent();

		private void BtnEdit_Click(object sender, RoutedEventArgs e)
		{
			Manager.Navigate(new ItemEditPage((sender as Button)?.DataContext as Item));
		}

		private void BtnDelete_Click(object sender, RoutedEventArgs e)
		{
			var itemsForRemoving = DGridItems.SelectedItems.Cast<Item>().ToList();
			if (MessageBox.Show($"Вы точно хотите удалить следующие {itemsForRemoving.Count()} элементов?", "Внимание",
						MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No) return;
			ComputerEntities.GetContext().Items.RemoveRange(itemsForRemoving);
			ComputerEntities.GetContext().SaveChanges();
			MessageBox.Show("Данные удалены!");
			DGridItems.ItemsSource = ComputerEntities.GetContext().Items.ToList();
		}

		private void BtnAdd_Click(object sender, RoutedEventArgs e)
		{
			Manager.Navigate(new ItemEditPage());
		}

		private void CbSort_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var list = DGridItems.ItemsSource.Cast<Item>().ToList();
			var enumerable = new List<Item>();
			switch (CbSort.SelectedItem.ToString())
			{
				case "Название":
					enumerable = list.OrderBy(x => x.Title).ToList();
					break;
				case "Производитель":
					enumerable = list.OrderBy(x => x.Manufacture.Title).ToList();
					break;
				case "Цена":
					enumerable = list.OrderBy(x => x.Cost).ToList();
					break;
				case "Количество на складе":
					enumerable = list.OrderBy(x => x.CountOnStorage).ToList();
					break;
			}
			DGridItems.ItemsSource = enumerable;
		}

		private void CbFilter_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			DGridItems.ItemsSource = ComputerEntities.GetContext().Items
				.Where(x => x.Manufacture.Title == CbFilter.SelectedItem.ToString()).ToList();
		}

		private void TbSearch_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			DGridItems.ItemsSource = ComputerEntities.GetContext().Items
				.Where(x => x.Title.ToLower().Contains(TbSearch.Text.ToLower()) || x.Manufacture.Title.ToLower().Contains(TbSearch.Text.ToLower())).ToList();
		}

		private void ItemsPage_OnLoaded(object sender, RoutedEventArgs e)
		{
			DGridItems.ItemsSource = ComputerEntities.GetContext().Items.ToList();
			CbFilter.ItemsSource =
				ComputerEntities.GetContext().Items.GroupBy(x => x.Manufacture.Title).Select(x => x.Key).ToList();
			CbSort.ItemsSource = DGridItems.Columns.Select(x => x.Header).ToList();

			ColumnEdit.Visibility = Data.IsManager() ? Visibility.Visible : Visibility.Collapsed;
			BtnDelete.Visibility = Data.IsManager() ? Visibility.Visible : Visibility.Collapsed;
			BtnAdd.Visibility = Data.IsManager() ? Visibility.Visible : Visibility.Collapsed;
		}

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			DGridItems.ItemsSource = ComputerEntities.GetContext().Items.ToList();
		}
	}
}
