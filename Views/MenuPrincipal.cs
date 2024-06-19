using DesafioCSharp2.Controllers;

namespace DesafioCSharp2.Views
{
    public class MenuPrincipal(PacienteController pacienteController, ConsultaController consultaController)
    {
        MenuPacientes menuPacientes = new MenuPacientes(pacienteController, consultaController);
        MenuConsultas menuConsultas = new MenuConsultas(pacienteController, consultaController);

        public bool Executar()
        {

            while (true)
            {
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
                        menuConsultas.Executar();
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
}