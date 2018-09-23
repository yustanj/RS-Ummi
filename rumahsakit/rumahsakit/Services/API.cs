
using RestSharp;
using rumahsakit.Helpers;
using rumahsakit.Models;
using rumahsakit.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace rumahsakit.Services
{
    public class API
    {
        public static IRestResponse CallAPI(string resource, string[,] parameter, Method method, string[,] header)
        {
            BaseViewModel Base = new BaseViewModel();
            IRestResponse response;

            if (!Base.IsConnected)
            {
                response = new RestResponse
                {
                    Content = "{\"errors\":[\"Not connected to internet\"]}",
                    StatusCode = HttpStatusCode.NoContent,
                    ContentType = "application/json"
                };
            }
            else
            {
                var request = new RestRequest(resource, method);

                if (parameter != null)
                {
                    for (int i = 0; i < parameter.Length / 2; i++)
                    {
                        request.AddParameter(parameter[i, 0], parameter[i, 1]); // adds to POST or URL querystring based on Method
                    }
                }

                if (header != null)
                {
                    for (int i = 0; i < header.Length / 2; i++)
                    {
                        request.AddHeader(header[i, 0], header[i, 1]);
                    }
                }

                // execute the request
                response = GlobalVar.Domain.Execute(request);
                response.ContentType = "application/json";
                if (response.StatusCode != HttpStatusCode.InternalServerError)
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        LocalData.IsLogin = false;
                    }
                }
                else
                {
                    response.Content = "{\"errors\":[\"Unknown error\"]}";
                }
            }
            return response;
        }
    }
}