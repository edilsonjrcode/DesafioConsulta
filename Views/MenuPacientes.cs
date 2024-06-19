using DesafioCSharp2.Controllers;
using DesafioCSharp2.Dto;
using DesafioCSharp2.Utils;

public class MenuPacientes()
{
    readonly PacienteController pacienteController = new();
    readonly ConsultaController consultaController = new();

    static void PrintError(String msg)
    {
        Exception e = new Exception(msg);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nOcorreu um erro: {0}\n", e.Message);
        Console.ResetColor();
    }
    public void VCadastrarPaciente()
    {

        int count = 1;
        string nome = "";
        string cpf = "";
        string dataDeNascimento = "";

        while (count < 3)
        {

            if (count == 1)
            {
                Console.Write("CPF: ");
                cpf = Console.ReadLine();
                try
                {
                    cpf.ValidaCpf();
                }
                catch (Exception e)
                {
                    PrintError(e.Message);
                    continue;
                }
                count++;
            }

            if (count == 2)
            {
                Console.Write("Nome: ");
                nome = Console.ReadLine();
                try
                {
                    nome.ValidaNome();
                }
                catch (Exception e)
                {
                    PrintError(e.Message);
                    continue;
                }
                count++;
            }

            Console.Write("Data de Nascimento: ");
            if (count == 3)
            {
                dataDeNascimento = Console.ReadLine();
                try
                {
                    dataDeNascimento.ValidaData();
                }
                catch (Exception e)
                {
                    PrintError(e.Message);
                    continue;
                }
                count++;
            }
        }
        
        PacienteDto paciente = new PacienteDto(nome, cpf, dataDeNascimento);
        pacienteController.AddPaciente(paciente);
        if(pacienteController.AddPaciente(paciente)){
            System.Console.WriteLine("Paciente cadastrado com sucesso!");
        }
    }

    public void Executar()
    {
        while (true)
        {
            Console.WriteLine("Menu do Cadastro de Pacientes");
            Console.WriteLine("1 - Cadastrar Novo Paciente");
            Console.WriteLine("2 - Excluir Paciente");
            Console.WriteLine("3 - Listar Pacientes (Ordenado por CPF)");
            Console.WriteLine("4 - Listar Pacientes (Ordenado por Nome)");
            Console.WriteLine("5 - Voltar p/ menu principal");

            var entrada = Console.ReadLine();

            switch (entrada)
            {
                case "1":
                    VCadastrarPaciente();
                    break;
                // case "2":
                //     _consultaController.AgendarConsulta();
                //     break;
                // case "3":
                //     _pacienteController.ListarPacientes();
                //     break;
                // case "4":
                //     _consultaController.AgendarConsulta();
                //     break;
                // case "5":
                //     menuPrincipal.Executar();
                //     break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }

    }
}