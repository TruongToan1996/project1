using System.ComponentModel.DataAnnotations;

namespace Aptech3.Models.Bookings
{
    public class BookingInput
    {
        //public int BookingId { get; set; }

        [Required(ErrorMessage = "Customer ID is required")]
        public int? CustomerId { get; set; }
        [Required(ErrorMessage = "User ID is required")]
        public string UserId { get; set; }
        [Required(ErrorMessage = "Bus ID is required")]
        public int? BusId { get; set; }

        public DateTime? BookingDate { get; set; }

        public DateTime? TravelDate { get; set; }

        public int? NumberOfSeats { get; set; }

        public int? TotalPrice { get; set; }

        public string? PaymentStatus { get; set; }

        public string? Status { get; set; }

        public string? Description { get; set; }

    }
}
