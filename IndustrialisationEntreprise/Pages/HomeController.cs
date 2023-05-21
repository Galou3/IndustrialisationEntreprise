using IndustrialisationEntreprise.Pages;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var entrepot = await _context.Entrepots.FirstOrDefaultAsync();
        if (entrepot == null)
        {
            entrepot = new Entrepot { EspaceLibre = 100 }; // Initialise l'entrepôt avec 100 d'espace libre
            _context.Entrepots.Add(entrepot);
            await _context.SaveChangesAsync();
        }

        return View(entrepot);
    }

    [HttpPost]
    public async Task<IActionResult> Ajouter()
    {
        var entrepot = await _context.Entrepots.FirstOrDefaultAsync();
        if (entrepot != null)
        {
            entrepot.AjouterStock(1); // Ajoute du stock. Adaptez la quantité en fonction de vos besoins.
            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Index");
    }
}
