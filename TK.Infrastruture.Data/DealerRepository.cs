using System;
using System.Collections.Generic;
using System.Text;
using TK.Core.Contracts.Repository;
using TK.Core.Entites;
using TK.Infrastruture.Sql;

namespace TK.Infrastruture.Data
{
    public class DealerRepository : IDealerRepository
    {
        private readonly DemoContext context;

        public DealerRepository(DemoContext context)
        {
            this.context = context;
        }
        public void AddDealer(Dealer dealer)
        {
            context.Dealers.Add(dealer);
            context.SaveChanges();
        }
    }
}
