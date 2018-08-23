using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using Poli.Makro.Core.Controllers;
using Poli.Makro.Core.Helpers.String;
using Poli.Makro.Core.Json.Login1;
using RestSharp;

namespace Poli.Makro.Core.KORAPI
{
    public class BasicRequests
    {
        public static bool CheckToken(string userid, string token)
        {
            try
            {
                if (InternetController.InternetCheck())
                {
                    // request host
                    var client = new RestClient("http://api.kor.onl/");
                    // request relative url
                    var request = new RestRequest("apps/kor/login.php", Method.POST);

                    // add important parameters
                    request.AddOrUpdateParameter("type", "json");
                    request.AddOrUpdateParameter("request", "token");
                    request.AddOrUpdateParameter("token", token);
                    request.AddOrUpdateParameter("primary_credential", "1");


                    // get query result
                    var response = client.Execute(request);

					Debug.WriteLine(response.Content);

                    if (!string.IsNullOrEmpty(response.Content))
                    {
                        var settings = new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Ignore,
                            MissingMemberHandling = MissingMemberHandling.Ignore,
                            PreserveReferencesHandling = PreserveReferencesHandling.Objects
                        };

                        var tokenCheckJsonObj = JsonConvert.DeserializeObject<RootobjectforToken>(response.Content, settings);

                        if (tokenCheckJsonObj.code == 1)
                        {
							return tokenCheckJsonObj.result == "OK" ? true : false;
                        }
                        else
                        {
                            Debug.WriteLine(response.Content);
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp.ToString());
                // save error record
            }

            return false;
        }
    }
}
