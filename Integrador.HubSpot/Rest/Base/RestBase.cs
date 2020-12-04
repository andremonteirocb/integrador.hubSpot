using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Integrador.HubSpot.Rest.Models;
using Integrador.HubSpot.Extensions;

namespace Integrador.HubSpot.Rest.Base
{
    public abstract class RestBase
    {
        internal virtual string UrlBase => ConfigurationManager.AppSettings["app:url"];
        internal virtual string HapiKey => ConfigurationManager.AppSettings["user:hapikey"];
        internal virtual string UrlBaseForms => ConfigurationManager.AppSettings["app:urlforms"];

        protected virtual T Get<T>(string endpoint) where T : class, new()
        {
            T valor = new T();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync(endpoint).GetAwaiter().GetResult();
                valor = response.ToStringDeserialize<T>();
            }

            return valor;
        }

        protected virtual List<T> GetAll<T>(string endpoint) where T : class, new()
        {
            List<T> valor = new List<T>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync(endpoint).GetAwaiter().GetResult();
                valor = response.ToStringDeserialize<List<T>>();
            }

            return valor;
        }

        protected virtual TResult Post<TInput, TResult>(string endpoint, TInput value)
            where TInput : AbstractModel
            where TResult : new()
        {
            TResult valor = new TResult();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = new StringContent(value.ToJson(), Encoding.UTF8, "application/json");
                var response = client.PostAsync(endpoint, json).GetAwaiter().GetResult();
                valor = response.ToStringDeserialize<TResult>();
            }

            return valor;
        }

        protected virtual TResult PostInList<TInput, TResult>(string endpoint, TInput value)
            where TResult : new()
        {
            TResult valor = new TResult();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(value, Newtonsoft.Json.Formatting.None);
                var json = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = client.PostAsync(endpoint, json).GetAwaiter().GetResult();
                valor = response.ToStringDeserialize<TResult>();
            }

            return valor;
        }

        protected virtual TResult Delete<TResult>(string endpoint)
            where TResult : new()
        {
            TResult valor = new TResult();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.DeleteAsync(endpoint).GetAwaiter().GetResult();
                valor = response.ToStringDeserialize<TResult>();
            }

            return valor;
        }

        protected virtual TResult Put<TInput, TResult>(string endpoint, TInput value)
            where TInput : AbstractModel
            where TResult : new()
        {
            TResult valor = new TResult();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = new StringContent(value.ToJson(), Encoding.UTF8, "application/json");
                var response = client.PutAsync(endpoint, json).GetAwaiter().GetResult();
                valor = response.ToStringDeserialize<TResult>();
            }

            return valor;
        }

        protected virtual TResult PutInList<TInput, TResult>(string endpoint, TInput value)
            where TResult : new()
        {
            TResult valor = new TResult();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(value, Newtonsoft.Json.Formatting.None);
                var json = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = client.PutAsync(endpoint, json).GetAwaiter().GetResult();
                valor = response.ToStringDeserialize<TResult>();
            }

            return valor;
        }

        protected T CriarModelError<T>(string campo)
            where T : new()
        {
            T valor = new T();

            var model = new ModelError { Status = "error", Message = $"O campo chave [{campo}] é obrigatório!" };
            return model.ToJson().ToDeserialize<T>();
        }

        protected T CriarModelErrorMensagem<T>(string mensagem)
            where T : new()
        {
            T valor = new T();

            var model = new ModelError { Status = "error", Message = mensagem };
            return model.ToJson().ToDeserialize<T>();
        }
    }
}
