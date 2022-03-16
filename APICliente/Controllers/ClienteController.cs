using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using APICliente.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace APICliente.Controllers
{
    public class ClienteController : Controller
    {
        HttpClient client;
        public ClienteController()
        {
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:62959/");
                client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            }
        }
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        //incluindo um novo produto
        //[HttpGet]
        //public ActionResult Incluir()
        //{
        //    return View();
        //}

        [HttpPost]
        public async Task<ActionResult> Listar(LimiteCliente cliente)
        {
            try
            {
                
                var response = await client.GetAsync("api/clientes/listaclientes");
                if (response.IsSuccessStatusCode)
                {

                    var resultado = await response.Content.ReadAsStringAsync();

                    var lista = JsonConvert.DeserializeObject<LimiteCliente[]>(resultado).ToList();

                    return View(lista);

                }
                else
                {
                    var mensagem = response.ReasonPhrase;
                    throw new Exception(mensagem);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
                return View("_Erro");
            }
        }

    }
}