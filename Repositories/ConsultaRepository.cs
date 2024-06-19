using DesafioCSharp2.Dto;
using DesafioCSharp2.Model;
using DesafioCSharp2.Utils;

namespace DesafioCSharp2.Repositories
{
    public class ConsultaRepository
    {

        private List<Consulta> Consultas = [];

        public bool VerificaSePossuiAgendamento(string cpf)
        {
            foreach (Consulta ConsultaCadastrada in Consultas)
            {
                if (ConsultaCadastrada.Cpf == cpf)
                {
                    if (ConsultaCadastrada.DataConsulta > DateTime.Now.Date)
                    {
                        return true;
                        // throw new Exception("O usuário já possui um agendamento.");
                    }
                }
            }
            return false;
        }

        public void AgendarConsulta(ConsultaDto consulta)
        {

            foreach (Consulta ConsultaCadastrada in Consultas)
            {
                if (ConsultaCadastrada.DataConsulta == consulta.DataConsulta.ConverteData())
                {
                    if (consulta.HoraInicial.ConverteHora() >= ConsultaCadastrada.HoraInicial && consulta.HoraInicial.ConverteHora() <= ConsultaCadastrada.HoraFinal
                    && consulta.HoraFinal.ConverteHora() >= ConsultaCadastrada.HoraInicial && consulta.HoraInicial.ConverteHora() <= ConsultaCadastrada.HoraFinal)
                    {
                        throw new Exception("Já existe um agendamento nesse horário, escolha um horário diferente.");
                    }
                }
            }
            Consulta novaConsulta = new Consulta(consulta.Cpf, consulta.DataConsulta.ConverteData(), consulta.HoraInicial.ConverteHora(), consulta.HoraFinal.ConverteHora());
            Consultas.Add(novaConsulta);
        }

        public bool CancelarConsulta(ConsultaDto consulta)
        {

            foreach (Consulta ConsultaCadastrada in Consultas)
            {
                if (ConsultaCadastrada.Cpf == consulta.Cpf && ConsultaCadastrada.DataConsulta == consulta.DataConsulta.ConverteData()
                && ConsultaCadastrada.HoraInicial == consulta.HoraInicial.ConverteHora())
                {
                    Consultas.Remove(ConsultaCadastrada);
                    return true;
                }
            }
            throw new Exception("Os dados informados não são semelhantes ao agendamento existente.");
        }

        public List<ConsultaDto> TransformaTipoListaDto()
        {

            List<ConsultaDto> listaConsultas = new List<ConsultaDto>();

            foreach (Consulta Consulta in Consultas)
            {
                ConsultaDto ConsultaDto = new ConsultaDto(Consulta.Cpf, Consulta.DataConsulta.ToString("ddMMyyyy"), Consulta.HoraInicial.ConverteTimeToString(), Consulta.HoraFinal.ConverteTimeToString());
                listaConsultas.Add(ConsultaDto);
            }

            return listaConsultas;
        }

        public List<ConsultaDto> ListarConsultas()
        {
            return TransformaTipoListaDto().OrderBy(o => o.DataConsulta).ThenBy(o => o.HoraInicial).ToList();
        }

        public List<ConsultaDto> ListarConsultasPorPeriodo(string dataInicial, string dataFinal)
        {
            return TransformaTipoListaDto().Where(o => o.DataConsulta.ConverteData() >= dataInicial.ConverteData() && o.DataConsulta.ConverteData() <= dataFinal.ConverteData())
            .OrderBy(o => o.DataConsulta).ThenBy(o => o.HoraInicial).ToList();
        }

        public List<ConsultaDto> ListarConsultaPorCpf(string cpf)
        {
            return TransformaTipoListaDto().Where(o => o.Cpf == cpf).ToList();
        }

    }
}
