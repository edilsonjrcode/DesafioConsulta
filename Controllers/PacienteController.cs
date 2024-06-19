using DesafioCSharp2.Dto;
using DesafioCSharp2.Services;

namespace DesafioCSharp2.Controllers
{
    class PacienteController
    {

        readonly PacienteServices _services = new PacienteServices();

        public bool AddPaciente(PacienteDto paciente)
        {
            try
            {
                _services.IncluirPaciente(paciente);
            }
            catch
            {
                throw;
            }
            return true;
        }

        public bool DeletePaciente(bool possuiConsulta, string cpf)
        {
            try
            {
                _services.ExcluirPaciente(possuiConsulta, cpf);
            }
            catch
            {
                throw;
            }
            return true;
        }

        public bool CpfEstaCadastrado(string cpf)
        {
            return _services.CpfEstaCadastrado(cpf);
        }

        public List<PacienteDto> ListarPorNome()
        {
            return _services.ListarPacientesPorNome();
        }

        public List<PacienteDto> ListarPorCpf()
        {
            return _services.ListarPacientesPorCpf();
        }

    }
}
