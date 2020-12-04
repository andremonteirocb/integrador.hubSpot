using Integrador.HubSpot.Rest.Base;
using Integrador.HubSpot.Rest.Models;
using Integrador.HubSpot.Rest.Models.Get;
using System.Linq;
using Integrador.HubSpot.Extensions;
using System.Collections.Generic;

namespace Integrador.HubSpot.Rest
{
    public class RestAssociation : RestBase
    {
        /// <summary>
        /// Cria a associação da linha do item ao deal
        /// </summary>
        /// <param name="dados"></param>
        /// <returns></returns>
        public AssociationModelGet CriarAssociacao(long lineItemId, long dealId)
        {
            if (lineItemId <= 0) return base.CriarModelError<AssociationModelGet>("LINEITEMID");
            if (dealId <= 0) return base.CriarModelError<AssociationModelGet>("DEALID");

            var value = new AssociationModelPost { LineItemId = lineItemId, DealId = dealId, Category = "HUBSPOT_DEFINED", DefinitionId = 20 };
            var endpoint = $"{base.UrlBase}/crm-associations/v1/associations?hapikey={base.HapiKey}";
            var model = base.Put<AssociationModelPost, AssociationModelGet>(endpoint, value);
            return model;
        }

        /// <summary>
        /// Informar o lineItemId e dealId para desfazer a associação
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public AssociationModelGet DeletarAssociacao(long lineItemId, long dealId)
        {
            if (lineItemId <= 0) return base.CriarModelError<AssociationModelGet>("LINEITEMID");
            if (dealId <= 0) return base.CriarModelError<AssociationModelGet>("DEALID");

            var value = new AssociationModelPost { LineItemId = lineItemId, DealId = dealId, Category = "HUBSPOT_DEFINED", DefinitionId = 20 };
            var endpoint = $"{base.UrlBase}/crm-associations/v1/associations/delete?hapikey={base.HapiKey}";
            var model = base.Put<AssociationModelPost, AssociationModelGet>(endpoint, value);
            return model;
        }
    }
}
