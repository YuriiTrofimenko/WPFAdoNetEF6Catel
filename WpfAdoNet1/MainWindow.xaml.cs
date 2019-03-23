using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace WpfAdoNet1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqlConnection conn;
        public MainWindow()
        {
            InitializeComponent();

            //SqlConnection conn =
            //new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=store;Integrated Security=True");
            //conn.Open();
            //conn.Close();
            //MultipleActiveResultSets=True

            conn =
                new SqlConnection(
                    @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=store;Integrated Security=True"
                );

            refreshCategoriesList();
        }

        private void addCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            int result = 0;
            try
            {
                conn.Open();
                SqlCommand insertCommand = conn.CreateCommand();
                insertCommand.CommandText =
                    $"INSERT INTO [Categories] ([name]) VALUES (N'{categoryNameTextBox.Text}')";
                result = insertCommand.ExecuteNonQuery();
                
            }
            catch (Exception)
            {

                throw;
            }
            finally {
                conn.Close();
            }

            if (result > 0)
            {
                refreshCategoriesList();
            }
        }

        private void refreshCategoriesList() {
            /*using (conn =
                new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=store;Integrated Security=True"))
            {
                conn.Open();

                SqlCommand selectCommand = conn.CreateCommand();
                selectCommand.CommandText = "SELECT * FROM [Categories]";
                categoriesTextBlock.Text = "";
                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        categoriesTextBlock.Text += reader["id"] + " " + reader["name"] + "\n";
                    }
                }
            }*/

            try
            {
                conn.Open();

                SqlCommand selectCommand = conn.CreateCommand();
                selectCommand.CommandText = "SELECT * FROM [Categories]";
                categoriesTextBlock.Text = "";
                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        categoriesTextBlock.Text += reader["id"] + " " + reader["name"] + "\n";
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
                
            
        }
    }
}
