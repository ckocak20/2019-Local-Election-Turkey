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
    public partial class FormElection2 : Form
    {
        public FormElection2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Seçtiğiniz partiyi onaylıyor musunuz ?", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                using (var db = new localelectionsEntities())
                {
                    var query = db.ilceler.Where(u => u.ilce_isim == FormOy.ilce).FirstOrDefault();
                    if (rbAk.Checked)
                    {
                        query.ilce_akp_oy++;
                    }
                    else if (rbChp.Checked)
                    {
                        query.ilce_chp_oy++;
                    }
                    else if (rbIyi.Checked)
                    {
                        query.ilce_iyi_oy++;
                    }
                    else if (rbMhp.Checked)
                    {
                        query.ilce_mhp_oy++;
                    }
                    else if (rbSp.Checked)
                    {
                        query.ilce_saadet_oy++;
                    }
                    var query2 = db.user.Where(u => u.userID == FormOy.userID).First();
                    query2.isUsed = true;

                    db.SaveChanges();
                    DialogResult dr = MessageBox.Show("Ana sayfaya yönlendiriliyorsunuz. Katılımınız için teşekkür ederiz.","Teşekkürler",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Ana sayfaya yönlendiriliyorsunuz...");
                this.Close();
            }
        }

        private void FormElection2_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\images\ak.jpg");
            pbChp.Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\images\chp.jpg");
            pbMhp.Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\images\mhp.jpg");
            pbIyi.Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\images\iyi.jpg");
            pbSp.Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\images\sp.jpg");
        }
        private void pbChp_Click(object sender, EventArgs e)
        {
            rbChp.Checked = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            rbAk.Checked = true;
        }

        private void pbMhp_Click(object sender, EventArgs e)
        {
            rbMhp.Checked = true;
        }

        private void pbIyi_Click(object sender, EventArgs e)
        {
            rbIyi.Checked = true;
        }

        private void pbSp_Click(object sender, EventArgs e)
        {
            rbSp.Checked = true;
        }
    }
}
