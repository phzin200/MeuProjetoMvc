using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MeuProjetoMvc.Models;
using Microsoft.AspNetCore.Authorization;

namespace MeuProjetoMvc.Controllers;

public class HomeController : Controller
{
    [Authorize]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [AllowAnonymous]
   public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
