using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalsDAL.Model
{
    [Table("Rentals")]
    public class RentalDTO
    {
        [Key]
        public int RentID { get; set; }
        public string carReg { get; set; }
        public string CustName { get; set; }
        public System.DateTime RentDate { get; set; }
        public int RentFee { get; set; }
    }
}