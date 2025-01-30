using Modbus.Device;
using MySqlX.XDevAPI;

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SKAN_PAC_INPUT_IP_LASERY.klasy;

internal class pac
{
    public

string ipAddress = ""; // IP urządzenia Modbus
    int port = 502; // Port Modbus TCP (domyślnie 502)
    ushort iec801 = 801; // Adres początkowy rejestru
    ushort iec801num = 4; // Liczba rejestrów do odczytania
    ushort cmc = 501; // Adres początkowy rejestru
    ushort cmcnum = 2; // Liczba rejestrów do odczytania}
    ushort input = 200;
    ushort inputnum = 1;
    public string blad = "brak bledu";
    public double dIEC801;
    public float fCMC;
    public bool iINPUT;
    public string czas;
    public bool zatrzymajSkanowanie;
    public bool udalosie=false;

    public async void czytajiNPUT(string ip, TextBox _TextBox)
    {

        Stopwatch odpytanie = new Stopwatch();
        odpytanie.Start();
        ipAddress = ip;
        try
        {
            // Tworzymy połączenie TCP
            using (TcpClient client = new TcpClient(ip, port))
            {
                //         client.ReceiveTimeout = 100; // 1 sekunda na odpowiedź
                //         client.SendTimeout = 100; // 1 sekunda na wysłanie danych
                // Tworzymy instancję ModbusIpMaster
                ModbusIpMaster master = ModbusIpMaster.CreateIp(client);

                // Odczytujemy dane z rejestrów Holding Registers
                ushort[] registersiec801 = master.ReadInputRegisters(1, iec801, iec801num);
                ushort[] registersieccmc = master.ReadInputRegisters(1, cmc, cmcnum);
                bool[] registersiecinput = master.ReadInputs(1, input, inputnum);


                ulong rawValue = ((ulong)registersiec801[0] << 48) | ((ulong)registersiec801[1] << 32) | ((ulong)registersiec801[2] << 16) | registersiec801[3];


                dIEC801 = BitConverter.Int64BitsToDouble((long)rawValue);

                uint combined2 = (uint)((registersieccmc[0] << 16) | registersieccmc[1]);
                byte[] bytes2 = BitConverter.GetBytes(combined2);
                fCMC = BitConverter.ToSingle(bytes2, 0);

                iINPUT = registersiecinput[0];


                //Thread.Sleep(30000);

                udalosie = true;

                // Jeśli pracujesz w pętli
                if (_TextBox.InvokeRequired)
                {
                    _TextBox.Invoke(new Action(() =>
                    {
                        _TextBox.Text += Environment.NewLine + ip + " odczytane" + Environment.NewLine;
                    }));
                }
                else
                {
                    _TextBox.Text += Environment.NewLine + ip + " odczytane" + Environment.NewLine;
                }


                
            }

        }
        catch (Exception ex)
        {
            if (_TextBox.InvokeRequired)
            {
                _TextBox.Invoke(new Action(() =>
                {
                    _TextBox.Text += Environment.NewLine + ip + " BŁĄD" + Environment.NewLine;
                }));
            }
            else
            {
                _TextBox.Text += Environment.NewLine + ip + " BŁĄD" + Environment.NewLine;
            }
            blad = $"Problemowy adres: {ip} "+ex.Message;
           // _TextBox.Text += $"Problemowy adres: {ip} ";
            udalosie =false;
        }
        
        czas = odpytanie.Elapsed.TotalMilliseconds.ToString();


    }


    public async void czytajDI(string ip)
    {

        Stopwatch odpytanie = new Stopwatch();
        odpytanie.Start();
        ipAddress = ip;
        try
        {
            // Tworzymy połączenie TCP
            using (TcpClient client = new TcpClient(ip, port))
            {
                //         client.ReceiveTimeout = 100; // 1 sekunda na odpowiedź
                //         client.SendTimeout = 100; // 1 sekunda na wysłanie danych
                // Tworzymy instancję ModbusIpMaster
                ModbusIpMaster master = ModbusIpMaster.CreateIp(client);

                // Odczytujemy dane z rejestrów Holding Registers
                bool[] registersiecinput = master.ReadInputs(1, input, inputnum);
                iINPUT = registersiecinput[0];
            }

        }
        catch (Exception ex)
        {
            blad = $"Problemowy adres: {ip}";
        }

        czas = odpytanie.Elapsed.TotalMilliseconds.ToString();


    }


