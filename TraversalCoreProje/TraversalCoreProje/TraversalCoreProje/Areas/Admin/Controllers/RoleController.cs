using EntityLayer.Concreate; // AppROle sınıfını kullanabilmek için ekledik
using Microsoft.AspNetCore.Identity; // RoleMenager sınıfını kullanabilmek için ekledik
using Microsoft.AspNetCore.Mvc;
using NToastNotify; // IToastNotification interface'ni kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProje.Areas.Admin.Models; // CreateRoleViewModel sınıfını kullanabilmek için ekledik

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Role")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleMenager;
        private readonly UserManager<AppUser> _userMenager;
        private readonly IToastNotification _toastNotification;

        public RoleController(RoleManager<AppRole> roleMenager, UserManager<AppUser> userMenager, IToastNotification toastNotification)
        {
            _roleMenager = roleMenager;
            _userMenager = userMenager;
            _toastNotification = toastNotification;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _roleMenager.Roles.ToList();
            return View(values);
        }

        [Route("CreateRole")]
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [Route("CreateRole")]
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            AppRole role = new AppRole()
            {
                Name = model.RoleName
            };
            var result = await _roleMenager.CreateAsync(role);
            if(result.Succeeded)
            {
                _toastNotification.AddSuccessToastMessage("Rol Eklendi");
                return RedirectToAction("Index");
            }
            else
            {
                _toastNotification.AddErrorToastMessage("Rol eklenemedi");
                return View(model);
            }
        }

        [Route("DeleteRole/{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var value = _roleMenager.Roles.FirstOrDefault(x => x.Id == id);
            await _roleMenager.DeleteAsync(value);
            _toastNotification.AddWarningToastMessage("Rol Silindi");
            return RedirectToAction("Index");
        }

        [Route("UpdateRole/{id}")]
        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var value = _roleMenager.Roles.FirstOrDefault(x => x.Id == id);
            UpdateRoleViewModel updateRoleViewModel = new UpdateRoleViewModel()
            {
                RoleID = value.Id,
                RoleName = value.Name
            };
            return View(updateRoleViewModel);
        }

        [Route("UpdateRole/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel model)
        {
            var value = _roleMenager.Roles.FirstOrDefault(x => x.Id == model.RoleID);
            value.Name = model.RoleName;
            await _roleMenager.UpdateAsync(value);
            _toastNotification.AddSuccessToastMessage("Rol Güncellendi");
            return RedirectToAction("Index");
        }
        [Route("UserList")]
        public IActionResult UserList()
        {
            var values = _userMenager.Users.ToList();
            return View(values);
        }

        [Route("AssignRole/{id}")]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userMenager.Users.FirstOrDefault(x => x.Id == id);
            TempData["Userid"] = user.Id;
            var roles = _roleMenager.Roles.ToList();
            var userRoles = await _userMenager.GetRolesAsync(user);
            List<RoleAssignViewModel> roleAssignViewModels = new List<RoleAssignViewModel>();
            foreach (var item in roles)
            {
                RoleAssignViewModel model = new RoleAssignViewModel();
                model.RoleID = item.Id;
                model.RoleName = item.Name;
                model.RoleExist = userRoles.Contains(item.Name);
                roleAssignViewModels.Add(model);
            }
            return View(roleAssignViewModels);
        }

        [Route("AssignRole/{id}")]
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
        {
            /* birden fazla seçim yapacağımız durumlar olacağı için list olarak gönderdik RoleAssignViewModel sınıfını*/
            var userid =(int) TempData["userid"]; /* int değere dönüştürdü var ile tanımlandığı için object değerdir*/
            var user = _userMenager.Users.FirstOrDefault(x => x.Id == userid);
            foreach(var item in model)
            {
                if(item.RoleExist)
                {
                    _toastNotification.AddSuccessToastMessage("Kullanıcı Rol Eklendi");
                    await _userMenager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    _toastNotification.AddWarningToastMessage("Kullanıcı Rol Kaldırıldı");
                    await _userMenager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }
            return RedirectToAction("UserList");
        }
    }
}
