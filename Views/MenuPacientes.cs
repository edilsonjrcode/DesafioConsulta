using DesafioCSharp2.Controllers;
using DesafioCSharp2.Dto;
using DesafioCSharp2.Utils;

public class MenuPacientes(PacienteController pacienteController, ConsultaController consultaController)
{
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
            try
            {
                if (count == 1)
                {
                    Console.Write("CPF: ");
                    cpf = Console.ReadLine();
                    try
                    {
                        if(!pacienteController.CpfEstaCadastrado(cpf)){
                            cpf.ValidaCpf();
                        } else {
                            throw new Exception("CPF já está cadastrado!");
                        }
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

                PacienteDto paciente = new PacienteDto(nome, cpf, dataDeNascimento);
                pacienteController.AddPaciente(paciente);
                System.Console.WriteLine("Paciente cadastrado com sucesso!\n");
            }
            catch (Exception e)
            {
                PrintError(e.Message);
                continue;

            }
            count++;

        }
    }

    public void VDeletarPaciente()
    {

        Console.Write("CPF: ");
        string cpf = Console.ReadLine();
        try
        {
            cpf.ValidaCpf();
            pacienteController.DeletePaciente(consultaController.PossuiAgendamento(cpf), cpf);
            System.Console.WriteLine("Paciente deletado com sucesso!\n");

        }
        catch (Exception e)
        {
            PrintError(e.Message);
        }
    }

    public void VListarPacientePorCpf()
    {
        List<PacienteDto> pacientes = pacienteController.ListarPorCpf();

        System.Console.WriteLine("------------------------------------------------------------");
        System.Console.WriteLine("CPF          Nome              Dt.Nasc.             Idade");
        System.Console.WriteLine("------------------------------------------------------------");
        foreach (PacienteDto paciente in pacientes)
        {
            System.Console.WriteLine("{0}  {1}           {2}             {3}",
            paciente.Cpf, paciente.Nome, paciente.DataDeNascimento.ConverteData().ToString("dd/MM/yyyy"), paciente.DataDeNascimento.ConverteIdade());
            List<ConsultaDto> consultas = consultaController.ListarConsultaPorCpf(paciente.Cpf);
            if (consultas.Count > 0)
            {
                System.Console.WriteLine("          Agendado para: {0}", consultas[0].DataConsulta.ConverteData().ToString("dd/MM/yyyy"));
                System.Console.WriteLine("          {0} às {1}", consultas[0].HoraInicial.ConverteHora(), consultas[0].HoraFinal.ConverteHora());
            }
        }
        System.Console.WriteLine("------------------------------------------------------------");
    }

    public void VListarPacientePorNome()
    {
        List<PacienteDto> pacientes = pacienteController.ListarPorNome();

        System.Console.WriteLine("------------------------------------------------------------");
        System.Console.WriteLine("CPF          Nome              Dt.Nasc.             Idade");
        System.Console.WriteLine("------------------------------------------------------------");

        foreach (PacienteDto paciente in pacientes)
        {
            System.Console.WriteLine("{0}  {1}           {2}             {3}",
            paciente.Cpf, paciente.Nome, paciente.DataDeNascimento.ConverteData().ToString("dd/MM/yyyy"), paciente.DataDeNascimento.ConverteIdade());
            List<ConsultaDto> consultas = consultaController.ListarConsultaPorCpf(paciente.Cpf);
            if (consultas.Count > 0)
            {
                System.Console.WriteLine("      Agendado para: {0}", consultas[0].DataConsulta.ConverteData().ToString("dd/MM/yyyy"));
                System.Console.WriteLine("      {0} às {1}", consultas[0].HoraInicial.ConverteHora(), consultas[0].HoraFinal.ConverteHora());
            }
        }
        System.Console.WriteLine("------------------------------------------------------------");
    }
    public bool Executar()
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
                case "2":
                    VDeletarPaciente();
                    break;
                case "3":
                    VListarPacientePorCpf();
                    break;
                case "4":
                    VListarPacientePorNome();
                    break;
                case "5":
                    return false;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }

    }
}