using Computer.Classes;
using Computer.Entity;
using System.Windows;
using System.Windows.Controls;

namespace Computer.Pages.EditPages
{
	/// <summary>
	/// Логика взаимодействия для CustomerEditPage.xaml
	/// </summary>
	public partial class CustomerEditPage : Page
	{
		private Customer _currentCustomer;
		public CustomerEditPage()
		{
			InitializeComponent();
			_currentCustomer = new Customer();
			DataContext = _currentCustomer;
		}
		public CustomerEditPage(Customer customer)
		{
			InitializeComponent();
			_currentCustomer = customer;
			DataContext = _currentCustomer;
		}

		private void BtnAdd_Click(object sender, RoutedEventArgs e)
		{
			_currentCustomer = DataContext as Customer;
			if (_currentCustomer.ID == 0) ComputerEntities.GetContext().Customers.Add(_currentCustomer);
			ComputerEntities.GetContext().SaveChanges();
			Manager.GoBack();
		}
	}
}
