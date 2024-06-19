using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCSharp2.Dto {
    public class PacienteDto {

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string DataDeNascimento { get; set; }

        public PacienteDto(string Nome, string Cpf, string DataDeNascimento){
            this.Nome = Nome;
            this.Cpf = Cpf;
            this.DataDeNascimento = DataDeNascimento;
        }

    }
}
