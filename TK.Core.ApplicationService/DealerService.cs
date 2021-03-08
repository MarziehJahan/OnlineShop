using System;
using System.Collections.Generic;
using System.Text;
using TK.Core.Contracts.Repository;
using TK.Core.Contracts.Service;
using TK.Core.Entites;

namespace TK.Core.ApplicationService
{
    public class DealerService : IDealerService
    {
        private readonly IDealerRepository dealerRepository;

        public DealerService(IDealerRepository dealerRepository)
        {
            this.dealerRepository = dealerRepository;
        }
        public void AddDealer(Dealer dealer)
        {
            dealerRepository.AddDealer(dealer);
        }
    }
}
