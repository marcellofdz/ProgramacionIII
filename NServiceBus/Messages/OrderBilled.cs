using NServiceBus;
using System;

namespace Messages
{
    public class OrderBilled : IEvent
    {
        public string OrderId { get; set; }


        public DateTime FechaIngreso = DateTime.Now;

        public string Description { get; set; }

        public int CustomerID { get; set; }

        public string CustomerName { get; set; }

        public decimal Amount { get; set; }
    }
}