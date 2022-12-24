using AMPROJECT.Data;
using AMPROJECT.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AMPROJECT.Controllers
{
    public class AchatController1 : Controller
    {

        public readonly Panier _panier;

        public AchatController1(Panier panier)
        {
            _panier = panier;
        }

        public IActionResult Index()
        {
            var items = _panier.GetPanierItems();
            _panier.PaniersItems= items;
            var response = new PanierViewModel()
            {
                Panier = _panier,
                PanierTotal = _panier.GetPanierTotal()
            };

            return View(response);
        }
    }
}
