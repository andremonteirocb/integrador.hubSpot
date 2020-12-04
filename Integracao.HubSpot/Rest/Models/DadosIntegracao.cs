using Integrador.HubSpot.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.HubSpot.Rest.Models
{
    public class DadosIntegracao : AbstractModel
    {
        public FonteDeDados FonteDeDados { get; set; }
        public DadosFormulario Formulario { get; set; }
        public DadosInscricao Inscricao { get; set; }
        public DadosLineItem LineItem { get; set; }
        public DadosContact Contact { get; set; }
        public DadosProduct Product { get; set; }
        public DadosDeal Deal { get; set; }

        public DadosIntegracao()
        {
            this.Formulario = new DadosFormulario();
            this.Inscricao = new DadosInscricao();
            this.LineItem = new DadosLineItem();
            this.Contact = new DadosContact();
            this.Product = new DadosProduct();
            this.Deal = new DadosDeal();
        }
    }

    /// <summary>
    /// Classe responsável por guardar os dados básicos do candidato
    /// </summary>
    public class DadosInscricao
    {
        public string CodigoInscricao { get; set; }
        public long InscricaoId { get; set; }
        public long CourseId { get; set; }
        public string Email { get; set; }
    }    

    /// <summary>
    /// Classe responsável por guardar o identificador do contato
    /// Todas as propriedades que devem ser criadas ou atualizadas no contato
    /// </summary>
    public class DadosContact : DadosBase
    {
        public long ContactId { get; set; }
        public DadosContact()
        {
            this.Propriedades = new List<Propriedade>();
        }
    }

    /// <summary>
    /// Classe responsável por guardar o deal com seu identificador
    /// Todas as propriedades que devem ser criadas ou atualizadas no deal
    /// Propriedade: Em caso de TRUE essa propriedade vai ser utilizada após o método de inserirDeal, pois o mesmo não suporte atualização de propriedades criadas manualmente
    /// </summary>
    public class DadosDeal : DadosBase
    {
        public long DealId { get; set; }
        public DadosDeal()
        {
            this.Propriedades = new List<Propriedade>();
        }
    }
    
    public class DadosProduct : DadosBase
    {
        public Enumeradores.TipoOperacaoManutencaoCurso TipoOperacao { get; set; }
        public long ProductId { get; set; }
        public DadosProduct()
        {
            this.Propriedades = new List<Propriedade>();
        }
    }

    public class DadosLineItem : DadosBase
    {
        public long LineItemId { get; set; }
        public DadosLineItem()
        {
            this.Propriedades = new List<Propriedade>();
        }
    }

    public class DadosFormulario : DadosBase
    {
        public string PortalId { get; set; }
        public string FormId { get; set; }
        public ContextForm Contexto { get; set; }
        public DadosFormulario()
        {
            this.Propriedades = new List<Propriedade>();
        }
    }

    public class DadosBase
    {
        public List<Propriedade> Propriedades { get; set; }
        public string RecuperarValorPropriedade(string chave) => this?.Propriedades?.FirstOrDefault(prop => prop.Chave == chave)?.Valor;
        public void AdicionarPropriedade(string chave, string valor) => this.Propriedades.Add(new Propriedade { Chave = chave, Valor = valor });
    }

    public class Propriedade
    {
        public string Chave { get; set; }
        public string Valor { get; set; }
    }

    public enum FonteDeDados : int
    {
        NaoDefinido = 0,
        Candidato = 1,
        CandidatoATransferencia = 2,
        AgendamentoOnline = 3,
        CursosAluno = 4
    }
}
