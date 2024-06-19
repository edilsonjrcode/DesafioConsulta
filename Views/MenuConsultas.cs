using DesafioCSharp2.Controllers;
using DesafioCSharp2.Dto;
using DesafioCSharp2.Utils;

public class MenuConsultas()
{

    // readonly MenuPrincipal menuPrincipal = new();


    static void PrintError(String msg)
    {
        Exception e = new Exception(msg);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nOcorreu um erro: {0}\n", e.Message);
        Console.ResetColor();
    }

    public void Executar()
    {
        while (true)
        {
            Console.WriteLine("Consultas");
            Console.WriteLine("1 - Agendar Consulta");
            Console.WriteLine("2 - Cancelar Agendamento");
            Console.WriteLine("3 - Listar Agenda");
            Console.WriteLine("4 - Voltar p/ menu principal");

            var entrada = Console.ReadLine();

            switch (entrada)
            {
                case "1":
                    VCadastrarPaciente();
                    break;
                case "2":
                    _consultaController.AgendarConsulta();
                    break;
                case "3":
                    _pacienteController.ListarPacientes();
                    break;
                case "4":
                    _consultaController.AgendarConsulta();
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }

    }
}