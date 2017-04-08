using Nap.Demo.WebClientMVC.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Nap.Demo.WebClientMVC.Services
{
    public class NapDemoService
    {
        private const string DemoApiUrl = "http://localhost:9000/";
        private System.Net.Http.HttpClient _client = null;

        public NapDemoService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(DemoApiUrl);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        /*
                    // List data response.
                    HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
                    if (response.IsSuccessStatusCode)
                    {
                        // Parse the response body. Blocking!
                        var dataObjects = response.Content.ReadAsAsync<IEnumerable<DataObject>>().Result;
                        foreach (var d in dataObjects)
                        {
                            Console.WriteLine("{0}", d.Name);
                        }
                    }

        */
        public List<UserAccount> GetAll()
        {
            List<UserAccount> results = new List<UserAccount>();
            HttpResponseMessage response = _client.GetAsync("api/UserAccounts").Result;
            if (response.IsSuccessStatusCode)
            {
                var userAccounts = response.Content.ReadAsAsync<IEnumerable<UserAccount>>().Result;
                foreach (UserAccount u in userAccounts)
                {
                    results.Add(u);
                }
            }
            return results;
        }

    }
}