using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioCSharp2.Utils;

namespace DesafioCSharp2.Dto {
    class ConsultaDto {
        public string Cpf { get; set; }
        public string DataConsulta { get; set; }
        public string HoraInicial { get; set; }
        public string HoraFinal { get; set; }

        public ConsultaDto(string Cpf, string DataConsulta, string HoraInicial, string HoraFinal){
            this.Cpf = Cpf;
            this.DataConsulta = DataConsulta;
            this.HoraInicial = HoraInicial;
            this.HoraFinal = HoraFinal;
        }

        
        public bool PeriodoFuturo()
        {
            try
            {
                HoraInicial.ConverteHora();
                HoraFinal.ConverteHora();
                TimeSpan horaAtual = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                if (DataConsulta.ConverteData() >= new DateTime())
                {
                    System.Console.WriteLine("A data da consulta é maior ou igual a data de hoje");
                    return false;
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return true;
        }
    }
}
