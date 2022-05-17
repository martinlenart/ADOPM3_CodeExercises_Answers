using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Linq_Orders_Customers
{
    static class LinqExtensions
    {
        public static void Print<T>(this IEnumerable<T> collection)
        {
            collection.ToList().ForEach(item => Console.WriteLine(item));
        }
    }
    public class OrderCustomer
    {
        public Customer cus { get; set; }
        public Order ord { get; set; }
    }

    class Program
    {
        const int NrOfCustomers = 10_000;
        const int MaxNrOfOrdersPerCustomer = 20;

        static void Main(string[] args)
        {
            //Create Order and customer Lists
            List<Order> OrderList = new List<Order>();
            List<Customer> CustomerList = new List<Customer>();

            var rnd = new Random();
            for (int c = 0; c < NrOfCustomers; c++)
            {
                var cus = Customer.Factory.CreateWithRandomData();
                CustomerList.Add(cus);

                //Create a random number of order for the customer. Could be 0
                for (int o = 0; o < rnd.Next(0, MaxNrOfOrdersPerCustomer+1); o++)
                {
                    OrderList.Add(Order.Factory.CreateWithRandomData(cus.CustomerID));
                }
            }

            QueryCustomersWithLinq(CustomerList);
            QueryOrdersWithLinq(CustomerList, OrderList);

            var balticCustomers = CustomerList.Where(c => c.Country == "Lettland").ToList();
            var xs = new XmlSerializer(typeof(List<Customer>));
            using (Stream s = File.Create(fname("BalticCustomers.xml")))
                xs.Serialize(s, balticCustomers);
        }

        private static void QueryCustomersWithLinq(IEnumerable<Customer> customers)
        {
            Console.WriteLine($"Number of customers: {customers.Count()}");
            var countryList = customers.Select(c => c.Country).Distinct().ToList();
            foreach (var country in countryList)
            {
                Console.WriteLine(country);
            }
            Console.WriteLine($"Number of customers in Lettland: {customers.Where(c => c.Country == "Lettland").Count()}");


        }

        private static void QueryOrdersWithLinq(IEnumerable<Customer> customers, IEnumerable<Order> orders)
        {
            Console.WriteLine($"Number of orders: {orders.Count()}");

          var ordersBaltic = orders.Join(customers, o => o.CustomerID, c => c.CustomerID, (o, c) => new OrderCustomer { ord = o, cus = c })
                .Where(oc => (oc.cus.Country == "Lettland") && (oc.ord.Value > 1000)).ToList();

            Console.WriteLine($"Number of orders in Lettland: {ordersBaltic.Count()}");
            
            var xs = new XmlSerializer(typeof(List<OrderCustomer>));
            using (Stream s = File.Create(fname("BalticOrders.xml")))
                xs.Serialize(s, ordersBaltic);
        }

        static string fname(string name)
        {
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            documentPath = Path.Combine(documentPath, "Nisse");
            if (!Directory.Exists(documentPath)) Directory.CreateDirectory(documentPath);
            return Path.Combine(documentPath, name);
        }
    }
}
///Exercises:
//1.    Antalet kunder, Antalet kunder i Sverige, Äldsta kundens födelsedag, Yngsta kundens födelsedag
//2.    Använd GroupBy för att lista antalet kunder per land
//3.    Antalet kunder med ett efternamn som slutar på 'son'

//4.    Antalet ordrar och totalt ordervärde av de 5 största ordrarna
//5.    Använd Join för att lista kund och ordervärde för de 5 största ordrarna
//6.    Använd GroupJoin för att lista de 5 största kunderna baserat på ordervärde
