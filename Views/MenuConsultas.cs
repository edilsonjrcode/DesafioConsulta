using DesafioCSharp2.Controllers;
using DesafioCSharp2.Dto;
using DesafioCSharp2.Utils;

namespace DesafioCSharp2.Views
{
    public class MenuConsultas(PacienteController pacienteController, ConsultaController consultaController)
    {

        static void PrintError(string msg)
        {
            Exception e = new(msg);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nOcorreu um erro: {0}\n", e.Message);
            Console.ResetColor();
        }

        public void VCadastrarConsulta()
        {

            int count = 1;
            string cpf = "";
            string data = "";
            string horaInicial = "";
            string horaFinal = "";

            while (count <= 4)
            {
                try
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
                        Console.Write("Data da Consulta: ");
                        data = Console.ReadLine();
                        try
                        {
                            data.ValidaData();
                        }
                        catch (Exception e)
                        {
                            PrintError(e.Message);
                            continue;
                        }
                        count++;
                    }

                    if (count == 3)
                    {
                        Console.Write("Hora Inicial: ");
                        horaInicial = Console.ReadLine();
                        try
                        {
                            horaInicial.ValidaHora();
                        }
                        catch (Exception e)
                        {
                            PrintError(e.Message);
                            continue;
                        }
                        count++;
                    }

                    if (count == 4)
                    {
                        Console.Write("Hora Final: ");
                        horaFinal = Console.ReadLine();
                        try
                        {
                            horaInicial.ValidaHora();
                        }
                        catch (Exception e)
                        {
                            PrintError(e.Message);
                            continue;
                        }
                    }
                    ConsultaDto consulta = new ConsultaDto(cpf, data, horaInicial, horaFinal);
                    consultaController.AddConsulta(pacienteController.CpfEstaCadastrado(consulta.Cpf), consulta);
                    Console.WriteLine("Agendamento realizado com sucesso!\n");

                }
                catch (Exception e)
                {
                    PrintError(e.Message);
                    continue;
                }
                count++;

            }


        }

        public void VDeletarConsulta()
        {
            int count = 1;
            string cpf = "";
            string data = "";
            string horaInicial = "";

            while (count <= 3)
            {
                try
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
                        Console.Write("Data da Consulta: ");

                        data = Console.ReadLine();
                        try
                        {
                            data.ValidaData();
                        }
                        catch (Exception e)
                        {
                            PrintError(e.Message);
                            continue;
                        }
                        count++;
                    }

                    if (count == 3)
                    {
                        Console.Write("Hora Inicial: ");

                        horaInicial = Console.ReadLine();
                        try
                        {
                            horaInicial.ValidaHora();
                        }
                        catch (Exception e)
                        {
                            PrintError(e.Message);
                            continue;
                        }
                    }
                    ConsultaDto consulta = new ConsultaDto(cpf, data, horaInicial, "");
                    consultaController.DeleteConsulta(pacienteController.CpfEstaCadastrado(consulta.Cpf), consulta);
                    Console.WriteLine("Agendamento excluído com sucesso!\n");

                }
                catch (Exception e)
                {
                    PrintError(e.Message);
                    break;
                }
                count++;

            }
        }

        public void VListarAgenda()
        {
            // Console.Clear();
            Console.WriteLine("Apresentar a agenda T-Toda ou P-Periodo:");
            var entrada = Console.ReadLine()?.ToUpper();

            switch (entrada)
            {
                case "T":
                    try
                    {
                        List<ConsultaDto> consultas = consultaController.ListarConsultas();
                        Console.WriteLine("-------------------------------------------------------------");
                        Console.WriteLine("Data        H.Ini     H.Fim     Tempo      Nome       Dt.Nasc.");
                        Console.WriteLine("-------------------------------------------------------------");
                        foreach (ConsultaDto consulta in consultas)
                        {
                            List<PacienteDto> paciente = pacienteController.ListarPacientePorCpf(consulta.Cpf);
                            if (consultas.Count > 0)
                            {
                                Console.WriteLine("{0} {1}  {2}   {3}   {4} {5}", consulta.DataConsulta.ConverteData().ToString("dd/MM/yyyy"),
                                consulta.HoraInicial.ConverteHora(), consulta.HoraFinal.ConverteHora(), consulta.HoraFinal.ConverteHora() - consulta.HoraInicial.ConverteHora(),
                                paciente[0].Nome, paciente[0].DataDeNascimento.ConverteData().ToString("dd/MM/yyyy"));
                            }
                        }
                        Console.WriteLine("-------------------------------------------------------------");
                    }
                    catch (Exception e)
                    {
                        PrintError(e.Message);
                    }
                    break;


                case "P":

                    try
                    {

                        Console.Write("Data inicial: ");
                        var dataInicial = Console.ReadLine();

                        Console.Write("Data final: ");
                        var dataFinal = Console.ReadLine();

                        List<ConsultaDto> consultasPorPeriodo = consultaController.ListarConsultasPorPeriodo(dataInicial, dataFinal);


                        Console.WriteLine("-------------------------------------------------------------");
                        Console.WriteLine("Data        H.Ini     H.Fim     Tempo      Nome       Dt.Nasc.");
                        Console.WriteLine("-------------------------------------------------------------");
                        foreach (ConsultaDto consulta in consultasPorPeriodo)
                        {
                            List<PacienteDto> paciente = pacienteController.ListarPacientePorCpf(consulta.Cpf);
                            if (consultasPorPeriodo.Count > 0)
                            {
                                Console.WriteLine("{0} {1}  {2}   {3}   {4} {5}", consulta.DataConsulta.ConverteData().ToString("dd/MM/yyyy"),
                                consulta.HoraInicial.ConverteHora(), consulta.HoraFinal.ConverteHora(), consulta.HoraFinal.ConverteHora() - consulta.HoraInicial.ConverteHora(),
                                paciente[0].Nome, paciente[0].DataDeNascimento.ConverteData().ToString("dd/MM/yyyy"));
                            }
                        }
                        Console.WriteLine("-------------------------------------------------------------");
                    }
                    catch (Exception e)
                    {
                        PrintError(e.Message);
                    }
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
        public bool Executar()
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
                        VCadastrarConsulta();
                        break;
                    case "2":
                        VDeletarConsulta();
                        break;
                    case "3":
                        VListarAgenda();
                        break;
                    case "4":
                        return false;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }

        }
    }
}