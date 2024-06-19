using DesafioCSharp2.Controllers;
using DesafioCSharp2.Dto;
using DesafioCSharp2.Views;

class Program
{

    public static void Main(String[] args)
    {
        
        PacienteController pacienteController = new();
        ConsultaController consultaController = new();

        MenuPrincipal menu = new(pacienteController, consultaController);
        menu.Executar();
    }
}