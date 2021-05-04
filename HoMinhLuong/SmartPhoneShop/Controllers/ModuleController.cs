using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyLibrary.DAO;

namespace SmartPhoneShop.Controllers
{
    public class ModuleController : Controller
    {
        MenuDAO menuDAO = new MenuDAO();
        SliderDAO sliderDAO = new SliderDAO();
        CategoryDAO categoryDAO = new CategoryDAO();
        // GET: Module
        public ActionResult MainMenu()
        {
            var list = menuDAO.GetList(0);
            return View(list);
        }
        public ActionResult Slideshow()
        {
            var list = sliderDAO.getList("slideshow"); 
            return View("Slideshow", list);
        }
        public ActionResult ListCategory()
        {
            var list = categoryDAO.getList(0);
            return View("ListCategory", list);
        }
        public ActionResult ProductBuyHot()
        {
            return View("ProductBuyHot");
        }
        public ActionResult LastNews()
        {
            return View("LastNews");
        }
    }
}
 
