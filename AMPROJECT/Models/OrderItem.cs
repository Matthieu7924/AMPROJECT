using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMPROJECT.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int Quantite { get; set; }   
        public double Montant { get; set; }    

        public double Prix { get; set; }




        public int FilmId { get; set; }

        [ForeignKey("FilmId")]
        public virtual Film Film { get; set; }



        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
    }
}
