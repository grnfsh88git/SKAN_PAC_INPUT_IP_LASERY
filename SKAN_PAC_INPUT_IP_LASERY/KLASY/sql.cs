using Google.Protobuf.Collections;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAN_PAC_INPUT_IP_LASERY.klasy;

internal class sql
{
    private string connectionString = "Server=192.168.80.90;Database=energy;User ID=wojtek;Password=5yFL71Nf2ux;";
    private string connectionString_jpc = "Data Source=JPC25;Initial Catalog=raporty;User ID=read;Password=zx;Encrypt=True;TrustServerCertificate=True";
    public DataTable dataTable = new DataTable();
    public DataTable brobotyJPC = new DataTable();
    public string etykieta;
    public string blad;
    public string wyslijblad;


    public void roboty()
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                etykieta = "Połączono z bazą danych injection_base!";
                string query = "SELECT `energy_id`, `energy_id2`, `energy_ip1`, `energy_ip2` FROM injection_base where lokalizacja like 17 or lokalizacja like 16 or lokalizacja like 15  ";
                MySqlCommand command = new MySqlCommand(query, connection);


                // Pobierz dane do DataTable

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                adapter.Fill(dataTable);

                // Ustaw dane jako źródło GridView




            }
            catch (Exception ex)
            {
                etykieta = ex.ToString();
            }
        }




    }
    public void roboty_jpc(DataGridView _DataGridView,Button _Button)
    {
        brobotyJPC.Clear();
        using (SqlConnection connection = new SqlConnection(connectionString_jpc))
        {
            
            try
            {
                connection.Open();
                string query = "SELECT (nr), TRIM(robot) as robot FROM lista_wtryskarek where robot not like '-%' order by nr ";
                SqlCommand command = new SqlCommand(query, connection);




                SqlDataAdapter adapter = new SqlDataAdapter(command);
                
                adapter.Fill(brobotyJPC);
                _DataGridView.DataSource = brobotyJPC;

            }
            catch (Exception ex)
            {
                _Button.Text = ex.ToString();
            }
        }

    }

    /*
    public void roboty_jpc()
    {

        using (SqlConnection connection = new SqlConnection(connectionString_jpc))
        {

            try
            {
                connection.Open();
                string query = "SELECT (nr), (robot) FROM lista_wtryskarek where robot not like '-'  ";
                SqlCommand command = new SqlCommand(query, connection);




                SqlDataAdapter adapter = new SqlDataAdapter(command);
                                adapter.Fill(brobotyJPC);


            }
            catch (Exception ex)
            {
                
            }
        }

    }

    */
    public void wyslij (string nazwa_tebeli, bool input)
    {
        
        wyslijblad = "pracuje";
        string query = $"INSERT INTO `{nazwa_tebeli}`(praca)VALUES(@prac)";
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                etykieta = "Połączono z bazą danych injection_base!";

                // Tworzenie polecenia
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@prac", input);


                    // Wykonanie zapytania
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Liczba wstawionych wierszy: {rowsAffected}");
                }



                wyslijblad = "zakonczono";

            }
            catch (Exception ex)
            {
                wyslijblad = ex.Message;
                sprawdzIUtworz(nazwa_tebeli);
            }
            
        }

    }

    public void sprawdzIUtworz(string nazwa_tabeli)
    {
        string query = $"CREATE TABLE IF NOT EXISTS `{nazwa_tabeli}` (ID INT UNSIGNED AUTO_INCREMENT PRIMARY KEY, data TIMESTAMP DEFAULT CURRENT_TIMESTAMP, praca TINYINT(1) NOT NULL)";


        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                etykieta = "Połączono z bazą danych injection_base!";

                // Tworzenie polecenia
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    


                    // Wykonanie zapytania
                    int rowsAffected = command.ExecuteNonQuery();
                    
                }



                blad = "zakonczono";

            }
            catch (Exception ex)
            {
                blad = ex.Message;
            }

        }
    }

        
    
}
