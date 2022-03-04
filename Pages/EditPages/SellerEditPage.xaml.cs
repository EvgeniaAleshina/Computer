using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Computer.Entity;

namespace Computer.Pages.EditPages
{
	/// <summary>
	/// Логика взаимодействия для SellerEditPage.xaml
	/// </summary>
	public partial class SellerEditPage : Page
	{
		private readonly Seller _currentSeller;
		public SellerEditPage()
		{
			InitializeComponent();
			_currentSeller = new Seller();
			DataContext = _currentSeller;
		}
		public SellerEditPage(Seller selectedSeller)
		{
			InitializeComponent();
			_currentSeller = selectedSeller;
			DataContext = _currentSeller;
		}

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void SellerEditPage_OnLoaded(object sender, RoutedEventArgs e)
		{
			CbUsers.ItemsSource = ComputerEntities.GetContext().Users.ToList();
		}
	}
}
