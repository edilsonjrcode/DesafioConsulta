using DesafioCSharp2.Controllers;
using DesafioCSharp2.Dto;
using DesafioCSharp2.Repositories;
using DesafioCSharp2.Services;
using DesafioCSharp2.Utils;

class Program {

    public static void Main(String[] args) {

        PacienteController pacienteController = new PacienteController();
        ConsultaController consultaController = new ConsultaController();

        PacienteDto paciente = new PacienteDto("Joãozinho", "02136548977", "18061981");
        PacienteDto paciente2 = new PacienteDto("Adamastor", "70698772423", "15042001");
        PacienteDto paciente3 = new PacienteDto("Pedrita", "32156987589", "16022009");

        pacienteController.AddPaciente(paciente); 
        pacienteController.AddPaciente(paciente2); 
        pacienteController.AddPaciente(paciente3); 

        pacienteController.ListarPorNome();
        pacienteController.ListarPorCpf();

        ConsultaDto consulta  = new ConsultaDto("32156987589", "20062024", "1500", "1700");
        ConsultaDto consulta1 = new ConsultaDto("70698772423", "20062024", "1400", "1445");
        ConsultaDto consulta2 = new ConsultaDto("02136548977", "20062024", "1800", "1900");
        consultaController.AddConsulta(pacienteController.CpfEstaCadastrado(consulta.Cpf),consulta);
        consultaController.AddConsulta(pacienteController.CpfEstaCadastrado(consulta1.Cpf),consulta1);
        consultaController.AddConsulta(pacienteController.CpfEstaCadastrado(consulta2.Cpf),consulta2);
        consultaController.ListarConsultas();
        consultaController.DeleteConsulta(pacienteController.CpfEstaCadastrado(consulta2.Cpf),consulta2);
        consultaController.ListarConsultas();
        System.Console.WriteLine("Fim");

        // TimeSpan span = new TimeSpan(15,00,00);
        // string hora = span.Hours.ToString();
        // string minutos = span.Minutes.ToString();
        // System.Console.WriteLine(hora+minutos);
    } 
}