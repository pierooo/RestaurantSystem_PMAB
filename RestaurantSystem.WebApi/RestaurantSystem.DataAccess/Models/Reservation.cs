namespace RestaurantSystem.DataAccess.Models
{
    public class Reservation : EntityBase
    {
        public RestaurantTable? RestaurantTable { get; set; }

        public int RestaurantTableId { get; set; }

        public DateTime ReservationDate { get; set; }

        public string? Status { get; set; }

        public string? Description { get; set; }
    }
}
