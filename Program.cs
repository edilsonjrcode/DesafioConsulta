using DesafioCSharp2.Controllers;
using DesafioCSharp2.Dto;
using DesafioCSharp2.Repositories;
using DesafioCSharp2.Services;
using DesafioCSharp2.Utils;

class Program {

    public static void Main(String[] args) {

        PacienteController controller = new PacienteController();

        PacienteDto paciente = new PacienteDto();

        paciente.Nome = "Joãozinho";
        paciente.Cpf = "70698772423";
        paciente.DataDeNascimento = "18062012";

        // _services.IncluirPaciente(paciente);    
        controller.AddPaciente(paciente); 
        controller.AddPaciente(paciente); 
           
    } 
}