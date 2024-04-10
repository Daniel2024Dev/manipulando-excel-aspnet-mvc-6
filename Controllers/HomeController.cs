using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AgendaVeicular.Models;

namespace AgendaVeicular.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        RepositoryAnotacaoModel repository = new RepositoryAnotacaoModel();// Cria uma instância do repositório
        repository.CriaDiretorio();// Chama o método CriaDiretorio() para criar o diretório e o arquivo de banco de dados, se não existirem
        
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}