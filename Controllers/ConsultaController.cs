using DesafioCSharp2.Dto;
using DesafioCSharp2.Services;

namespace DesafioCSharp2.Controllers
{
    public class ConsultaController
    {

        ConsultaServices _services = new ConsultaServices();

        public bool AddConsulta(bool cpfCadastrado, ConsultaDto paciente)
        {
            try
            {
                _services.AgendarConsulta(cpfCadastrado, paciente);
            }
            catch
            {
                throw;
            }
            return true;
        }

        public bool DeleteConsulta(bool cpfCadastrado, ConsultaDto paciente)
        {
            try
            {
                _services.RemoverConsulta(cpfCadastrado, paciente);
            }
            catch
            {
                throw;
            }
            return true;
        }

        public bool PossuiAgendamento(string cpf)
        {
            return _services.PossuiAgendamento(cpf);
        }

        public List<ConsultaDto> ListarConsultas()
        {
            return _services.ListarConsultas();
        }

        public List<ConsultaDto> ListarConsultasPorPeriodo(string dataInicial, string dataFinal)
        {
            return _services.ListarConsultasPorPeriodo(dataInicial, dataFinal);
        }

        public List<ConsultaDto> ListarConsultaPorCpf(string cpf)
        {
            return _services.ListarConsultaPorCpf(cpf);
        }
    }
}
