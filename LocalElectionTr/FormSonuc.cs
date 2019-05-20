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
    public partial class FormSonuc : Form
    {
        public FormSonuc()
        {
            InitializeComponent();
        }

        private void FormSonuc_Load(object sender, EventArgs e)
        {
            using (var db = new localelectionsEntities())
            {
                var query = db.iller.Where(u => u.il_no > 0).ToList<iller>();
                foreach (var item in query)
                {
                    cmbSehir.Items.Add(item.il_isim);
                }
            }
        }

        private void cmbSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var db = new localelectionsEntities())
            {
                if (cmbIlce.Items.Count>0)
                {
                    cmbIlce.Items.Clear();
                   
                }
                var query = db.iller.Where(u => u.il_isim == cmbSehir.SelectedItem).FirstOrDefault();
                var query2 = db.ilceler.Where(x => x.il_no == query.il_no).ToList<ilceler>();
                foreach (var item in query2)
                {
                    cmbIlce.Items.Add(item.ilce_isim);
                }
            }
        }

        private void btnGoster_Click(object sender, EventArgs e)
        {
            #region fullcode
            //using (var db = new localelectionsEntities())
            //{
            //    var query = db.iller.Where(u => u.il_isim == cmbSehir.SelectedItem).First();
            //    double _akp, _chp, _mhp, _ip, _sp, _diger;
            //    _akp = Convert.ToDouble(query.il_akp_oy);
            //    _chp = Convert.ToDouble(query.il_chp_oy);
            //    _ip = Convert.ToDouble(query.il_ip_oy);
            //    _mhp = Convert.ToDouble(query.il_mhp_oy);
            //    _sp = Convert.ToDouble(query.il_saadet_oy);
            //    _diger = Convert.ToDouble(query.il_other);       

            //    foreach (var item in chart1.Series)
            //    {
            //        item.Points.Clear();
            //    }


            //    chart1.Series["OYLAR"].Points.Add(_akp);
            //    chart1.Series["OYLAR"].Points.Add(_chp);
            //    chart1.Series["OYLAR"].Points.Add(_ip);
            //    chart1.Series["OYLAR"].Points.Add(_mhp);
            //    chart1.Series["OYLAR"].Points.Add(_sp);
            //    chart1.Series["OYLAR"].Points.Add(_diger);

            //    chart1.Series["OYLAR"].Points[0].AxisLabel = "AKP";
            //    chart1.Series["OYLAR"].Points[1].AxisLabel = "CHP";
            //    chart1.Series["OYLAR"].Points[2].AxisLabel = "İYİ";
            //    chart1.Series["OYLAR"].Points[3].AxisLabel = "MHP";
            //    chart1.Series["OYLAR"].Points[4].AxisLabel = "SP";
            //    chart1.Series["OYLAR"].Points[5].AxisLabel = "Diğer";

            //    chart1.Series["OYLAR"].Points[0].Color = Color.Yellow;
            //    chart1.Series["OYLAR"].Points[1].Color = Color.Red;
            //    chart1.Series["OYLAR"].Points[2].Color = Color.Aqua;
            //    chart1.Series["OYLAR"].Points[3].Color = Color.Blue;
            //    chart1.Series["OYLAR"].Points[4].Color = Color.Green;
            //    chart1.Series["OYLAR"].Points[5].Color = Color.Gray;

            //    chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -70;
            //    chart1.BackColor = Color.YellowGreen;
            //} 
            #endregion
            GraphInfo graph = new GraphInfo();
            graph.ilGrafigiGetir(cmbSehir.SelectedItem.ToString(), chart1);
            graph.ilceGrafigiGetir(cmbIlce.SelectedItem.ToString(), chart2);
            graph.genelGrafigiGetir(chart3);
        }
    }
}
