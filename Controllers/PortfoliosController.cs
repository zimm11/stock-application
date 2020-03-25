using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StockApplication.Data;
using StockApplication.Models;
using System.Web;
using System.Security.Claims;
using StockApplication.Services;
using System.Net.Http;

namespace StockApplication.Controllers
{
    public class PortfoliosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public PortfoliosController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Portfolios
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            var portfolioList = await _context.Portfolios.Where(m => m.AppUser == currentUser).ToListAsync();
            
            foreach(var stock in portfolioList)
            {
                stock.CurrentPrice =  await StockApi.GetStockPrice(stock.Symbol);
               
            }

            return View(portfolioList);
        }

        // GET: Portfolios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            var portfolio = await _context.Portfolios
               .FirstOrDefaultAsync(m => m.ID == id);
            if (portfolio == null)
            {
                return NotFound();
            }

            return View(portfolio);
        }

        // GET: Portfolios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Portfolios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Portfolio model)
        {   
            try
            {
                if (ModelState.IsValid)
                {
                    var stockData = await StockApi.GetStockData(model.Symbol);
                    var portfolio = new Portfolio
                    {
                        ID = model.ID,
                        AppUser = await _userManager.GetUserAsync(User),
                        Symbol = model.Symbol,
                        CompanyName = stockData.CompanyName,
                        PurchaseDateTime = model.PurchaseDateTime,
                        AmountOfShares = model.AmountOfShares,
                        PricePerShare = model.PricePerShare,
                        TotalPurchasePrice = model.PricePerShare * model.AmountOfShares
                    };

                    _context.Add(portfolio);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (NullReferenceException)
            {
                ModelState.AddModelError("", "Unable to locate company for that symbol. Please check spelling and try again.");
            }
            catch (DataException dex)
            {
                Console.WriteLine(dex);
                ModelState.AddModelError("", "Unable to save your changes.  Please try again.");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error, Please try again.");
            }
            return View();
        }

        // GET: Portfolios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolio = await _context.Portfolios.FindAsync(id);
            if (portfolio == null)
            {
                return NotFound();
            }
            return View(portfolio);
        }

        // POST: Portfolios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Symbol,CompanyName,PurchaseDateTime,AmountOfShares,TotalPurchasePrice")] Portfolio portfolio)
        {
            if (id != portfolio.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(portfolio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortfolioExists(portfolio.ID))
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
            return View(portfolio);
        }

        // GET: Portfolios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolio = await _context.Portfolios
                .FirstOrDefaultAsync(m => m.ID == id);
            if (portfolio == null)
            {
                return NotFound();
            }

            return View(portfolio);
        }

        // POST: Portfolios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var portfolio = await _context.Portfolios.FindAsync(id);
            _context.Portfolios.Remove(portfolio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PortfolioExists(int id)
        {
            return _context.Portfolios.Any(e => e.ID == id);
        }
    }
}
