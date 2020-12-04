using Integrador.HubSpot.Rest.Base;
using Integrador.HubSpot.Rest.Models;
using Integrador.HubSpot.Rest.Models.Get;
using System.Linq;
using Integrador.HubSpot.Extensions;
using System.Collections.Generic;

namespace Integrador.HubSpot.Rest
{
    public class RestLineItem : RestBase
    {
        /// <summary>
        /// Cria uma linha de item para o produto
        /// </summary>
        /// <param name="dados"></param>
        /// <returns></returns>
        public LineItemObjectModelGet CriarLinhaDeItem(DadosIntegracao dados)
        {
            var value = dados?.LineItem?.Propriedades?.Select(prop => new ModelPostInArray { Name = prop.Chave, Value = prop.Valor })?.ToList();
            var endpoint = $"{base.UrlBase}/crm-objects/v1/objects/line_items?hapikey={base.HapiKey}";
            var model = base.PostInList<List<ModelPostInArray>, LineItemObjectModelGet>(endpoint, value);
            dados.LineItem.LineItemId = model.ObjectId;
            return model;
        }

        /// <summary>
        /// Informar a lineItemId da linha para busca
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public LineItemObjectModelGet RecuperarLineItem(long lineItemId)
        {
            if (lineItemId <= 0) return base.CriarModelError<LineItemObjectModelGet>("LINEITEMID");

            var endpoint = $"{base.UrlBase}/crm-objects/v1/objects/line_items/{lineItemId}?hapikey={base.HapiKey}";
            var model = base.Get<LineItemObjectModelGet>(endpoint);
            return model;
        }

        /// <summary>
        /// Atualiza as propriedades do line item
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public LineItemObjectModelGet AtualizarLineItem(DadosIntegracao dados)
        {
            if (dados.LineItem.LineItemId <= 0) return base.CriarModelError<LineItemObjectModelGet>("LINEITEMID");

            var value = dados?.LineItem?.Propriedades?.Select(prop => new ModelPostInArray { Name = prop.Chave, Value = prop.Valor })?.ToList();
            var endpoint = $"{base.UrlBase}/crm-objects/v1/objects/line_items/{dados.LineItem.LineItemId}/?hapikey={base.HapiKey}";
            var model = base.PutInList<List<ModelPostInArray>, LineItemObjectModelGet>(endpoint, value);
            return model;
        }

        /// <summary>
        /// Informar o lineItemId da linha de item que será deletada
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public LineItemModelDelete DeletarLineItem(long lineItemId)
        {
            if (lineItemId <= 0) return base.CriarModelError<LineItemModelDelete>("LINEITEMID");

            var endpoint = $"{base.UrlBase}/crm-objects/v1/objects/line_items/{lineItemId}?hapikey={base.HapiKey}";
            var model = base.Delete<LineItemModelDelete>(endpoint);
            return model;
        }
    }
}
