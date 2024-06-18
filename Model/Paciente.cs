using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCSharp2.Model {
    class Paciente {

        private string nome;

        private string cpf;

        private DateTime dataDeNascimento;

        public Paciente(string Nome, string Cpf, DateTime DataDeNascimento){
            this.nome = Nome;
            this.cpf = Cpf;
            this.dataDeNascimento = DataDeNascimento;
        }

    }
}
