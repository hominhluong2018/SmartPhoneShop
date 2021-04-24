using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyLibrary;
using MyLibrary.Model;
using MyLibrary.DAO;

namespace SmartPhoneShop.Controllers
{
    public class SiteController : Controller
    {
        LinkDAO _linkDAO = new LinkDAO();
        ProductDAO _productDAO = new ProductDAO();
        PostDAO _postDAO = new PostDAO();
        CategoryDAO _categoryDAO = new CategoryDAO();
       
        // GET: Site
        public ActionResult Index(String slug = "")
        {
            //SmartPhoneDBContext db = new SmartPhoneDBContext();
            //db.Products.Count();
            if (slug == "")
            {
                return this.Home();
            }
            else
            {
                Link row_link = _linkDAO.getRow(slug);
                if (row_link != null)
                {
                    string typelink = row_link.TypeLink;
                    switch (typelink)
                    {
                        case "category": { return this.ProductCategory(slug); }
                        case "topic": { return this.PostTopic(slug); }
                        case "page": { return this.PostPage(slug); }
                    }
                }
                else
                {
                    //chi tiet sp
                    if (_productDAO.getRow(slug) != null)
                    {
                        return this.ProductDetail(slug);
                    }
                    if (_postDAO.getRow(slug) != null)
                    {
                        return this.PostDetail(slug);
                    }
                    return this.Error404(slug);
                }
            }
            return this.Home();
        }
        public ActionResult Home()
        {
             var vm = _categoryDAO.getList(0);
            return View("Home", vm);
        }
        public ActionResult Product()
        {
            return View("Product");
        }
        public ActionResult ProductHome(int catId, string name)
        {
            ViewBag.NameCat = name; 
            List<int> listcatid = _categoryDAO.getListId(catId);
            int limit = 6;
            var list = _productDAO.GetList(listcatid, limit);
            return View("ProductHome", list);
        }
        public ActionResult ProductCategory(String slug)
        {
            int limit = 1000;
            int skip = 0;
            var row_cat = _categoryDAO.getRow(slug);
            int catId = row_cat.Id;
            List<int> listcatid = _categoryDAO.getListId(catId);
            var list = _productDAO.GetList(listcatid, limit, skip);
            return View("ProductCategory", list);
        }
        public ActionResult ProductDetail(String slug)
        {
            return View("ProductDetail");
        }
        public ActionResult Post()
        {
            return View("Post");
        }
        public ActionResult PostTopic(String slug)
        {
            return View("PostTopic");
        }
        public ActionResult PostDetail(String slug)
        {
            return View("PostDetail");
        }
        public ActionResult PostPage(String slug)
        {
            return View("PostPage");
        }
        public ActionResult Error404(String slug)
        {
            return View("Error404");
        }

    }
}

