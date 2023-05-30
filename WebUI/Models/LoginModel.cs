using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Models
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public IActionResult OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                if(Authenticate(Username, Password))
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return Page();
        }        



        private bool Authenticate(string username, string password)
        {


            return true;
        }
    }


}