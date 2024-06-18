using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCSharp2.Model {
    class Paciente {

        public string Nome { get; private set; }

        public string Cpf { get; private set; }

        public DateTime DataDeNascimento { get; private set; }

        
        public Paciente(string Nome, string Cpf, DateTime DataDeNascimento){
            this.Nome = Nome;
            this.Cpf = Cpf;
            this.DataDeNascimento = DataDeNascimento;
        }

    }
}
