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
	/// Логика взаимодействия для ServiceEditPage.xaml
	/// </summary>
	public partial class ServiceEditPage : Page
	{
		public ServiceEditPage()
		{
			InitializeComponent();
		}
		public ServiceEditPage(Service selectedService)
		{
			InitializeComponent();
		}

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			
		}
	}
}
