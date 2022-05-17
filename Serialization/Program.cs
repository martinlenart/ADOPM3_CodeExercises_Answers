using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Serialization
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

            var customersLettland = CustomerList.Where(c => c.Country == "Lettland").ToList();
            var xs = new XmlSerializer(typeof(List<Customer>));
            using (Stream s = File.Create(fname("CustomersLettland.xml")))
                xs.Serialize(s, customersLettland);

            Console.WriteLine($"Customer data written to {fname("CustomersLettland.xml")}");

            var largestOrders = OrderList.Join(CustomerList, o => o.CustomerID, c => c.CustomerID, (o, c) => new OrderCustomer { ord = o, cus = c })
                .OrderByDescending(oc => oc.ord.Total).Take(10).ToList();

            xs = new XmlSerializer(typeof(List<OrderCustomer>));
            using (Stream s = File.Create(fname("LargestOrders.xml")))
                xs.Serialize(s, largestOrders);

            Console.WriteLine($"Order data written to : {fname("LargestOrders.xml")}");

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
//1.    Serialisera alla kunder i Lettland till en xml fil.
//2.    Öppna filen i Excel och Word och undersök innehållet.
//3.    Serialisera kund och orderdata för de 10 största kunderna till en xml fil. Öppna i Excel
//4.    Serialisera alla kunder i Sverige till en Json fil. Öppna file och titta på innehållet
