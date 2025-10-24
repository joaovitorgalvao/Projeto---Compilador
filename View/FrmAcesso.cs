using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compilador_C_
{
    public partial class FrmAcesso : Form
    {
        public FrmAcesso()
        {
            InitializeComponent();
        }

        private void btnAcessar_Click(object sender, EventArgs e)
        {
            // Esconde o FrmAcesso
            this.Hide();

            // Cria e mostra o Form1
            Form1 form1 = new Form1();

            // Ao fechar o Form1, mostra novamente o FrmAcesso
            form1.FormClosed += (s, args) => this.Show();

            form1.Show();
        }

        private void FrmAcesso_Load(object sender, EventArgs e)
        {

        }
    }
}
