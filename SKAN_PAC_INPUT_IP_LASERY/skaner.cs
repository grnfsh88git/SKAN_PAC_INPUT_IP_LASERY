using MySqlX.XDevAPI;
using SKAN_PAC_INPUT_IP_LASERY.klasy;


namespace SKAN_PAC_INPUT_IP_LASERY
{
    public partial class skaner : Form
    {
        public skaner()
        {
            InitializeComponent();
        }
        bool jedenraz = true;
        bool skanuje;
        pac _pac = new pac();
        sql _sql = new sql();
        private async void b_skanuj_pac_Click(object sender, EventArgs e)
        {
            if (int.TryParse(t_interwal.Text, out int result) && Convert.ToInt16(t_interwal.Text) > 29)
            {

                b_skanuj_pac.Enabled = false;
                b_skanuj_pac_ZATRZYMAJ.Enabled = true;
                if (!skanuje)
                {
                    _pac.zatrzymajSkanowanie = false;
                    skanuje = true;
                }

                b_skanuj_pac.BackColor = Color.Red;


                MessageBox.Show("Skanowanie co [s]: " + result.ToString());
                _pac.skanuj_JPC(Convert.ToInt16(t_interwal.Text), dataGridView1, b_skanuj_pac, l_pobierz, dataGridView_listarobotow, b_lista_robotow_pobierz, textBox1,t_log1);
            }
            else
            {
                MessageBox.Show("Wpisz poprawn¹ liczbê. conajmniej 30");
            }





        }

        private void b_skanuj_pac_ZATRZYMAJ_Click(object sender, EventArgs e)
        {
            b_skanuj_pac.Enabled = true;
            b_skanuj_pac_ZATRZYMAJ.Enabled = false;

            if (skanuje)
            {
                _pac.zatrzymajSkanowanie = true;
                skanuje = false;
            }
        }

        private void b_lista_robotow_pobierz_Click(object sender, EventArgs e)
        {
            sql _sql = new sql();
            _sql.roboty_jpc(dataGridView_listarobotow, b_lista_robotow_pobierz);
        }

        private void t_interwal_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
