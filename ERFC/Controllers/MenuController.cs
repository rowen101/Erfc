using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using ERFC.Core;
using ERFC.ActionFilters;
using ERFC.Models;

namespace ERFC.Controllers
{
    [AuthorizationRequired]
    public class MenuController : ApiController
    {


        ERFCDBEntities db = new ERFCDBEntities();
        clsprocedure procedure = new clsprocedure();

        [HttpGet]
        public IHttpActionResult GetMenubyAppsID(int id)
        {

            var jsonOut = (from aa in db.core_appmenu
                           from bb in db.core_appmenu.Where(mapmenu => mapmenu.menucode == aa.prtmenucode).DefaultIfEmpty()
                           where aa.sysId == id
                           select new
                           {
                               aa.menuId,
                               aa.menucode,
                               aa.menuname,
                               aa.prtmenucode,
                               parentMenu = string.IsNullOrEmpty(bb.menuname) ? "As Parent" : bb.menuname,
                               parentOrder = bb.menuorder,
                               aa.menutype,
                               aa.isactive,
                               aa.menuorder,
                               aa.classicon
                           })
                               .OrderBy(aa => aa.parentOrder)
                               .ThenBy(bb => bb.menuorder)
                               .ToList()
                               .Distinct();

            return Json(jsonOut);
        }

        [HttpGet]
        public IHttpActionResult GetAllMenu()
        {
            var jsonOut = (from aa in db.core_appmenu
                           from bb in db.core_appmenu.Where(mapmenu => mapmenu.menucode == aa.prtmenucode).DefaultIfEmpty()
                           where aa.isactive == true && aa.forweb == true
                           select new { aa.sysId, aa.menuId, aa.menuname, aa.prtmenucode, parentMenu = string.IsNullOrEmpty(bb.menuname) ? "As Parent" : bb.menuname, parentOrder = bb.menuorder, aa.menutype, aa.isactive, aa.menuorder, aa.classicon }).OrderBy(aa => aa.parentOrder).ThenBy(bb => bb.menuorder).ToList();

            return Json(jsonOut);
        }

        [HttpGet]
        public HttpResponseMessage GetMenubyId(int id, int sysid)
        {
            try
            {
                db.Configuration.LazyLoadingEnabled = false;

                var menuDetails = db.core_appmenu.Where(aa => aa.menuId == id && aa.sysId == sysid).FirstOrDefault();
                if (menuDetails == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK, menuDetails);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpGet]
        public HttpResponseMessage GetParentMenu(int id)
        {

            try
            {
                db.Configuration.LazyLoadingEnabled = false;

                var menuDetails = db.core_appmenu.Where(aa => aa.sysId == id && aa.prtmenucode == "0").Select(aa => new { aa.menuId, aa.menucode, aa.sysId, aa.menuname, aa.prtmenucode, aa.menuorder, aa.isactive, aa.viewtype, aa.istransaction, aa.menutype, aa.accesslevel, aa.defaultemployee, aa.defaultcustomer, aa.defaultsupplier, aa.forweb, aa.formobile }).ToList(); ;
                if (menuDetails == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK, menuDetails);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpPost]
        public HttpResponseMessage SaveMenu(core_appmenu menu)
        {


            //bool isNew = false;
            try
            {

                //set menuID value if the menu is empty
                if (string.IsNullOrEmpty(menu.menucode))
                {
                    string currentDate = DateTime.Now.Ticks.ToString();
                    menu.menucode = currentDate;
                }


                if (string.IsNullOrEmpty(menu.prtmenucode))
                {
                    menu.prtmenucode = "0";
                }

                //check if the menu is exist set isNew val to true
                if (db.core_appmenu.Where(aa => aa.sysId == menu.sysId && aa.menuId == menu.menuId).Count() == 0)
                {

                    db.Entry(menu).State = EntityState.Added;
                    db.SaveChanges();

                }
                else
                {
                    db.Entry(menu).State = EntityState.Modified;
                    db.SaveChanges();
                }


                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);

            }

        }

        [HttpGet]
        public HttpResponseMessage DeleteMenu(int id)
        {
            try
            {
                core_appmenu Qmenu = db.core_appmenu.Where(aa => aa.menuId == id).FirstOrDefault();
                db.core_appmenu.Remove(Qmenu);
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();

            }
            base.Dispose(disposing);
        }
    }
}