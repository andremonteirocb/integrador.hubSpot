using Integrador.HubSpot.Rest.Base;
using Integrador.HubSpot.Rest.Models;
using Integrador.HubSpot.Rest.Models.Get;
using System.Linq;
using Integrador.HubSpot.Extensions;
using System.Collections.Generic;

namespace Integrador.HubSpot.Rest
{
    public class RestEngagement : RestBase
    {
        /// <summary>
        /// Cria um engajament para um determinado contato
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public EngagementModelGet CriarEngagement(int contatoID, string conteudo)
        {
            var value = new EngagementModelPost
            {
                Engagement = new Engagement
                {
                    Active = true,
                    Type = "NOTE"
                },
                Associations = new EngagementAssociations
                {
                    ContactIds = new int[] { contatoID }
                },
                Metadata = new EngagementMetadata
                {
                    Body = conteudo
                }
            };

            var endpoint = $"{base.UrlBase}/engagements/v1/engagements?hapikey={base.HapiKey}";
            var model = base.Post<EngagementModelPost, EngagementModelGet>(endpoint, value);
            return model;
        }
    }
}
