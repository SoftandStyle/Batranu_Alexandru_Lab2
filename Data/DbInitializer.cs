using Batranu_Alexandru_Lab2.Models;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;

namespace Batranu_Alexandru_Lab2.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibraryContext(serviceProvider.GetRequiredService<DbContextOptions<LibraryContext>>()))
            {
                if (context.Books.Any())
                {
                    return; // BD a fost creata anterio


                     var authors = new Author[]
                                     {
                     new Author { FirstName = "Mihail", LastName = "Sadoveanu" },
                     new Author { FirstName = "George", LastName = "Calinescu" },
                     new Author { FirstName = "Mircea", LastName = "Eliade" }
                                     };
                     context.Authors.AddRange(authors);
                     context.SaveChanges();

                     var books = new Book[]
                     {
                     new Book { Title = "Baltagul", Price = Decimal.Parse("22"), AuthorID = authors[0].ID },
                     new Book { Title = "Enigma Otiliei", Price = Decimal.Parse("18"), AuthorID = authors[1].ID },
                     new Book { Title = "Maytrei", Price = Decimal.Parse("27"), AuthorID = authors[2].ID }
                     };
                     context.Books.AddRange(books);
                     context.SaveChanges();

                     context.Customers.AddRange(
                     new Customer
                     {
                         Name = "Popescu Marcela",
                         Adress = "Str. Plopilor, nr. 24",
                         BirthDate = DateTime.Parse("1979-09-01")
                     },
                     new Customer
                     {
                         Name = "Mihailescu Cornel",
                         Adress = "Str. Bucuresti, nr. 45, ap. 2",
                         BirthDate = DateTime.Parse("1969-07-08")
                     });

                     context.SaveChanges();



                     var orders = new Order[] {

                         new Order {

                             BookID = 7,
                             CustomerID = 9,
                             OrderDate = DateTime.Parse("2021-02-25")

                         },
                         new Order {

                             BookID = 10,
                             CustomerID = 9,
                             OrderDate = DateTime.Parse("2021-09-28"),

                         },
                         new Order {

                             BookID = 8,
                             CustomerID = 10,
                             OrderDate = DateTime.Parse("2021-10-28"),

                         },
                         new Order {

                             BookID = 10,
                             CustomerID = 10,
                             OrderDate = DateTime.Parse("2021-09-28"),

                         },
                         new Order {

                             BookID = 8,
                             CustomerID = 9,
                             OrderDate = DateTime.Parse("2021-09-28"),

                         },
                         new Order {

                             BookID = 11,
                             CustomerID = 10,
                             OrderDate = DateTime.Parse("2021-10-28"),

                         },

                     };
                     foreach (Order e in orders) { 

                         context.Orders.Add(e);

                     }
                     context.SaveChanges();

                     var publishers = new Publisher[]
                     {
                         new Publisher
                         {
                             PublisherName = "Humanitas",
                             Adress = "Str. Aviatorilor, nr. 40, Bucuresti",
                         },
                         new Publisher
                         {
                             PublisherName = "Nemira",
                             Adress = "Str. Plopilor, nr. 35, Ploiesti",
                         },
                         new Publisher
                         {
                             PublisherName = "Paralela45",
                             Adress = "Str. Cascadelor, nr. 22, Cluj-Napoca",
                         },
                     };
                     foreach (Publisher p in publishers) {

                         context.Publishers.Add(p);

                     }
                     context.SaveChanges();


               
                    
                   var publishedbooks = new PublishedBook[] {

                        new PublishedBook {

                            BookID = books.Single(c => c.Title == "Maytrei").ID,
                            PublisherID = publishers.Single(i => i.PublisherName == "Humanitas").ID

                        },
                        new PublishedBook {

                            BookID = books.Single(c => c.Title == "Enigma Otiliei I").ID,
                            PublisherID = publishers.Single(i => i.PublisherName == "Humanitas").ID

                        },
                        new PublishedBook {

                            BookID = books.Single(c => c.Title == "Baltagul").ID,
                            PublisherID = publishers.Single(i => i.PublisherName == "Nemira").ID

                        },
                        new PublishedBook {

                            BookID = books.Single(c => c.Title == "Fata de hartie").ID,
                            PublisherID = publishers.Single(i => i.PublisherName == "Paralela 45").ID

                        },
                       new PublishedBook {

                            BookID = books.Single(c => c.Title == "Panza de paianjen").ID,
                            PublisherID = publishers.Single(i => i.PublisherName == "Paralela 45").ID

                        },
                    
                        new PublishedBook {

                            BookID = books.Single(c => c.Title == "De veghe in lanul de secara").ID,
                            PublisherID = publishers.Single(i => i.PublisherName == "Paralela 45").ID

                        },

                    };
                    foreach (PublishedBook pb in publishedbooks) {

                        context.PublishedBooks.Add(pb);
                    
                    }
                    context.SaveChanges();

                    

                }
            }

        }
    }
}
