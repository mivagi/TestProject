using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Data.Models
{
    public class Cart
    {
        private List<CartItem> cartCollection = new List<CartItem>();
        public virtual void AddItem(Car car, int quartity)
        {
            CartItem item = cartCollection.Where(p => p.Car.Id == car.Id).FirstOrDefault();
            if (item == null)
            {
                cartCollection.Add(
                    new CartItem { Car = car, Quantity = quartity }
                    );
            }
            else
            {
                item.Quantity += quartity;
            }
        }
        public virtual IEnumerable<CartItem> Lines => cartCollection;
    }
}
