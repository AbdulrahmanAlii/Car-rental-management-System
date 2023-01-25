using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalsDAL.Model
{
    [Table("Returns")]
    public class ReturnDTO
    {
        [Key]
        public int ReturnID { get; set; }
        public string CarReg { get; set; }
        public string CustName { get; set; }
        public System.DateTime ReturnDate { get; set; }
        public int Fine { get; set; }
    }
}