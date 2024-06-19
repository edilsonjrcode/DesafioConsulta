﻿using System.Globalization;

namespace DesafioCSharp2.Utils
{
    public static class Utils
    {

        public static bool ValidaCpf(this string cpf)
        {
            return true;
        }

        public static bool ValidaNome(this string nome)
        {
            if (nome.Length < 5)
            {
                throw new Exception("O nome do paciente deve ter pelo menos 5 caracteres");
            }
            else return true;
        }

        public static DateTime ConverteData(this string data)
        {
            try
            {
                DateTime.ParseExact(data, "ddMMyyyy", CultureInfo.InvariantCulture);
            }
            catch
            {
                throw new Exception("ERRO: A data precisa estar no formato DDMMYYYY. Ex: 01012000 ");
            }
            DateTime dataConvertida = DateTime.ParseExact(data, "ddMMyyyy", CultureInfo.InvariantCulture);
            return dataConvertida.Date;
        }

        public static bool ValidaData(this string data)
        {
            if (data.Length < 8 || data.Length > 8)
            {
                throw new Exception("ERRO: A data precisa estar no formato DDMMYYYY. Ex: 01012000 ");
            }
            else
            {
                try
                {
                    data.ConverteData();
                }
                catch (Exception e)
                {
                    throw;
                }
                return true;
            }
        }

        public static bool ValidaSeCrianca(this string data)
        {
            if (data.ValidaData())
            {
                TimeSpan dataDiferenca = DateTime.Now - data.ConverteData();

                int idade = dataDiferenca.Days / 365;
                if (idade >= 13)
                {
                    return true;
                }
            }
            throw new Exception("paciente deve ter pelo menos 13 anos.");
        }


        public static TimeSpan ConverteHora(this string hora)
        {
            try
            {
                TimeSpan novaHora = new TimeSpan(int.Parse(hora.Substring(0, 2)), int.Parse(hora.Substring(2, 2)), 00);
            }
            catch
            {
                throw new Exception("ERRO: A hora precisa estar no formato HHMM. Ex: 1545");
            }
            TimeSpan horario = new TimeSpan(int.Parse(hora.Substring(0, 2)), int.Parse(hora.Substring(2, 2)), 00);
            return horario;
        }

        public static bool ValidaHora(this string hora)
        {
            if (hora.Length < 4 || hora.Length > 4)
            {
                throw new Exception("ERRO: A hora precisa estar no formato HHMM. Ex: 1545");
            }
            else
            {
                string minutos = hora.Substring(2, 2);
                if (minutos == "00" || minutos == "15" || minutos == "30" || minutos == "45")
                {
                    try
                    {
                        hora.ConverteHora();
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }
                else
                {
                    throw new Exception("ERRO: O horário permitido deve ter o intervalo de 15min. Ex: 1545, 1630");
                }
                return true;
            }
        }

        public static String ConverteTimeToString(this TimeSpan time)
        {
            return time.ToString().Substring(0, 2) + time.ToString().Substring(3, 2);
        }
    }
}

