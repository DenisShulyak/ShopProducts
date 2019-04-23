using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProducts
{
    public class Basket
    {
        public int Id { get; set; }

        public int IdUser { get; set; }
        public User User { get; set; }

        public int IdProduct { get; set; }
        public Product Product { get; set; }
    }
}
