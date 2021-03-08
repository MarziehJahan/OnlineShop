using System;
using System.Collections.Generic;
using System.Text;
using TK.Core.Entites;

namespace TK.Core.Contracts.Pay
{
    public interface IPayment
    {
        PaymentResult pay(string price);
        VerifyPayment Verify(string transactonID);
    }
}
