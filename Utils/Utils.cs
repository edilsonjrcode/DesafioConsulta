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
            if (nome.Length < 5) return false;
            else return true;
        }

        public static DateTime ConverteData(this string data){
            DateTime dataConvertida = DateTime.ParseExact(data, "ddMMyyyy", CultureInfo.InvariantCulture);
            return dataConvertida;
        }

        public static bool ValidaData(this string data) {
            if (data.Length < 8 || data.Length > 8) {
                return false;
            } else {
                try {
                    data.ConverteData();
                } catch (Exception e){
                    return false;
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
            return false;
        }
    }
}
