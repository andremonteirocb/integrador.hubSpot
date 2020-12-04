using Integrador.HubSpot.Rest.Base;
using Integrador.HubSpot.Rest.Models;
using Integrador.HubSpot.Rest.Models.Get;
using System.Linq;
using Integrador.HubSpot.Extensions;
using System.Collections.Generic;

namespace Integrador.HubSpot.Rest
{
    public class RestDeal : RestBase
    {
        /// <summary>
        /// Recupera todos as propriedades para deal
        /// groupId: dealinformation
        /// groupId: analyticsinformation
        /// </summary>
        /// <returns></returns>
        public List<GroupModelGet> RecuperarTodasAsPropriedades(string groupId = "dealinformation", bool incluirPropriedades = true)
        {
            var endpoint = $"{base.UrlBase}/properties/v1/deals/groups?hapikey={base.HapiKey}&includeProperties={incluirPropriedades}";
            var model = base.GetAll<GroupModelGet>(endpoint).ToList();

            if (!string.IsNullOrEmpty(groupId))
                model = model.FindAll(m => m.GroupId == groupId);

            return model;
        }

        /// <summary>
        /// Cria uma nova propriedade para ser utilizada pelos deals
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public DealPropertyModelGet CriarPropriedadeNoDeal(DealPropertyModelPost value)
        {
            var endpoint = $"{base.UrlBase}/properties/v1/deals/properties?hapikey={base.HapiKey}";
            var model = base.Post<DealPropertyModelPost, DealPropertyModelGet>(endpoint, value);
            return model;
        }

        /// <summary>
        /// Informar o dealId do deal para busca
        /// </summary>
        /// <param name="dealId"></param>
        /// <returns></returns>
        public DealModelGet RecuperarDeal(long dealId)
        {
            if (dealId <= 0) return base.CriarModelError<DealModelGet>("DEALID");

            var endpoint = $"{base.UrlBase}/deals/v1/deal/{dealId}?hapikey={base.HapiKey}";
            var model = base.Get<DealModelGet>(endpoint);
            return model;
        }

        /// <summary>
        /// Verifica se o deal já exista e retorna o mesmo, caso não tenha o deal cria o mesmo
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public DealModelGet CriarDeal(DadosIntegracao dados)
        {
            var value = new DealModelPost {
                Associations = new Rest.Models.Associations { ContactIds = new long[] { dados.Contact.ContactId } },
                Properties = dados?.Deal.Propriedades?.Select(prop => new PropertyName { Name = prop.Chave, Value = prop.Valor })?.ToList()
            };
            var endpoint = $"{base.UrlBase}/deals/v1/deal?hapikey={base.HapiKey}";
            var model = base.Post<DealModelPost, DealModelGet>(endpoint, value);
            dados.Deal.DealId = model.DealId;
            return model;
        }

        /// <summary>
        /// Atualiza as propriedades do deal
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public DealModelGet AtualizarDeal(DadosIntegracao dados)
        {
            if (dados.Deal.DealId <= 0) return base.CriarModelError<DealModelGet>("DEALID");

            var value = new DealModelPut {
                DealId = dados.Deal.DealId,
                Properties = dados?.Deal.Propriedades?.Select(prop => new PropertyName { Name = prop.Chave, Value = prop.Valor })?.ToList()
            };
            var endpoint = $"{base.UrlBase}/deals/v1/deal/{value.DealId}?hapikey={base.HapiKey}";
            var model = base.Put<DealModelPut, DealModelGet>(endpoint, value);
            return model;
        }

        /// <summary>
        /// Informar o dealId do deal que será deletado
        /// </summary>
        /// <param name="dealId"></param>
        public DealModelDelete DeletarDeal(long dealId)
        {
            if (dealId <= 0) return base.CriarModelError<DealModelDelete>("DEALID");

            var endpoint = $"{base.UrlBase}/deals/v1/deal/{dealId}?hapikey={base.HapiKey}";
            var model = base.Delete<DealModelDelete>(endpoint);
            return model;
        }
    }
}
