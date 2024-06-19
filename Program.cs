using DesafioCSharp2.Controllers;
using DesafioCSharp2.Dto;

class Program
{

    public static void Main(String[] args)
    {

        MenuPrincipal menu = new MenuPrincipal();
        menu.Executar();

        // PacienteController pacienteController = new PacienteController();
        // ConsultaController consultaController = new ConsultaController();

        // PacienteDto paciente = new PacienteDto("Joãozinho", "02136548977", "18061981");
        // PacienteDto paciente2 = new PacienteDto("Adamastor", "70698772423", "15042001");
        // PacienteDto paciente3 = new PacienteDto("Pedrita", "32156987589", "16022009");
        // PacienteDto paciente4 = new PacienteDto("Vasconcelos", "23654897212", "12012000");

        // pacienteController.AddPaciente(paciente);
        // pacienteController.AddPaciente(paciente2);
        // pacienteController.AddPaciente(paciente3);
        // pacienteController.AddPaciente(paciente4);

        // pacienteController.ListarPorNome();
        // pacienteController.ListarPorCpf();

        // ConsultaDto consulta = new ConsultaDto("32156987589", "25062024", "1500", "1700");
        // ConsultaDto consulta1 = new ConsultaDto("70698772423", "20062024", "1400", "1445");
        // ConsultaDto consulta2 = new ConsultaDto("02136548977", "19062024", "1800", "1900");
        // ConsultaDto consulta3 = new ConsultaDto("23654897212", "20062024", "0800", "0900");
        // consultaController.AddConsulta(pacienteController.CpfEstaCadastrado(consulta.Cpf), consulta);
        // consultaController.AddConsulta(pacienteController.CpfEstaCadastrado(consulta1.Cpf), consulta1);
        // consultaController.AddConsulta(pacienteController.CpfEstaCadastrado(consulta2.Cpf), consulta2);
        // consultaController.AddConsulta(pacienteController.CpfEstaCadastrado(consulta3.Cpf), consulta3);
        // consultaController.ListarConsultas();
        // consultaController.DeleteConsulta(pacienteController.CpfEstaCadastrado(consulta3.Cpf), consulta3);
        // consultaController.ListarConsultas();
        // consultaController.ListarConsultasPorPeriodo("190624", "21062024");
        
        // pacienteController.DeletePaciente(consultaController.PossuiAgendamento(paciente.Cpf), paciente.Cpf);

        // pacienteController.ListarPorNome();
        // pacienteController.ListarPorCpf();
        
        

        // System.Console.WriteLine("Fim");


    }
}