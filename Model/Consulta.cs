namespace DesafioCSharp2.Model
{
    class Consulta(string Cpf, DateTime DataConsulta, TimeSpan HoraInicial, TimeSpan HoraFinal)
    {
        public string Cpf { get; private set; } = Cpf;
        public DateTime DataConsulta { get; private set; } = DataConsulta;
        public TimeSpan HoraInicial { get; private set; } = HoraInicial;
        public TimeSpan HoraFinal { get; private set; } = HoraFinal;
    }
}
