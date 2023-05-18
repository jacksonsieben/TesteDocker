using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using teste.RazorPages.Models;

namespace teste.RazorPages.Pages
{
    public class Index : PageModel
    {
        public List<PessoaModel>PessoaList { get; set; } = new();
        
        public Index(){}
       
        public async Task<IActionResult> OnGetAsync(){
            var httpClient = new HttpClient();
            var url = "http://api-container:8000/Pessoa";
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await httpClient.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();

            PessoaList = JsonConvert.DeserializeObject<List<PessoaModel>>(content)!;
            return Page();
        }

    }
}