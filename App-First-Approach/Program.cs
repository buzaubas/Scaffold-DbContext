using App_First_Approach.Data;
using Microsoft.EntityFrameworkCore;

namespace App_First_Approach
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Scaffold-DbContext 'Data Source=223-10;Initial Catalog=ShopDb;Trusted_Connection=true;Encrypt=false' Microsoft.EntityFrameworkCore.SqlServer -ContextDir Data -OutputDir Models

            using var dbContext = new ShopDbContext();
            try
            {
                Console.WriteLine("Enter login: ");
                var login = Console.ReadLine() ?? throw new InvalidOperationException("No Login");

                //var user = dbContext.Users.Include(d => d.Baskets).First(f => f.Login == login);

                var user = dbContext.Users.Include(d => d.Baskets).ThenInclude(d => d.BasketProducts).ThenInclude(p => p.Product).Where(w => w.Baskets.Any(a => a.BasketProducts.Any())).First(f => f.Login == login);
                //foreach (var userBasket in user.Baskets)
                //{
                //    Console.WriteLine($"\t{userBasket.Id}, {userBasket.CreateDate}");
                //    var product = dbContext.BasketProducts.Include(f => f.Product).FirstOrDefault(f => f.BasketId == userBasket.Id);
                //    Console.WriteLine($"\t\t{product.Product.Name})");

                //    if (product != null) 
                //    {
                //        Console.WriteLine($"Product =  ${userBasket.User.Name} gas"); 
                //    }
                //}
                Console.Clear();
                Console.WriteLine($"User with loin - {user.Login} has following baskets: ");

                foreach (var userBasket in user.Baskets)
                {
                    foreach (var userBasketProduct in userBasket.BasketProducts)
                    {
                        Console.WriteLine($"User {userBasket.User.Name} has - {userBasketProduct.Product.Name}"); 
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e); ;
                throw;
            }
        }
    }
}

//SELECT    нельзя использовать EntityFrameWork