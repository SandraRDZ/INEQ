using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaseDatos;

namespace INEQ.Controllers
{
    public class EquipmentsController : Controller
    {
        private IneqDev db = new IneqDev();

        // GET: Equipments
        public async Task<ActionResult> Index()
        {
            var equipments = db.Equipments.Include(e => e.Brand).Include(e => e.EquipmentType).Include(e => e.Model).Include(e => e.Status).Include(e => e.Warehouse);
            return View(await equipments.ToListAsync());
        }

        // GET: Equipments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipment equipment = await db.Equipments.FindAsync(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        // GET: Equipments/Create
        public ActionResult Create()
        {
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Description");
            ViewBag.EquipmentTypeId = new SelectList(db.EquipmentTypes, "Id", "Description");
            ViewBag.ModelId = new SelectList(db.Models, "Id", "Description");
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Description");
            ViewBag.WarehouseId = new SelectList(db.Warehouses, "Id", "Description");
            return View();
        }

        // POST: Equipments/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,EquipmentTypeId,ModelId,BrandId,StatusId,WarehouseId,EntryDate,Serie,SofttekId,Active")] Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                db.Equipments.Add(equipment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Description", equipment.BrandId);
            ViewBag.EquipmentTypeId = new SelectList(db.EquipmentTypes, "Id", "Description", equipment.EquipmentTypeId);
            ViewBag.ModelId = new SelectList(db.Models, "Id", "Description", equipment.ModelId);
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Description", equipment.StatusId);
            ViewBag.WarehouseId = new SelectList(db.Warehouses, "Id", "Description", equipment.WarehouseId);
            return View(equipment);
        }

        // GET: Equipments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipment equipment = await db.Equipments.FindAsync(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Description", equipment.BrandId);
            ViewBag.EquipmentTypeId = new SelectList(db.EquipmentTypes, "Id", "Description", equipment.EquipmentTypeId);
            ViewBag.ModelId = new SelectList(db.Models, "Id", "Description", equipment.ModelId);
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Description", equipment.StatusId);
            ViewBag.WarehouseId = new SelectList(db.Warehouses, "Id", "Description", equipment.WarehouseId);
            return View(equipment);
        }

        // POST: Equipments/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,EquipmentTypeId,ModelId,BrandId,StatusId,WarehouseId,EntryDate,Serie,SofttekId,Active")] Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Description", equipment.BrandId);
            ViewBag.EquipmentTypeId = new SelectList(db.EquipmentTypes, "Id", "Description", equipment.EquipmentTypeId);
            ViewBag.ModelId = new SelectList(db.Models, "Id", "Description", equipment.ModelId);
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Description", equipment.StatusId);
            ViewBag.WarehouseId = new SelectList(db.Warehouses, "Id", "Description", equipment.WarehouseId);
            return View(equipment);
        }

        // GET: Equipments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipment equipment = await db.Equipments.FindAsync(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        // POST: Equipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Equipment equipment = await db.Equipments.FindAsync(id);
            db.Equipments.Remove(equipment);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
