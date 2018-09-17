using Microsoft.AspNet.Identity;
using MusicianHub.Dtos;
using MusicianHub.Models;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace MusicianHub.Controllers
{
    [System.Web.Http.Authorize] //only accessible by authenticated users
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

       
        [System.Web.Mvc.HttpPost] // Will only be called with HttpPost
        [ValidateAntiForgeryToken]
        public IHttpActionResult Attend(AttendanceDto dto) // created AttendanceDto class for data transfer objects between client/server
        {
            var userId = User.Identity.GetUserId();

            if (_context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == dto.GigId))
            {
                return BadRequest("The attendance already exists.");
            }

            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}
