using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_CRUD_app.Models;
using X.PagedList;

namespace Web_CRUD_app.Controllers
{
    public class Products : Controller
    {
        private readonly DB _context;

        public Products(DB context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index(int? page) //add page parameter
        {

            var pageNumber = page ?? 1; // default number of pages

            int pageSize = 10; //max product amount on one page

            List<tblProduct> products = _context.Products.ToList(); // product to list

            var onePageOfProducts = products.ToPagedListAsync(pageNumber, pageSize);


            return View(await onePageOfProducts); //send 10 product to the page

        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProduct = await _context.Products
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tblProduct == null)
            {
                return NotFound();
            }

            return View(tblProduct);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ProductName,Price,UnitOfMeasure")] tblProduct tblProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblProduct);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProduct = await _context.Products.FindAsync(id);
            if (tblProduct == null)
            {
                return NotFound();
            }
            return View(tblProduct);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ProductName,Price,UnitOfMeasure")] tblProduct tblProduct)
        {
            if (id != tblProduct.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblProductExists(tblProduct.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tblProduct);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProduct = await _context.Products
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tblProduct == null)
            {
                return NotFound();
            }

            return View(tblProduct);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblProduct = await _context.Products.FindAsync(id);
            _context.Products.Remove(tblProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblProductExists(int id)
        {
            return _context.Products.Any(e => e.ID == id);
        }
    }
}
