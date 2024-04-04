using KMA.CSharp2024.Gomenyuk_lab01.Models;
using KMA.CSharp2024.Gomenyuk_lab01.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Reflection.Emit;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace KMA.CSharp2024.Gomenyuk_lab01
{
    public partial class MainWindow : Window
    {
        private PersonDatabase _db = new PersonDatabase();

        public MainWindow()
        {
            InitializeComponent();
            Procider.IsEnabled = false;
            jail.DataContext = _db.GetBase();
        }

        private void Procider_Click(object sender, RoutedEventArgs e)
        {
            Procider.IsEnabled = false;
            Procider.IsEnabled = true;
        }

        private void custom_Sorting(object sender, DataGridSortingEventArgs e)
        {
            if (e.Column.Header.ToString() == "Email")
            {
                ObservableCollection<Person> people = _db.GetBase();
                //Implement sort on the column "Email" using LINQ
                if (e.Column.SortDirection == null || e.Column.SortDirection == ListSortDirection.Descending)
                {
                    jail.ItemsSource = new ObservableCollection<Person>(from p in people
                                                                      orderby p.EmailDomain ascending
                                                                        select p);
                    e.Column.SortDirection = ListSortDirection.Ascending;
                }
                else
                {
                    jail.ItemsSource = new ObservableCollection<Person>(from p in people
                                                                      orderby p.EmailDomain descending
                                                                        select p);
                    e.Column.SortDirection = ListSortDirection.Descending;
                }
                e.Handled = true;
            }
            // Remove sorting indicators from other columns
            foreach (var dgColumn in jail.Columns)
            {
                if (dgColumn.Header.ToString() != e.Column.Header.ToString())
                {
                    dgColumn.SortDirection = null;
                }
            }
        }
    }
}