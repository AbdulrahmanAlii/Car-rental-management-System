using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalsDAL.Model
{
    [Table("Car")]
    public class CarDTO
    {
        [Key]
        public int Id { get; set; }
        public string RegNum { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Available { get; set; }
        public double Price { get; set; }
    }
}