using Computer.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Computer.Classes;

namespace Computer.Pages.EditPages
{
	/// <summary>
	/// Логика взаимодействия для ItemEditPage.xaml
	/// </summary>
	public partial class ItemEditPage : Page
	{
		private readonly Item _currentItem;
		public ItemEditPage()
		{
			InitializeComponent();
			_currentItem = new Item();
			DataContext = _currentItem;
			GetComboBox();
		}
		public ItemEditPage(Item selectedItem)
		{
			InitializeComponent();
			_currentItem = selectedItem;
			DataContext = _currentItem;
			GetComboBox();
		}

		private void GetComboBox()
		{
			CbManufacture.ItemsSource = ComputerEntities.GetContext().Manufactures.ToList();
		}
		private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(TbTitle.Text) || string.IsNullOrWhiteSpace(TbCost.Text) ||
			    CbManufacture.SelectedItem == null)
			{
				MessageBox.Show("Заполните все поля!");
				return;
			}

			if (_currentItem.ID == 0) ComputerEntities.GetContext().Items.Add(_currentItem);
			ComputerEntities.GetContext().SaveChanges();
			MessageBox.Show("Товар успешно добавлен");
			Manager.GoBack();
		}
	}
}
