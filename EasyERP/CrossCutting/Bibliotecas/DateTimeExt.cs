namespace Biblioteca
{
    public static class DateTimeExt
    {
        //public static List<SelectListItem> ListarDiasDaSemana()
        //{
        //    return new List<SelectListItem>
        //    {
        //        new() { Value = "1", Text = "Domingo" },
        //        new() { Value = "2", Text = "Segunda-feira" },
        //        new() { Value = "3", Text = "Terça-feira" },
        //        new() { Value = "4", Text = "Quarta-feira" },
        //        new() { Value = "5", Text = "Quinta-feira" },
        //        new() { Value = "6", Text = "Sexta-feira" },
        //        new() { Value = "7", Text = "Sábado" }
        //    };
        //}

        /// <summary>
        /// Retorna uma data com o primeiro dia do mês
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DateTime PrimeiroDiaDoMes(this DateTime? data) => data.HasValue ? new DateTime(data.Value.Year, data.Value.Month, 1) : DateTime.Today;

        /// <summary>
        /// Retorna o último dia do mês no formato de data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>DateTime</returns>
        public static DateTime UltimoDiaDoMes(this DateTime? data) =>
            data.HasValue ?
            new DateTime(data.Value.Year, data.Value.Month, DateTime.DaysInMonth(data.Value.Year, data.Value.Month)).AddHours(23).AddMinutes(59).AddSeconds(59)
            : DateTime.Today;

        public static List<DateTime> DiasDaSemanaNoMes(int ano, int mes, DayOfWeek diaSemana)
        {
            var datas = new List<DateTime>();

            DateTime inicio = new DateTime(ano, mes, 1);
            int diasNoMes = DateTime.DaysInMonth(ano, mes);

            for (int dia = 0; dia < diasNoMes; dia++)
            {
                DateTime data = inicio.AddDays(dia);

                if (data.DayOfWeek == diaSemana)
                {
                    datas.Add(data);
                }
            }

            return datas;
        }

        /// <summary>
        /// Retorna o dia da semana por extenso
        /// </summary>
        /// <param name="diaID"></param>
        /// <returns></returns>
        public static string DiaDaSemanaExtenso(this int diaID)
        {
            switch (diaID)
            {
                case 1: return "Domingo";
                case 2: return "Segunda-feira";
                case 3: return "Terça-feira";
                case 4: return "Quarta-feira";
                case 5: return "Quinta-feira";
                case 6: return "Sexta-feira";
                case 7: return "Sábado";
                default: return string.Empty;
            }
        }

        public static string ObterMesCompleto(this int m)
        {
            return m switch
            {
                1 => "Janeiro",
                2 => "Fevereiro",
                3 => "Março",
                4 => "Abril",
                5 => "Maio",
                6 => "Junho",
                7 => "Julho",
                8 => "Agosto",
                9 => "Setembro",
                10 => "Outubro",
                11 => "Novembro",
                12 => "Dezembro",
                _ => throw new ArgumentOutOfRangeException(nameof(m), "Mês inválido.")
            };
        }

        public static string CalcularIdadeString(this DateTime dataNascimento)
        {
            DateTime hoje = DateTime.Today;

            int anos = hoje.Year - dataNascimento.Year;

            if (dataNascimento.Date > hoje.AddYears(-anos))
                anos--;

            if (anos >= 1)
                return anos == 1 ? "1 ano" : $"{anos} anos";

            int meses = ((hoje.Year - dataNascimento.Year) * 12) +
                        (hoje.Month - dataNascimento.Month);

            if (hoje.Day < dataNascimento.Day)
                meses--;

            return meses == 1 ? "1 mês" : $"{meses} meses";
        }

        /// <summary>
        /// Converte um DateTime em String
        /// </summary>
        /// <param name="data">DateTime</param>
        /// <returns>String no formato dd/MM/yyyy</returns>
        public static string DataParaDDMMYYYY(this DateTime? data) => data == null ? "" : data.Value.ToString("dd/MM/yyyy");
        /// <summary>
        /// Converte um DateTime em String
        /// </summary>
        /// <param name="data">DateTime</param>
        /// <returns>String no formato dd/MM/yy</returns>
        public static string DataParaDDMMYY(this DateTime? data) => data == null ? "" : data.Value.ToString("dd/MM/yy");
        /// <summary>
        /// Converte um DateTime em String
        /// </summary>
        /// <param name="data">DateTime</param>
        /// <returns>String no formato dd 'de' MMMM 'de' yyyy</returns>
        public static string DataPorExtenso(this DateTime? data) => data == null ? "" : data.Value.ToString("dd 'de' MMMM 'de' yyyy");
        /// <summary>
        /// Converte um DateTime em String
        /// </summary>
        /// <param name="data">DateTime</param>
        /// <returns>String no formato dd 'de' MMM</returns>
        public static string DataPorAbreviada(this DateTime? data) => data == null ? "" : data.Value.ToString("dd 'de' MMM");
    }
}
