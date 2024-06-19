using DesafioCSharp2.Dto;
using DesafioCSharp2.Model;
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

        public bool AgendarConsulta(bool CpfCadastrado, ConsultaDto consulta){
            try{
                if(CpfCadastrado){
                    consulta.DataConsulta.ValidaData();
                    consulta.HoraInicial.ValidaHora();
                    consulta.HoraFinal.ValidaHora();
                    _repositoryConsulta.VerificaSePossuiAgendamento(consulta.Cpf);
                    if (consulta.PeriodoFuturo()){
                        _repositoryConsulta.AgendarConsulta(consulta);
                        return true;
                    }
                }
                else {
                    throw new Exception("CPF não está cadastrado!");
                }
            } catch (Exception e){
                throw;
            }
            return false;
        }

        public List<ConsultaDto> ListarConsultas(){
            return _repositoryConsulta.TransformaTipoListaDto();
        }

    }
}
