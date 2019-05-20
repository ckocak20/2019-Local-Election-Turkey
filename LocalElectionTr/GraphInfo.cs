using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace LocalElectionTr
{
    public class GraphInfo
    {
        /// <summary>
        /// İllere ait oylamaların sonucunu grafiğe basar.
        /// </summary>
        /// <param name="sehir">Hangi ilin oy listesi görünmesi isteniyorsa o ilin adı.</param>
        /// <param name="ilChart">Grafiğin basılması istendiği chart objesi.</param>
        public void ilGrafigiGetir(string sehir, Chart ilChart)
        {
            using (var db = new localelectionsEntities())
            {
                var query = db.iller.Where(u => u.il_isim == sehir).First();
                double _akp, _chp, _mhp, _ip, _sp, _diger;
                _akp = Convert.ToDouble(query.il_akp_oy);
                _chp = Convert.ToDouble(query.il_chp_oy);
                _ip = Convert.ToDouble(query.il_ip_oy);
                _mhp = Convert.ToDouble(query.il_mhp_oy);
                _sp = Convert.ToDouble(query.il_saadet_oy);
                _diger = Convert.ToDouble(query.il_other);

                foreach (var item in ilChart.Series)
                {
                    item.Points.Clear();
                }


                ilChart.Series["OYLAR"].Points.Add(_akp);
                ilChart.Series["OYLAR"].Points.Add(_chp);
                ilChart.Series["OYLAR"].Points.Add(_ip);
                ilChart.Series["OYLAR"].Points.Add(_mhp);
                ilChart.Series["OYLAR"].Points.Add(_sp);
                ilChart.Series["OYLAR"].Points.Add(_diger);

                ilChart.Series["OYLAR"].Points[0].AxisLabel = "AKP";
                ilChart.Series["OYLAR"].Points[1].AxisLabel = "CHP";
                ilChart.Series["OYLAR"].Points[2].AxisLabel = "İYİ";
                ilChart.Series["OYLAR"].Points[3].AxisLabel = "MHP";
                ilChart.Series["OYLAR"].Points[4].AxisLabel = "SP";
                ilChart.Series["OYLAR"].Points[5].AxisLabel = "Diğer";

                ilChart.Series["OYLAR"].Points[0].Color = Color.Yellow;
                ilChart.Series["OYLAR"].Points[1].Color = Color.Red;
                ilChart.Series["OYLAR"].Points[2].Color = Color.Aqua;
                ilChart.Series["OYLAR"].Points[3].Color = Color.Blue;
                ilChart.Series["OYLAR"].Points[4].Color = Color.Green;
                ilChart.Series["OYLAR"].Points[5].Color = Color.Gray;

                ilChart.ChartAreas[0].AxisX.LabelStyle.Angle = -70;
              
            }
        }

        /// <summary>
        /// Seçilen ilçeye ait oylamaların sonucunu grafiğe basar
        /// </summary>
        /// <param name="ilce">Hangi ilçe oyunun listelenmesi isteniyorsa o ilçenin adı</param>
        /// <param name="ilceChart">Dönecek sonucun hangi chart objesine basılacaksa onun adı</param>
        public void ilceGrafigiGetir(string ilce, Chart ilceChart)
        {
            using (var db = new localelectionsEntities())
            {
                var query = db.ilceler.Where(u => u.ilce_isim == ilce).First();
                double _akp, _chp, _mhp, _ip, _sp, _diger;
                _akp = Convert.ToDouble(query.ilce_akp_oy);
                _chp = Convert.ToDouble(query.ilce_chp_oy);
                _ip = Convert.ToDouble(query.ilce_iyi_oy);
                _mhp = Convert.ToDouble(query.ilce_mhp_oy);
                _sp = Convert.ToDouble(query.ilce_saadet_oy);
                _diger = Convert.ToDouble(query.ilce_other);

                foreach (var item in ilceChart.Series)
                {
                    item.Points.Clear();
                }


                ilceChart.Series["OYLAR"].Points.Add(_akp);
                ilceChart.Series["OYLAR"].Points.Add(_chp);
                ilceChart.Series["OYLAR"].Points.Add(_ip);
                ilceChart.Series["OYLAR"].Points.Add(_mhp);
                ilceChart.Series["OYLAR"].Points.Add(_sp);
                ilceChart.Series["OYLAR"].Points.Add(_diger);

                ilceChart.Series["OYLAR"].Points[0].AxisLabel = "AKP";
                ilceChart.Series["OYLAR"].Points[1].AxisLabel = "CHP";
                ilceChart.Series["OYLAR"].Points[2].AxisLabel = "İYİ";
                ilceChart.Series["OYLAR"].Points[3].AxisLabel = "MHP";
                ilceChart.Series["OYLAR"].Points[4].AxisLabel = "SP";
                ilceChart.Series["OYLAR"].Points[5].AxisLabel = "Diğer";

                ilceChart.Series["OYLAR"].Points[0].Color = Color.Yellow;
                ilceChart.Series["OYLAR"].Points[1].Color = Color.Red;
                ilceChart.Series["OYLAR"].Points[2].Color = Color.Aqua;
                ilceChart.Series["OYLAR"].Points[3].Color = Color.Blue;
                ilceChart.Series["OYLAR"].Points[4].Color = Color.Green;
                ilceChart.Series["OYLAR"].Points[5].Color = Color.Gray;

                ilceChart.ChartAreas[0].AxisX.LabelStyle.Angle = -70;
              
            }
        }
        /// <summary>
        /// Ülke geneli bütün partilerin oylarını getirir.
        /// </summary>
        /// <param name="chart">Oyların bastırılması istenilen chart objesi</param>
        public void genelGrafigiGetir(Chart chart)
        {
            using (var db = new localelectionsEntities())
            {
                var query = db.iller.Where(i => i.il_no > 0).ToList<iller>();
                var query2 = db.ilceler.Where(il => il.ilce_no > 0).ToList<ilceler>();

                double _akp = 0, _chp = 0, _mhp = 0, _ip = 0, _sp = 0, _diger = 0;
                foreach (var item in query)
                {
                    _akp += Convert.ToDouble(item.il_akp_oy);
                    _chp += Convert.ToDouble(item.il_chp_oy);
                    _mhp += Convert.ToDouble(item.il_mhp_oy);
                    _ip += Convert.ToDouble(item.il_ip_oy);
                    _sp += Convert.ToDouble(item.il_saadet_oy);
                    _diger += Convert.ToDouble(item.il_other);
                }

                foreach (var item in query2)
                {
                    _akp += Convert.ToDouble(item.ilce_akp_oy);
                    _chp += Convert.ToDouble(item.ilce_chp_oy);
                    _mhp += Convert.ToDouble(item.ilce_mhp_oy);
                    _ip += Convert.ToDouble(item.ilce_iyi_oy);
                    _sp += Convert.ToDouble(item.ilce_saadet_oy);
                    _diger += Convert.ToDouble(item.ilce_other);
                }


                foreach (var item in chart.Series)
                {
                    item.Points.Clear();
                }


                chart.Series["OYLAR"].Points.Add(_akp);
                chart.Series["OYLAR"].Points.Add(_chp);
                chart.Series["OYLAR"].Points.Add(_ip);
                chart.Series["OYLAR"].Points.Add(_mhp);
                chart.Series["OYLAR"].Points.Add(_sp);
                chart.Series["OYLAR"].Points.Add(_diger);

                chart.Series["OYLAR"].Points[0].AxisLabel = "AKP";
                chart.Series["OYLAR"].Points[1].AxisLabel = "CHP";
                chart.Series["OYLAR"].Points[2].AxisLabel = "İYİ";
                chart.Series["OYLAR"].Points[3].AxisLabel = "MHP";
                chart.Series["OYLAR"].Points[4].AxisLabel = "SP";
                chart.Series["OYLAR"].Points[5].AxisLabel = "Diğer";

                chart.Series["OYLAR"].Points[0].Color = Color.Yellow;
                chart.Series["OYLAR"].Points[1].Color = Color.Red;
                chart.Series["OYLAR"].Points[2].Color = Color.Aqua;
                chart.Series["OYLAR"].Points[3].Color = Color.Blue;
                chart.Series["OYLAR"].Points[4].Color = Color.Green;
                chart.Series["OYLAR"].Points[5].Color = Color.Gray;

                chart.ChartAreas[0].AxisX.LabelStyle.Angle = -70;

            }
        }

    }

}
