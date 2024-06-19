using DesafioCSharp2.Controllers;
using DesafioCSharp2.Dto;
using DesafioCSharp2.Repositories;
using DesafioCSharp2.Services;
using DesafioCSharp2.Utils;

class Program {

    public static void Main(String[] args) {

        PacienteController controller = new PacienteController();
        ConsultaServices _services = new ConsultaServices();

        PacienteDto paciente = new PacienteDto("Joãozinho", "02136548977", "18061981");
        PacienteDto paciente2 = new PacienteDto("Adamastor", "70698772423", "15042001");
        PacienteDto paciente3 = new PacienteDto("Pedrita", "32156987589", "16022009");

        controller.AddPaciente(paciente); 
        controller.AddPaciente(paciente2); 
        controller.AddPaciente(paciente3); 

        controller.ListarPorNome();
        controller.ListarPorCpf();

        ConsultaDto consulta = new ConsultaDto("32156987589", "18062024", "1500", "1600");
        _services.AgendarConsulta(consulta);

        

        // string time = "1645";

        // time.ValidaHora();

        // TimeSpan t1 = new TimeSpan(15,40,00);
        // System.Console.WriteLine(t1);
        // TimeSpan t2 = time.ConverteHora();
        // System.Console.WriteLine(t2);
        // TimeSpan t3 = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        // System.Console.WriteLine(t3 > t2);


    } 
}