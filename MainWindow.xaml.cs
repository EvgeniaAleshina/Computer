using Computer.Classes;
using Computer.Pages;
using System;
using System.Windows;

namespace Computer
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			Manager.MainFrame = MainFrame;
			Manager.Navigate(new Auth());
		}

		private void BtnBack_Click(object sender, RoutedEventArgs e)
		{
			Manager.GoBack();
		}

		private void MainFrame_ContentRendered(object sender, EventArgs e)
		{
			BtnBack.Visibility = Manager.MainFrame.CanGoBack ? Visibility.Visible : Visibility.Hidden;
			TbStatus.Text = Data.Status;
		}
	}
}