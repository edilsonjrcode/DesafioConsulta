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
    class ConsultaController {

        ConsultaServices _services = new ConsultaServices();

        public bool AddConsulta(bool cpfCadastrado, ConsultaDto paciente){
            try {
                _services.AgendarConsulta(cpfCadastrado, paciente);
            }
            catch (Exception erro){
                throw;
            }
            return true;
        }

        public List<ConsultaDto> ListarConsultas(){
            return _services.ListarConsultas();
        }

    }
}
