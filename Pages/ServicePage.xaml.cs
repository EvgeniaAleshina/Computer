using System.Collections.Generic;
using Computer.Classes;
using Computer.Entity;
using Computer.Pages.EditPages;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Computer.Pages
{
	public partial class ServicePage : Page
	{
		public ServicePage()
		{
			InitializeComponent();
		}

		private void BtnEdit_Click(object sender, RoutedEventArgs e)
		{
			Manager.Navigate(new ServiceEditPage((sender as Button)?.DataContext as Service));
		}
		private void BtnDelete_Click(object sender, RoutedEventArgs e)
		{
			var servicesForRemoving = DGridServices.SelectedItems.Cast<Service>().ToList();
			if (MessageBox.Show($"Вы точно хотите удалить следующие {servicesForRemoving.Count()} элементов?", "Внимание",
				    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No) return;
			ComputerEntities.GetContext().Services.RemoveRange(servicesForRemoving);
			ComputerEntities.GetContext().SaveChanges();
			MessageBox.Show("Данные удалены!");
			DGridServices.ItemsSource = ComputerEntities.GetContext().Services.ToList();
		}
		private void BtnAdd_Click(object sender, RoutedEventArgs e)
		{
			Manager.Navigate(new ServiceEditPage());
		}
		private void CbSort_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var list = DGridServices.ItemsSource.Cast<Service>().ToList();
			var enumerable = new List<Service>();
			switch (CbSort.SelectedItem.ToString())
			{
				case "Название":
					enumerable = list.OrderBy(x => x.Title).ToList();
					break;
				case "Стоимость":
					enumerable = list.OrderBy(x => x.Cost).ToList();
					break;
			}
			DGridServices.ItemsSource = enumerable;
		}
		private void TbSearch_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			DGridServices.ItemsSource = ComputerEntities.GetContext().Services
				.Where(x => x.Title.ToLower().Contains(TbSearch.Text.ToLower())).ToList();
		}
		private void ServicePage_OnLoaded(object sender, RoutedEventArgs e)
		{
			DGridServices.ItemsSource = ComputerEntities.GetContext().Services.ToList();
			CbSort.ItemsSource = DGridServices.Columns.Select(x => x.Header).ToList();

			BtnAdd.Visibility = Data.IsManager() ? Visibility.Visible : Visibility.Collapsed;
			BtnDelete.Visibility = Data.IsManager() ? Visibility.Visible : Visibility.Collapsed;
			CellEdit.Visibility = Data.IsManager() ? Visibility.Visible : Visibility.Collapsed;
		}
	}
}
