using Computer.Classes;
using System.Windows;
using System.Windows.Controls;

namespace Computer.Pages
{
	public partial class MenuPage : Page
	{
		public MenuPage() => InitializeComponent();

		private void Service_Click(object sender, RoutedEventArgs e) => Manager.Navigate(new ServicePage());
		private void Accessories_Click(object sender, RoutedEventArgs e) => Manager.Navigate(new AccessoriesPage());
		private void Items_Click(object sender, RoutedEventArgs e) => Manager.Navigate(new ItemsPage());
		private void Manufacture_Click(object sender, RoutedEventArgs e) => Manager.Navigate(new ManufacturePage());
		private void Seller_Click(object sender, RoutedEventArgs e) => Manager.Navigate(new SellerPage());
		private void Customer_Click(object sender, RoutedEventArgs e) => Manager.Navigate(new CustomerPage());
		private void SaleAccessories_Click(object sender, RoutedEventArgs e) => Manager.Navigate(new SaleAccessoriesPage());
		private void SaleItem_Click(object sender, RoutedEventArgs e) => Manager.Navigate(new SaleItems());
		private void UseService_Click(object sender, RoutedEventArgs e) => Manager.Navigate(new SaleServicePage());
		private void MenuPage_OnLoaded(object sender, RoutedEventArgs e)
		{
			BtnManufactures.Visibility = Data.IsManager() ? Visibility.Visible : Visibility.Collapsed;
			BtnSellers.Visibility = Data.IsManager() ? Visibility.Visible : Visibility.Collapsed;
			BtnCustomers.Visibility = Data.IsStaff() ? Visibility.Visible : Visibility.Collapsed;
			BtnProfile.Visibility = Data.IsSeller() ? Visibility.Visible : Visibility.Collapsed;
		}
		private void BtnProfile_OnClick(object sender, RoutedEventArgs e) => Manager.Navigate(new ProfileSellerPage());
	}
}
