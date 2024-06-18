using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCSharp2.Utils {
    public static class Utils {

        public static bool ValidaCpf(this string cpf) {
            return true;
        }

        public static bool ValidaNome(this string nome) {
            if (nome.Length < 5) {
                throw new Exception("O nome do paciente deve ter pelo menos 5 caracteres");
            } 
            else return true;
        }

        public static DateTime ConverteData(this string data){
            try{
                DateTime.ParseExact(data, "ddMMyyyy", CultureInfo.InvariantCulture);
            }
            catch {
                throw new Exception("ERRO: A data precisa estar no formato DDMMYYYY. Ex: 01012000 ");
            }
            DateTime dataConvertida = DateTime.ParseExact(data, "ddMMyyyy", CultureInfo.InvariantCulture);
            return dataConvertida;
        }

        public static bool ValidaData(this string data) {
            if (data.Length < 8 || data.Length > 8) {
                throw new Exception("ERRO: A data precisa estar no formato DDMMYYYY. Ex: 01012000 ");
            } else {
                try {
                    data.ConverteData();
                } catch (Exception e){
                    throw;
                }
                return true;
            }
        }

        public static bool ValidaSeCrianca(this string data) {
            if (data.ValidaData()) {
                TimeSpan dataDiferenca = DateTime.Now - data.ConverteData();

                int idade = dataDiferenca.Days / 365;  
                if (idade >= 13){
                    return true;
                }          
            }
            throw new Exception("paciente deve ter pelo menos 13 anos.");
        }

    }
}
