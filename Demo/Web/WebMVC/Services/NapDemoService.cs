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
        private const string DemoApiUrl = "http://localhost:9001/api/";

        public List<UserAccount> GetAll()
        {
            List<UserAccount> results = new List<UserAccount>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(DemoApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("UserAccount").Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseString = response.Content.ReadAsStringAsync().Result;
                    results = JsonConvert.DeserializeObject<List<UserAccount>>(responseString);
                }
            }

            return results;
        }

        public UserAccount GetUserAccount(int id)
        {
            UserAccount result = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(DemoApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("UserAccount/" + id.ToString()).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseString = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<UserAccount>(responseString);
                }
            }

            return result;
        }

        public UserAccount Add(UserAccount item)
        {
            UserAccount result = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(DemoApiUrl);
                client.DefaultRequestHeaders.Clear();
                string jsonContent = JsonConvert.SerializeObject(item);
                StringContent httpContent = new System.Net.Http.StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                var response = client.PostAsync("UserAccount", httpContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    //string responseString = response.Content.ReadAsStringAsync().Result;
                    //result = JsonConvert.DeserializeObject<UserAccount>(responseString);
                }
            }

            return result;
        }

        public void Remove(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(DemoApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.DeleteAsync("UserAccount/" + id.ToString()).Result;
            }
        }

        public bool Update(UserAccount item)
        {
            bool result = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(DemoApiUrl);
                client.DefaultRequestHeaders.Clear();
                string jsonContent = JsonConvert.SerializeObject(item);
                StringContent httpContent = new System.Net.Http.StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                var response = client.PutAsync("UserAccount", httpContent).Result;
                result = response.IsSuccessStatusCode;
            }
            return result;

        }
    }
}