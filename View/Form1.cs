using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Compilador_C_.Control;

namespace Compilador_C_
{
    public partial class Form1 : Form
    {
        private string codigoFonte = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnEscolherArquivo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Arquivos de texto|*.txt;*.cpp;*.c;*.code|Todos os arquivos|*.*";
                dlg.Title = "Selecione um arquivo de código-fonte";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    codigoFonte = File.ReadAllText(dlg.FileName);
                    txtCodigo.Text = codigoFonte;
                    txtSaida.Clear();
                }
            }
        }

        private void btnCompilar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(codigoFonte))
            {
                MessageBox.Show("Escolha um arquivo antes de compilar!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 🔹 1. Análise Léxica
                Lexer lexer = new Lexer(codigoFonte);
                List<Token> tokens = lexer.Analisar();

                txtSaida.AppendText("📦 TOKENS RECONHECIDOS:\r\n");
                foreach (var token in tokens)
                    txtSaida.AppendText(token + "\r\n");

                // 🔹 2. Análise Sintática
                Parser parser = new Parser(tokens);
                List<AstNode> astList = parser.ParseAll();
                txtSaida.AppendText("\r\n🧩 ANÁLISE SINTÁTICA CONCLUÍDA COM SUCESSO!\r\n");

                // 🔹 3. Análise Semântica
                SemanticAnalyzer semanticAnalyzer = new SemanticAnalyzer();
                foreach (var ast in astList)
                {
                    semanticAnalyzer.Analyze(ast);
                }

                txtSaida.AppendText("\r\n✅ ANÁLISE SEMÂNTICA CONCLUÍDA COM SUCESSO!\r\n");
            }
            catch (Exception ex)
            {
                txtSaida.AppendText($"\r\n❌ Erro: {ex.Message}\r\n");
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}