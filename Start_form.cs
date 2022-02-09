using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinoteatr_bilet
{
    public partial class Start_form : Form
    {

        static string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mrwoodu\Source\Repos\kinotest2\kinnoooo-main\AppData\Kino_DB.mdf;Integrated Security=True";
        SqlConnection connect_to_DB = new SqlConnection(conn);

        SqlCommand command;
        SqlDataAdapter adapter;


        public static int FilmC = 0;
        public static int Saal = 0;
        public static int SaalW = 0;
        public static int SaalH = 0;

        Label lbl;
        Button btn;
        public object Start_btn_2 { get; private set; }

        public Start_form()
        {
            this.Height = 500;
            this.Width = 500;
            var b = 0;

            Button Start_btn = new Button
            {
                Text = "Minu oma aken",
                Location = new System.Drawing.Point(100, 100)
            };

            btn = new Button();
            btn.Text = "Veel aken";
            btn.Location = new System.Drawing.Point(190, 300);
            btn.Enabled = false;


            this.Controls.Add(btn);
            btn.Click += Start_btn_2_Click;

            PictureBox film = new PictureBox
            {
                Image = Image.FromFile(@"..\..\Filmid\jazz.jpg"),
                Location = new System.Drawing.Point(10, 100),
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new System.Drawing.Size(140, 140)
            };

            PictureBox film2 = new PictureBox
            {
                Image = Image.FromFile(@"..\..\Filmid\joker.jpg"),
                Location = new System.Drawing.Point(150, 100),
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new System.Drawing.Size(140, 140)

            };
            PictureBox film3 = new PictureBox
            {
                Image = Image.FromFile(@"..\..\Filmid\navalny.jpg"),
                Location = new System.Drawing.Point(290, 100),
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new System.Drawing.Size(140, 140)
            };
            lbl = new Label();
            lbl.Text = $"{FilmC}";

            lbl.Location = new Point(50, 300);
            this.Controls.Add(lbl);

            film.Click += Film_Click;
            film2.Click += Film_Click2;
            film3.Click += Film_Click3;

            RadioButton rb1 = new RadioButton
            {
                Text = "Saal1",
                Location = new System.Drawing.Point(50, 400)
            };
            RadioButton rb2 = new RadioButton
            {
                Text = "Saal2",
                Location = new System.Drawing.Point(200, 400)
            };
            RadioButton rb3 = new RadioButton
            {
                Text = "Saal3",
                Location = new System.Drawing.Point(350, 400)
            };
            rb1.CheckedChanged += Rb1_CheckedChanged;
            rb2.CheckedChanged += Rb2_CheckedChanged;
            rb3.CheckedChanged += Rb3_CheckedChanged;

            this.Controls.Add(rb1);
            this.Controls.Add(rb2);
            this.Controls.Add(rb3);

            this.Controls.Add(film);
            this.Controls.Add(film2);
            this.Controls.Add(film3);
            this.Controls.Add(lbl);
            film.Click += Film_Click;
            film2.Click += Film_Click2;
            film3.Click += Film_Click3;

        }

        private void Rb3_CheckedChanged(object sender, EventArgs e)
        {
            Saal = 3;
            lbl.Text = $"{Saal}";
            SaalW = 10;
            SaalH = 6;
            if (FilmC != 0)
            {
                btn.Enabled = true;
            }
        }

        private void Rb2_CheckedChanged(object sender, EventArgs e)
        {
            Saal = 2;
            lbl.Text = $"{Saal}";
            SaalW = 12;
            SaalH = 8;
            if (FilmC != 0)
            {
                btn.Enabled = true;
            }
        }

        private void Rb1_CheckedChanged(object sender, EventArgs e)
        {
            Saal = 1;
            lbl.Text = $"{Saal}";
            SaalW = 15;
            SaalH = 10;
            if (FilmC != 0)
            {
                btn.Enabled = true;
            }
        }

        private void Film_Click(object sender, EventArgs e)
        {
            FilmC = 1;
            lbl.Text = $"{FilmC}";
            if (Saal != 0)
            {
                btn.Enabled = true;
            }
        }
        private void Film_Click2(object sender, EventArgs e)
        {
            FilmC = 2;
            lbl.Text = $"{FilmC}";
            if (Saal != 0)
            {
                btn.Enabled = true;
            }
        }
        private void Film_Click3(object sender, EventArgs e)
        {
            FilmC = 3;
            lbl.Text = $"{FilmC}";
            if (Saal != 0)
            {
                btn.Enabled = true;
            }
        }

        private void Start_btn_2_Click(object sender, EventArgs e)
        {
            Hide();
            Zal_vaata uus_aken = new Zal_vaata(SaalH, SaalW);//запускает пустую форму
            uus_aken.StartPosition = FormStartPosition.CenterScreen;
            uus_aken.ShowDialog();
            uus_aken = null;
            Show();
            string mc = "Mortal Kombat";
            using (StreamWriter srb = new StreamWriter(@"..\..\zapisfilma\Film.txt", true))
            {
                srb.WriteLine(mc);
            }
            this.Hide();
        }


        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Start_form
            // 
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Name = "Start_form";
            this.Load += new System.EventHandler(this.Start_form_Load);
            this.ResumeLayout(false);
        }

        private void Start_form_Load(object sender, EventArgs e)
        {

        }
    }
}
