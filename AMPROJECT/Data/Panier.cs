using AMPROJECT.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMPROJECT.Data
{
    [Table("Panier")]

    public class Panier
    {

        public MyDbContext _context { get; set; }
        public string? PanierId { get; set; }

        public List<PanierItem> PaniersItems { get; set; }
        public Panier(MyDbContext context)
        {
            _context = context;

        }

        public void AjouterAuPanier(Film film)
        {
            var panierItem = _context.PanierItems.FirstOrDefault(n => n.Films.Id == film.Id &&  n.PanierItemId == PanierId);
            if (panierItem == null)
            {
                panierItem = new PanierItem()
                {
                    PanierItemId = PanierId,
                    Films = film,
                    Quantites = 1
                };

                _context.PanierItems.Add(panierItem);
            }
            else
            {
                panierItem.Quantites++;
            }

            _context.SaveChanges();
        }

        public void SuprimeItemPanier(Film film)
        {
            var panierItem = _context.PanierItems.FirstOrDefault(n => n.Films.Id == film.Id && n.PanierItemId == PanierId);
            if (panierItem != null)
            {
              if(panierItem.Quantites > 1)
                {
                    panierItem.Quantites--;
                }
                else
                {
                    _context.PanierItems.Remove(panierItem);
                }

             
            }
           
            _context.SaveChanges();


        }
        public List<PanierItem> GetPanierItems()
        {
            return PaniersItems ?? (PaniersItems = _context
                .PanierItems.Where(n => n.PanierItemId == PanierId).Include(n => n.Films).ToList());

        }

        public double GetPanierTotal()
        {
            var total = _context.PanierItems.Where(n => n.PanierItemId == PanierId).Select(n => n.Films.Prix * n.Quantites).Sum();

            return (double)total;
        }

        //[Key]
        //public int PanierId { get; set; }

        //public int FilmId { get; set; }
        //[ForeignKey(nameof(FilmId))]
        // public Film? Films { get; set; }

        //public ICollection<Livre> LivrePaniers { get; set; }


        //public User? Users { get; set; }



    }
}
