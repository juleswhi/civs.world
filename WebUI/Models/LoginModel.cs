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
        public string username { get; set; }
        [BindProperty]
        public string password { get; set; }

        public IActionResult OnPostAsync()
        {
            Console.WriteLine("POST");
            if(ModelState.IsValid)
            {
                if(Authenticate(username, password))
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