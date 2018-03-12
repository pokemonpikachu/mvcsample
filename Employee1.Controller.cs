using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Core.Objects;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class Employee1Controller : Controller
    {
        // GET: Employee1
        public ActionResult Reg_Cust()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Reg_Cust(cus_79 c)
        {
            if (ModelState.IsValid)
            {
                DB01TEST01Entities db = new DB01TEST01Entities();
                ObjectParameter op = new ObjectParameter("id", 0);
                db.sp_sri_reg(c.name, c.city, op);
                int cuid = Convert.ToInt32(op.Value);
                Response.Write("<script>alert('Successfully registered for id " + cuid + "')</script>");
            }
            return View();
        }
        public ActionResult View_Reg()
        {
            DB01TEST01Entities db1 = new DB01TEST01Entities();
            var v=db1.sp_sri_view().ToList();
            ViewBag.Table = v;
            return View();
        }
        public ActionResult Vbid_Reg(cus_79 c1)
        {
            if (ModelState.IsValid)
            {
                DB01TEST01Entities db2 = new DB01TEST01Entities();
                var v = db2.sp_sri_vbid(c1.id).ToList();
                ViewBag.table = v;
            }
            return View();
        }
        public ActionResult Update_Reg(cus_79 c2)
        {
            DB01TEST01Entities db3 = new DB01TEST01Entities();
            db3.sp_sri_updt(c2.id, c2.name, c2.city);
            return View();
        }
        public ActionResult Del_Reg(cus_79 c3)
        {
            DB01TEST01Entities db4 = new DB01TEST01Entities();
            db4.sp_sri_delt(c3.id);
            
            Response.Write("<script>alert('Deleted " + c3.id + "')</script>");
            return View();
        }
    }
}
