using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;

namespace ДЗ_Модуль_16
{
    internal class TableFiller
    {        
        /// <summary>
        /// Заполнение таблиц
        /// </summary>
        /// <param name="sender">Передай экземпляр класса, для которого будем заполнять таблицу</param>
        public static void GoFill(object sender)
        {
            if (sender.GetType() == typeof(Person))
            {
                List<Person> list = Person.GetList();
                using (PersonContext personDb = new PersonContext())
                {
                    foreach (Person person in list)
                    {
                        personDb.Persons.Add(person);
                    }
                    personDb.SaveChanges();
                }
                
            }
            if (sender.GetType() == typeof(Order))
            {
                List<Order> list = Order.GetList();
                using (OrderContext orderDb = new OrderContext())
                {
                    foreach (Order order in list)
                    {
                        orderDb.Orders.Add(order);
                    }
                    orderDb.SaveChanges();
                    
                }
                
            }
        }
        public static List<string> GetEmails()
        {
            List<string> emails = new List<string>();

            using (PersonContext personDb = new PersonContext())
            {
                var tempPersons = personDb.Persons.ToList();
                foreach (var person in tempPersons)
                {
                    emails.Add(person.Email);
                }
            }



                return emails;
        }
    }


}
