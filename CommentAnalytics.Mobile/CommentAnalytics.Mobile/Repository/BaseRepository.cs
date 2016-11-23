using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CommentAnalytics.Mobile.Repository
{
    public class UriParameter : Dictionary<string, string>
    {
        public void Add(string key, DateTime value)
        {
            base.Add(key, value.ToString("MM-dd-yyyy"));
        }
    }

    public abstract class BaseRepository
    {
        private string ControllerName;
        private HttpClient httpClient = new HttpClient();

        public BaseRepository()
        {
            this.ControllerName = this.GetType().Name;
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Content-Type:
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            httpClient.BaseAddress = new Uri("http://commentanalyticsservices.azurewebsites.net/api/", UriKind.Absolute);
        }

        protected async Task<T> Get<T>(UriParameter parameters = null, [CallerMemberName]string MethodName = null, string ControllerName = null)
        {
            var result = await this.httpClient.GetAsync(UrlGenerator(parameters, MethodName, ControllerName));
            if (result.IsSuccessStatusCode)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(await result.Content.ReadAsStringAsync());
            }
            else
            {
                return default(T);
            }
        }

        protected async Task<HttpResponseMessage> Get(UriParameter parameters, [CallerMemberName]string MethodName = null, string ControllerName = null)
        {
            var result = await this.httpClient.GetAsync(UrlGenerator(parameters, MethodName, ControllerName));

            return result;
        }

        protected async Task<HttpResponseMessage> Get([CallerMemberName]string MethodName = null, string ControllerName = null)
        {
            var result = await this.httpClient.GetAsync(UrlGenerator(null, MethodName, ControllerName));

            return result;
        }

        protected async Task<ResponseType> Post<RequestType, ResponseType>(UriParameter UriParameters, RequestType BodyParameters = default(RequestType), [CallerMemberName]string MethodName = null, string ControllerName = null)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(BodyParameters);
            var result = await this.httpClient.PostAsync(UrlGenerator(UriParameters, MethodName, ControllerName), new StringContent(json, Encoding.UTF8, "application/json"));
            if (result.IsSuccessStatusCode)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseType>(await result.Content.ReadAsStringAsync());

            }
            else
            {
                return default(ResponseType);
            }
        }

        protected async Task<ResponseType> Post<RequestType, ResponseType>(RequestType BodyParameters = default(RequestType), [CallerMemberName]string MethodName = null, string ControllerName = null)
        {
            return await Post<RequestType, ResponseType>(null, BodyParameters, MethodName, ControllerName);
        }

        protected async Task<HttpResponseMessage> Post<RequestType>(UriParameter UriParameters, RequestType BodyParameters = default(RequestType), [CallerMemberName]string MethodName = null, string ControllerName = null)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(BodyParameters);
            System.Net.Http.StringContent content = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            var result = await this.httpClient.PostAsync(UrlGenerator(UriParameters, MethodName, ControllerName), content);
            return result;
        }

        protected async Task<HttpResponseMessage> Post<RequestType>(RequestType BodyParameters, [CallerMemberName]string MethodName = null, string ControllerName = null)
        {
            return await Post<RequestType>(null, BodyParameters, MethodName, ControllerName);
        }

        private string UrlGenerator(UriParameter UriParameters, string MethodName, string ControllerName)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            string contr = ControllerName != null ? ControllerName : this.ControllerName;
            sb.AppendFormat("{0}/{1}", contr, MethodName);

            if (UriParameters != null)
            {
                int i = 0;
                sb.Append("?");
                foreach (string key in UriParameters.Keys)
                {
                    if (i > 0)
                        sb.Append("&");

                    sb.Append(string.Format("{0}={1}", key, UriParameters[key]));
                    i++;
                }
            }
            return sb.ToString();
        }
    }

}
