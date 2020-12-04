using Integrador.HubSpot.Rest.Base;
using Integrador.HubSpot.Rest.Models;
using Integrador.HubSpot.Rest.Models.Get;
using System.Linq;
using Integrador.HubSpot.Extensions;
using System.Collections.Generic;

namespace Integrador.HubSpot.Rest
{
    public class RestIntegrations : RestBase
    {
        public IntegrationsModelGet RecuperarNumeroDeRequestDiarioDaApi()
        {
            var endpoint = $"{base.UrlBase}/integrations/v1/limit/daily?hapikey={base.HapiKey}";
            var model = base.GetAll<IntegrationsModelGet>(endpoint);

            if (model == null)
                return new IntegrationsModelGet();

            return model.FirstOrDefault();
        }
    }
}