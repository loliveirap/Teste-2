using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TesteWebApiContatos.Models;

namespace TesteWebApiContatos.Controllers
{
    public class ContatoController : Controller
    {
        // GET: Contato
        public ActionResult Index()
        {
            var api = new HttpClient();
            api.BaseAddress = new Uri("http://localhost:7831/api/");

            var retorno = api.GetAsync("Contato").Result;
            
            if (retorno.IsSuccessStatusCode)
            {
                var _retorno = retorno.Content.ReadAsAsync<IEnumerable<Contato>>().Result;                

                var _contato = new List<Contato>();

                foreach(var item in _retorno)
                {
                    _contato.Add(new Contato
                    {
                        Nome = item.Nome,
                        Email = item.Email
                    });
                }

                return View(_contato);
            }
            return View();
        }
    }
}