using System.Windows.Controls;

namespace Computer.Classes
{
	internal class Manager
	{
		public static Frame MainFrame { get; set; }
		public static void Navigate(Page page) => MainFrame.Navigate(page);
		public static void GoBack() => MainFrame.GoBack();
	}
}