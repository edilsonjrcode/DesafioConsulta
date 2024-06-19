using DesafioCSharp2.Dto;
using DesafioCSharp2.Repositories;
using DesafioCSharp2.Utils;

namespace DesafioCSharp2.Services
{
    public class PacienteServices
    {

        PacienteRepository _repository = new PacienteRepository();

        public bool IncluirPaciente(PacienteDto paciente)
        {
            try
            {
                // paciente.Cpf.ValidaCpf();
                // paciente.Nome.ValidaNome();
                // paciente.DataDeNascimento.ValidaData();
                paciente.DataDeNascimento.ValidaSeCrianca();
                if (!_repository.VerificaSeCpfEstaCadastrado(paciente.Cpf))
                {
                    _repository.IncluirPaciente(paciente);
                    return true;
                } else {
                    throw new Exception("CPF já está cadastrado");
                }
            }
            catch
            {
                throw;
            }
        }

        public bool ExcluirPaciente(bool possuiConsulta, string cpf)
        {
            try
            {
                if (!possuiConsulta)
                {
                    _repository.ExcluirPaciente(cpf);
                }
                else
                {
                    throw new Exception("O paciente não pode ser excluído pois possui consultas futuras.");
                }
            }
            catch
            {
                throw;
            }
            return false;
        }

        public bool CpfEstaCadastrado(string cpf)
        {
            return _repository.VerificaSeCpfEstaCadastrado(cpf);
        }

        public List<PacienteDto> ListarPacientesPorNome()
        {
            if (_repository.ListarPacientesPorNome().Count() <= 0)
            {
                return [];
            }
            return _repository.ListarPacientesPorNome();

        }

        public List<PacienteDto> ListarPacientesPorCpf()
        {
            if (_repository.ListarPacientesPorCpf().Count() <= 0)
            {
                return [];
            }
            return _repository.ListarPacientesPorCpf();
        }

        public List<PacienteDto> PacientePorCpf(string cpf)
        {
            return _repository.ListarPacientePorCpf(cpf);
        }
    }
}
