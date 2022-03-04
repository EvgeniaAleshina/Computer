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
	/// Логика взаимодействия для AccessoriesPage.xaml
	/// </summary>
	public partial class AccessoriesPage : Page
	{
		public AccessoriesPage()
		{
			InitializeComponent();
		}

		private void BtnEdit_Click(object sender, RoutedEventArgs e)
		{
			Manager.Navigate(new AccessoriesEditPage((sender as Button)?.DataContext as Accessory));
		}

		private void BtnDelete_Click(object sender, RoutedEventArgs e)
		{
			var accessoryForRemoving = DGridAccessories.SelectedItems.Cast<Accessory>().ToList();
			if (MessageBox.Show($"Вы точно хотите удалить следующие {accessoryForRemoving.Count()} элементов?", "Внимание",
				    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No) return;
			ComputerEntities.GetContext().Accessories.RemoveRange(accessoryForRemoving);
			ComputerEntities.GetContext().SaveChanges();
			MessageBox.Show("Данные удалены!");
			DGridAccessories.ItemsSource = ComputerEntities.GetContext().Accessories.ToList();
		}

		private void BtnAdd_Click(object sender, RoutedEventArgs e)
		{
			Manager.Navigate(new AccessoriesEditPage());
		}

		private void TbSearch_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			var searchText = TbSearch.Text.ToLower();
			var Accessories = new List<Accessory>();
			ComputerEntities.GetContext().Accessories.ToList().ForEach(x =>
			{
				if (x.Title.ToLower().Contains(searchText) ||
						x.Manufacture.Title.ToLower().Contains(searchText) ||
						x.Cost.ToString().Contains(searchText))
					Accessories.Add(x);
			});
			DGridAccessories.ItemsSource = Accessories;
		}

		private void CbFilter_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			DGridAccessories.ItemsSource = ComputerEntities.GetContext().Accessories
				.Where(x => x.Manufacture.Title == CbFilter.SelectedItem.ToString()).ToList();
		}

		private void CbSort_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var list = DGridAccessories.ItemsSource.Cast<Accessory>().ToList();
			var enumerable = new List<Accessory>();
			switch (CbSort.SelectedItem.ToString())
			{
				case "Название":
					enumerable = list.OrderBy(x => x.Title).ToList();
					break;
				case "Производитель":
					enumerable = list.OrderBy(x => x.Manufacture.Title).ToList();
					break;
				case "Стоимость":
					enumerable = list.OrderBy(x => x.Cost).ToList();
					break;
			}

			DGridAccessories.ItemsSource = enumerable;
		}

		private void AccessoriesPage_OnLoaded(object sender, RoutedEventArgs e)
		{
			DGridAccessories.ItemsSource = ComputerEntities.GetContext().Accessories.ToList();
			CbSort.ItemsSource = new List<string> { "Название", "Производитель", "Стоимость" };
			CbFilter.ItemsSource = ComputerEntities.GetContext().Accessories.GroupBy(x => x.Manufacture.Title).Select(x => x.Key)
				.ToList();

			BtnAdd.Visibility = Data.IsManager() ? Visibility.Visible : Visibility.Collapsed;
			BtnDelete.Visibility = Data.IsManager() ? Visibility.Visible : Visibility.Collapsed;
			ColumnEdit.Visibility = Data.IsManager() ? Visibility.Visible : Visibility.Collapsed;
		}
	}
}
