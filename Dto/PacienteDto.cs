namespace DesafioCSharp2.Dto
{
    public class PacienteDto(string Nome, string Cpf, string DataDeNascimento)
    {

        public string Nome { get; set; } = Nome;

        public string Cpf { get; set; } = Cpf;

        public string DataDeNascimento { get; set; } = DataDeNascimento;
    }
}
