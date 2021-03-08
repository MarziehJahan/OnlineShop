using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TK.Core.Contracts.Service;

namespace PresentationHost.Components
{
    public class LastProductsViewComponent : ViewComponent
    {
        private readonly IProdctService productServic;

        public LastProductsViewComponent(IProdctService productServic)
        {
            this.productServic = productServic;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = productServic.GetNewestProduct().Take(6).ToList();
            return View(data);
        }
    }
}
