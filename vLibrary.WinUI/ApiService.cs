using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vLibrary.Model;
namespace vLibrary.WinUI
{
    public class ApiService
    {
        private string _route = null;
        public ApiService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object search)
        {

            var url = $"{Properties.Settings.Default.APIUrl}/{_route}";
            if(search != null)
            {
                url += "?";
                url += await search.ToQueryString(); ;
            }
            
            return await url.GetJsonAsync<T>();
        }
    }
}
