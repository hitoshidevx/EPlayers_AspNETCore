using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EPlayers_AspNETCore.Models;
using Microsoft.AspNetCore.Http;

namespace EPlayers_AspNETCore.Controllers
{
    public class NoticiasController : Controller
    {

        Noticias noticiasModel = new Noticias();
        public IActionResult Index()
        {
            ViewBag.Noticia = noticiasModel.ReadAll();
            return View();
        }
        public IActionResult Cadastrar(IFormCollection form)
        {
            Noticias novaNoticia  = new Noticias();
            novaNoticia.IdNoticia = Int32.Parse(  form["IdNoticia"]  );
            novaNoticia.Titulo    = form["Título"];
            novaNoticia.Texto     = form["Texto"];
            novaNoticia.Imagem    = form["Imagem"];

            noticiasModel.Create(novaNoticia);
            return LocalRedirect("~/Noticias");
        }
    }
}
