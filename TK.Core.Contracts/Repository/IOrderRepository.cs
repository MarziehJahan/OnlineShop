using TK.Core.Entites;

namespace TK.Core.Contracts.Repository
{
    public interface IOrderRepository
    {
        void Save(Order order);
        void SetOrderToken(int orderId, string token);
        void PaymentDone(string token, int tId);
    }

}

