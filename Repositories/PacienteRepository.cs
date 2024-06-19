using DesafioCSharp2.Dto;
using DesafioCSharp2.Model;
using DesafioCSharp2.Utils;

namespace DesafioCSharp2.Repositories
{
    public class PacienteRepository
    {

        private List<Paciente> pacientes = [];

        public bool VerificaSeCpfEstaCadastrado(string cpf)
        {
            foreach (Paciente pacienteCadastrado in pacientes)
            {
                if (pacienteCadastrado.Cpf == cpf)
                {
                    return true;
                }
            }
            return false;
        }

        public void IncluirPaciente(PacienteDto paciente)
        {
            Paciente novoPaciente = new Paciente(paciente.Nome, paciente.Cpf, paciente.DataDeNascimento.ConverteData());
            pacientes.Add(novoPaciente);
        }

        public bool ExcluirPaciente(string cpf)
        {
            foreach (Paciente pacienteCadastrado in pacientes)
            {
                if (pacienteCadastrado.Cpf == cpf)
                {
                    pacientes.Remove(pacienteCadastrado);
                    return true;
                }
            }
            throw new Exception("CPF não encontrado.");
        }

        public List<PacienteDto> TransformaTipoListaDto()
        {

            List<PacienteDto> listaPacientes = new List<PacienteDto>();

            foreach (Paciente paciente in pacientes)
            {
                PacienteDto pacienteDto = new PacienteDto(paciente.Nome, paciente.Cpf, paciente.DataDeNascimento.ToString("ddMMyyyy"));
                listaPacientes.Add(pacienteDto);
            }

            return listaPacientes;
        }

        public List<PacienteDto> ListarPacientesPorNome()
        {
            return TransformaTipoListaDto().OrderBy(o => o.Nome).ToList();
        }

        public List<PacienteDto> ListarPacientesPorCpf()
        {
            return TransformaTipoListaDto().OrderBy(o => o.Cpf).ToList();
        }
    }
}
