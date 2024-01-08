using FamilyLoan.Core.Domain.Customers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FamilyLoan.Endpoints.WebUI.Controllers
{
    public class IdentityController : Controller
    {
        private readonly SignInManager<Customer> signInManager;
        private readonly UserManager<Customer> userManager;

        public IdentityController(SignInManager<Customer> signInManager,UserManager<Customer> userManager )
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        [Route("/Login")]

        public IActionResult Login(string ReturnUrl)
        {
            ViewBag.returnUrl = ReturnUrl;
            return View();
        }
        [HttpPost]
        [Route("/Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>  Login(string username, string password,string returnUrl)
        {
          if(username==null || password==null)
            {
                return View(nameof(ErrorLogin));

            }
          
            var user = await userManager.FindByNameAsync(username);
            
            if (user == null)
            {
                return View(nameof(ErrorLogin));
                
            }
            

            var result = await signInManager.PasswordSignInAsync(user,password,true,false);
            
            if (result.Succeeded)
            {

                return Redirect(returnUrl ?? "/");
            }

            if (result.IsLockedOut)
            {
                var forgotPassLink = Url.Action(nameof(ForgotPassword),"Identity", new { }, Request.Scheme);
                var content = string.Format("نام کاربری شما قفل شده است برای شروع مجدد روی لینک کلیک کنید: {0}", forgotPassLink);
                //var message = new Message(new string[] { user.Email }, "Locked out account information", content, null);
                //await _emailSender.SendEmailAsync(message);
                ModelState.AddModelError("", "The account is locked out");
                return View();
            }
            else
            {
                ModelState.AddModelError("", "Invalid Login Attempt");
                return View();
            }



            return View();
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
[HttpPost]
        public async Task<IActionResult> ForgotPassword(string Email)
        {
            return View();
        }

        public IActionResult ErrorLogin()
        {
            return View();
        }

    }
    
}
