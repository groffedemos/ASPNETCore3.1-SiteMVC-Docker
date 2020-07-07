using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SiteContagem.Models;

namespace SiteContagem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static readonly Contador _CONTADOR = new Contador();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(
            [FromServices]IConfiguration configuration)
        {
            lock (_CONTADOR)
            {
                _CONTADOR.Incrementar();
                _logger.LogInformation($"Contador - Valor atual: {_CONTADOR.ValorAtual}");

                TempData["Contador"] = _CONTADOR.ValorAtual;
                TempData["Local"] = _CONTADOR.Local;
                TempData["Kernel"] = _CONTADOR.Kernel;
                TempData["TargetFramework"] = _CONTADOR.TargetFramework;
                TempData["MensagemFixa"] = "Teste";
                TempData["MensagemVariavel"] = configuration["MensagemVariavel"];
            }            

            return View();
        }

        public IActionResult Teste1()
        {
            TempData["Mensagem1"] = "Vendo uno 4 portas  ";
            return View();
        }

        public IActionResult Teste2()
        {
            TempData["Mensagem2"] = "Se vale jaba.. se inscrevam no meu canal.. kkkkk https://youtube.com/user/julioarrudac";
            return View();
        }

        public IActionResult Teste3()
        {
            TempData["Mensagem3"] = "Mensagem 3 - Renato (e não o Bot) esteve aqui";
            return View();
        }

        public IActionResult Teste4() 
        {
            TempData["Mensagem4"] = "Me sigam na Twitch : https://www.twitch.tv/tbertuzzi (propaganda 😉 ) ";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}