using DesafioCSharp2.Dto;
using DesafioCSharp2.Repositories;
using DesafioCSharp2.Utils;

namespace DesafioCSharp2.Services
{
    class ConsultaServices
    {

        private ConsultaRepository _repositoryConsulta = new ConsultaRepository();

        public bool AgendarConsulta(bool CpfCadastrado, ConsultaDto consulta)
        {
            try
            {
                if (consulta.HoraInicial.ConverteHora() >= new TimeSpan(8, 0, 0) && consulta.HoraInicial.ConverteHora() <= new TimeSpan(19, 0, 0)
                && consulta.HoraFinal.ConverteHora() >= new TimeSpan(8, 0, 0) && consulta.HoraFinal.ConverteHora() <= new TimeSpan(19, 0, 0))
                {
                    if (CpfCadastrado)
                    {
                        consulta.DataConsulta.ValidaData();
                        consulta.HoraInicial.ValidaHora();
                        consulta.HoraFinal.ValidaHora();
                        _repositoryConsulta.VerificaSePossuiAgendamento(consulta.Cpf);
                        if (consulta.HoraFinal.ConverteHora() > consulta.HoraInicial.ConverteHora())
                        {
                            if (consulta.PeriodoFuturo())
                            {
                                _repositoryConsulta.AgendarConsulta(consulta);
                                return true;
                            }
                        }
                        else
                        {
                            throw new Exception("A hora final é maior que a hora inicial!");
                        }
                    }
                    else
                    {
                        throw new Exception("CPF não está cadastrado!");
                    }
                }
                else
                {
                    throw new Exception("O horário selecionado está fora do horário de funcionamento. Nosso horário de funcionamento é de 08:00 às 19:00");
                }


            }
            catch (Exception e)
            {
                throw;
            }
            return false;
        }

        public bool RemoverConsulta(bool CpfCadastrado, ConsultaDto consulta)
        {
            try
            {
                if (CpfCadastrado)
                {
                    if (_repositoryConsulta.VerificaSePossuiAgendamento(consulta.Cpf))
                    {
                        _repositoryConsulta.CancelarConsulta(consulta);
                        return true;
                    }
                    else
                    {
                        throw new Exception("O paciente não possui agendamento");
                    }
                }
                else
                {
                    throw new Exception("CPF não está cadastrado!");
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool PossuiAgendamento(string cpf)
        {
            return _repositoryConsulta.VerificaSePossuiAgendamento(cpf);
        }

        public List<ConsultaDto> ListarConsultas()
        {
            return _repositoryConsulta.ListarConsultas();
        }

        public List<ConsultaDto> ListarConsultasPorPeriodo(string dataInicial, string dataFinal)
        {
            try
            {
                if (dataInicial.ValidaData() && dataFinal.ValidaData())
                {
                    return _repositoryConsulta.ListarConsultasPorPeriodo(dataInicial, dataFinal);
                }
            }
            catch
            {
                throw;
            }
            return [];

        }

    }
}
