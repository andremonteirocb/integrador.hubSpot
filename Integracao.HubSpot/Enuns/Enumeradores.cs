using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.HubSpot.Enuns
{
    public class Enumeradores
    {
        public enum TipoOperacaoManutencaoCurso : int
        {
            NaoDefinido = Int16.MinValue,
            Incluir = 1,
            Alterar = 2,
            Remover = 3
        }
    }
}
