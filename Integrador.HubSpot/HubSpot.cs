using System;
using Integrador.HubSpot.Rest;
using Integrador.HubSpot.Rest.Base;

namespace Integrador.HubSpot
{
    public class HubSpot : IDisposable
    {
        public HubSpot()
        {
            this.Integrations = new RestIntegrations();
            this.Association = new RestAssociation();
            this.Engagement = new RestEngagement();
            this.Pipeline = new RestPipeline();
            this.LineItem = new RestLineItem();
            this.Product = new RestProduct();
            this.Contact = new RestContact();
            this.Deal = new RestDeal();
            this.Form = new RestForm();
        }

        public void Dispose()
        {
            this.Integrations = null;
            this.Association = null;
            this.Engagement = null;
            this.Pipeline = null;
            this.LineItem = null;
            this.Product = null;
            this.Contact = null;
            this.Deal = null;
            this.Form = null;
        }

        public RestIntegrations Integrations { get; private set; }
        public RestAssociation Association { get; private set; }
        public RestEngagement Engagement { get; private set; }
        public RestPipeline Pipeline { get; private set; }
        public RestLineItem LineItem { get; private set; }
        public RestProduct Product { get; private set; }
        public RestContact Contact { get; private set; }
        public RestDeal Deal { get; private set; }
        public RestForm Form { get; private set; }
    }
}
