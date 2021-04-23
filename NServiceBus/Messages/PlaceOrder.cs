using NServiceBus;
using System;

namespace Messages
{
    public class PlaceOrder : ICommand
    {
        public string OrderId { get; set; }

        public DateTime FechaIngreso = DateTime.Now;

        public string Description { get; set; }

        public string CustomerID { get; set; }

        public string CustomerName { get; set; }

        public string Amount { get; set; }
    }
}