using Integrador.HubSpot.Rest.Base;
using Integrador.HubSpot.Rest.Models;
using Integrador.HubSpot.Rest.Models.Get;
using System.Linq;
using Integrador.HubSpot.Extensions;
using System.Collections.Generic;
using System;

namespace Integrador.HubSpot.Rest
{
    public class RestForm : RestBase
    {
        /// <summary>
        /// Envia o formulário para HUBSPOT
        /// </summary>
        /// <param name="dados"></param>
        /// <returns></returns>
        public FormModelGet EnviarFormulario(DadosIntegracao dados, bool skipValidation = false)
        {
            if (string.IsNullOrEmpty(dados.Inscricao.Email)) return base.CriarModelError<FormModelGet>("E-MAIL");

            var value = new FormModelPost {
                SkipValidation = skipValidation,
                Properties = dados?.Formulario?.Propriedades?.Select(prop => new PropertyName { Name = prop.Chave, Value = prop.Valor })?.ToList(),
                Context = dados.Formulario.Contexto
            };
            var endpoint = $"{base.UrlBaseForms}/submissions/v3/integration/submit/{dados.Formulario.PortalId}/{dados.Formulario.FormId}";
            var model = base.Post<FormModelPost, FormModelGet>(endpoint, value);
            return model;
        }
    }
}
