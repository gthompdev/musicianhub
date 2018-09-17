using Microsoft.AspNet.Identity;
using MusicianHub.Models;
using MusicianHub.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace MusicianHub.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }


        [Authorize] //users cannot add a gig unless they are logged in
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = _context.Genres.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken] //avoids cross site request forgeries
        public ActionResult Create(GigFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList(); // set genres property of veiwModel
                return View("Create", viewModel);
            }
            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(), // used function to avoid reflection 
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };

            _context.Gigs.Add(gig);//access db
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");

        }
    }
}