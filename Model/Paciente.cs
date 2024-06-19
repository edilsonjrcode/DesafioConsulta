namespace DesafioCSharp2.Model
{
    class Paciente(string Nome, string Cpf, DateTime DataDeNascimento)
    {

        public string Nome { get; private set; } = Nome;

        public string Cpf { get; private set; } = Cpf;

        public DateTime DataDeNascimento { get; private set; } = DataDeNascimento;
    }
}
