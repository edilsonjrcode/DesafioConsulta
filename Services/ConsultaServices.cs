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
                _repositoryPaciente.VerificaSeCpfEstaCadastrado(consulta.Cpf);
                consulta.DataConsulta.ValidaData();
                consulta.HoraInicial.ValidaHora();
                consulta.HoraFinal.ValidaHora();
                if(_repositoryPaciente.VerificaSeCpfEstaCadastrado(consulta.Cpf)){
                     consulta.PeriodoFuturo();
                } else {
                    throw new Exception("CPF não já está cadastrado!");
                }
            } catch (Exception e){
                throw;
            }
            return false;

        }

    }
}
