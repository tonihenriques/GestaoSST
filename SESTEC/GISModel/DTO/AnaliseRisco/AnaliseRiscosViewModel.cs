using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISModel.DTO.AnaliseRisco
{
    public class AnaliseRiscosViewModel
    {

        public string DescricaoAtividade { get; set; }
        
        public string FonteGeradora { get; set; }
        
        public string NomeDaImagem { get; set; }
        
        public string Imagem { get; set; }       

        public bool AlocaAtividade { get; set; }

        public string IDAtividadeEstabelecimento { get; set; }

        public string IDAlocacao { get; set; }

        public string Riscos { get; set; }

        public string idPossiveisDanos { get; set; }

        public string idControle { get; set; }

        public Enum EClasseDoRisco { get; set; }

        public string Tragetoria { get; set; }

        public string PossiveisDanos { get; set; }





    }
}
