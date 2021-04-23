using NServiceBus;
using System;

namespace Messages
{
    #region OrderPlaced

    public class OrderPlaced : IEvent
    {
        public string OrderId { get; set; }


        public DateTime FechaIngreso = DateTime.Now;

        public string Description { get; set; }

        public string CustomerID { get; set; }

        public string CustomerName{get;set;}

        public string Amount { get; set; }
    }

    #endregion
}