using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador_C_.Control
{
    internal class AstNode
    {
        public string Tipo { get; set; } = string.Empty;   // Ex: "Declaracao", "Atribuicao", "Numero", etc.
        public string Valor { get; set; } = string.Empty;  // Valor literal (ex: "10", "+", "x")
        public AstNode Esquerda { get; set; }             // Subárvore à esquerda
        public AstNode Direita { get; set; }              // Subárvore à direita

        public AstNode() { }

        public AstNode(string tipo, string valor)
        {
            Tipo = tipo;
            Valor = valor;
        }

        public override string ToString()
        {
            return $"[Tipo: {Tipo}, Valor: {Valor}]";
        }
    }
}
