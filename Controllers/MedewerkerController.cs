using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCLibraryApp.Models;
using MVCLibraryApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;


namespace MVCLibraryApp.Controllers
{
    [Authorize(Roles = "Medewerker")]
    public class MedewerkerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedewerkerController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult ItemsAndAuthors()
        {
            var authors = _context.Auteurs.ToList();
            var items = _context.Items.Include(i => i.Auteur).ToList();

            ViewBag.Authors = authors;
            ViewBag.Items = items;

            return View();
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

        // GET: ItemModels
        public async Task<IActionResult> IndexItem()
        {
            var applicationDbContext = _context.Items.Include(i => i.Auteur).Include(i => i.Locatie);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ItemModels/Details/5
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

            lending.Status = "Returned";
            lending.Einddatum = DateTime.Now; // Set the end date as the current date
            lending.Item.Status = "Available"; // Set the item status to Available
                                               // Calculate any penalty costs if applicable
                                               // ...

            _context.SaveChanges();

            return RedirectToAction("LeningenBeheer");
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

            return RedirectToAction("ItemsAndAuthors");
        }
        // Alle leningen en reserveringen beheren
        public async Task<IActionResult> ManageLoansAndReservations()
        {
            var loans = await _context.Lenings.ToListAsync();
            var reservations = await _context.Reserveringen.ToListAsync();

            // Pass the loans and reservations data to the view
            ViewBag.Loans = loans;
            ViewBag.Reservations = reservations;

            return View();
        }

        // Volledige CRUD op Users met het type/level/rechten van Bezoeker
        public async Task<IActionResult> ManageUsers()
        {
            var users = await _context.Users.ToListAsync();

            // Pass the users data to the view
            ViewBag.Users = users;

            return View();
        }

        // Openstaande posten (facturen/openstaand bedrag) inzien
        public IActionResult ViewOutstandingInvoices()
        {
            // Implementation for viewing outstanding invoices
            return View();
        }

        // Betalingen verwerken
        public IActionResult ProcessPayments()
        {
            // Implementation for processing payments
            return View();
        }

        // Bezoeker accounts blokkeren
        public IActionResult BlockVisitorAccount()
        {
            // Implementation for blocking a visitor account
            return View();
        }

        // Locaties aan de Items toekennen
        public IActionResult AssignLocationsToItems()
        {
            // Implementation for assigning locations to items
            return View();
        }

        // Kan abonnementen toevoegen en annuleren
        public IActionResult AddSubscription()
        {
            // Implementation for adding a subscription
            return View();
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
    }
}
