using DesafioCSharp2.Dto;
using DesafioCSharp2.Repositories;
using DesafioCSharp2.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCSharp2.Services {
    class PacienteServices {

        private PacienteRepository _repository;

        public bool IncluirPaciente(PacienteDto paciente){
            if (paciente.Cpf.ValidaCpf() && paciente.Nome.ValidaNome() && paciente.DataDeNascimento.ValidaData() && paciente.DataDeNascimento.ValidaSeCrianca()){
                _repository.IncluirPaciente(paciente);
                return true;             
            }
            return false;
        }

    }
}
