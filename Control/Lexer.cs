using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Compilador_C_.Control
{
    internal class Lexer
    {
        private string _codigoFonte;

        public Lexer(string codigoFonte)
        {
            _codigoFonte = codigoFonte;
        }

        /// 
        /// Analisa o código-fonte e retorna a lista de Tokens.
        /// 
        public List<Token> Analisar()
        {
            var tokens = new List<Token>();

            // Expressões regulares para identificar padrões
            var regex = new List<(string Tipo, string Padrao)>
            {
                ("PalavraReservada", @"\b(if|else|while|for|int|float|return)\b"),
                ("Identificador", @"[a-zA-Z_][a-zA-Z0-9_]*"),
                ("Numero", @"\b\d+(\.\d+)?\b"),
                ("Operador", @"[+\-*/=]"),
                ("Pontuacao", @"[;,\(\)\{\}]"),
                ("Espaco", @"\s+")
            };

            int pos = 0;
            while (pos < _codigoFonte.Length)
            {
                bool casou = false;

                foreach (var regra in regex)
                {
                    var match = Regex.Match(_codigoFonte.Substring(pos), $"^{regra.Padrao}");
                    if (match.Success)
                    {
                        casou = true;

                        // Ignora espaços em branco (não viram tokens)
                        if (regra.Tipo != "Espaco")
                        {
                            tokens.Add(new Token(regra.Tipo, match.Value));
                        }

                        pos += match.Length;
                        break;
                    }
                }

                if (!casou)
                {
                    throw new Exception($"Erro Léxico: caractere inesperado '{_codigoFonte[pos]}' na posição {pos}");
                }
            }

            return tokens;
        }
    }
}
