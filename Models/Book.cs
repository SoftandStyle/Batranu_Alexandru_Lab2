using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Batranu_Alexandru_Lab2.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }

            [Column(TypeName = "decimal(6, 2)")]
       
        public decimal Price { get; set; }

        public int? AuthorID {  get; set; }
        public Author? Author { get; set; }

        public ICollection<Order>? Orders { get; set;}
        public ICollection<PublishedBook> PublishedBooks { get; set; }

        internal static IQueryable<Book> OrderByDescending(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }


    
}
