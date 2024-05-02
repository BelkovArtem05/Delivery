using Delivery.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Model
{
    internal class ClientsTable
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Fathername { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public static ClientsTable ConvertClientOnClientsTable(Clients client)
        {
            ClientsTable clientsTable = new ClientsTable();
            clientsTable.Id = client.IdClient;
            clientsTable.Firstname = client.Firstname;
            clientsTable.Lastname = client.Lastname;
            clientsTable.Fathername = client.Fathername;
            clientsTable.Phone = client.Phone;
            clientsTable.Email = client.Email;

            return clientsTable;
        }
    }
}
