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
	/// Логика взаимодействия для CustomerPage.xaml
	/// </summary>
	public partial class CustomerPage : Page
	{
		public CustomerPage()
		{
			InitializeComponent();
		}

		private void BtnEdit_Click(object sender, RoutedEventArgs e)
		{
			Manager.Navigate(new CustomerEditPage((sender as Button)?.DataContext as Customer));
		}

		private void BtnDelete_Click(object sender, RoutedEventArgs e)
		{
			var customersForRemoving = DGridCustomers.SelectedItems.Cast<Customer>().ToList();
			if (MessageBox.Show($"Вы точно хотите удалить следующие {customersForRemoving.Count()} элементов?", "Внимание",
						MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No) return;
			ComputerEntities.GetContext().Customers.RemoveRange(customersForRemoving);
			ComputerEntities.GetContext().SaveChanges();
			MessageBox.Show("Данные удалены!");
			DGridCustomers.ItemsSource = ComputerEntities.GetContext().Customers.ToList();
		}

		private void BtnAdd_Click(object sender, RoutedEventArgs e)
		{
			Manager.Navigate(new CustomerEditPage());
		}

		private void CbSort_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var list = DGridCustomers.ItemsSource.Cast<Customer>();
			var enumerable = new List<Customer>();
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
			DGridCustomers.ItemsSource = enumerable;
		}
		private void TbSearch_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			var searchText = TbSearch.Text.ToLower();
			var customers = new List<Customer>();
			ComputerEntities.GetContext().Customers.ToList().ForEach(x =>
			{
				if (x.Fullname.ToLower().Contains(searchText) ||
				    (!string.IsNullOrWhiteSpace(x.Phone) && x.Phone.Contains(searchText)) ||
				    (!string.IsNullOrWhiteSpace(x.Email) && x.Email.ToLower().Contains(searchText)))
					customers.Add(x);
			});
			DGridCustomers.ItemsSource = customers;
		}

		private void CustomerPage_OnLoaded(object sender, RoutedEventArgs e)
		{
			DGridCustomers.ItemsSource = ComputerEntities.GetContext().Customers.ToList();
			CbSort.ItemsSource = DGridCustomers.Columns.Select(x => x.Header).ToList();
			BtnDelete.Visibility = Data.IsManager() ? Visibility.Visible : Visibility.Collapsed;
		}
	}
}