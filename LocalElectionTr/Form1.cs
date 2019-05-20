using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocalElectionTr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// formelection ve formelection2 için "diğer" seçeneği eklenecek.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void btnOykullan_Click(object sender, EventArgs e)
        {
            FormOy formOy = new FormOy();
            formOy.Show();
          
        }

        private void btnSonuc_Click(object sender, EventArgs e)
        {
            FormSonuc formSonuc = new FormSonuc();
            formSonuc.Show();
          
        }
    }
}
