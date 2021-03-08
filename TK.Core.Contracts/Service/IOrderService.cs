using TK.Core.Entites;

namespace TK.Core.Contracts.Service
{
    public interface IOrderService
    {
        void SaveOrder(Order order);

        void SetTransactionId(int orderId, string token);

        void PaymentDone(string token, int tId);
    }
}
