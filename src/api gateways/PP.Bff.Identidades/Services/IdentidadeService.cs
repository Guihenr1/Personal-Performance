using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using PP.Bff.Identidades.Extensions;
using PP.Bff.Identidades.Models;
using RestSharp;

namespace PP.Bff.Identidades.Services {
    public interface IIdentidadeService
    {
        Task<AutenticacaoViewModel> Autenticar(UsuarioLogin usuario);
    }

    public class IdentidadeService : Service, IIdentidadeService {
        private readonly RestClient _client;

        public IdentidadeService(IOptions<AppServicesSettings> settings) {
            _client = new RestClient(settings.Value.IdentidadeUrl);
        }

        public async Task<AutenticacaoViewModel> Autenticar(UsuarioLogin usuario)
        {
            var response = new AutenticacaoViewModel();
            var body = ObterConteudo(usuario);

            var request = new RestRequest("/identidade/autenticar/", Method.POST);
            request.AddParameter(body.Parameters.FirstOrDefault());
            var identidade = await _client.ExecuteAsync(request);
            if (identidade.StatusCode != HttpStatusCode.OK) {
                var errors = await DeserializarObjetoResponse<ErrorResponse>(identidade?.Content);
                response.Errors.AddRange(errors.Errors.Mensagens);

                return response;
            }

            response.usuarioRespostaLogin = await DeserializarObjetoResponse<UsuarioRespostaLoginViewModel>(identidade?.Content);

            return response;
        }
    }
}