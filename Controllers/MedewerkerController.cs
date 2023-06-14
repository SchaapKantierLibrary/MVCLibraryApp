using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCLibraryApp.Models;
using MVCLibraryApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MVCLibraryApp.Interfaces;
using MVCLibraryApp.Data;

namespace MVCLibraryApp.Controllers
{
    [Authorize(Roles = "Medewerker,Beheerder")]
    public class MedewerkerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<BezoekerModel> _userManager;
        private readonly IUserRedirectionService _redirectionService;
        private readonly IGenerateInvoiceService _generateInvoiceService;


        public MedewerkerController(ApplicationDbContext context, UserManager<BezoekerModel> userManager, IUserRedirectionService redirectionService, IGenerateInvoiceService generateInvoiceService)
        {
            _context = context;
            _userManager = userManager;
            _redirectionService = redirectionService;
            _generateInvoiceService = generateInvoiceService;
        }


        public async Task<IActionResult> Dashboard()
        {
            var result = await _redirectionService.GetRedirectBasedOnRole(User);
            if (result != null)
                return result;

            return View();
        }

        public async Task<IActionResult> IndexBezoeker()
        {
            var users = await _userManager.GetUsersInRoleAsync("Bezoeker");
            var usersWithRoles = new List<(BezoekerModel, IList<string>)>();
            var userLockoutStatus = new Dictionary<string, bool>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                usersWithRoles.Add((user, roles));
                var lockoutEndDate = await _userManager.GetLockoutEndDateAsync(user);
                userLockoutStatus.Add(user.Id, lockoutEndDate.HasValue && lockoutEndDate.Value > DateTimeOffset.Now);
            }

            // Eagerly load the Abonnement property for each user
            await _context.Bezoekers.Include(b => b.Abonnement).LoadAsync();

            ViewBag.Bezoekers = users;
            ViewBag.Rol = usersWithRoles.ToDictionary(x => x.Item1.Id, x => x.Item2);
            ViewBag.LockoutStatus = userLockoutStatus;

