using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCSharp2.Dto {
    class ConsultaDto {
        public string Cpf { get; set; }
        public string DataConsulta { get; set; }
        public string HoraInicial { get; set; }
        public string HoraFinal { get; set; }

        public ConsultaDto(string Cpf, string DataConsulta, string HoraInicial, string HoraFinal){
            this.Cpf = Cpf;
            this.DataConsulta = DataConsulta;
            this.HoraFinal = HoraInicial;
            this.HoraFinal = HoraFinal;
        }
    }
}
