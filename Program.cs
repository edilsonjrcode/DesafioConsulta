using DesafioCSharp2.Controllers;
using DesafioCSharp2.Dto;
using DesafioCSharp2.Repositories;
using DesafioCSharp2.Services;
using DesafioCSharp2.Utils;

class Program {

    public static void Main(String[] args) {

        PacienteController controller = new PacienteController();

        PacienteDto paciente = new PacienteDto("Joãozinho", "02136548977", "18061981");
        PacienteDto paciente2 = new PacienteDto("Adamastor", "70698772423", "15042001");
        PacienteDto paciente3 = new PacienteDto("Pedrita", "32156987589", "16022009");

        controller.AddPaciente(paciente); 
        controller.AddPaciente(paciente2); 
        controller.AddPaciente(paciente3); 

        controller.ListarPorNome();
        controller.ListarPorCpf();
           
    } 
}