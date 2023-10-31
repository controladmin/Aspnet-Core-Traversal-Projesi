using EntityLayer.Concreate; // AppUser sınıfını kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc; //Usermenager sınıfını kulanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.IO; // Directory sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProje.Areas.Member.Models; // UserEditViewModel sınıfını kullanabilmek için bu kütüphaneyi ekledik


/*bu controller Areas klasörü altındaki Controller*/
namespace TraversalCoreProje.Areas.Member.Controllers
{
    /* SignIn sayfasında kullanıcı adı şifre ile giriş yaparken aşağıdaki iki attribute ifadesini girmez isek profil düzenleme sayfasına gitmez hata verir 
     * ondan dolayı bu iki attribute ifadesini ekledik kullanıcı adı şifre ile giriş yapan personelin bilgileri geliyor profil düzenleme sayfasında
    */

    /*iki tane controller dosyası olduğu için bu controllerin hangi kısımda olduğunu belirtiyoruz*/
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userMenager;

        public ProfileController(UserManager<AppUser> userMenager)
        {
            _userMenager = userMenager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userMenager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.Name = values.Name;
            userEditViewModel.Surname = values.Surname;
            userEditViewModel.PhoneNumber = values.PhoneNumber;
            userEditViewModel.Mail = values.Email;
            return View(userEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var user = await _userMenager.FindByNameAsync(User.Identity.Name);
            if(p.Image!=null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/userimages/" + imageName;
                var stream = new FileStream(saveLocation,FileMode.Create);
                await p.Image.CopyToAsync(stream);
                user.ImageUr = imageName;
            }
            user.Name = p.Name;
            user.Surname = p.Surname;
            user.Email = p.Mail;
            user.PhoneNumber = p.PhoneNumber;
            user.PasswordHash = _userMenager.PasswordHasher.HashPassword(user, p.Password);
            var result = await _userMenager.UpdateAsync(user);
            if(result.Succeeded)
            {
              return  RedirectToAction("SignIn", "Login");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View();
        }
    }
}
