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

namespace WpfAdoNet2_EF6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        storeEntities db = new storeEntities();
        public MainWindow()
        {
            InitializeComponent();

            //1
            //categoriesListView.ItemsSource =
            //db.Categories.ToList();

            //2
            //categoriesListView.ItemsSource =
            //db.Categories.Select((c) => c.id + " - " + c.name).ToList();

            Console.WriteLine(db.Categories
                .Select((c) => c.id + " - " + c.name)
                .Where((cs) => cs.Length > 2)
                );

            categoriesListView.ItemsSource =
                db.Categories
                .Where((c) => c.id > 3)
                .Select((c) => c.id + " - " + c.name)
                .ToList();
        }
    }
}
