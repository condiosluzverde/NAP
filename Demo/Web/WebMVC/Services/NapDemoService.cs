using Nap.Demo.WebMVC.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using Newtonsoft.Json;

using System.Net.Http.Headers;
using System.Net;

namespace Nap.Demo.WebMVC.Services
{
    public class NapDemoService
    {
        private const string DemoApiUrl = "http://localhost:9000/api/";
        private const string DemoApiAllowedOrigin = "http://localhost:9001";

        private void initHttpClient(HttpClient client)
        {
            client.BaseAddress = new Uri(DemoApiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<UserAccount> GetAll()
        {
            List<UserAccount> results = new List<UserAccount>();

            using (var client = new HttpClient())
            {
                initHttpClient(client);

                var response = client.GetAsync("UserAccount").Result;
                response.EnsureSuccessStatusCode();

                string responseString = response.Content.ReadAsStringAsync().Result;
                results = JsonConvert.DeserializeObject<List<UserAccount>>(responseString);
            }

            return results;
        }

        public UserAccount GetUserAccount(int id)
        {
            UserAccount result = null;
            using (var client = new HttpClient())
            {
                initHttpClient(client);

                var response = client.GetAsync("UserAccount/" + id.ToString()).Result;
                response.EnsureSuccessStatusCode();

                string responseString = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<UserAccount>(responseString);
            }

            return result;
        }

        public void Add(UserAccount item)
        {
            using (var client = new HttpClient())
            {
                initHttpClient(client);

                string jsonContent = JsonConvert.SerializeObject(item);
                StringContent httpContent = new System.Net.Http.StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                var response = client.PostAsync("UserAccount", httpContent).Result;
                response.EnsureSuccessStatusCode();
            }
        }

        public void Remove(int id)
        {
            using (var client = new HttpClient())
            {
                initHttpClient(client);
                client.DefaultRequestHeaders.Add("Origin", DemoApiAllowedOrigin);

                var response = client.DeleteAsync("UserAccount/" + id.ToString()).Result;
                response.EnsureSuccessStatusCode();
            }
        }

        public bool Update(UserAccount item)
        {
            bool result = false;
            using (var client = new HttpClient())
            {
                initHttpClient(client);
                client.DefaultRequestHeaders.Add("Origin", DemoApiAllowedOrigin);

                string jsonContent = JsonConvert.SerializeObject(item);
                StringContent httpContent = new System.Net.Http.StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                var response = client.PutAsync("UserAccount/" + item.Id.ToString(), httpContent).Result;
                response.EnsureSuccessStatusCode();

                result = response.IsSuccessStatusCode;
            }
            return result;
        }
    }
}