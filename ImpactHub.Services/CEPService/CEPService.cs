using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpactHub.Services.CEPService
{
    public class CEPService : ICEPService
    {
        public async Task<IEnumerable<CEPResponse>> NaoSeiMeuCEP(string estado, string cidade, string rua)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("https://viacep.com.br/");

            string formattedCidade = cidade.Replace(" ", "%20");
            string formattedRua = rua.Replace(" ", "%20");


            HttpResponseMessage response = await client.GetAsync($"ws/{estado}/{formattedCidade}/{formattedRua}/json/");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<IEnumerable<CEPResponse>>(json);
            }
            else
            {
                return null;
            }
        }

        public async Task<CEPResponse> BuscarCEP(string cep)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("https://viacep.com.br/");

            HttpResponseMessage response = await client.GetAsync($"ws/{cep}/json/");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<CEPResponse>(json);
            }
            else
            {
                return null;
            }
        }

    }
}
