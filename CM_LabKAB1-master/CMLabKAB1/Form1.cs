using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using System.Text.RegularExpressions;



/*public struct Point
{
    public int num;
    public double x, y;

    public Point(int nn, double xx, double yy)
    {
        num = nn;
        x = xx;
        y = yy;
    }
};*/
struct twopoint
{
   public double x1, x2;
    public twopoint( double xx1, double xx2)
    {
        x1 = xx1;
        x2 = xx2;
    }
};
struct Pointforsys
{
    public int num;
    public double x, y1, y2;
    public Pointforsys(int nn, double xx, double yy1, double yy2)
    {
        num = nn;
        x = xx;
        y1 = yy1;
        y2 = yy2;
    }
};
namespace CMLabKAB1
{
    public partial class Form1 : Form
    {
        int maxnum;
        double u10, u20, h00, E, xn, a, b, c;
        double eboard = 0.05;

        Form2 form = new Form2();

        public Form1()
        {
            InitializeComponent();


            h00 = double.Parse(textBox3.Text);
            u10 = double.Parse(textBox9.Text);
            u20 = double.Parse(textBox10.Text);
            maxnum = int.Parse(textBox1.Text);
            E = double.Parse(textBox2.Text);
            xn = double.Parse(textBox4.Text);
            a = double.Parse(textBox11.Text);
            b = double.Parse(textBox12.Text);
            c = double.Parse(textBox13.Text);
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked == true)
            {
                RezOsn2();
            }

            if (checkBox1.Checked == false)
            {
                Conststep();
            }

