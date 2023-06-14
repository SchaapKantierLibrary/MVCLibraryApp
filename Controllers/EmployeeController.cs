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
    [Authorize(Roles = "Employee,Admin")]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<VisitorModel> _userManager;
        private readonly IUserRedirectionService _redirectionService;
        private readonly IGenerateInvoiceService _generateInvoiceService;


        public EmployeeController(ApplicationDbContext context, UserManager<VisitorModel> userManager, IUserRedirectionService redirectionService, IGenerateInvoiceService generateInvoiceService)
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

        public async Task<IActionResult> IndexVisitor()
        {
            var users = await _userManager.GetUsersInRoleAsync("Visitor");
            var usersWithRoles = new List<(VisitorModel, IList<string>)>();
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



        public IActionResult CreateVisitor()
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

            return View(new CreateVisitorViewModel());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVisitor(CreateVisitorViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var abonnement = _context.Abonnementen.Find(model.AbonnementID);
                    if (abonnement != null)
                    {
                        var user = new VisitorModel
                        {
                            UserName = model.Email,
                            Email = model.Email,
                            Name = model.Name,
                            AbonnementID = model.AbonnementID,
                        };

                        var result = await _userManager.CreateAsync(user, model.Password);
                        if (result.Succeeded)
                        {
                            await _userManager.AddToRoleAsync(user, "Visitor");
                            await _context.SaveChangesAsync();
                            return RedirectToAction(nameof(IndexVisitor));
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
        public async Task<IActionResult> EditVisitor(string id)
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

            var model = new VisitorViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                AbonnementID = user.AbonnementID
            };

            Console.WriteLine("EditVisitor - User found: " + user.Email); // Debugging statement
            Console.WriteLine("EditVisitor - Abonnementen count: " + abonnementenList.Count); // Debugging statement

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditVisitor(VisitorViewModel model)
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
                    user.Name = model.Name;
                    user.AbonnementID = model.AbonnementID;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(IndexVisitor));
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
        public async Task<IActionResult> DeleteVisitor(string id)
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
                return RedirectToAction(nameof(IndexVisitor));
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
            return View("IndexVisitor");
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

                return RedirectToAction("IndexVisitor");
            }

            return NotFound();
        }


        private Models.InvoiceModel CalculateFineAndGenerateInvoice(LoanModel lending, VisitorModel user)
        {
            return _generateInvoiceService.CalculateFineAndGenerateInvoice(lending, user);
        }



        public IActionResult LoansManagement()
        {
            var availableItems = _context.Items.Where(item => item.Status == "Available").ToList();
            var ReservedItems = _context.Items.Where(item => item.Status == "Not Available").ToList();

            // Here is where you fetch the loans
            var loans = _context.Lenings.Include(l => l.Item)
                                 .ThenInclude(i => i.Author)
                                 .Include(l => l.Visitor)
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
                    var lening = new LoanModel
                    {
                        ItemID = itemId,
                        VisitorID = reservation.VisitorID,  // Get the user id from the reservation
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(7),  // one week from now
                        Status = "Borrowed",
                        FineCosts = 0,
                        // Set other properties as needed
                    };

                    _context.Lenings.Add(lening);
                    item.Status = "Not Available";  // Update item status
                    _context.SaveChanges();  // Save changes
                }
            }

            // Redirect to the Dashboard view
            return RedirectToAction("LoansManagement");
        }

        [HttpPost]
        public IActionResult ReturnItem(int itemId)
        {
            var lending = _context.Lenings.Include(l => l.Item).FirstOrDefault(l => l.Item.ID == itemId);
            if (lending == null)
            {
                return NotFound();
            }

            var user = _context.Users.Find(lending.VisitorID);

            // Call our new method
            var invoice = CalculateFineAndGenerateInvoice(lending, user);

            // Save changes
            _context.SaveChanges();

            if (invoice != null)
            {
                return RedirectToAction("ConfirmPayment", "Employee", new { id = invoice.Id });
            }

            // return to LoansManagement if there is no invoice (item is returned on time)
            return RedirectToAction("LoansManagement");
        }


        public IActionResult ConfirmPayment(int Id)
        {
            // Fetch the specific invoice from the database
            var invoice = _context.Invoice.Find(Id);

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
            var invoice = _context.Invoice.Find(id);  // Use the "id" parameter
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
            lending.EndDate = DateTime.Now;
            lending.Item.Status = "Available";

            // Update Geldbank TotalEarnings
            var geldbank = _context.Geldbank.FirstOrDefault(g => g.ID == 1);
            if (geldbank != null)
            {
                geldbank.TotalEarnings += invoice.Amount;
            }

            // Save changes
            _context.SaveChanges();

            // Redirect to the LoansManagement action
            return RedirectToAction("LoansManagement", "Employee");
        }

        public async Task<IActionResult> IndexInvoice()
        {
            var applicationDbContext = _context.Invoice.Include(f => f.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FactuurModels/DetailsInvoice/5
        public async Task<IActionResult> DetailsInvoice(int? id)
        {
            if (id == null || _context.Invoice == null)
            {
                return NotFound();
            }

            var factuurModel = await _context.Invoice
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
            var applicationDbContext = _context.Items.Include(i => i.Author).Include(i => i.Location);
            return View(await applicationDbContext.ToListAsync());
        }


        public async Task<IActionResult> DetailsItem(int? id)
        {
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }

            var itemModel = await _context.Items
                .Include(i => i.Author)
                .Include(i => i.Location)
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
                    Title = viewModel.Titel,
                    AuthorID = viewModel.AuthorID,
                    Status = "Available",
                    PublicationYear = viewModel.PublicationYear,
                    LocationID = viewModel.LocationID
                };

                _context.Add(itemModel);
                await _context.SaveChangesAsync();

                return RedirectToAction("IndexItem", "Employee"); // Replace "YourControllerName" with the actual name of your controller
            }

            ViewBag.AuteurID = new SelectList(_context.Auteurs, "ID", "ID", viewModel.AuthorID);
            ViewBag.LocatieID = new SelectList(_context.Locaties, "ID", "ID", viewModel.LocationID);

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
            item.Title = itemModel.Title;
            item.AuthorID = itemModel.AuthorID;
            item.PublicationYear = itemModel.PublicationYear;
            item.Status = itemModel.Status;
            item.LocationID = itemModel.LocationID;

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

        // GET: AuteurModels/DetailsInvoice/5
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
        public async Task<IActionResult> CreateAuthor(AuthorViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var auteurModel = new AuthorModel
                {
                    Name = viewModel.Name,
                    Bio = viewModel.Bio
                };

                _context.Add(auteurModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("IndexAuthor", "Employee");
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
        public IActionResult EditAuthor(AuthorModel authorModel)
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
        public IActionResult AddSubscription(ReservationModel model)
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
        public async Task<IActionResult> CreateAbonnement([Bind("ID,Type,MaxItems,ReturnTerm,ProlongedTerm,ReservationCosts,FineCosts,AbonnementsCosts")] AbonnementModel abonnementModel)
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
        public async Task<IActionResult> EditAbonnement(int id, [Bind("ID,Type,MaxItems,ReturnTerm,ProlongedTerm,ReservationCosts,FineCosts,AbonnementsCosts")] AbonnementModel abonnementModel)
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