    public async void skanuj(sql _mysql, int ile_skanowan, int delay, DataGridView grid, Button przycisk, Label _label)
    {
        


        // przycisk.Text = "...TRWA SKANOWANIE..." + _mysql.etykieta.ToString();
        int il = 0;
        //      PAC _pac = new PAC();
        DataTable DT_DI = new DataTable();
        DT_DI.Columns.Add("IP", typeof(string));   // Kolumna typu int
        DT_DI.Columns.Add("DI", typeof(string));
        DT_DI.Columns.Add("czas_odpytania [ms]", typeof(string));   // Kolumna typu int
        int ilerazy = _mysql.dataTable.Rows.Count;
        while (!zatrzymajSkanowanie)
        {
            il++;
            przycisk.Text = "...TRWA SKANOWANIE..." + il.ToString();
            try
            {
                Stopwatch odpytanie = new Stopwatch();


                var tasks = new Task[ilerazy];
                pac[] zadanie = new pac[ilerazy];
                for (int i = 0; i < ilerazy; i++)
                {
                    zadanie[i] = new pac(); // Przyjmuję, że PAC ma domyślny konstruktor
                }

                for (int i = 0; i < ilerazy; i++)
                {
                    int tasknumber = i;
                    string ip = _mysql.dataTable.Rows[tasknumber][columnName: "energy_ip1"].ToString();
                  //  tasks[tasknumber] = Task.Run(() => zadanie[tasknumber].czytajiNPUT(ip,));

                }

                await Task.WhenAll(tasks);


                int nr = 1;
                foreach (DataRow row in _mysql.dataTable.Rows)
                {
                    DT_DI.Rows.Add(zadanie[nr].ipAddress, zadanie[nr].iINPUT, zadanie[nr].czas);
                    nr++;
                }





                odpytanie.Stop();
            }
            catch (Exception ex)
            {

            }
            grid.DataSource = DT_DI;
            await Task.Delay(TimeSpan.FromSeconds(delay));


        }

        przycisk.Text = "SKANUJ";
        przycisk.BackColor = Color.Fuchsia;
        przycisk.Enabled = true;
        if(zatrzymajSkanowanie)
        {
            przycisk.Text = "...Zatzrymano...";
        }
        
    }



