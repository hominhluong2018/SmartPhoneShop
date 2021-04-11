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
        LinkDAO linkDAO = new LinkDAO();
        ProductDAO productDAO = new ProductDAO();
        PostDAO postDAO = new PostDAO();
        // GET: Site
        public ActionResult Index(String slug = "")
        {
            SmartPhoneDBContext db = new SmartPhoneDBContext();
            db.Products.Count();
            if (slug == "")
            {
                return this.Home();
            }
            else
            {
                Link row_link = linkDAO.getRow(slug);
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
                    if (productDAO.getRow(slug) != null)
                    {
                        return this.ProductDetail(slug);
                    }
                    if (postDAO.getRow(slug) != null)
                    {
                        return this.PostDetail(slug);
                    }
                    return this.Error404(slug);
                }
            }
            return this.Error404(slug);
        }
        public ActionResult Home()
        {
            return View("Home");
        }
        public ActionResult Product()
        {
            return View("Product");
        }
        public ActionResult ProductCategory(String slug)
        {
            return View("ProductCategory");
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

