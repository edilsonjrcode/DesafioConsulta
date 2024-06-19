using DesafioCSharp2.Controllers;

public class MenuPrincipal()
{

    private readonly PacienteController _pacienteController;
    private readonly ConsultaController _consultaController;
    MenuPacientes menuPacientes = new MenuPacientes();
    MenuConsultas menuConsultas = new MenuConsultas();

    public MenuPrincipal(PacienteController pacienteController, ConsultaController consultaController)
        {
            this._pacienteController = pacienteController;
            this._consultaController = consultaController;
        }

    public bool Executar()
    {

        while (true)
        {
            // Console.Clear();
            Console.WriteLine("Menu Principal");
            Console.WriteLine("1 - Cadastro de Pacientes");
            Console.WriteLine("2 - Agenda");
            Console.WriteLine("3 - Fim");

            var entrada = Console.ReadLine();

            switch (entrada)
            {
                case "1":
                    menuPacientes.Executar();
                    break;
                case "2":
                    // menuConsultas.Executar();
                    break;
                case "3":
                    return false;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }

    }
}