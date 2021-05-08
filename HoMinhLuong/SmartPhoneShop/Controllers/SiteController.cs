using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyLibrary;
using MyLibrary.Model;
using MyLibrary.DAO;
using PagedList;

namespace SmartPhoneShop.Controllers
{
    public class SiteController : Controller
    {
        LinkDAO _linkDAO = new LinkDAO();
        ProductDAO _productDAO = new ProductDAO();
        PostDAO _postDAO = new PostDAO();
        CategoryDAO _categoryDAO = new CategoryDAO();
        TopicDAO _topicDAO = new TopicDAO();
        // GET: Site
        public ActionResult Index(String slug = "", int? page=1)
        {
            SmartPhoneDBContext db = new SmartPhoneDBContext();
            db.Products.Count();
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
                        case "category": { return this.ProductCategory(slug,page); }
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
        public ActionResult Product(int? page)
        {
            int pageSize = 12;
            int pageNumber = page??1;
            //var limit = 9;
            var list = _productDAO.GetList(pageSize, pageNumber);
            return View("Product", list);
        }
        public ActionResult ProductHome(int catId, string name)
        {
            ViewBag.NameCat = name; 
            List<int> listcatid = _categoryDAO.getListId(catId);
            int limit = 6;
            var list = _productDAO.GetList(listcatid, limit);
            return View("ProductHome", list);
        }
        public ActionResult ProductCategory(String slug, int? page)
        {
            int pageSize = 6;
            int pageNumber = page??1;
            var row_cat = _categoryDAO.getRow(slug);
            int catId = row_cat.Id;
            ViewBag.Title = row_cat.Name;
            List<int> listcatid = _categoryDAO.getListId(catId);
            ViewBag.Slug = slug;
            var list = _productDAO.GetList(listcatid, pageNumber, pageSize);
            return View("ProductCategory", list);
        }
        public ActionResult ProductDetail(String slug)
        {
            int limit = 6;
            var row = _productDAO.getRow(slug);
            int catid = row.CatId;//thuộc loại nào
            List<int> listcatid = _categoryDAO.getListId(catid);
            var listother = _productDAO.GetList(listcatid,limit, row.Id, true);
            ViewBag.ListOther = listother;
             return View("ProductDetail", row);
        }
        public ActionResult Post()
        {
            return View("Post");
        }
        public ActionResult PostTopic(String slug)
        {

            var row_topic = _topicDAO.getRow(slug);
            ViewBag.Title = row_topic.Name;
            int topicid = row_topic.Id;
            //var list = _postDAO.getList(); 
            return View("PostTopic");
        }
        public ActionResult PostDetail(String slug)
        {

            int limit = 10;
            var row = _postDAO.getRow(slug);
            int? topid = row.TopId;
            ViewBag.ListOther = _postDAO.getList(topid, limit, row.Id);
            return View("PostDetail",row);
        }
        public ActionResult PostPage(String slug)
        {
            var row = _postDAO.getRow(slug);
            return View("PostPage",row);
        }
        public ActionResult Error404(String slug)
        {
            return View("Error404");
        }

    }
}

