using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Delivery.Model.Models;

namespace Delivery.Model
{
    internal class DataWorker
    {
        public static bool createCategory(string name)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (!db.Categories.Any(el => el.Name == name))
                {
                    Categories category = new Categories()
                    {
                        Name = name,
                    };

                    db.Categories.Add(category);
                    db.SaveChanges();

                    return true;
                }
                return false;
            }
        }
        public static bool editCategory(Categories oldCategory, string name)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Categories category = db.Categories.FirstOrDefault(i => i.IdCategory == oldCategory.IdCategory);
                if (category != null)
                {
                    category.Name = name;

                    db.SaveChanges();

                    return true;
                }
                return false;
            }
        }
        public static void deleteCategory(Categories category)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Categories.Remove(category);
                db.SaveChanges();
            }
        }

        public static List<Categories> SelectAllCategories()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Categories.ToList();
            }
        }

        public static bool createFood(string name, int price, string description, int categoryId, int quantity)
        {
            using (ApplicationContext db = new ApplicationContext())
            {                
                Food food = new Food()
                {
                    Name = name,
                    Price = price,
                    Description = description, 
                    CategoryId = categoryId, 
                    Quantity = quantity, 
                };
                db.Food.Add(food);
                db.SaveChanges();
                return true;
              
            }
        }
        public static bool editFood(Food oldFood, string name, int price, string description, int categoryId, int quantity)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Food food= db.Food.FirstOrDefault(i => i.IdFood == oldFood.IdFood);
                if (food != null)
                {
                    food.Name = name;
                    food.Price = price;
                    food.Description = description;
                    food.CategoryId = categoryId;
                    food.Quantity = quantity;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public static void deleteFood(Food food)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Food.Remove(food);
                db.SaveChanges();
            }
        }

        public static List<Food> SelectAllFood()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Food.ToList();
            }
        }

        public static List<FoodTable> SelectAllFoodTable()
        {
            List<Food> food = SelectAllFood();
            List<FoodTable> foodTable = new List<FoodTable>();
            
            foreach(Food one in food)
            {
                foodTable.Add(FoodTable.ConvertFoodOnFoodTable(one));
            }

            return foodTable;
        }

        public static List<Workers> SelectAllWorkers()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Workers.ToList();
            }
        }

        public static bool createOrder(int clientId, int workerId, int foodId, int deliveryPrice, string status, string address)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Orders order = new Orders()
                {
                    ClientId = clientId,
                    WorkerId = workerId,
                    FoodId = foodId,
                    DeliveryPrice = deliveryPrice, 
                    Status = status,
                    Address = address,
                };
                db.Orders.Add(order);
                db.SaveChanges();
                return true;
            }
        }

        public static bool editOrder(Orders oldOrder, string status, string address)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Orders order = db.Orders.FirstOrDefault(i => i.IdOrder == oldOrder.IdOrder);
                if (order != null)
                {
                    order.Status = status; 
                    order.Address= address;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public static void deleteOrder(Orders order)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Orders.Remove(order);
                db.SaveChanges();
            }
        }

        public static List<Orders> SelectAllOrders()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Orders.ToList();
            }
        }

        public static List<OrdersTable> SelectAllOrdersTable()
        {
            List<Orders> orders = SelectAllOrders();
            List<OrdersTable> ordersTable = new List<OrdersTable>();

            foreach (Orders order in orders)
            {
                ordersTable.Add(OrdersTable.ConvertOrderOnOrdersTable(order));
            }
            
            return ordersTable;
        }

        public static bool createClient(string firstname, string lastname, string fathername, string phone, string email)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Clients client = new Clients()
                {
                    Firstname = firstname, 
                    Lastname = lastname, 
                    Fathername = fathername,
                    Phone= phone,
                    Email = email,
                };

                db.Clients.Add(client);
                db.SaveChanges();
                return true;
            }
        }

        public static bool editClient(Clients oldClient, string firstname, string lastname, string fathername, string phone, string email)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Clients client = db.Clients.FirstOrDefault(i => i.IdClient == oldClient.IdClient);
                if (client != null)
                {
                    client.Firstname = firstname;
                    client.Lastname = lastname;
                    client.Fathername = fathername;
                    client.Phone= phone;
                    client.Email= email;

                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public static void deleteClient(Clients client)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Clients.Remove(client);
                db.SaveChanges();
            }
        }

        public static List<Clients> SelectAllClients()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Clients.ToList();
            }
        }

        public static List<ClientsTable> SelectAllClientsTable()
        {
            List<Clients> clients = SelectAllClients();
            List<ClientsTable> clientsTable = new List<ClientsTable>();

            foreach (Clients client in clients)
            {
                clientsTable.Add(ClientsTable.ConvertClientOnClientsTable(client));
            }
            return clientsTable;
        }

        

    }
}
