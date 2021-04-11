using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyLibrary.DAO;
using SmartPhoneShop.Models;

namespace SmartPhoneShop.Controllers
{
    public class ModuleController : Controller
    {
        MenuDAO menuDAO = new MenuDAO();
        // GET: Module
        public ActionResult MainMenu()
        {
            var list = menuDAO.GetList(0);
            var menu = new List<MenuVM>();
            foreach (var item in  list)
            {
                var childMenu = menuDAO.GetList(item.Id);
                var childMenuVm = new List<MenuVM>();
                foreach (var child in childMenu)
                {
                    childMenuVm.Add(new MenuVM
                    {
                        Id = child.Id,
                        ParentId = child.ParentId,
                        Name = child.Name,
                        Link = child.Link
                    });
                }
                menu.Add(new MenuVM
                {
                    Id = item.Id,
                    ParentId = item.ParentId,
                    Link = item.Link,
                    Name = item.Name,
                    ChildMenu = childMenuVm
                });
            }

            return View(menu);
        }
    }
}