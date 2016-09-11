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
    public class EquipmentTypesController : Controller
    {
        private IneqDev db = new IneqDev();

        // GET: EquipmentTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.EquipmentTypes.ToListAsync());
        }

        // GET: EquipmentTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipmentType equipmentType = await db.EquipmentTypes.FindAsync(id);
            if (equipmentType == null)
            {
                return HttpNotFound();
            }
            return View(equipmentType);
        }

        // GET: EquipmentTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EquipmentTypes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Description,UsefulLife,GuaranteeDuration,Active")] EquipmentType equipmentType)
        {
            if (ModelState.IsValid)
            {
                db.EquipmentTypes.Add(equipmentType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(equipmentType);
        }

        // GET: EquipmentTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipmentType equipmentType = await db.EquipmentTypes.FindAsync(id);
            if (equipmentType == null)
            {
                return HttpNotFound();
            }
            return View(equipmentType);
        }

        // POST: EquipmentTypes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Description,UsefulLife,GuaranteeDuration,Active")] EquipmentType equipmentType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipmentType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(equipmentType);
        }

        // GET: EquipmentTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipmentType equipmentType = await db.EquipmentTypes.FindAsync(id);
            if (equipmentType == null)
            {
                return HttpNotFound();
            }
            return View(equipmentType);
        }

        // POST: EquipmentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EquipmentType equipmentType = await db.EquipmentTypes.FindAsync(id);
            db.EquipmentTypes.Remove(equipmentType);
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
