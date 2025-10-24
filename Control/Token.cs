using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador_C_.Control
{
    internal class Token
    {
        // Tipo do token (ex: Identificador, Número, Operador, PalavraReservada, etc.)
        public string Tipo { get; set; }

        // Valor do token (ex: "x", "123", "+", "if", etc.)
        public string Valor { get; set; }

        // Construtor para facilitar a criação de tokens
        public Token(string tipo, string valor)
        {
            Tipo = tipo;
            Valor = valor;
        }

        // Método para exibir o token como string (útil para debug)
        public override string ToString()
        {
            return $"[Tipo: {Tipo}, Valor: {Valor}]";
        }
    }
}
