﻿using DesafioCSharp2.Dto;
using DesafioCSharp2.Model;
using DesafioCSharp2.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCSharp2.Repositories {
    class PacienteRepository {

        private List<Paciente> pacientes;

        public void IncluirPaciente(PacienteDto paciente) {
            Paciente novoPaciente = new Paciente(paciente.Nome, paciente.Cpf, paciente.DataDeNascimento.ConverteData());
            pacientes.Add(novoPaciente);
        }

        public void ExcluirPaciente(Paciente paciente) {
            pacientes.Remove(paciente);
        }

        public List<Paciente> ListarPacientes() {
            return pacientes;
        }
    }
}
