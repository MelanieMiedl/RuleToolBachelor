using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RuleTool.Data;
using RuleTool.Models;

namespace RuleTool.Controllers
{
    public class RulesController : Controller
    {
        private readonly RuleToolContext _context;

        public RulesController(RuleToolContext context)
        {
            _context = context;
        }

        // GET: Rules
        public async Task<IActionResult> Index(string searchString)
        {
            var rules = from m in _context.Rule
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                rules = rules.Where(s => s.Name.Contains(searchString));
            }

            return View(await rules.ToListAsync());
        }

        // GET: Rules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rule = await _context.Rule
                .FirstOrDefaultAsync(m => m.id == id);
            if (rule == null)
            {
                return NotFound();
            }

            return View(rule);
        }

        // GET: Rules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,FieldLeft,Operator,FieldRight,Description,Creator,Region,CreationDate")] Rule rule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rule);
        }

        // GET: Rules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rule = await _context.Rule.FindAsync(id);
            if (rule == null)
            {
                return NotFound();
            }
            return View(rule);
        }

        // POST: Rules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,FieldLeft,Operator,FieldRight,Description,Creator,Region,CreationDate")] Rule rule)
        {
            if (id != rule.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RuleExists(rule.id))
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
            return View(rule);
        }

        // GET: Rules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rule = await _context.Rule
                .FirstOrDefaultAsync(m => m.id == id);
            if (rule == null)
            {
                return NotFound();
            }

            return View(rule);
        }

        // POST: Rules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rule = await _context.Rule.FindAsync(id);
            _context.Rule.Remove(rule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RuleExists(int id)
        {
            return _context.Rule.Any(e => e.id == id);
        }
    }
}
