using Newtonsoft.Json;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Biblioteca
{
    public static class StringExt
    {
        public static string NormalizarCNPJ(this string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return string.Empty;

            return Regex.Replace(valor.Trim().ToUpper(), "[^A-Z0-9]", "");
        }

        public static void LimparModelState(ModelStateDictionary modelState, params string[] excecoes)
        {
            var chavesRemover = modelState.Keys
                .Where(k => !excecoes.Contains(k))
                .ToList();

            foreach (var key in chavesRemover)
            {
                modelState.Remove(key);
            }
        }

        public static (bool senhaValida, string? mensagem) ValidarSenha(string senha)
        {
            bool senhaValida = true;
            string mensagem = string.Empty;

            if (senha.Length < 8)
            {
                senhaValida = false;
                mensagem = "A senha deve ter no mínimo 8 caracteres.";
            }

            if (!Regex.IsMatch(senha, "[A-Z]"))
            {
                senhaValida = false;
                mensagem = "A senha deve conter pelo menos uma letra maiúscula.";
            }

            if (!Regex.IsMatch(senha, "[a-z]"))
            {
                senhaValida = false;
                mensagem = "A senha deve conter pelo menos uma letra minúscula.";
            }

            if (!Regex.IsMatch(senha, "[0-9]"))
            {
                senhaValida = false;
                mensagem = "A senha deve conter pelo menos um número.";
            }
            return (senhaValida, mensagem);
        }

        public static string GerarUsuario(string NomeCompleto, string? cod = null)
        {
            if (string.IsNullOrWhiteSpace(NomeCompleto))
                throw new Exception("Usuário inválido.");

            if (string.IsNullOrWhiteSpace(cod))
                cod = KeyGenerator.GetUniqueKey(4);

            if (cod.Length > 4)
                cod = cod.Substring(0, 4);

            var nomes = NomeCompleto.Trim().ToLower().Split(" ");
            string userbase = $"{nomes[0]}.{nomes[^1]}";
            string usuario = userbase + '_' + cod;
            return usuario.Trim().ToLower();
        }

        public static string LimparNumeros(this string dado)
        {
            if (!string.IsNullOrWhiteSpace(dado))
            {
                dado = dado.Trim();
                return Regex.Replace(dado, "[^0-9]", "");
            }
            return dado;
        }

        public static string GeneroString(this string genero)
        {
            string generoString = string.Empty;
            switch (genero)
            {
                case "M":
                    generoString = "Masculino";
                    break;
                case "F":
                    generoString = "Feminino";
                    break;
            }

            return generoString;
        }

        public static string FormatarCPF(this string cpf)
        {
            if (!string.IsNullOrEmpty(cpf))
            {
                cpf = cpf.Trim();
                cpf = Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
            }
            return cpf;
        }

        public static string FormatarTelefone(this string? telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone))
                return "Sem telefone cadastrado";

            telefone = telefone.Trim();
            telefone = Convert.ToUInt64(telefone).ToString(@"(000) 00000-0000");
            return telefone;
        }

        public static string FormatarCEP(this string? cep)
        {
            if (!string.IsNullOrEmpty(cep))
            {
                cep = cep.Trim();
                cep = Convert.ToUInt64(cep).ToString(@"00000-000");
            }
            return cep;
        }

        public static string FormatarNomeCompleto(this string nomeCompleto)
        {
            string[] nomes = nomeCompleto.Trim().Split(" ");
            List<string> nomesFormatados = new List<string>();

            foreach (string s in nomes)
            {
                string nomeFormatado = char.ToUpper(s[0]) + s.Substring(1).ToLower();
                nomesFormatados.Add(nomeFormatado);
            }

            string ret = string.Join(" ", nomesFormatados);
            return ret.Trim();
        }

        public static string PrimeiroNome(this string nome)
        {
            if (string.IsNullOrWhiteSpace(nome)) return "--";

            var nomes = nome.Split(" ");
            return nomes[0].Trim();
        }

        //
        // Summary:
        //     Clona o objeto.
        //
        // Parameters:
        //   source:
        //     O objeto a ser clonado.
        //
        // Type parameters:
        //   T:
        //     Tipo do objeto.
        //
        // Returns:
        //     Nova instância do objeto clonado.
        public static T Clonar<T>(this T source)
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source));
        }
    }
}
