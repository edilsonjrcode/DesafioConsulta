using DesafioCSharp2.Dto;
using DesafioCSharp2.Model;
using DesafioCSharp2.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCSharp2.Repositories
{
    class PacienteRepository
    {

        private List<Paciente> pacientes = [];

        public bool VerificaSeCpfEstaCadastrado(string cpf)
        {
            foreach (Paciente pacienteCadastrado in pacientes)
            {
                if (pacienteCadastrado.Cpf == cpf)
                {
                    return true;
                    // throw new Exception("CPF já está cadastrado!");
                }
            }
            return false;

        }

        public void IncluirPaciente(PacienteDto paciente)
        {
            Paciente novoPaciente = new Paciente(paciente.Nome, paciente.Cpf, paciente.DataDeNascimento.ConverteData());
            pacientes.Add(novoPaciente);
        }

        public void ExcluirPaciente(PacienteDto paciente)
        {
            Paciente novoPaciente = new Paciente(paciente.Nome, paciente.Cpf, paciente.DataDeNascimento.ConverteData());
            pacientes.Remove(novoPaciente);
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
