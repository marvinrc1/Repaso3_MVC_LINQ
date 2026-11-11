using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Repaso3_MVC_LINQ.Controllers
{
    public class ProductosCController : Controller
    {
        DB_LinQDataContext DB = new DB_LinQDataContext();

        // GET: ProductosC
        public ActionResult Index()
        {
            var lista = DB.productos.ToList();
            return View(lista);
        }

        // GET: ProductosC/Details/5
        public ActionResult Details(int id)
        {
            producto dato = (from c in DB.productos
                             where c.id_producto == id
                             select c).Single();

            return View(dato);
        }

        // GET: ProductosC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductosC/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection,producto dato)
        {
            try
            {
                // TODO: Add insert logic here
                DB.insert_producto(dato.categoria,dato.nombre_producto,dato.descripcion_produto,dato.precio);
                DB.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductosC/Edit/5
        public ActionResult Edit(int id)
        {
            producto dato = (from c in DB.productos
                             where c.id_producto == id
                             select c).Single();

            return View(dato);
        }

        // POST: ProductosC/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, producto dato)
        {
            try
            {
                // TODO: Add update logic here
                DB.update_producto(dato.id_producto, dato.categoria, dato.nombre_producto, dato.descripcion_produto, dato.precio);
                DB.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductosC/Delete/5
        public ActionResult Delete(int id)
        {
            producto dato = (from c in DB.productos
                             where c.id_producto == id
                             select c).Single();

            return View(dato);
        }

        // POST: ProductosC/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection, producto dato)
        {
            try
            {
                // TODO: Add delete logic here
                DB.delete_producto(id);
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
