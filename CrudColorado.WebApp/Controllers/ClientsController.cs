using CrudColorado.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CrudColorado.WebApp.Controllers
{
    public class ClientsController : Controller
    {
        private readonly string apiUrl = "https://localhost:7251/api/Clients";
        public async Task<IActionResult> Index()
        {
            List<ClientModel> clientsList = new List<ClientModel>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiUrl))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    clientsList = JsonConvert.DeserializeObject<List<ClientModel>>(apiResponse);
                }
            }
            return View(clientsList);
        }

        public ViewResult AddClient() => View();

        [HttpPost]
        public async Task<IActionResult> AddClient(ClientModel client)
        {
            ClientModel clientReceived = new ClientModel();

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(client),Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync(apiUrl, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    clientReceived = JsonConvert.DeserializeObject<ClientModel>(apiResponse);
                }
            }
            return View(clientReceived);
        }

        public ViewResult GetClient() => View();
        [HttpPost]
        public async Task<IActionResult> GetClient(int id)
        {
            ClientModel client = new ClientModel();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiUrl + "/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    client = JsonConvert.DeserializeObject<ClientModel>(apiResponse);
                }
            }
            return View(client);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateClient(int id)
        {
            ClientModel client = new ClientModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiUrl + "/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    client = JsonConvert.DeserializeObject<ClientModel>(apiResponse);
                }
            }
            return View(client);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateClient(ClientModel client)
        {
            ClientModel clientReceived = new ClientModel();

            using (var httpClient = new HttpClient())
            {
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(client.Id.ToString()), "Id");
                content.Add(new StringContent(client.Name), "Name");
                content.Add(new StringContent(client.Address), "Address");
                content.Add(new StringContent(client.City), "City");
                content.Add(new StringContent(client.State), "State");
                content.Add(new StringContent(client.DtInsertion.ToString()), "DtInsertion");

                using (var response = await httpClient.PutAsync(apiUrl, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Sucesso";
                    clientReceived = JsonConvert.DeserializeObject<ClientModel>(apiResponse);
                }
            }
            return View(clientReceived);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteClient(int Id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync(apiUrl + "/" + Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");
        }
    }


}
