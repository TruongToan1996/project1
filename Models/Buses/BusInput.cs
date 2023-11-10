using Aptech3.Models.Bookings;
using System.ComponentModel.DataAnnotations;

namespace Aptech3.Models.Buses
{
    public class BusInput
    {
        [Required(ErrorMessage = "BusName is required")]
        public string? BusName { get; set; }

        [Required(ErrorMessage = "BusType ID is required")]
        public int? BusTypeId { get; set; }

        [Required(ErrorMessage = "TotalSeats is required")]
        public int? TotalSeats { get; set; }

        [Required(ErrorMessage = "RouteId is required")]
        public int? RouteId { get; set; }

        public TimeSpan? DepartureTime { get; set; }

        public int? AvailableSeats { get; set; }

        public string? Description { get; set; }
      
    }
}
