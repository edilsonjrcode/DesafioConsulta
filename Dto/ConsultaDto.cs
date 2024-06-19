using DesafioCSharp2.Utils;

namespace DesafioCSharp2.Dto
{
    public class ConsultaDto(string Cpf, string DataConsulta, string HoraInicial, string HoraFinal)
    {
        public string Cpf { get; set; } = Cpf;
        public string DataConsulta { get; set; } = DataConsulta;
        public string HoraInicial { get; set; } = HoraInicial;
        public string HoraFinal { get; set; } = HoraFinal;

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
            catch
            {
                throw;
            }
            return false;
        }
    }
}
