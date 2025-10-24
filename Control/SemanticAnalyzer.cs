using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador_C_.Control
{
    internal class SemanticAnalyzer
    {
        // Dicionário que armazena variáveis declaradas e seus valores
        private readonly Dictionary<string, double> _variaveis;

        public SemanticAnalyzer()
        {
            _variaveis = new Dictionary<string, double>();
        }

        /// <summary>
        /// Método principal da análise semântica.
        /// Percorre a árvore sintática (AST) e verifica regras como:
        /// - Declaração e uso de variáveis
        /// - Atribuições válidas
        /// - Operações com tipos compatíveis
        /// </summary>
        public void Analyze(AstNode node)
        {
            if (node == null) return;

            switch (node.Tipo)
            {
                case "Declaracao":
                    // Exemplo: int x = 10
                    if (string.IsNullOrEmpty(node.Valor))
                        throw new Exception("Erro Semântico: nome de variável inválido na declaração.");

                    if (_variaveis.ContainsKey(node.Valor))
                        throw new Exception($"Erro Semântico: variável '{node.Valor}' já foi declarada.");

                    double valorInicial = AvaliarExpressao(node.Direita);
                    _variaveis[node.Valor] = valorInicial;

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"🧠 Variável '{node.Valor}' declarada com valor inicial {valorInicial}");
                    Console.ResetColor();
                    break;

                case "Atribuicao":
                    if (string.IsNullOrEmpty(node.Valor))
                        throw new Exception("Erro Semântico: nome de variável inválido na atribuição.");

                    if (!_variaveis.ContainsKey(node.Valor))
                        throw new Exception($"Erro Semântico: variável '{node.Valor}' não foi declarada.");

                    double novoValor = AvaliarExpressao(node.Direita);
                    _variaveis[node.Valor] = novoValor;

                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine($"🔄 Variável '{node.Valor}' atualizada para {novoValor}");
                    Console.ResetColor();
                    break;

                case "Operacao":
                    // Apenas avalia a expressão para validar semântica (ex: divisão por zero)
                    _ = AvaliarExpressao(node);
                    break;

                default:
                    // Recursão: percorre os nós filhos
                    Analyze(node.Esquerda);
                    Analyze(node.Direita);
                    break;
            }
        }

        /// <summary>
        /// Avalia expressões numéricas ou identificadores
        /// e retorna seu valor como double.
        /// </summary>
        private double AvaliarExpressao(AstNode node)
        {
            if (node == null)
                return 0;

            if (node.Tipo == "Numero")
            {
                if (double.TryParse(node.Valor, out double numero))
                    return numero;
                throw new Exception($"Erro Semântico: valor numérico inválido '{node.Valor}'.");
            }

            if (node.Tipo == "Identificador")
            {
                if (!_variaveis.ContainsKey(node.Valor))
                    throw new Exception($"Erro Semântico: variável '{node.Valor}' usada antes da declaração.");
                return _variaveis[node.Valor];
            }

            double esquerda = AvaliarExpressao(node.Esquerda);
            double direita = AvaliarExpressao(node.Direita);

            switch (node.Valor)
            {
                case "+":
                    return esquerda + direita;
                case "-":
                    return esquerda - direita;
                case "*":
                    return esquerda * direita;
                case "/":
                    if (direita != 0)
                        return esquerda / direita;
                    else
                        throw new Exception("Erro Semântico: divisão por zero detectada.");
                default:
                    throw new Exception($"Erro Semântico: operador desconhecido '{node.Valor}'.");
            }
        }
    }
}