    public async Task skanuj_JPC(int delay, DataGridView grid, Button przycisk, Label _label,DataGridView _DataGridView, Button _button,TextBox _textBox,TextBox _LOG       )
    {
        sql _sql = new sql();
        _sql.roboty_jpc(_DataGridView, _button);

        // przycisk.Text = "...TRWA SKANOWANIE..." + _mysql.etykieta.ToString();

        //      PAC _pac = new PAC();
        DataTable DT_DI = new DataTable();
        DT_DI.Columns.Add("nr", typeof(string));
        DT_DI.Columns.Add("IP", typeof(string));   // Kolumna typu int
        DT_DI.Columns.Add("DI", typeof(string));
        DT_DI.Columns.Add("czas_odpytania [ms]", typeof(string));   // Kolumna typu int
        DT_DI.Columns.Add("robot", typeof(string));
        DT_DI.Columns.Add("data", typeof(DateTime));
        int ilerazy = _sql.brobotyJPC.Rows.Count;
        int il = 0;
        DataTable DT_robotyIP = new DataTable();
        DT_robotyIP = _sql.brobotyJPC;
        DT_robotyIP.Columns.Add("IPs");
        
        foreach(DataRow dr in DT_robotyIP.Rows)
        {
            


            if(Convert.ToInt16(DT_robotyIP.Rows[il]["nr"]) < 300)
            {
                DT_robotyIP.Rows[il]["IPs"] = "192.168.80." + DT_robotyIP.Rows[il]["nr"];
            }
            else
            {
                DT_robotyIP.Rows[il]["IPs"] = "192.168.80." + (Convert.ToInt16(DT_robotyIP.Rows[il]["nr"]) - 100).ToString();
            }
            if(DT_robotyIP.Rows[il]["IPs"].ToString() == "192.168.80.17")
                {
                DT_robotyIP.Rows[il]["IPs"] = "192.168.55.78";
                
                }
            il++;
        }

        il = 0;
        _DataGridView.DataSource = DT_robotyIP;
        int il_While = 0;
        int ile_bledow = 0;
        while (!zatrzymajSkanowanie)
        {

            string ip=" ";
            il_While++;
            przycisk.Text = "...TRWA SKANOWANIE..." + il_While.ToString();
            _label.Text = "zaczynam ";
            try
            {
                Stopwatch odpytanie = new Stopwatch();
               

                var tasks = new Task[ilerazy];
                pac[] zadanie = new pac[ilerazy];
                for (int i = 0; i < ilerazy; i++)
                {
                    zadanie[i] = new pac(); // Przyjmuję, że PAC ma domyślny konstruktor
                }

                _LOG.Text = "zaczynam ładowanie tasków   " + DateTime.Now + Environment.NewLine;
                var cancellationTokenSource = new CancellationTokenSource();
                cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(60)); // Ustawienie limitu czasu na 60 sekund
                var cancellationToken = cancellationTokenSource.Token;

                var semaphore = new SemaphoreSlim(5); // Ogranicz równoległość do 5

                for (int ii = 0; ii < ilerazy; ii++)
                {


                    int tasknumber = ii;
                    try 
                    {

                        

                        tasks[tasknumber] = Task.Run(async() =>
                        {

                            await semaphore.WaitAsync();

                            try
                            {
                                cancellationToken.ThrowIfCancellationRequested();


                                zadanie[tasknumber].czytajiNPUT(DT_robotyIP.Rows[tasknumber]["IPs"].ToString(), _LOG);  // 'ip' używane jest lokalnie w każdym zadaniu
                            }
                            finally
                            {
                                semaphore.Release();
                            }


                        }, cancellationToken);
                        _LOG.Text += tasknumber.ToString() + " ";
                    }
                    catch (Exception ex)
                    { _LOG.Text += Environment.NewLine + tasknumber.ToString() + " " + ex.Message + "  " + Environment.NewLine; }


                }

                await Task.WhenAll(tasks);

                _LOG.Text += "ZAŁADOWANE  "+DateTime.Now  + Environment.NewLine;

               DT_DI.Clear();
                int nr = 0;
                foreach (DataRow row in DT_robotyIP.Rows)
                {
                    if (zadanie[nr].udalosie==true)
                    {
                        DT_DI.Rows.Add(nr, zadanie[nr].ipAddress, zadanie[nr].iINPUT, zadanie[nr].czas, DT_robotyIP.Rows[nr]["robot"].ToString(), DateTime.Now);
                        _sql.wyslij("Z " + DT_robotyIP.Rows[nr]["robot"], zadanie[nr].iINPUT);
                      
                    }
                    else
                    {
                        _label.Text = "błędów =" + ile_bledow.ToString();
                        _textBox.Text += nr.ToString() + " " + zadanie[nr].ipAddress.ToString() + " " + zadanie[nr].udalosie.ToString() + " " + DateTime.Now.ToString() + "    "+ zadanie[nr].blad+Environment.NewLine;
                    }
                    _LOG.Text += "wgrany do bazy "+ nr.ToString() + DateTime.Now + Environment.NewLine;
                    _LOG.Text += nr.ToString() + " " + zadanie[nr].ipAddress.ToString() + " " + zadanie[nr].udalosie.ToString() + " " + DateTime.Now.ToString() + "    ";
                    nr++;
                }


                odpytanie.Stop();

            }
            catch (Exception ex)
            {
                _label.Text = ip + " ";
                _label.Text += ex.Message + "  ";
                zatrzymajSkanowanie = true;
            }
            grid.DataSource = DT_DI;
            _LOG.Text += $"czekam {delay} s";
            await Task.Delay(TimeSpan.FromSeconds(delay));

            _sql.brobotyJPC.Clear();
            DT_robotyIP.Clear();
            _sql.roboty_jpc(_DataGridView, _button);
            ilerazy = _sql.brobotyJPC.Rows.Count;
            il = 0;
           
            DT_robotyIP = _sql.brobotyJPC;
            _LOG.Text += "sprawdzam roboty"+Environment.NewLine;

            foreach (DataRow dr in DT_robotyIP.Rows)
            {



                if (Convert.ToInt16(DT_robotyIP.Rows[il]["nr"]) < 300)
                {
                    DT_robotyIP.Rows[il]["IPs"] = "192.168.80." + DT_robotyIP.Rows[il]["nr"];
                }
                else
                {
                    DT_robotyIP.Rows[il]["IPs"] = "192.168.80." + (Convert.ToInt16(DT_robotyIP.Rows[il]["nr"]) - 100).ToString();
                }
                if (DT_robotyIP.Rows[il]["IPs"].ToString() == "192.168.80.17")
                {
                    DT_robotyIP.Rows[il]["IPs"] = "192.168.55.78";

                }
                il++;
            }
            _LOG.Text += "przypisałem roboty" + Environment.NewLine +" "+ DateTime.Now;

        }
        przycisk.Text = "SKANUJ";
        przycisk.BackColor = Color.Fuchsia;
        przycisk.Enabled = true;
        if (zatrzymajSkanowanie)
        {
            przycisk.Text = "...Zatzrymano...";
        }

    }
}
