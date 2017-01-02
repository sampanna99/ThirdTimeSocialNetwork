using System.Collections.Generic;
using ThirdTime.Models;

namespace ThirdTime.ViewModels
{
    public class HomeViewModel
    {
        public bool ShowActions { get; set; }
        public IEnumerable<Gig> UpcomingGigs { get; set; }
        public string Heading { get; set; }
    }
}