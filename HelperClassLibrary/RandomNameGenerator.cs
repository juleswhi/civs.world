using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace HelperClassLibrary
{
    class NameGeneratorApiClient
    {

        static List<Name> Names;
        static HttpClient client = new HttpClient();

        private static string url = "https://api.parser.name/?api_key=030c445c99003e79b29d7caa684b6403&endpoint=generate&results=25";

        public void InitializeClient()
        {
            Names = new List<Name>();

           

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<NameModel> GenerateNames()
        {
            using(HttpResponseMessage response = await client.GetAsync(url))
            {
                if(response.IsSuccessStatusCode)
                {
                    NameModel? name = await response.Content.ReadFromJsonAsync<NameModel>();
                    return name;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
