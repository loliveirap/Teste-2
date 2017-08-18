using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace TesteWebApiContatos.Controllers
{
    public class AutenticacaoController : Controller
    {
        // GET: Autenticacao
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string senha)
        {
            var api = new HttpClient();
            api.BaseAddress = new Uri("http://localhost:7831/api/");

            var content = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("email", email),
                new KeyValuePair<string, string>("senha", senha)
            });

            var retorno = api.PostAsync("Autenticacao", content).Result;
            if (retorno.IsSuccessStatusCode) {
                //var _retorno = retorno.Content.ReadAsStringAsync().Result;
		
		FormsAuthentication.SetAuthCookie(email, false);
                return RedirectToAction("Index", "Contato");
            }
            return View();
        }
	
	public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Autenticacao");
        }
    }
}



            //if(txtUsuario == "convenios" || txtUsuario == "CONVENIOS" || txtUsuario == "Convenios" && txtSenha == "admin2017")
            //{
            //    FormsAuthentication.SetAuthCookie(txtUsuario, false);
            //    return RedirectToAction("Index", "Home");
            //}
            //else
            //{
            //    TempData.Add("Erro", "Usuário ou senha incorretos.");
            //    return View();
            //}