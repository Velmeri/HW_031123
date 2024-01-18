using HW_031123.MVVM.MVs;
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

namespace HW_031123
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private MainViewModel DataContext;
		public MainWindow()
		{
			InitializeComponent();
			DataContext = new MainViewModel();
		}

		private void New_Click(object sender, RoutedEventArgs e)
		{
			DataContext.CreateNewContact();
		}

		private void Save_Click(object sender, RoutedEventArgs e)
		{
			DataContext.SaveContact();
		}

		private void Delete_Click(object sender, RoutedEventArgs e)
		{
			DataContext.DeleteContact();
		}
	}
}
