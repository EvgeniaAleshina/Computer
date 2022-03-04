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
	/// Логика взаимодействия для SellerPage.xaml
	/// </summary>
	public partial class SellerPage : Page
	{
		public SellerPage()
		{
			InitializeComponent();
		}

		private void BtnEdit_Click(object sender, RoutedEventArgs e)
		{
			Manager.Navigate(new SellerEditPage((sender as Button)?.DataContext as Seller));
		}

		private void BtnDelete_Click(object sender, RoutedEventArgs e)
		{
			var sellersForRemoving = DGridSellers.SelectedItems.Cast<Seller>().ToList();
			if (MessageBox.Show($"Вы точно хотите удалить следующие {sellersForRemoving.Count()} элементов?", "Внимание",
						MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No) return;
			ComputerEntities.GetContext().Sellers.RemoveRange(sellersForRemoving);
			ComputerEntities.GetContext().SaveChanges();
			MessageBox.Show("Данные удалены!");
			DGridSellers.ItemsSource = ComputerEntities.GetContext().Sellers.ToList();
		}

		private void BtnAdd_Click(object sender, RoutedEventArgs e)
		{
			Manager.Navigate(new SellerEditPage());
		}

		private void CbSort_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var list = DGridSellers.ItemsSource.Cast<Seller>();
			var enumerable = new List<Seller>();
			switch (CbSort.SelectedItem.ToString())
			{
				case "ФИО":
					enumerable = list.OrderBy(x => x.Fullname).ToList();
					break;
				case "Телефон":
					enumerable = list.OrderBy(x => x.Phone).ToList();
					break;
				case "Почта":
					enumerable = list.OrderBy(x => x.Email).ToList();
					break;
			}
			DGridSellers.ItemsSource = enumerable;
		}

		private void TbSearch_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			var searchText = TbSearch.Text.ToLower();
			var sellers = new List<Seller>();
			ComputerEntities.GetContext().Sellers.ToList().ForEach(x =>
			{
				if (x.Fullname.ToLower().Contains(searchText) || (!string.IsNullOrWhiteSpace(x.Phone) && x.Phone.Contains(searchText)) || (!string.IsNullOrWhiteSpace(x.Email) && x.Email.ToLower().Contains(searchText)))
					sellers.Add(x);
			});
			DGridSellers.ItemsSource = sellers;
		}

		private void SellerPage_OnLoaded(object sender, RoutedEventArgs e)
		{
			DGridSellers.ItemsSource = ComputerEntities.GetContext().Sellers.ToList();
			CbSort.ItemsSource = DGridSellers.Columns.Select(x => x.Header).ToList();
		}
	}
}
