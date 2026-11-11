using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Repaso3_MVC_LINQ.Controllers
{
    public class VentasCController : Controller
    {
        DB_LinQDataContext DB = new DB_LinQDataContext();

        // GET: VentasC
        public ActionResult Index()
        {
            var lista = DB.v_ventas.ToList();
            
            return View(lista);
        }

        // GET: VentasC/Details/5
        public ActionResult Details(int id)
        {
            var dato = (from c in DB.v_ventas
                        where c.id_venta == id
                        select c).Single();

            return View(dato);
        }

        // GET: VentasC/Create
        public ActionResult Create()
        {
           var lista = DB.productos.ToList();

            return View(lista);
        }

        public ActionResult Vender(int id)
        {
            var dato = (from c in DB.productos
                             
                             where c.id_producto == id
                             select c).Single();

            return View(dato);
        }

        // POST: VentasC/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection,int MiCampo,producto dato)
        {
            try
            {
                // TODO: Add insert logic here
                ViewBag.cantidad = MiCampo;
                DB.insert_venta(dato.id_producto, ViewBag.cantidad);
                DB.SubmitChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Vender");
            }
        }

        // GET: VentasC/Edit/5
        public ActionResult Edit(int id)
        {
          var dato = (from c in DB.ventas
                          where c.id_venta == id
                          select c).Single();

            return View(dato);
        }

        // POST: VentasC/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, venta dato)
        {
            try
            {
                // TODO: Add update logic here
                DB.update_venta(id, dato.id_producto, dato.cantidad);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: VentasC/Delete/5
        public ActionResult Delete(int id)
        {
            venta dato = (from c in DB.ventas
                          where c.id_venta == id
                          select c).Single();

            return View(dato);
        }

        // POST: VentasC/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                DB.delete_venta(id);
                DB.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
