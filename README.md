# HUBSPOT
.NET Class Library for integration with HUBSPOT API <br />
.Net Framework 4.6.1

### Adicione as chaves no web.config
```c#
  <add key="user:hapikey" value="_hapikey_do_cliente_hubspot" />
  <add key="app:urlforms" value="https://api.hsforms.com" />
  <add key="app:url" value="https://api.hubapi.com" />
  ```
### Criar engagement
```c#
using(var hubspot = new HubSpot())
{
    hubspot.Engagement.CriarEngagement(contactId, mensagem);
}
```

### Obter produto pelo id
```c#
using(var hubspot = new HubSpot())
{
  var produto = hubSpot.Product.RecuperarProdutoById(productId);
}
```

### Obter todos os produtos
```c#
using(var hubspot = new HubSpot())
{
  var produtos = hubSpot.Product.RecuperarTodosOsProdutos();
}
```

### Criar produto
```c#
using(var hubspot = new HubSpot())
{
  var dados = new DadosIntegracao
  {
      Deal = new DadosDeal
      {
          Propriedades = new List<Propriedade> 
          {
              new Rest.Models.Propriedade { Chave = "chave", Valor = "valor" },
              new Rest.Models.Propriedade { Chave = "recurringbillingfrequency", Valor = "per_six_months" }
          }
      }
  };
  var produto = hubSpot.Product.CriarProduto(dados);
}
```

### Atualizar produto
```c#
using(var hubspot = new HubSpot())
{
  var dados = new DadosIntegracao
  {
      Deal = new DadosDeal
      {
          Propriedades = new List<Propriedade> 
          {
              new Rest.Models.Propriedade { Chave = "chave", Valor = "novo_valor" },
              new Rest.Models.Propriedade { Chave = "recurringbillingfrequency", Valor = "per_six_months" }
          }
      }
  };
  var produto = hubSpot.Product.AtualizarProduto(dados);
}
```

### Deletar produto
```c#
using(var hubspot = new HubSpot())
{
  hubSpot.Product.DeletarProduto(productId);
}
```

### Obter pipeline pelo id
```c#
using(var hubspot = new HubSpot())
{
  hubSpot.Pipeline.RecuperarTodosOsPipelines();
}
```

### Obter todos os pipelines
```c#
using(var hubspot = new HubSpot())
{
  hubSpot.Pipeline.RecuperarPipelineComDealStages(pipelineId);
}
```

### Obter requests do dia
```c#
using(var hubspot = new HubSpot())
{
  var integration = hubSpot.Integrations.RecuperarNumeroDeRequestDiarioDaApi();
}
```

### Enviar formulário
```c#
using(var hubspot = new HubSpot())
{
  var dados = new DadosIntegracao
  {
      Deal = new DadosFormulario
      {
          PortalId = "portal_id",
          FormId = "form_id",
          Contexto = new ContextForm 
          {
            CookieHubSpot = "cookie",
            PageUri = "page_uri",
            IpAddress = "ip_address",
            PageName = "page_name"
          },
          Propriedades = new List<Propriedade> 
          {
              new Rest.Models.Propriedade { Chave = "chave", Valor = "valor" }
          }
      }
  };
  //skipValidation ignorar erros caso true
  var form = _hubSpot.Form.EnviarFormulario(dados, skipValidation);
}
```

### Obter propriedades do contato
```c#
using(var hubspot = new HubSpot())
{
  //var groupId = "contactinformation";
  var propriedades = _hubSpot.Contact.RecuperarTodasAsPropriedades(groupId);
}
```

### Obter contado por e-mail
```c#
using(var hubspot = new HubSpot())
{
  var contato = _hubSpot.Contact.RecuperarContatoByEmail("email");
}
```

### Obter contado por id
```c#
using(var hubspot = new HubSpot())
{
  var contato = _hubSpot.Contact.RecuperarContatoByEmail(contactId);
}
```

### Criar ou atualizar um contato
```c#
using(var hubspot = new HubSpot())
{
  var dados = new DadosIntegracao
  {
      Inscricao = new DadosInscricao
      {
          Email = "email_usuario"
      },
      Contact = new DadosContact
      {
          Propriedades = new List<Propriedade> 
          {
              new Rest.Models.Propriedade { Chave = "chave", Valor = "valor" }
          }
      }
  };
  var contato = _hubSpot.Contact.CriarOuAtualizarContact(dados);
}
```

### Deletar contato
```c#
using(var hubspot = new HubSpot())
{
  var contato = _hubSpot.Contact.DeletarContato(contactId);
}
```

### Obter propriedades do deal
```c#
using(var hubspot = new HubSpot())
{
  //var groupId = "dealinformation";
  //var incluirPropriedades = true;
  var propriedades = _hubSpot.Deal.RecuperarTodasAsPropriedades(groupId, incluirPropriedades);
}
```

### Obter deal por id
```c#
using(var hubspot = new HubSpot())
{
  var deal = _hubSpot.Deal.RecuperarDeal(dealId);
}
```

### Criar um deal
```c#
using(var hubspot = new HubSpot())
{
  var dados = new DadosIntegracao
  {
      Inscricao = new DadosInscricao
      {
          Email = "email_usuario"
      },
      Contact = new DadosContact
      {
          ContactId = 11111, //contactId
          Propriedades = new List<Propriedade> 
          {
              new Rest.Models.Propriedade { Chave = "chave", Valor = "valor" }
          }
      },
      Deal = new DadosDeal
      {
          Propriedades = new List<Propriedade> 
          {
              new Rest.Models.Propriedade { Chave = "chave", Valor = "valor" }
          }
      }
  };
  var deal = _hubSpot.Deal.CriarDeal(dados);
}
```

### Atualizar um deal
```c#
using(var hubspot = new HubSpot())
{
  var dados = new DadosIntegracao
  {
      Inscricao = new DadosInscricao
      {
          Email = "email_usuario"
      },
      Deal = new DadosDeal
      {
          DealId = 1323112, //dealId
          Propriedades = new List<Propriedade> 
          {
              new Rest.Models.Propriedade { Chave = "chave", Valor = "novo_valor" }
          }
      }
  };
  var deal = _hubSpot.Deal.CriarDeal(dados);
}
```

### Deletar deal
```c#
using(var hubspot = new HubSpot())
{
  var deal = _hubSpot.Deal.DeletarDeal(dealId);
}
```