            return View(users);
        }



        public IActionResult CreateBezoeker()
        {
            try
            {
                // This should actually come from your database.
                var abonnementenList = _context.Abonnementen.ToList();
                ViewBag.Abonnementen = new SelectList(abonnementenList, "ID", "Type"); // Notice ID (not Id)
            }
            catch (Exception ex)
            {
                // Log or handle exception as needed
                Console.WriteLine(ex.Message);
            }

            return View(new CreateBezoekerViewModel());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBezoeker(CreateBezoekerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var abonnement = _context.Abonnementen.Find(model.AbonnementID);
                    if (abonnement != null)
                    {
                        var user = new BezoekerModel
                        {
                            UserName = model.Email,
                            Email = model.Email,
                            Naam = model.Naam,
                            AbonnementID = model.AbonnementID,
                        };

                        var result = await _userManager.CreateAsync(user, model.Password);
                        if (result.Succeeded)
                        {
                            await _userManager.AddToRoleAsync(user, "Bezoeker");
                            await _context.SaveChangesAsync();
                            return RedirectToAction(nameof(IndexBezoeker));
                        }
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Abonnement ID.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle exception as needed
                Console.WriteLine(ex.Message);
            }

            // If we got this far, something failed, so redisplay form
            try
            {
                var abonnementenList = _context.Abonnementen.ToList();
                ViewBag.Abonnementen = new SelectList(abonnementenList, "ID", "Type");
            }
            catch (Exception ex)
            {
                // Log or handle exception as needed
                Console.WriteLine(ex.Message);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditBezoeker(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var abonnementenList = _context.Abonnementen.ToList();
            ViewBag.Abonnementen = new SelectList(abonnementenList, "ID", "Type");

            var model = new BezoekerViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Naam = user.Naam,
                AbonnementID = user.AbonnementID
            };

            Console.WriteLine("EditBezoeker - User found: " + user.Email); // Debugging statement
            Console.WriteLine("EditBezoeker - Abonnementen count: " + abonnementenList.Count); // Debugging statement

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBezoeker(BezoekerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.FindByIdAsync(model.Id);
                    if (user == null)
                    {
                        return NotFound();
                    }

                    user.Email = model.Email;
                    user.Naam = model.Naam;
                    user.AbonnementID = model.AbonnementID;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(IndexBezoeker));
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle exception as needed
                Console.WriteLine(ex.Message);
            }

            // If we got this far, something failed, so redisplay form
            try
            {
                var abonnementenList = _context.Abonnementen.ToList();
                ViewBag.Abonnementen = new SelectList(abonnementenList, "ID", "Type");
            }
            catch (Exception ex)
            {
                // Log or handle exception as needed
                Console.WriteLine(ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBezoeker(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(IndexBezoeker));
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            // If we got this far, something failed, so redisplay form
            // Replace 'YourView' with the name of the view you want to display in case of an error
            return View("IndexBezoeker");
        }

        [HttpPost]
        public async Task<IActionResult> ToggleBlockUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                var lockoutEndDate = await _userManager.GetLockoutEndDateAsync(user);
                if (lockoutEndDate.HasValue && lockoutEndDate.Value > DateTimeOffset.Now)  // if user is blocked
                {
                    await _userManager.SetLockoutEndDateAsync(user, null);  // unblock the user
                }
                else
                {
                    await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.MaxValue);  // block the user
                }

                return RedirectToAction("IndexBezoeker");
            }

            return NotFound();
        }


        private FactuurModel CalculateFineAndGenerateInvoice(LeningModel lending, BezoekerModel user)
        {
            return _generateInvoiceService.CalculateFineAndGenerateInvoice(lending, user);
        }



        public IActionResult LeningenBeheer()
        {
            var availableItems = _context.Items.Where(item => item.Status == "Available").ToList();
            var ReservedItems = _context.Items.Where(item => item.Status == "Not Available").ToList();

            // Here is where you fetch the loans
            var loans = _context.Lenings.Include(l => l.Item)
                                 .ThenInclude(i => i.Auteur)
                                 .Include(l => l.Bezoeker)
                                 .Where(l => l.Status == "Borrowed")  // Only include loans with status "Borrowed"
                                 .ToList();

            var reservations = _context.Reserveringen.ToList();
            var users = _context.Users.ToList();


            ViewBag.AvailableItems = availableItems;
            ViewBag.ReservedItems = ReservedItems;
            ViewBag.Loans = loans;
            ViewBag.Reservations = reservations;
            ViewBag.Users = users;

            return View();
        }


        [HttpPost]
        public IActionResult LendItem(int itemId)
        {
            // Get the item
            var item = _context.Items.FirstOrDefault(i => i.ID == itemId);

            if (item != null)
            {
                // Delete the reservation for this item
                var reservation = _context.Reserveringen.FirstOrDefault(r => r.ItemID == itemId);
                if (reservation != null)
                {
                    _context.Reserveringen.Remove(reservation);

                    // Create a new Lening
                    var lening = new LeningModel
                    {
                        ItemID = itemId,
                        BezoekerID = reservation.BezoekerID,  // Get the user id from the reservation
                        Startdatum = DateTime.Now,
                        Einddatum = DateTime.Now.AddDays(7),  // one week from now
                        Status = "Borrowed",
                        Boetekosten = 0,
                        // Set other properties as needed
                    };

                    _context.Lenings.Add(lening);
                    item.Status = "Not Available";  // Update item status
                    _context.SaveChanges();  // Save changes
                }
            }

            // Redirect to the Dashboard view
            return RedirectToAction("LeningenBeheer");
        }

        [HttpPost]
        public IActionResult ReturnItem(int itemId)
        {
            var lending = _context.Lenings.Include(l => l.Item).FirstOrDefault(l => l.Item.ID == itemId);
            if (lending == null)
            {
                return NotFound();
            }

            var user = _context.Users.Find(lending.BezoekerID);

            // Call our new method
            var invoice = CalculateFineAndGenerateInvoice(lending, user);

            // Save changes
            _context.SaveChanges();

            if (invoice != null)
            {
                return RedirectToAction("ConfirmPayment", "Medewerker", new { id = invoice.Id });
            }

            // return to LeningenBeheer if there is no invoice (item is returned on time)
            return RedirectToAction("LeningenBeheer");
        }


        public IActionResult ConfirmPayment(int Id)
        {
            // Fetch the specific invoice from the database
            var invoice = _context.Facturen.Find(Id);

            if (invoice == null)
            {
                // Handle the case when no invoice is found
                return NotFound();
            }

            return View(invoice);  // Pass invoice to the view
        }
        [HttpPost]
        public IActionResult ProcessPayment(int id)  // Change parameter name from "Id" to "id"
        {
            var invoice = _context.Facturen.Find(id);  // Use the "id" parameter
            if (invoice == null)
            {
                return NotFound();
            }

            // Mark invoice as Paid
            invoice.Description = "Paid";

            // Fetch the lending
            var lending = _context.Lenings.Include(l => l.Item).FirstOrDefault(l => l.Item.ID == invoice.ItemID);
            if (lending == null)
            {
                return NotFound();
            }

            // Update the item status and lending status
            lending.Status = "Returned";
            lending.Einddatum = DateTime.Now;
            lending.Item.Status = "Available";

            // Update Geldbank TotalEarnings
            var geldbank = _context.Geldbank.FirstOrDefault(g => g.ID == 1);
            if (geldbank != null)
            {
                geldbank.TotalEarnings += invoice.Amount;
            }

            // Save changes
            _context.SaveChanges();

            // Redirect to the LeningenBeheer action
            return RedirectToAction("LeningenBeheer", "Medewerker");
        }

        public async Task<IActionResult> IndexFactuur()
        {
            var applicationDbContext = _context.Facturen.Include(f => f.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FactuurModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Facturen == null)
            {
                return NotFound();
            }

            var factuurModel = await _context.Facturen
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (factuurModel == null)
            {
                return NotFound();
            }

            return View(factuurModel);
        }



        // GET: ItemModels
        public async Task<IActionResult> IndexItem()
        {
            var applicationDbContext = _context.Items.Include(i => i.Auteur).Include(i => i.Locatie);
            return View(await applicationDbContext.ToListAsync());
        }


        public async Task<IActionResult> DetailsItem(int? id)
        {
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }

            var itemModel = await _context.Items
                .Include(i => i.Auteur)
                .Include(i => i.Locatie)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (itemModel == null)
            {
                return NotFound();
            }

            return View(itemModel);
        }


        // Items en Authors aanmaken en bewerken
        public IActionResult CreateItem()
        {
            ViewBag.AuteurID = new SelectList(_context.Auteurs, "ID", "ID");
            ViewBag.LocatieID = new SelectList(_context.Locaties, "ID", "ID");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateItem(ItemViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Map the properties from the view model to the entity model
                var itemModel = new ItemModel
                {
                    Titel = viewModel.Titel,
                    AuteurID = viewModel.AuteurID,
                    Status = "Available",
                    Publicatiejaar = viewModel.Publicatiejaar,
                    LocatieID = viewModel.LocatieID
                };

                _context.Add(itemModel);
                await _context.SaveChangesAsync();

                return RedirectToAction("IndexItem", "Medewerker"); // Replace "YourControllerName" with the actual name of your controller
            }

            ViewBag.AuteurID = new SelectList(_context.Auteurs, "ID", "ID", viewModel.AuteurID);
            ViewBag.LocatieID = new SelectList(_context.Locaties, "ID", "ID", viewModel.LocatieID);

            return View("IndexItem");
        }


        [HttpGet]
        public IActionResult EditItem(int id)
        {
            var item = _context.Items.FirstOrDefault(i => i.ID == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        public IActionResult EditItem(ItemModel itemModel)
        {
            var item = _context.Items.FirstOrDefault(i => i.ID == itemModel.ID);
            if (item == null)
            {
                return NotFound();
            }

            // Update properties
            item.Titel = itemModel.Titel;
            item.AuteurID = itemModel.AuteurID;
            item.Publicatiejaar = itemModel.Publicatiejaar;
            item.Status = itemModel.Status;
            item.LocatieID = itemModel.LocatieID;

            _context.SaveChanges();

            return RedirectToAction("IndexItem");
        }

        // GET: AuteurModels
        public async Task<IActionResult> IndexAuthor()
        {
            return _context.Auteurs != null ?
                        View(await _context.Auteurs.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Auteurs'  is null.");
        }

        // GET: AuteurModels/Details/5
        public async Task<IActionResult> DetailsAuthor(int? id)
        {
            if (id == null || _context.Auteurs == null)
            {
                return NotFound();
            }

            var auteurModel = await _context.Auteurs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (auteurModel == null)
            {
                return NotFound();
            }

            return View(auteurModel);
        }


        public IActionResult CreateAuthor()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAuthor(AuteurViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var auteurModel = new AuteurModel
                {
                    Name = viewModel.Name,
                    Bio = viewModel.Bio
                };

                _context.Add(auteurModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("IndexAuthor", "Medewerker");
            }

            return View(viewModel);
        }


        [HttpGet]
        public IActionResult EditAuthor(int id)
        {
            var author = _context.Auteurs.FirstOrDefault(a => a.ID == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        [HttpPost]
        public IActionResult EditAuthor(AuteurModel authorModel)
        {
            var author = _context.Auteurs.FirstOrDefault(a => a.ID == authorModel.ID);
            if (author == null)
            {
                return NotFound();
            }

            // Update properties
            author.Name = authorModel.Name;
            author.Bio = authorModel.Bio;

            _context.SaveChanges();

            return RedirectToAction("IndexAuthor");
        }
       
        [HttpPost]
        public IActionResult AddSubscription(ReserveringModel model)
        {
            // Logic for adding a subscription
            if (ModelState.IsValid)
            {
                _context.Reserveringen.Add(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Dashboard));
            }

            return View(model);
        }

        public IActionResult CancelSubscription(int subscriptionId)
        {
            // Implementation for canceling a subscription
            var subscription = _context.Reserveringen.FirstOrDefault(subscription => subscription.ID == subscriptionId);
            if (subscription == null)
            {
                return NotFound();
            }

            return View(subscription);
        }

        [HttpPost]
        public IActionResult CancelSubscription(int subscriptionId, bool confirmCancellation)
        {
            // Logic for canceling a subscription
            if (confirmCancellation)
            {
                var subscription = _context.Reserveringen.FirstOrDefault(subscription => subscription.ID == subscriptionId);
                if (subscription == null)
                {
                    return NotFound();
                }

                _context.Reserveringen.Remove(subscription);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Dashboard));
        }

        // GET: AbonnementModels
        public async Task<IActionResult> IndexAbonnement()
        {
            return _context.Abonnementen != null ?
                        View(await _context.Abonnementen.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Abonnementen'  is null.");
        }

      
    

        // GET: AbonnementModels/Create
        public IActionResult CreateAbonnement()
        {
            return View();
        }

        // POST: AbonnementModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAbonnement([Bind("ID,Type,MaximaleItems,Uitleentermijn,Verlengingen,Reserveringskosten,Boetekosten,Abonnementskosten")] AbonnementModel abonnementModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(abonnementModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(abonnementModel);
        }

        // GET: AbonnementModels/Edit/5
        public async Task<IActionResult> EditAbonnement(int? id)
        {
            if (id == null || _context.Abonnementen == null)
            {
                return NotFound();
            }

            var abonnementModel = await _context.Abonnementen.FindAsync(id);
            if (abonnementModel == null)
            {
                return NotFound();
            }
            return View(abonnementModel);
        }

        // POST: AbonnementModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAbonnement(int id, [Bind("ID,Type,MaximaleItems,Uitleentermijn,Verlengingen,Reserveringskosten,Boetekosten,Abonnementskosten")] AbonnementModel abonnementModel)
        {
            if (id != abonnementModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(abonnementModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbonnementModelExists(abonnementModel.ID))
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
            return View(abonnementModel);
        }

        // GET: AbonnementModels/Delete/5
        public async Task<IActionResult> DeleteAbonnement(int? id)
        {
            if (id == null || _context.Abonnementen == null)
            {
                return NotFound();
            }

            var abonnementModel = await _context.Abonnementen
                .FirstOrDefaultAsync(m => m.ID == id);
            if (abonnementModel == null)
            {
                return NotFound();
            }

            return View(abonnementModel);
        }

        // POST: AbonnementModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Abonnementen == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Abonnementen'  is null.");
            }
            var abonnementModel = await _context.Abonnementen.FindAsync(id);
            if (abonnementModel != null)
            {
                _context.Abonnementen.Remove(abonnementModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AbonnementModelExists(int id)
        {
            return (_context.Abonnementen?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }

}

