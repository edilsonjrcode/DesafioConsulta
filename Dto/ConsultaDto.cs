using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioCSharp2.Utils;

namespace DesafioCSharp2.Dto
{
    class ConsultaDto
    {
        public string Cpf { get; set; }
        public string DataConsulta { get; set; }
        public string HoraInicial { get; set; }
        public string HoraFinal { get; set; }

        public ConsultaDto(string Cpf, string DataConsulta, string HoraInicial, string HoraFinal)
        {
            this.Cpf = Cpf;
            this.DataConsulta = DataConsulta;
            this.HoraInicial = HoraInicial;
            this.HoraFinal = HoraFinal;
        }


        public bool PeriodoFuturo()
        {
            try
            {
                if ((DataConsulta.ConverteData() > DateTime.Now.Date || (DataConsulta.ConverteData() == DateTime.Now.Date && HoraInicial.ConverteHora() > new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second))) 
                && HoraFinal.ConverteHora() > HoraInicial.ConverteHora())
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return false;
        }
    }
}
