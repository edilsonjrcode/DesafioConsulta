using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCSharp2.Model {
    class Consulta {
        public string Cpf { get; private set; }
        public DateTime DataConsulta { get; private set; }
        public DateTime HoraInicial { get; private set; }
        public DateTime HoraFinal { get; private set; }

        public Consulta(string Cpf, DateTime DataConsulta, DateTime HoraInicial, DateTime HoraFinal){
            this.Cpf = Cpf;
            this.DataConsulta = DataConsulta;
            this.HoraFinal = HoraInicial;
            this.HoraFinal = HoraFinal;
        }
    }
}
