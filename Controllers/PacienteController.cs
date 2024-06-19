using DesafioCSharp2.Dto;
using DesafioCSharp2.Repositories;
using DesafioCSharp2.Services;
using DesafioCSharp2.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCSharp2.Controllers {
    class PacienteController {

        PacienteServices _services = new PacienteServices();

        public bool AddPaciente(PacienteDto paciente){
            try {
                _services.IncluirPaciente(paciente);
            }
            catch (Exception erro){
                throw;
            }
            return true;
        }

        public bool CpfEstaCadastrado(string cpf){
            return _services.CpfEstaCadastrado(cpf);
        }

        public List<PacienteDto> ListarPorNome(){
            return _services.ListarPacientesPorNome();
        }

        public List<PacienteDto> ListarPorCpf(){
            return _services.ListarPacientesPorCpf();
        }

    }
}
