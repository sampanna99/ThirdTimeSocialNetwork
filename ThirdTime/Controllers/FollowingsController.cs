using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using ThirdTime.Dtos;
using ThirdTime.Models;

namespace ThirdTime.Controllers
{

    [Authorize]
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();
            if (_context.Followings.Any(f => f.FolloweeId == userId && f.FollowerId == dto.FollowerId))
            {
                return BadRequest("Following already exists");
            }
            var following = new Following
            {
                FolloweeId = userId,
                FollowerId = dto.FollowerId
            };
            _context.Followings.Add(following);
            _context.SaveChanges();

            return Ok();

        }
    }
}
