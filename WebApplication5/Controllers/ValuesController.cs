using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.IO;
using System.Dynamic;

namespace WebApplication5.Controllers
{
    public class ValuesController : ApiController
    {
        // GET /chuck
        /// <summary>
        /// chuck
        /// </summary>
        /// <returns>list of joke categories</returns>
        public string Get()
        {
            WebClient client = new WebClient();
            string wbc = client.DownloadString("https://api.chucknorris.io/jokes/categories");
            return wbc;

        }

        //GET /swapi
        ///<summary>
        /// swapi
        /// </summary>
        /// <param name="id"></param>
        /// <returns>all Star Wars People</returns>
        public string Get(int id)
        {
            dynamic dobj;
            string wbc1="";
            if (id > 0)
            {
                
                WebClient client = new WebClient();
                wbc1 = client.DownloadString("https://swapi.dev/api/people/");
                dobj = JsonConvert.DeserializeObject<dynamic>(wbc1);
            }
            
            return wbc1;
        }

        // POST api/values
        public string Post(SearchOption SearchAPI,string quiry)
        {
            SearchAPI=SearchOption.AllDirectories;
            string wbc2 = "";
            string wbc3 = "";
            WebClient client = new WebClient();
            
            wbc2 = client.DownloadString("https://api.chucknorris.io/jokes/search?query={query}");
            wbc3 = client.DownloadString("https://swapi.dev/api/people/?search={query}");
            quiry = wbc2 + wbc3;
            return quiry;

        }

    }
}
