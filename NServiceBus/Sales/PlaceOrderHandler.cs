using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace Sales
{
    public class PlaceOrderHandler :
        IHandleMessages<PlaceOrder>
    {
        static ILog log = LogManager.GetLogger<PlaceOrderHandler>();

        #region UpdatedHandler

        public Task Handle(PlaceOrder message, IMessageHandlerContext context)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            
            log.Info($"Received PlaceOrder, OrderId = {message.OrderId}, Date = {message.FechaIngreso}, Name = {message.Description}, ");

            var orderPlaced = new OrderPlaced
            {
                OrderId = message.OrderId,
                FechaIngreso = DateTime.Now,
                Amount = message.Amount,
                CustomerID = message.CustomerID,
                CustomerName = message.CustomerName,
                Description = message.Description
            };

            conn.Open();
            SqlCommand com = new SqlCommand("guardarOrden", conn);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@OrderID", message.OrderId);
            com.Parameters.AddWithValue("@OrderDescription", message.Description);
            com.Parameters.AddWithValue("@CustomerID", message.CustomerID);
            com.Parameters.AddWithValue("@CustomerName", message.CustomerName);
            com.Parameters.AddWithValue("@OrderAmount", message.Amount);

            com.ExecuteNonQuery();
            return context.Publish(orderPlaced);
        }

        #endregion
    }
}