            //}
        }
    
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            form.ShowDialog();
        }
     

        private void DrawMainSys(Pointforsys[] arr1, int n)
        {
            Random rnd = new Random();
            //pane.CurveList.Clear();
            GraphPane pane1 = zedGraphControl1.GraphPane;
            GraphPane pane2 = zedGraphControl2.GraphPane;
            GraphPane pane3 = zedGraphControl3.GraphPane;

            pane1.Title.Text = "Зависимость   u1|x(угла маятника от времени)"; pane2.Title.Text = "Зависимость u2|x(угловой скорости маятника от времени)";
            pane3.Title.Text = "Зависимость u2|u1";
            pane1.XAxis.Title.Text = "X ось(время)";
            pane2.XAxis.Title.Text = "X ось(время)";
            pane1.YAxis.Title.Text = "U1 ось(угол)";
            pane2.YAxis.Title.Text = "U2 ось(скорость)";
            pane3.YAxis.Title.Text = "U2 ось";
            pane3.XAxis.Title.Text = "U1 ось";
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            PointPairList list3 = new PointPairList();

            for (int i = 0; i < n; i++)
            {
                // добавим в список точку

                list1.Add(arr1[i].x, arr1[i].y1);
                list2.Add(arr1[i].x, arr1[i].y2);
                list3.Add(arr1[i].y1, arr1[i].y2);


            }
            LineItem myCurve1 = pane1.AddCurve("", list1, Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)), SymbolType.None);
            LineItem myCurve2 = pane2.AddCurve("", list2, Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)), SymbolType.None);
            LineItem myCurve3 = pane3.AddCurve("", list3, Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)), SymbolType.None);

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            zedGraphControl2.AxisChange();
            zedGraphControl2.Invalidate();
            zedGraphControl3.AxisChange();
            zedGraphControl3.Invalidate();
        }




        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox2.Text == "") return;
            var actual = textBox2.Text;
            var disallowed = @"[^0-9,]";
            var newText = Regex.Replace(actual, disallowed, string.Empty);
            if (string.CompareOrdinal(textBox2.Text, newText) != 0)
            {
                var sstart = textBox2.SelectionStart;
                textBox2.Text = newText;
                textBox2.SelectionStart = sstart - 1;
            }
            E = double.Parse(textBox2.Text);
        
        }




        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "") return;
            var actual = textBox1.Text;
            var disallowed = @"[^0-9]";
            var newText = Regex.Replace(actual, disallowed, string.Empty);
            if (string.CompareOrdinal(textBox1.Text, newText) != 0)
            {
                var sstart = textBox1.SelectionStart;
                textBox1.Text = newText;
                textBox1.SelectionStart = sstart - 1;
            }
            maxnum = int.Parse(textBox1.Text);
            form.label11.Text = Convert.ToString(maxnum);
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if ((textBox9.Text == "") || (textBox9.Text == "-")) return;
            var actual = textBox9.Text;
            var disallowed = @"[^0-9,-]";
            var newText = Regex.Replace(actual, disallowed, string.Empty);
            if (string.CompareOrdinal(textBox9.Text, newText) != 0)
            {
                var sstart = textBox9.SelectionStart;
                textBox9.Text = newText;
                textBox9.SelectionStart = sstart - 1;
            }
            u10 = double.Parse(textBox9.Text);
            form.label24.Text = Convert.ToString(u10);
        }


        


        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox3.Text == "") return;
            var actual = textBox3.Text;
            var disallowed = @"[^0-9,]";
            var newText = Regex.Replace(actual, disallowed, string.Empty);
            if (string.CompareOrdinal(textBox3.Text, newText) != 0)
            {
                var sstart = textBox3.SelectionStart;
                textBox3.Text = newText;
                textBox3.SelectionStart = sstart - 1;
            }
            h00 = double.Parse(textBox3.Text);
            form.label23.Text = Convert.ToString(h00);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "") return;
            var actual = textBox4.Text;
            var disallowed = @"[^0-9,]";
            var newText = Regex.Replace(actual, disallowed, string.Empty);
            if (string.CompareOrdinal(textBox4.Text, newText) != 0)
            {
                var sstart = textBox4.SelectionStart;
                textBox4.Text = newText;
                textBox4.SelectionStart = sstart - 1;
            }
            xn = double.Parse(textBox4.Text);
        }

      

        double osnov2y1(double x, double u1, double u2)//f1'
        {
            
            double y1 = u2;
            //double y2 = -b * (1 / c) * Math.Sin(u1);
            return y1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GraphPane pane1 = zedGraphControl1.GraphPane;
            GraphPane pane2 = zedGraphControl2.GraphPane;
            GraphPane pane3 = zedGraphControl3.GraphPane;
            pane1.CurveList.Clear();
            pane2.CurveList.Clear();
            pane3.CurveList.Clear();

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if ((textBox10.Text == "") || (textBox10.Text == "-")) return;
            var actual = textBox10.Text;
            var disallowed = @"[^0-9,-]";
            var newText = Regex.Replace(actual, disallowed, string.Empty);
            if (string.CompareOrdinal(textBox10.Text, newText) != 0)
            {
                var sstart = textBox10.SelectionStart;
                textBox10.Text = newText;
                textBox10.SelectionStart = sstart - 1;
            }
            u20 = double.Parse(textBox10.Text);
            form.label25.Text = Convert.ToString(u20);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GraphPane pane1 = zedGraphControl1.GraphPane;
            GraphPane pane2 = zedGraphControl2.GraphPane;
            GraphPane pane3 = zedGraphControl3.GraphPane;

            double xmin = Convert.ToDouble(textBox5.Text);
            double xmax = Convert.ToDouble(textBox6.Text);
            double ymin = Convert.ToDouble(textBox7.Text);
            double ymax = Convert.ToDouble(textBox8.Text);

            if (tabControl1.SelectedIndex == 0)
            {
                pane1.XAxis.Scale.Min = xmin;
                pane1.XAxis.Scale.Max = xmax;
                pane1.YAxis.Scale.Min = ymin;
                pane1.YAxis.Scale.Max = ymax;
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
            }
            if (tabControl1.SelectedIndex == 1)
            {
                pane2.XAxis.Scale.Min = xmin;
                pane2.XAxis.Scale.Max = xmax;
                pane2.YAxis.Scale.Min = ymin;
                pane2.YAxis.Scale.Max = ymax;
                zedGraphControl2.AxisChange();
                zedGraphControl2.Invalidate();
            }
            if (tabControl1.SelectedIndex == 2)
            {
                pane3.XAxis.Scale.Min = xmin;
                pane3.XAxis.Scale.Max = xmax;
                pane3.YAxis.Scale.Min = ymin;
                pane3.YAxis.Scale.Max = ymax;
                zedGraphControl3.AxisChange();
                zedGraphControl3.Invalidate();
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if ((textBox12.Text == "") || (textBox12.Text == "-")) return;
            var actual = textBox12.Text;
            var disallowed = @"[^0-9,-]";
            var newText = Regex.Replace(actual, disallowed, string.Empty);
            if (string.CompareOrdinal(textBox12.Text, newText) != 0)
            {
                var sstart = textBox12.SelectionStart;
                textBox12.Text = newText;
                textBox12.SelectionStart = sstart - 1;
            }
            b = double.Parse(textBox12.Text);
        }

        double osnov2y2(double x, double u1, double u2, double a, double b, double c)//f2'
        {
            // double mod = u2;
           // double y1 = u2;
            double y2 = -b * (1 / c) * Math.Sin(u1);
            return y2;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if ((textBox11.Text == "") || (textBox11.Text == "-")) return;
            var actual = textBox11.Text;
            var disallowed = @"[^0-9,-]";
            var newText = Regex.Replace(actual, disallowed, string.Empty);
            if (string.CompareOrdinal(textBox11.Text, newText) != 0)
            {
                var sstart = textBox11.SelectionStart;
                textBox11.Text = newText;
                textBox11.SelectionStart = sstart - 1;
            }
            a = double.Parse(textBox11.Text);
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Show();
        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            if ((textBox13.Text == "") || (textBox13.Text == "-")) return;
            var actual = textBox13.Text;
            var disallowed = @"[^0-9,-]";
            var newText = Regex.Replace(actual, disallowed, string.Empty);
            if (string.CompareOrdinal(textBox13.Text, newText) != 0)
            {
                var sstart = textBox11.SelectionStart;
                textBox13.Text = newText;
                textBox13.SelectionStart = sstart - 1;
            }
            c = double.Parse(textBox13.Text);
        }

        Pointforsys metodRKS(int num, double h, double x, double u1, double u2)
        {
            double v1 = u1;
            double v2 = u2;

            /*double k1 = 0, k2 = 0, k3 = 0;
            //
            k1 = osnov2y1(x, u1, u2, a, b, c);
            k2 = osnov2y1(x + h / 3, u1 + (h / 3) * k1, u2, a, b, c);
            //k3 = osnov2y1(x + h, u1 + h * (-k1 + k2), u2, a, b, c);
            k3 = osnov2y1(x + 2*h/3, u1 + 2*h*k2/3 , u2, a, b, c);
            v1 = v1 + h * (k1 / 4 + 3 * k3 / 4);

            k1 = 0; k2 = 0; k3 = 0;
            k1 = osnov2y2(x, u1, u2, a, b, c);
            k2 = osnov2y2(x + h / 3, u1, u2 + (h / 3) * k1, a, b, c);
            k3 = osnov2y2(x + 2*h/3, u1, u2 +2*h *k2/3, a, b, c);
            v2 = v2 + h * (k1 / 4 + 3 * k3 / 4);*/

            double k11 = 0.0, k21 = 0.0, k31 = 0.0;
            double k12 = 0.0, k22 = 0.0, k32 = 0.0;
            k11 = osnov2y1(x, u1, u2);
            k12 = osnov2y2(x, u1, u2, a, b, c);

            k21 = osnov2y1(x + h / 3, u1 + (h / 3) * k11, u2 + (h / 3) * k12);
            k22 = osnov2y2(x + h / 3, u1 + (h / 3) * k11, u2 + (h / 3) * k12, a, b, c);

            k31 = osnov2y1(x + 2 * h / 3, u1 + 2 * h * k21 / 3, u2 + 2 * h * k22 / 3);
            k32 = osnov2y2(x + 2 * h / 3, u1 + 2 * h * k21 / 3, u2 + 2 * h * k22 / 3, a, b, c);

            v1 = v1 + h * (k11 / 4 + 3 * k31 / 4);
            v2 = v2 +h * (k12/4 + 3* k32/4);

            x += h;

            Pointforsys st;
            st.num = num;
            st.x = x;
            st.y1 = v1;
            st.y2 = v2;

            return st;
        }
        void Form2Filling(double[] mas1, double[] mas2, int k, Pointforsys[] pnt)
        {
            double maxh = 0, minh = 110, emax = 0;
            int mah = 0, mih = 0;
            for (int i = 1; i < k; i++)
            {
                if (maxh < mas1[i])
                {
                    maxh = mas1[i];
                    mah = i;
                }
                if (minh > mas1[i])
                {
                    minh = mas1[i];
                    mih = i;
                }
                if (emax < mas2[i])
                {
                    emax = mas2[i];

                }

            }
            form.label14.Text = Convert.ToString(maxh);
            form.label16.Text = Convert.ToString(minh);
            form.label13.Text = Convert.ToString(Math.Abs(emax));
            form.label15.Text = Convert.ToString(pnt[mah].x);
            form.label17.Text = Convert.ToString(pnt[mih].x);
        }


        int Controlofxn(Pointforsys[] mas, double[] h, int k)
        {
            double hnew = h[k - 1 ], x0, u01, u02;
            int iter = k;
            while ((iter < maxnum) && ((mas[iter].x <= xn - eboard) || (mas[iter].x >= xn + eboard)))
            {
                hnew = hnew * 0.5;
                mas[iter].x = mas[iter - 1].x + hnew;

                if (mas[iter].x < xn + eboard)
                {
                    //Добавление точек в список 
                    Pointforsys t1, t2, t12;
                    x0 = mas[iter - 1].x;
                    u01 = mas[iter - 1].y1;
                    u02 = mas[iter - 1].y2;

                    t1 = metodRKS(iter, hnew, x0, u01, u02);
                    dataGridView1.Rows[iter].Cells[2].Value = t1.y1;

                    //(x(n+1/2),y(n+1/2))

                    x0 = mas[iter - 1].x;
                    u01 = mas[iter - 1].y1;
                    u02 = mas[iter - 1].y2;

                    t12 = metodRKS(iter, hnew * 0.5, x0, u01, u02);


                    //(x(n),Y(n))

                    x0 = t12.x;
                    u01 = t12.y1;

                    t2 = metodRKS(iter, hnew * 0.5, x0, u01, u02);
                    dataGridView1.Rows[iter].Cells[4].Value = t12.y1;
                    dataGridView1.Rows[iter].Cells[5].Value = t12.y2;

                    //... 
                    //double en1 = t2.y1 - t1.y1;
                    //double en2 = t2.y2 - t1.y2;
                    //double S = Math.Abs((Math.Max(en1, en2)));
                    double en1 = (t2.y1 - t1.y1) / (Math.Pow(2, 3) - 1);
                    double en2 = (t2.y2 - t1.y2) / (Math.Pow(2, 3) - 1);
                    double S = (Math.Max(Math.Abs(en1), Math.Abs(en2)));



                    double olp = S * Math.Pow(2, 3);
                    dataGridView1.Rows[iter].Cells[8].Value = olp;

                    //Запись данных в таблицу 
                    mas[iter] = t2;
                    h[iter] = hnew;
                    iter++;

                }
            }
            return iter;
        }

        void RezOsn2()
        {
            Pointforsys[] mas = new Pointforsys[maxnum];
            Pointforsys[] obh = new Pointforsys[maxnum];
            double[] e;
            e = new double[maxnum];
            e[0] = 0;
            double[] h;
            h = new double[maxnum];

            double x0 = 0.0, h0 = h00, u01 = u10, u02 = u20;
            //xn - граница отрезка интегрирования
            int n = maxnum, indicator = 0;
            dataGridView1.Rows.Clear();
            dataGridView1.RowCount = maxnum;


            Pointforsys t;
            t.num = 0;
            t.x = x0;
            t.y1 = u01;
            t.y2 = u02;
            mas[0] = t;
            obh[0] = t;
            h[0] = h00;

            //int c1, c2;
            //c1 = c2 = 0;
            twopoint e12;
            e12.x1 = 0;
            e12.x2 = 0;

            int i = 1;
            dataGridView1.Rows.Add();
            int v = 0;
            int w = 0;
            while (i < n)
            {
                Pointforsys t1, t12, t2;
                dataGridView1.Rows[i - 1].Cells[0].Value = i - 1;

                //(x(n+1),v(n+1))
                x0 = mas[i - 1].x;
                u01 = mas[i - 1].y1;
                u02 = mas[i - 1].y2;

                t1 = metodRKS(i, h0, x0, u01, u02);  //V(n+1)
                obh[i] = t1;

                //(x(n+1/2),y(n+1/2))

                t12 = metodRKS(i, h0 * (0.5), x0, u01, u02);



                //(x(n),Y(n))	

                t2 = metodRKS(i, h0 * (0.5), t12.x, t12.y1, t12.y2); //V(n+1)^
                dataGridView1.Rows[i].Cells[4].Value = t12.y1;
                dataGridView1.Rows[i].Cells[5].Value = t12.y2;
                int p = 3;
                double en1 = Math.Abs((t2.y1 - t1.y1)/7);
                double en2 = Math.Abs((t2.y2 - t1.y2) / 7);
                //double en1 = t2.y1 - t1.y1;
                //double en2 = t2.y2 - t1.y2;
               
                //e12.x1 = en1;
                //e12.x2 = en2;
                //double S = Math.Abs((Math.Max(en1, en2)));
                double S = (Math.Max((en1), (en2)));

                //int p = 3;
                e[i] = S * 8;
                dataGridView1.Rows[i].Cells[8].Value = e[i];
               

                if (S < E / (Math.Pow(2, p + 1)))
                {

                    h0 = 2.0 * h0;
                    h[i] = h0;
                    mas[i] = t2;

                    dataGridView1.Rows[i].Cells[11].Value = String.Empty;
                    dataGridView1.Rows[i].Cells[10].Value = 1;

                    indicator = 0;
                    if (mas[i].x > xn)
                        break;
                    i++;
                    w += 1;

                }
                else if (S > E)
                {
                    h0 = h0 * (0.5);
                    h[i] = h0;
                    indicator = 11;
                    v++;

                }
                else if ((S >= E / (Math.Pow(2, p + 1))) && (S <= E))
                {
                    mas[i] = t2;
                    h[i] = h0;
                    if (indicator == 11)
                    {
                        dataGridView1.Rows[i].Cells[10].Value = String.Empty;
                        dataGridView1.Rows[i].Cells[11].Value = 1;
                    }
                    indicator = 0;
                    if (mas[i].x > xn)
                        break;
                    i += 1;

                }
            }
            form.label26.Text = Convert.ToString(w);
            form.label30.Text = Convert.ToString(v);
            i = Controlofxn(mas, h, i);
            dataGridView1.RowCount = i;
            form.label11.Text = Convert.ToString(i);
            form.label32.Text = Convert.ToString(x0);
            form.label34.Text = Convert.ToString(u01);
            form.label36.Text = Convert.ToString(u02);
            Form2Filling(h, e, i, mas);
            for (int d = 0; (d < n) && (mas[d].x < xn) && (mas[i - 1].y1 != 0 && mas[i - 1].y2 != 0); d++)
            {
                dataGridView1.Rows[d].Cells[1].Value = mas[d].x;
                dataGridView1.Rows[d].Cells[2].Value = obh[d].y1;
                dataGridView1.Rows[d].Cells[3].Value = obh[d].y2;

                dataGridView1.Rows[d].Cells[9].Value =h[d];
                dataGridView1.Rows[d].Cells[6].Value = Convert.ToDouble(dataGridView1.Rows[d].Cells[2].Value) - Convert.ToDouble(dataGridView1.Rows[d].Cells[4].Value);
                dataGridView1.Rows[d].Cells[7].Value = Convert.ToDouble(dataGridView1.Rows[d].Cells[3].Value) - Convert.ToDouble(dataGridView1.Rows[d].Cells[5].Value);

                /* cout << i << "     " << mas[i].x << "     " << "(" << obh[i].y1 << " ; " << obh[i].y2 << ")" << "           " << "(" << mas[i].y1 << " ; " << mas[i].y2 << ")" << "         " << e[i] << "      " << h[i] << endl;
                cout << endl;
                cout << endl; */
            }
            DrawMainSys(mas, i);

        }

        void Conststep()
        {


            Pointforsys[] mas = new Pointforsys[maxnum];
            Pointforsys[] obh = new Pointforsys[maxnum];
            double[] e;
            e = new double[maxnum];
            e[0] = 0;
            double[] h;
            h = new double[maxnum];

            double x0 = 0.0, h0 = h00, u01 = u10, u02 = u20;
            //xn - граница отрезка интегрирования
            int n = maxnum, indicator = 0;
            dataGridView1.Rows.Clear();
            dataGridView1.RowCount = maxnum;


            Pointforsys t;
            t.num = 0;
            t.x = x0;
            t.y1 = u01;
            t.y2 = u02;
            mas[0] = t;
            obh[0] = t;
            h[0] = h00;

            //int c1, c2;
            //c1 = c2 = 0;
            twopoint e12;
            e12.x1 = 0;
            e12.x2 = 0;

            int i = 1;
            dataGridView1.Rows.Add();


            while ((i < maxnum) && (mas[i - 1].x < xn) )
            {
                Pointforsys t1, t12, t2;
                dataGridView1.Rows[i - 1].Cells[0].Value = i - 1;

                //(x(n+1),v(n+1))
                x0 = mas[i - 1].x;
                u01 = mas[i - 1].y1;
                u02 = mas[i - 1].y2;

                t1 = metodRKS(i, h0, x0, u01, u02);  //V(n+1)
                obh[i] = t1;

                //(x(n+1/2),y(n+1/2))

                t12 = metodRKS(i, h0 * (0.5), x0, u01, u02);



                //(x(n),Y(n))	

                t2 = metodRKS(i, h0 * (0.5), t12.x, t12.y1, t12.y2); //V(n+1)^
                dataGridView1.Rows[i].Cells[4].Value = t12.y1;
                dataGridView1.Rows[i].Cells[5].Value = t12.y2;

                mas[i] = t2;
                i++;
            }

            dataGridView1.RowCount = i;
            form.label11.Text = Convert.ToString(i);

            Form2Filling(h, e, i, mas);
            for (int d = 0; (d < n) && (mas[d].x < xn) && (mas[i - 1].y1 != 0 && mas[i - 1].y2 != 0); d++)
            {
                dataGridView1.Rows[d].Cells[1].Value = mas[d].x;
                dataGridView1.Rows[d].Cells[2].Value = obh[d].y1;
                dataGridView1.Rows[d].Cells[3].Value = obh[d].y2;

                dataGridView1.Rows[d].Cells[9].Value = h[0];
                dataGridView1.Rows[d].Cells[6].Value = Convert.ToDouble(dataGridView1.Rows[d].Cells[2].Value) - Convert.ToDouble(dataGridView1.Rows[d].Cells[4].Value);
                dataGridView1.Rows[d].Cells[7].Value = Convert.ToDouble(dataGridView1.Rows[d].Cells[3].Value) - Convert.ToDouble(dataGridView1.Rows[d].Cells[5].Value);

               
            }
            DrawMainSys(mas, i);


        }

        
    }

}






