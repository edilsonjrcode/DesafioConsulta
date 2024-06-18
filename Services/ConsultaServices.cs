using DesafioCSharp2.Dto;
using DesafioCSharp2.Repositories;
using DesafioCSharp2.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCSharp2.Services {
    class ConsultaServices {

        private ConsultaRepository _repositoryConsulta = new ConsultaRepository();
        private PacienteRepository _repositoryPaciente = new PacienteRepository();

        public bool AgendarConsulta(ConsultaDto consulta){
            try{
                consulta.DataConsulta.ValidaData();
                _repositoryPaciente.VerificaSeCpfEstaCadastrado(consulta.Cpf);
                if(!_repositoryPaciente.VerificaSeCpfEstaCadastrado(consulta.Cpf)){
                     
                }
            } catch (Exception e){
                throw;
            }
            return false;

        }

    }
}
