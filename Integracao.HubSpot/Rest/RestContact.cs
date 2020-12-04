using Integrador.HubSpot.Rest.Base;
using Integrador.HubSpot.Rest.Models;
using Integrador.HubSpot.Rest.Models.Get;
using System.Linq;
using Integrador.HubSpot.Extensions;
using System.Collections.Generic;

namespace Integrador.HubSpot.Rest
{
    public class RestContact : RestBase
    {
        /// <summary>
        /// Recupera todos as propriedades para contato
        /// groupId: contactinformation
        /// groupId: socialmediainformation
        /// groupId: emailinformation
        /// groupId: analyticsinformation
        /// groupId: conversioninformation
        /// </summary>
        /// <returns></returns>
        public List<GroupModelGet> RecuperarTodasAsPropriedades(string groupId = "contactinformation", bool incluirPropriedades = true)
        {
            var endpoint = $"{base.UrlBase}/properties/v1/contacts/groups?hapikey={base.HapiKey}&includeProperties={incluirPropriedades}";
            var model = base.GetAll<GroupModelGet>(endpoint).ToList();

            if (!string.IsNullOrEmpty(groupId))
                model = model.FindAll(m => m.GroupId == groupId);

            return model;
        }

        /// <summary>
        /// Informar o contactId do contato para busca
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public ContactModelGet RecuperarContatoById(long contactId)
        {
            if (contactId <= 0) return base.CriarModelError<ContactModelGet>("CONTACTID");

            var endpoint = $"{base.UrlBase}/contacts/v1/contact/vid/{contactId}/profile?hapikey={base.HapiKey}";
            var model = base.Get<ContactModelGet>(endpoint);
            return model;
        }

        /// <summary>
        /// Informar o email do contato para busca
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public ContactModelGet RecuperarContatoByEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) return base.CriarModelError<ContactModelGet>("E-mail");

            var endpoint = $"{base.UrlBase}/contacts/v1/contact/email/{email}/profile?hapikey={base.HapiKey}";
            var model = base.Get<ContactModelGet>(endpoint);
            return model;
        }

        /// <summary>
        /// Cria ou atualiza um contato, caso já exista um contato para o e-mail apenas atualiza o registro
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ContactModelGet CriarOuAtualizarContato(DadosIntegracao dados)
        {
            if (string.IsNullOrEmpty(dados.Inscricao.Email)) return base.CriarModelError<ContactModelGet>("E-MAIL");

            var value = new ContactModelPost {
                Email = dados.Inscricao.Email,
                Properties = dados?.Contact?.Propriedades?.Select(prop => new PropertyProp { Property = prop.Chave, Value = prop.Valor })?.ToList()
            };
            var endpoint = $"{base.UrlBase}/contacts/v1/contact/createOrUpdate/email/{value.Email}/?hapikey={base.HapiKey}";
            var model = base.Post<ContactModelPost, ContactModelGet>(endpoint, value);
            dados.Contact.ContactId = model.ContactId;
            return model;
        }

        /// <summary>
        /// Informar o contactId do contato que será deletado
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public ContactModelDelete DeletarContato(long contactId)
        {
            if (contactId <= 0) return base.CriarModelError<ContactModelDelete>("CONTACTID");

            var endpoint = $"{base.UrlBase}/contacts/v1/contact/vid/{contactId}?hapikey={base.HapiKey}";
            var model = base.Delete<ContactModelDelete>(endpoint);
            return model;
        }
    }
}
