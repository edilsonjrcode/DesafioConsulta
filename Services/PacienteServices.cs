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

        PacienteRepository _repository = new PacienteRepository();

        public bool IncluirPaciente(PacienteDto paciente){
            try{
                paciente.Cpf.ValidaCpf();
                paciente.Nome.ValidaNome();
                paciente.DataDeNascimento.ValidaData();
                paciente.DataDeNascimento.ValidaSeCrianca();
                if(!_repository.VerificaSeCpfEstaCadastrado(paciente)){
                    _repository.IncluirPaciente(paciente);
                    return true;  
                }
            } catch (Exception e){
                throw;
            }
            return false;
        }

    }
}
