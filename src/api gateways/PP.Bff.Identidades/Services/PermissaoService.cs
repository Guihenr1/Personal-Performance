using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using PP.Bff.Identidades.Extensions;
using PP.Bff.Identidades.Models;
using PP.Core.Enums;
using RestSharp;

namespace PP.Bff.Identidades.Services
{
    public interface IPermissaoService
    {
        Task<IEnumerable<PermissaoViewModel>> ObterPermissao(TipoUsuario tipoUsuario, string token);
    }

    public class PermissaoService : Service, IPermissaoService {
        private readonly RestClient _client;

        public PermissaoService(IOptions<AppServicesSettings> settings) {
            _client = new RestClient(settings.Value.PermissaoUrl);
        }

        public async Task<IEnumerable<PermissaoViewModel>> ObterPermissao(TipoUsuario tipoUsuario, string token) {
            var request = new RestRequest($"/tipo/{(int)tipoUsuario}", Method.GET);
            request.AddHeader("authorization", "Bearer " + token);
            var identidade = await _client.ExecuteAsync(request);
            if (identidade.StatusCode != HttpStatusCode.OK) return null;

            return await DeserializarObjetoResponse<IEnumerable<PermissaoViewModel>>(identidade?.Content);
        }
    }
}