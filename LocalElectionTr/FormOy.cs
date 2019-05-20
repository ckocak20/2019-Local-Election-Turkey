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
    public partial class FormOy : Form
    {
        public static string electionCode = "";
        public static int userID = 0;
        public static string il = "";
        public static string ilce = "";

        public FormOy()
        {
            InitializeComponent();
        }

        private void btnGetPass_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtLastName.Text != "" && txtTc.Text != "")
            {
                using (var db = new localelectionsEntities())
                {
                    var query = db.user.Where(u => u.user_fname == txtName.Text && u.user_lname == txtLastName.Text && txtTc.Text == u.user_tc).FirstOrDefault<user>();
                    var queryil = db.iller.Where(x => x.il_no == query.user_il).FirstOrDefault<iller>();
                    var queryilce = db.ilceler.Where(x => x.ilce_no == query.user_ilce).FirstOrDefault();

                    if (query != null && query.user_password != null && query.isUsed == false)
                    {
                        lblpass.Text = query.user_password;
                        txtAdres.Text = queryil.il_isim + "/" + queryilce.ilce_isim;
                        electionCode = query.user_password;
                        userID = query.userID;
                        il = queryil.il_isim;
                        ilce = queryilce.ilce_isim;

                    }
                    else if(query.isUsed == true)
                    {
                        lblpass.Text = "";
                        DialogResult dr = MessageBox.Show("Daha önce oyunuzu kullandınız.","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        if (dr == DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        lblpass.Text = "Seçmen bulunamadı! \nLütfen bilgilerinizi kontrol ediniz.";
                    }
                }
            }
            else
            {
                lblpass.Text = "Seçmen bulunamadı! \nLütfen bilgilerinizi kontrol ediniz.";
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormElection formElection = new FormElection();
            formElection.Show();
            this.Close();
        }
    }
}
