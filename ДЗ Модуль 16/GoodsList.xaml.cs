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
using System.Windows.Shapes;
using System.Data;
using System.Data.Entity;
using System.IO;

namespace ДЗ_Модуль_16
{
    /// <summary>
    /// Логика взаимодействия для GoodsList.xaml
    /// </summary>
    public partial class GoodsList : Window
    {
        public string personEmail;
        static OrderContext orderDB = new OrderContext();
        public GoodsList(string Email)
        {
            this.personEmail = Email;
            
            InitializeComponent();
            orderDB.Orders.Load();
            myDataGrid.DataContext = orderDB.Orders.Local.ToBindingList<Order>().Where(e => e.email == personEmail);
        }



        
    }
}
