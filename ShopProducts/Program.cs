using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ShopContext())
            {


                //  context.Users.Add(new User { Login = "den", Password = "123" });
            //    context.Baskets.Add(new Basket { IdProduct = 2, IdUser = 1 });
              //  context.SaveChanges();

                var baskets = context.Baskets.ToList();
                var users = context.Users.ToList();
                var products = context.Products.ToList();
              /*  context.Products.Add(new Product { Name = "Хлеб", Price = 80 });
                context.Products.Add(new Product { Name = "Кефир", Price = 320 });
                context.Products.Add(new Product { Name = "Молоко", Price = 350 });
                context.Products.Add(new Product { Name = "Пачка яиц", Price = 360 });
                context.Products.Add(new Product { Name = "Сникерс", Price = 200 });*/
                //var users = context.Users.Where(user => user.Login == "den").ToList();

                Console.WriteLine("1) Вход");
                Console.WriteLine("2) Регистрация");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Console.Write("Login: ");
                    string login = Console.ReadLine();
                    Console.Write("Password: ");
                    string password = Console.ReadLine();
                    bool ifRight = false;
                    for (int i = 0; i < users.Count; i++)
                    {
                        if (users[i].Login == login && users[i].Password == password)
                        {
                            Console.Clear();
                            Console.WriteLine("Вход выполнен успешно!");

                            Console.ReadLine();
                            Console.Clear();
                            ifRight = true;
                        }
                    }
                    if (ifRight)
                    {
                   

                            var user = context.Users.Where(x => x.Login == login).ToList();
                            Console.Clear();
                            Console.WriteLine("1) Просмотреть товары ");
                            Console.WriteLine("2) Просмотреть корзину");
                            int choiceInShop = int.Parse(Console.ReadLine());
                            if (choiceInShop == 1)
                            {
                                Console.Clear();
                                Console.WriteLine("Продукты: ");
                                for (int i = 0; i < products.Count; i++)
                                {
                                    Console.WriteLine(i + 1 + ") " + products[i].Name);
                                }
                                Console.WriteLine("Выберите продукт для добавления в корзину: ");
                                int choiceProduct = int.Parse(Console.ReadLine());
                                for (int i = 0; i < products.Count; i++)
                                {
                                    if (choiceProduct == i + 1)
                                    {
                                        var res = context.Baskets.ToList();
                                        context.Baskets.Add(new Basket { IdProduct = products[i].Id, IdUser = user[0].Id });
                                        context.SaveChanges();
                                        var res2 = context.Baskets.ToList();

                                        Console.Clear();
                                        Console.WriteLine("Добавлено в корзину!");
                                        Console.ReadLine();
                                        break;
                                    }
                                }
                            }
                            else if (choiceInShop == 2)
                            {
                                Console.Clear();
                                Console.WriteLine("Корзина: ");
                                for (int i = 0; i < baskets.Count; i++)
                                {
                                    for (int j = 0; j < products.Count; j++)
                                    {
                                         if(baskets[i].IdUser == user[0].Id && products[j].Id == baskets[i].IdProduct)
                                        {
                                            Console.WriteLine(products[j].Name);
                                        }
                                    }
                                     

                                }
                                Console.ReadLine();
                            }
                        
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Неправельный логин или пароль");
                        Console.ReadLine();
                    }

                }
                else if (choice == 2)
                {
                    Console.WriteLine("Введите login: ");
                    string login = Console.ReadLine();
                    Console.WriteLine("Введите password: ");
                    string password = Console.ReadLine();

                    context.Users.Add(new User { Login = login, Password = password});
                    context.SaveChanges();
                    Console.WriteLine("Вы заригестрированы!");
                    Console.ReadLine();
                }

            }
        }
    }
}
