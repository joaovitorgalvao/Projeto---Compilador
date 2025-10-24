using System;
using System.Collections.Generic;

namespace Compilador_C_.Control
{
    internal class Parser
    {
        private List<Token> _tokens;
        private int _pos;

        public Parser(List<Token> tokens)
        {
            _tokens = tokens;
            _pos = 0;
        }

        // Novo método: processa todas as linhas do código
        public List<AstNode> ParseAll()
        {
            var nodes = new List<AstNode>();

            while (_pos < _tokens.Count)
            {
                if (Match("PalavraReservada", "int"))
                {
                    nodes.Add(ParseDeclaracaoVariavel());
                }
                else if (Match("Identificador"))
                {
                    nodes.Add(ParseAtribuicao());
                }
                else
                {
                    throw new Exception($"Erro Sintático: token inesperado {_tokens[_pos].Valor}");
                }
            }

            return nodes;
        }

        private AstNode ParseDeclaracaoVariavel()
        {
            Consumir("PalavraReservada", "Esperado tipo 'int' no início da declaração.");
            Token identificador = Consumir("Identificador", "Esperado nome de variável após 'int'.");
            Consumir("Operador", "Esperado '=' após o nome da variável.");

            double valor = Expressao();

            Consumir("Pontuacao", "Esperado ';' ao final da declaração.");

            return new AstNode("Declaracao", identificador.Valor)
            {
                Direita = new AstNode("Numero", valor.ToString())
            };
        }

        private AstNode ParseAtribuicao()
        {
            Token identificador = Consumir("Identificador", "Esperado nome da variável para atribuição.");
            Consumir("Operador", "Esperado '=' na atribuição.");

            double valor = Expressao();

            Consumir("Pontuacao", "Esperado ';' ao final da atribuição.");

            return new AstNode("Atribuicao", identificador.Valor)
            {
                Direita = new AstNode("Numero", valor.ToString())
            };
        }

        private double Expressao()
        {
            double valor = Termo();

            while (_pos < _tokens.Count &&
                   (_tokens[_pos].Tipo == "Operador" &&
                   (_tokens[_pos].Valor == "+" || _tokens[_pos].Valor == "-")))
            {
                string op = _tokens[_pos].Valor;
                _pos++;

                double direito = Termo();
                if (op == "+") valor += direito;
                else valor -= direito;
            }

            return valor;
        }

        private double Termo()
        {
            double valor = Fator();

            while (_pos < _tokens.Count &&
                   (_tokens[_pos].Tipo == "Operador" &&
                   (_tokens[_pos].Valor == "*" || _tokens[_pos].Valor == "/")))
            {
                string op = _tokens[_pos].Valor;
                _pos++;

                double direito = Fator();
                if (op == "*") valor *= direito;
                else valor /= direito;
            }

            return valor;
        }

        private double Fator()
        {
            if (_pos >= _tokens.Count)
                throw new Exception("Erro Sintático: expressão incompleta.");

            Token atual = _tokens[_pos];

            if (atual.Tipo == "Numero")
            {
                _pos++;
                return double.Parse(atual.Valor);
            }
            else if (atual.Valor == "(")
            {
                _pos++;
                double valor = Expressao();

                if (_pos >= _tokens.Count || _tokens[_pos].Valor != ")")
                    throw new Exception("Erro Sintático: esperado ')'.");

                _pos++;
                return valor;
            }
            else if (atual.Tipo == "Identificador")
            {
                _pos++;
                return 0; // valor real será resolvido no SemanticAnalyzer
            }
            else
            {
                throw new Exception($"Erro Sintático: token inesperado {atual.Valor}");
            }
        }

        // ===========================================================
        // MÉTODOS AUXILIARES
        // ===========================================================

        private bool Match(string tipo, string valorEsperado = null)
        {
            if (_pos < _tokens.Count && _tokens[_pos].Tipo == tipo)
            {
                if (valorEsperado == null || _tokens[_pos].Valor == valorEsperado)
                    return true;
            }
            return false;
        }

        private Token Consumir(string tipoEsperado, string mensagemErro)
        {
            if (_pos < _tokens.Count && _tokens[_pos].Tipo == tipoEsperado)
                return _tokens[_pos++];

            throw new Exception($"Erro Sintático: {mensagemErro}");
        }
    }
}
