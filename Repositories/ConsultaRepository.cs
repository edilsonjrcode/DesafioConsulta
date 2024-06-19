using DesafioCSharp2.Dto;
using DesafioCSharp2.Model;
using DesafioCSharp2.Utils;

namespace DesafioCSharp2.Repositories
{
    class ConsultaRepository
    {

        private List<Consulta> Consultas = [];

        public bool VerificaSePossuiAgendamento(string cpf)
        {
            foreach (Consulta ConsultaCadastrada in Consultas)
            {
                if (ConsultaCadastrada.Cpf == cpf)
                {
                    if(ConsultaCadastrada.DataConsulta > DateTime.Now.Date){
                        throw new Exception("O usuário já possui um agendamento.");
                    }
                }
            }
            return false;
        }

        public void AgendarConsulta(ConsultaDto consulta)
        {

            foreach (Consulta ConsultaCadastrada in Consultas)
            {
                if(ConsultaCadastrada.DataConsulta == consulta.DataConsulta.ConverteData()){
                    
                }

            }
            Consulta novaConsulta = new Consulta(consulta.Cpf, consulta.DataConsulta.ConverteData(), consulta.HoraInicial.ConverteHora(), consulta.HoraFinal.ConverteHora());
            Consultas.Add(novaConsulta);
        }

        public void CancelarConsulta(ConsultaDto consulta)
        {
            Consulta novaConsulta = new Consulta(consulta.Cpf, consulta.DataConsulta.ConverteData(), consulta.HoraInicial.ConverteHora(), consulta.HoraFinal.ConverteHora());
            Consultas.Remove(novaConsulta);
        }

        public List<Consulta> ListarConsulta()
        {
            return Consultas;
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

        public List<ConsultaDto> ListarPacientesPorNome()
        {
            return TransformaTipoListaDto().OrderBy(o => o.DataConsulta).ToList();
        }

        public List<ConsultaDto> ListarPacientesPorCpf()
        {
            return TransformaTipoListaDto().OrderBy(o => o.Cpf).ToList();
        }

    }
}
