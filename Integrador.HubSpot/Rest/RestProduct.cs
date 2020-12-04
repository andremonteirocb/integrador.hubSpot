using Integrador.HubSpot.Rest.Base;
using Integrador.HubSpot.Rest.Models;
using Integrador.HubSpot.Rest.Models.Get;
using System.Linq;
using Integrador.HubSpot.Extensions;
using System.Collections.Generic;

namespace Integrador.HubSpot.Rest
{
    public class RestProduct : RestBase
    {
        /// <summary>
        /// Recuperar todos os produtos
        /// </summary>
        /// <returns></returns>
        public ProductModelGet RecuperarTodosOsProdutos()
        {
            var endpoint = $"{base.UrlBase}/crm-objects/v1/objects/products/paged?hapikey={base.HapiKey}&properties=name&properties=description&properties=price&properties=recurringbillingfrequency";
            var model = base.Get<ProductModelGet>(endpoint);
            return model;
        }

        /// <summary>
        /// Informar o productId do produto para busca
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public ProductObjectModelGet RecuperarProdutoById(long productId)
        {
            if (productId <= 0) return base.CriarModelError<ProductObjectModelGet>("PRODUCTID");

            var endpoint = $"{base.UrlBase}/crm-objects/v1/objects/products/{productId}?hapikey={base.HapiKey}&properties=name&properties=description&properties=price&properties=recurringbillingfrequency";
            var model = base.Get<ProductObjectModelGet>(endpoint);
            return model;
        }

        /// <summary>
        /// Cria um novo produto
        /// </summary>
        /// <param name="dados"></param>
        /// <returns></returns>
        public ProductObjectModelGet CriarProduto(DadosIntegracao dados)
        {
            var value = dados?.Product?.Propriedades?.Select(prop => new ModelPostInArray { Name = prop.Chave, Value = prop.Valor })?.ToList();
            var endpoint = $"{base.UrlBase}/crm-objects/v1/objects/products?hapikey={base.HapiKey}";
            var model = base.PostInList<List<ModelPostInArray>, ProductObjectModelGet>(endpoint, value);
            dados.Product.ProductId = model.ObjectId;
            return model;
        }

        /// <summary>
        /// Atualiza um produto
        /// </summary>
        /// <param name="dados"></param>
        /// <returns></returns>
        public ProductObjectModelGet AtualizarProduto(DadosIntegracao dados)
        {
            if (dados.Product.ProductId <= 0) return base.CriarModelError<ProductObjectModelGet>("PRODUCTID");

            var value = dados?.Product?.Propriedades?.Select(prop => new ModelPostInArray { Name = prop.Chave, Value = prop.Valor })?.ToList();
            var endpoint = $"{base.UrlBase}/crm-objects/v1/objects/products/{dados.Product.ProductId}?hapikey={base.HapiKey}";
            var model = base.PutInList<List<ModelPostInArray>, ProductObjectModelGet>(endpoint, value);
            return model;
        }

        /// <summary>
        /// Informar o contactId do contato que será deletado
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public ProductModelDelete DeletarProduto(long productId)
        {
            if (productId <= 0) return base.CriarModelError<ProductModelDelete>("PRODUCTID");

            var endpoint = $"{base.UrlBase}/crm-objects/v1/objects/products/{productId}?hapikey={base.HapiKey}";
            var model = base.Delete<ProductModelDelete>(endpoint);
            return model;
        }
    }
}
