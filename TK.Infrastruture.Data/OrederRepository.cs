using System;
using System.Linq;
using TK.Core.Contracts.Repository;
using TK.Core.Entites;
using TK.Infrastruture.Sql;

namespace TK.Infrastruture.Data
{
    public class OrederRepository : IOrderRepository
    {
        private readonly DemoContext context;

        public OrederRepository(DemoContext context)
        {

            this.context = context;
        }

  

        public void PaymentDone(string token, int tId)
        {
            try
            {
                var order = context.Orders.Where(c => c.paymentToken == token.ToString()).First();
                order.PaymentDate = DateTime.Now;
                order.PaymentId = tId.ToString();

                context.SaveChanges();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void Save(Order order)
        {
            context.AttachRange(order.Lines.Select(a => a.Product));
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }

        public void SetOrderToken(int orderId, string token)
        {
            try
            {
                var order = context.Orders.Find(orderId);
                order.paymentToken = token;
                context.SaveChanges();
            }
            catch (System.Exception)
            {

                throw;
            }

        }


    }
}

