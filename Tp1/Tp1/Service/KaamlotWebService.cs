using Acr.UserDialogs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Tp1.Models;
using Xamarin.Essentials;

namespace Tp1.Service
{
    public class KaamlotWebService
    {
        private const string apiUrl = "https://kaamelottfunctions20190105022434.azurewebsites.net/api/GetSamples?code=Xu9k6j3gEZJAdBecTxyHNMAYXcddhTgEogeBOk78IpHXynTxd8k7kg==";

        public static async Task<List<Sound>> GetSoundList()
        {
            try
            {
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    using (HttpClient clientHttp = new HttpClient())
                    {
                        var response = await clientHttp.GetAsync(apiUrl);
                        if (response.IsSuccessStatusCode)
                        {
                            string json = await response.Content.ReadAsStringAsync();
                            return JsonConvert.DeserializeObject<List<Sound>>(json);
                        }
                    }
                }
                UserDialogs.Instance.Toast(new ToastConfig("No Internet Connexion"));
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
