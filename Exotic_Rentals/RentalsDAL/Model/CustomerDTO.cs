using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalsDAL.Model
{
    [Table("Customer")]
    public class CustomerDTO
    {
        [Key]
        public int CustId { get; set; }
        public string CustName { get; set; }
        public string CustAddress { get; set; }
        public string CustPhone { get; set; }
    }
}