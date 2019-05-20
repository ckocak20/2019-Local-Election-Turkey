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
    public partial class FormElection : Form
    {
        public FormElection()
        {
            InitializeComponent();
        }

        private void FormElection_Load(object sender, EventArgs e)
        {
            rbSp.Checked = false;

            pictureBox1.Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory()+@"\images\ak.jpg");
            pbChp.Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\images\chp.jpg");
            pbMhp.Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\images\mhp.jpg");
            pbIyi.Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\images\iyi.jpg");
            pbSp.Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\images\sp.jpg");
            pBOther.Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\images\other.jpg");
        }

        private void button1_Click(object sender, EventArgs e)
        {
           DialogResult result = MessageBox.Show("Seçtiğiniz partiyi onaylıyor musunuz ?","Uyarı",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                using (var db = new localelectionsEntities())
                {
                    var query = db.iller.Where(u => u.il_isim == FormOy.il ).FirstOrDefault();
                    if (rbAk.Checked)
                    {
                        query.il_akp_oy++;
                    }
                    else if (rbChp.Checked)
                    {
                        query.il_chp_oy++;
                    }
                    else if (rbIyi.Checked)
                    {
                        query.il_ip_oy++;
                    }
                    else if (rbMhp.Checked)
                    {
                        query.il_mhp_oy++;
                    }
                    else if (rbSp.Checked)
                    {
                        query.il_saadet_oy++;
                    }
                    else if (rBOther.Checked)
                    {
                        query.il_other++;
                    }
                    var query2 = db.user.Where(u => u.userID == FormOy.userID).First();
                    query2.isUsed = true;

                    db.SaveChanges();
                    DialogResult dr = MessageBox.Show("İl belediye seçimini tamamladınız. İlçe belediye başkan seçim ekranına yönlendiriliyorsunuz...","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        FormElection2 fe2 = new FormElection2();
                        fe2.Show();
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Ana sayfaya yönlendiriliyorsunuz...");
                Form1 frm = new Form1();
                frm.Show();
                this.Close();
            }
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

        private void pBOther_Click(object sender, EventArgs e)
        {
            rBOther.Checked = true;
        }
    }
}
