using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using PP.Core.Communication;
using RestSharp;

namespace PP.Bff.Identidades.Services
{
    public abstract class Service  {
        protected RestRequest ObterConteudo(object dado) {
            var response = new RestRequest();
            response.AddParameter("application/json",
                JsonSerializer.Serialize(dado),
                ParameterType.RequestBody);
            return response;
        }

        protected async Task<T> DeserializarObjetoResponse<T>(string responseMessage) {
            var options = new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<T>(responseMessage, options);
        }

        protected ResponseResult RetornoOk() {
            return new ResponseResult();
        }
    }
}