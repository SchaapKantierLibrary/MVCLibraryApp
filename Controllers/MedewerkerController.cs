using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCLibraryApp.Models;
using Microsoft.EntityFrameworkCore;
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
            // Implementation for creating a new item
            return View();
        }

        [HttpPost]
        public IActionResult CreateItem(ItemModel model)
        {
            // Logic for creating a new item
            if (ModelState.IsValid)
            {
                _context.Items.Add(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Dashboard));
            }

            return View(model);
        }

        public IActionResult EditItem(int itemId)
        {
            // Implementation for editing an existing item
            var item = _context.Items.FirstOrDefault(item => item.ID == itemId);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        public IActionResult EditItem(ItemModel model)
        {
            // Logic for editing an existing item
            if (ModelState.IsValid)
            {
                var item = _context.Items.FirstOrDefault(item => item.ID == model.ID);
                if (item == null)
                {
                    return NotFound();
                }

                // Update the item properties
                item.Titel = model.Titel;
                item.Auteur = model.Auteur;
                item.Locatie = model.Locatie;
                // ... update other properties

                _context.SaveChanges();
                return RedirectToAction(nameof(Dashboard));
            }

            return View(model);
        }

        public IActionResult CreateAuthor()
        {
            // Implementation for creating a new author
            return View();
        }

        [HttpPost]
        public IActionResult CreateAuthor(AuteurModel model)
        {
            // Logic for creating a new author
            if (ModelState.IsValid)
            {
                _context.Auteurs.Add(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Dashboard));
            }

            return View(model);
        }

        public IActionResult EditAuthor(int authorId)
        {
            // Implementation for editing an existing author
            var author = _context.Auteurs.FirstOrDefault(author => author.ID == authorId);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        [HttpPost]
        public IActionResult EditAuthor(AuteurModel model)
        {
            // Logic for editing an existing author
            if (ModelState.IsValid)
            {
                var author = _context.Auteurs.FirstOrDefault(author => author.ID == model.ID);
                if (author == null)
                {
                    return NotFound();
                }

                // Update the author properties
                author.Name = model.Name;
                // ... update other properties

                _context.SaveChanges();
                return RedirectToAction(nameof(Dashboard));
            }

            return View(model);
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
