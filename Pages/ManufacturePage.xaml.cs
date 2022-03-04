using Computer.Classes;
using Computer.Entity;
using Computer.Pages.EditPages;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Computer.Pages
{
	/// <summary>
	/// Логика взаимодействия для ManufacturePage.xaml
	/// </summary>
	public partial class ManufacturePage : Page
	{
		public ManufacturePage()
		{
			InitializeComponent();
		}

		private void BtnEdit_Click(object sender, RoutedEventArgs e)
		{
			Manager.Navigate(new ManufactureEditPage((sender as Button)?.DataContext as Manufacture));
		}

		private void BtnDelete_Click(object sender, RoutedEventArgs e)
		{
			var manufactureForRemoving = DGridManufacture.SelectedItems.Cast<Manufacture>().ToList();
			if (MessageBox.Show($"Вы точно хотите удалить следующие {manufactureForRemoving.Count()} элементов?", "Внимание",
				    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No) return;
			ComputerEntities.GetContext().Manufactures.RemoveRange(manufactureForRemoving);
			ComputerEntities.GetContext().SaveChanges();
			MessageBox.Show("Данные удалены!");
			DGridManufacture.ItemsSource = ComputerEntities.GetContext().Manufactures.ToList();
		}

		private void BtnAdd_Click(object sender, RoutedEventArgs e)
		{
			Manager.Navigate(new ManufactureEditPage());
		}

		private void TbSearch_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			DGridManufacture.ItemsSource =
				ComputerEntities.GetContext().Manufactures.Where(str => str.Title.ToLower().Contains(TbSearch.Text.ToLower())).ToList();
		}

		private void ManufacturePage_OnLoaded(object sender, RoutedEventArgs e)
		{
			DGridManufacture.ItemsSource = ComputerEntities.GetContext().Manufactures.ToList();
		}
	}
}
