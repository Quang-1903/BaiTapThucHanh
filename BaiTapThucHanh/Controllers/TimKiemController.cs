using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaiTapThucHanh.Models;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace BaiTapThucHanh.Controllers
{
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        WebBanVaLiEntities db = new WebBanVaLiEntities();
        [HttpPost]
        public ActionResult KetQuaTimKiem(FormCollection f, int? page)
        {
            string searchkey = f["txtTimKiem"].ToString();
            List<tDanhMucSP> lstKQTK = db.tDanhMucSPs.Where(n => n.TenSP.Contains(searchkey)).ToList();
            int pageNumber = (page ?? 1);
            int pageSize = 9;
            if(lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Khong tim kiem thay thong tin san pham";
                return View(db.tDanhMucSPs.OrderBy(n => n.TenSP).ToPagedList(pageNumber,pageSize));
            }
            ViewBag.ThongBao = "da tim thay" + lstKQTK.Count + "san pham";
            return View(lstKQTK.OrderBy(n => n.TenSP).ToPagedList(pageNumber,pageSize));
        }
        [HttpGet]
        public ActionResult KetQuaTimKiem(int? page, string searchkey)
        {
           //ViewBag.keyword = searchkey;
            //string searchkey = f["txtTimKiem"].ToString();
            List<tDanhMucSP> lstKQTK = db.tDanhMucSPs.Where(n => n.TenSP.Contains(searchkey)).ToList();
            int pageNumber = (page ?? 1);
            int pageSize = 9;
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Khong tim kiem thay thong tin san pham";
                return View(db.tDanhMucSPs.OrderBy(n => n.TenSP).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "da tim thay" + lstKQTK.Count + "san pham";
            return View(lstKQTK.OrderBy(n => n.TenSP).ToPagedList(pageNumber, pageSize));
        }
    }
}