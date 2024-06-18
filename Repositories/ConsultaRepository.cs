using DesafioCSharp2.Dto;
using DesafioCSharp2.Model;
using DesafioCSharp2.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCSharp2.Repositories {
    class ConsultaRepository {

        private List<Consulta> consultas;

        public void AgendarConsulta(ConsultaDto consulta) {
            Consulta novaConsulta = new Consulta(consulta.Cpf, consulta.DataConsulta.ConverteData(), consulta.HoraInicial.ConverteData(), consulta.HoraFinal.ConverteData());
            consultas.Add(novaConsulta);
        }

        public void CancelarConsulta(ConsultaDto consulta) {
            Consulta novaConsulta = new Consulta(consulta.Cpf, consulta.DataConsulta.ConverteData(), consulta.HoraInicial.ConverteData(), consulta.HoraFinal.ConverteData());
            consultas.Remove(novaConsulta);
        }

        public List<Consulta> ListarConsulta() {
            return consultas;
        }

    }
}
