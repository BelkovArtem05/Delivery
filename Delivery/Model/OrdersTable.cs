using Delivery.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Model
{
    internal class OrdersTable
    {
        public int IdOrder { get; set; }
        public int? ClientId { get; set; }
        public int? FoodId { get; set; }
        public int? DeliveryPrice { get; set; }
        public int? WorkerId { get; set; }
        public DateTime? Date { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }

        public string NameClient { get; set; }
        public string NameFood{ get; set; }
        public string NameWorker { get; set; }

        public static OrdersTable ConvertOrderOnOrdersTable(Orders order)
        {
            OrdersTable ordersTable = new OrdersTable();
            ordersTable.IdOrder = order.IdOrder;
            ordersTable.ClientId = order.ClientId;
            ordersTable.WorkerId = order.WorkerId;
            ordersTable.DeliveryPrice = order.DeliveryPrice;
            ordersTable.FoodId = order.FoodId;
            ordersTable.Status = order.Status;
            ordersTable.Address = order.Address;

            using (ApplicationContext db = new ApplicationContext())
            {
                ordersTable.NameFood = db.Food.FirstOrDefault(g => g.IdFood == order.FoodId).Name;
                Workers worker = db.Workers.FirstOrDefault(g => g.IdWorker == order.WorkerId);
                ordersTable.NameWorker = $"{worker.Lastname} {worker.Firstname} {worker.Fathername}";
                Clients client = db.Clients.FirstOrDefault(g => g.IdClient == order.ClientId);
                ordersTable.NameClient = $"{client.Lastname} {client.Firstname} {client.Fathername} ";
            }

            return ordersTable;
        }
    }

}
