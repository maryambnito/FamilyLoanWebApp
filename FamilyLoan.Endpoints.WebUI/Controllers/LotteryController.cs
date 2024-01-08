using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyLoan.Endpoints.WebUI.Controllers
{
    public class LotteryController : BaseController
    {
        public IActionResult Lotteries()
        {

            return View();
        }
    }
}
