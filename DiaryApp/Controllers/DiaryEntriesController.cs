using DiaryApp.Data;
using DiaryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiaryApp.Controllers
{
    public class DiaryEntriesController : Controller
    {
        // 
        private readonly ApplicationDbContext _db;

        public DiaryEntriesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            // Get all diary entries from the database
            List<DiaryEntry> objDiaryEntryList = _db.DiaryEntries.ToList();

            // Return the list of diary entries to the view
            return View(objDiaryEntryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        // Create Action to handle the form post request

        [HttpPost]
        public IActionResult Create(DiaryEntry obj)
        {
            // Serverside Validation

            if (obj != null && obj.Title.Length < 3)
            {
                // ModelState is a property directly available to controllers. It give details about the state
                ModelState.AddModelError("Title", "Title too Short");
            }

            if (ModelState.IsValid)
            {
                // Add the obj passed from the form to the database
                _db.DiaryEntries.Add(obj); // Adds new diary entry to the database
                _db.SaveChanges(); // save changes to database
                                   // return RedirectToAction("Index", "Home");
                return RedirectToAction("Index");
            }

            return View(obj);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            DiaryEntry? diaryEntry = _db.DiaryEntries.Find(id);


            if (diaryEntry == null)
            {
                return NotFound();
            }
            return View(diaryEntry);        
        }

        [HttpPost]
        public IActionResult Edit(DiaryEntry obj)
        {
            // Serverside Validation

            if (obj != null && obj.Title.Length < 3)
            {
                // ModelState is a property directly available to controllers. It give details about the state
                ModelState.AddModelError("Title", "Title too Short");
            }

            if (ModelState.IsValid)
            {
                // Add the obj passed from the form to the database
                _db.DiaryEntries.Update(obj); // Update entry in the database
                _db.SaveChanges(); // save changes to database
                                   // return RedirectToAction("Index", "Home");
                return RedirectToAction("Index");
            }

            return View(obj);
        }
    }
}
