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
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
using System.Data.Entity;

namespace ДЗ_Модуль_16
{
    /// <summary>
    /// Логика взаимодействия для Task3.xaml
    /// </summary>
    public partial class Task3 : Page
    {
        static PersonContext personDB = new PersonContext();



        
        public Task3()
        {
            InitializeComponent();
            
            personDB.Persons.Load();
            myDataGrid.DataContext = personDB.Persons.Local.ToBindingList<Person>();
           
            
        }

        

        private void deletePerson_Click(object sender, RoutedEventArgs e)
        {
            personDB.Persons.Remove(myDataGrid.SelectedItem as Person);
            personDB.SaveChanges();
            
        }

        private void showGoods_Click(object sender, RoutedEventArgs e)
        {
            GoodsList goodsList = new GoodsList((myDataGrid.SelectedItem as Person).Email);
            goodsList.Show();
        }

        private void myDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            personDB.Persons.Append(myDataGrid.SelectedItem as Person);
            personDB.SaveChanges();
        }


        private void ShowAddInterface_Click(object sender, RoutedEventArgs e)
        {
            ShowAddInterface.Visibility = Visibility.Hidden;

            firsNameBox.Visibility = Visibility.Visible;
            lastNameBox.Visibility = Visibility.Visible;
            midNameBox.Visibility = Visibility.Visible;
            emailBox.Visibility = Visibility.Visible;
            phoneBox.Visibility = Visibility.Visible;
            firstNameBlock.Visibility = Visibility.Visible;
            lastNameBlock.Visibility = Visibility.Visible;
            midNameBlock.Visibility = Visibility.Visible;
            emailBlock.Visibility = Visibility.Visible;
            phoneBlock.Visibility = Visibility.Visible;
            Save.Visibility = Visibility.Visible;

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Person personToAdd = new Person();
            personToAdd.LastName = lastNameBox.Text;
            personToAdd.FirstName = firsNameBox.Text;
            personToAdd.MiddleName = midNameBox.Text;
            personToAdd.Email = emailBox.Text;
            personToAdd.Phone = phoneBox.Text;

            personDB.Persons.Add(personToAdd);
            personDB.SaveChanges();

            firsNameBox.Visibility = Visibility.Hidden;
            lastNameBox.Visibility = Visibility.Hidden;
            midNameBox.Visibility = Visibility.Hidden;
            emailBox.Visibility = Visibility.Hidden;
            phoneBox.Visibility = Visibility.Hidden;

            firstNameBlock.Visibility = Visibility.Hidden;
            lastNameBlock.Visibility = Visibility.Hidden;
            midNameBlock.Visibility = Visibility.Hidden;
            emailBlock.Visibility = Visibility.Hidden;
            phoneBlock.Visibility = Visibility.Hidden;
            Save.Visibility = Visibility.Hidden;

            firsNameBox.Text = null;
            lastNameBox.Text = null;
            midNameBox.Text = null;
            emailBox.Text = null;
            phoneBox.Text = null;

            ShowAddInterface.Visibility = Visibility.Visible;
        }

        private void firsNameBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!string.IsNullOrEmpty(firsNameBox.Text) && 
                !string.IsNullOrEmpty(lastNameBox.Text) && 
                !string.IsNullOrEmpty(midNameBox.Text) &&
                !string.IsNullOrEmpty(emailBox.Text) &&
                    !string.IsNullOrEmpty(phoneBox.Text))
            {
                Save.IsEnabled = true;
            }
        }
    }
}
