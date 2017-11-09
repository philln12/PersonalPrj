using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDB1.Domain;
using TestDB1.Service;

namespace TestDB1
{
    class Program
    {
        static void Main(string[] args)
        {

            //ProductService pservice = new ProductService();

            //IEnumerable<Product> prod = pservice.GetAllProducts();

            //foreach (Product product in prod)
            //{
            //    Console.WriteLine($"Product name: {product.ProductName} - product description: {product.ProductDescription}");

            //}
            //Console.ReadLine();

            PersonService pservice = new PersonService();

            IEnumerable<Person> peop = pservice.GetAllPersons();

            foreach (Person person in peop)
            {
                Console.WriteLine($"Person name: {person.FirstName}");

            }
            Console.ReadLine();
        }
    }
}
