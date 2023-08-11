using Digitalbank.Comercial.Usuarios.WebConsumo.Models.Usuario;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Digitalbank.Comercial.Usuarios.WebConsumo.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public async Task<ActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res =
                    await client.GetAsync("WcfServiceUsuario/UsuarioService.svc/res/ListarUsuario");



                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStreamAsync().Result;
                    DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(List<UsuarioViewModel>));
                    List<UsuarioViewModel> response = obj.ReadObject(result) as List<UsuarioViewModel>;

                    return View(response);
                }
                return View();
            }
        }

        public ActionResult Create()
        {
            ViewBag.MiListadoSexo = ListarSexos();
            return View();
        }

        public List<SelectListItem> ListarSexos()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "Masculino",
                    Value = "M"
                },
                new SelectListItem()
                {
                    Text = "Femenino",
                    Value = "F"
                },
                new SelectListItem()
                {
                    Text = "Indeterminado",
                    Value = "I"
                }
            };

        }

        // POST: Usuario
        [HttpPost]
        public async Task<ActionResult> Create(UsuarioViewModel usuario)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(UsuarioViewModel));
                MemoryStream men = new MemoryStream();
                ser.WriteObject(men, usuario);
                string data = Encoding.UTF8.GetString(men.ToArray(), 0, (int)men.Length);

                HttpResponseMessage res = await client.PostAsync("WcfServiceUsuario/UsuarioService.svc/res/AgregarUsuario",
                    new StringContent(data, Encoding.UTF8, "application/json"));

                if (res.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                else
                    return View();
            }
        }

        public async Task<ActionResult> Edit(int idUsuario)
        {
            ViewBag.MiListadoSexo = ListarSexos();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res =
                    await client.GetAsync("WcfServiceUsuario/UsuarioService.svc/res/ConsultarUsuario/" + idUsuario);



                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStreamAsync().Result;
                    DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(UsuarioViewModel));
                    UsuarioViewModel response = obj.ReadObject(result) as UsuarioViewModel;

                    return View(response);
                }
                return View();
            }
        }


        [HttpPost]
        public async Task<ActionResult> Edit(UsuarioViewModel usuario)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(UsuarioViewModel));
                MemoryStream men = new MemoryStream();
                ser.WriteObject(men, usuario);
                string data = Encoding.UTF8.GetString(men.ToArray(), 0, (int)men.Length);

                HttpResponseMessage res = await client.PutAsync("WcfServiceUsuario/UsuarioService.svc/res/ModificarUsuario",
                    new StringContent(data, Encoding.UTF8, "application/json"));

                if (res.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                else
                    return View();
            }
        }


        public async Task<ActionResult> Delete(int idUsuario)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res =
                    await client.GetAsync("WcfServiceUsuario/UsuarioService.svc/res/ConsultarUsuario/" + idUsuario);



                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStreamAsync().Result;
                    DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(UsuarioViewModel));
                    UsuarioViewModel response = obj.ReadObject(result) as UsuarioViewModel;

                    return View(response);
                }
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Delete(UsuarioViewModel usuario)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res =
                    await client.DeleteAsync("WcfServiceUsuario/UsuarioService.svc/res/EliminarUsuario/" + usuario.IdUsuario);



                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
        }
    }
}