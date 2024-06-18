using DesafioCSharp2.Model;
using DesafioCSharp2.Utils;

class Program {

    public static void Main(String[] args) {

        string CPF = "70698772423";

        string data = "28022001";

        // Console.WriteLine(CPF.ValidaCpf());
        // Console.WriteLine(CPF.ValidaNomeUsuario());
        Console.WriteLine(data.ValidaData());
        System.Console.WriteLine(data.ValidaSeCrianca());

    } 
}