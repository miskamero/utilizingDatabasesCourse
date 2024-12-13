using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;
using System.Drawing;



namespace Autokauppa.model
{
    public class DatabaseHallinta
    {
        string yhteysTiedot;
        SqlConnection dbYhteys;

        public DatabaseHallinta()
        {
            yhteysTiedot =
                 "Server = (localdb)\\MSSQLLocalDB;" +
                 "Database = Autokauppa;" +
                 "Trusted_Connection = True;";
            dbYhteys = new SqlConnection();
        }

        public bool connectDatabase()
        {
            dbYhteys.ConnectionString = yhteysTiedot;

            try
            {
                dbYhteys.Open();
                MessageBox.Show("Yhteys avattu");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Virheilmoitukset:" + e);
                dbYhteys.Close();
                return false;

            }

        }

        public bool testDatabaseConnection()
        {
            try
            {
                if (dbYhteys.State == System.Data.ConnectionState.Open)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Virheilmoitukset:" + e);
                return false;
            }
        }

        public void disconnectDatabase()
        {
            dbYhteys.Close();
        }

        // saveAutoIntoDatabase(makerID, modelID, colorID, fuelID, price, engineVolume, mileage, date);
        // saveAutoIntoDatabase(makerID, modelID, colorID, fuelID, price, engineVolume, mileage, date)
        public bool saveAutoIntoDatabase(int makerID, int modelID, int colorID, int fuelID, decimal price, decimal engineVolume, int mileage, DateTime date)
        {
            try
            {
                if (dbYhteys.State == System.Data.ConnectionState.Open)
                {
                    string query = @"
                        INSERT INTO auto (Hinta, Rekisteri_paivamaara, Moottorin_tilavuus, Mittarilukema, AutonMerkkiID, AutonMalliID, VaritID, PolttoaineID)
                        VALUES (@price, @date, @engineVolume, @mileage, @makerID, @modelID, @colorID, @fuelID)";

                    SqlCommand command = new SqlCommand(query, dbYhteys);
                    command.Parameters.AddWithValue("@price", price);
                    command.Parameters.AddWithValue("@date", date);
                    command.Parameters.AddWithValue("@engineVolume", engineVolume);
                    command.Parameters.AddWithValue("@mileage", mileage);
                    command.Parameters.AddWithValue("@makerID", makerID);
                    command.Parameters.AddWithValue("@modelID", modelID);
                    command.Parameters.AddWithValue("@colorID", colorID);
                    command.Parameters.AddWithValue("@fuelID", fuelID);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Auto tallennettu tietokantaan");
                    return true;
                }
                else
                {
                    MessageBox.Show("Database connection is not open.");
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error saving the car to the database: " + e.Message);
                return false;
            }
        }
        public int? GetNextLowestByPrice(decimal currentPrice, int currentID)
        {
            try
            {
                if (dbYhteys.State == System.Data.ConnectionState.Open)
                {
                    // Query for the next car (higher price or same price, higher ID)
                    string query = @"
                        SELECT TOP 1 ID 
                        FROM Auto 
                        WHERE (Hinta > @currentPrice) 
                           OR (Hinta = @currentPrice AND ID > @currentID)
                        ORDER BY Hinta ASC, ID ASC";

                    SqlCommand command = new SqlCommand(query, dbYhteys);
                    command.Parameters.AddWithValue("@currentPrice", currentPrice);
                    command.Parameters.AddWithValue("@currentID", currentID);

                    object result = command.ExecuteScalar();

                    // If no next car is found, wrap to the lowest-priced car
                    if (result == null)
                    {
                        query = @"
                            SELECT TOP 1 ID 
                            FROM Auto 
                            ORDER BY Hinta ASC, ID ASC";

                        command = new SqlCommand(query, dbYhteys);
                        result = command.ExecuteScalar();
                    }

                    return result != null ? (int?)result : null;
                }
                else
                {
                    MessageBox.Show("Database connection is not open.");
                    return null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error fetching the next available Car: " + e.Message);
                return null;
            }
        }

        public int? GetPreviousLowestByPrice(decimal currentPrice, int currentID)
        {
            try
            {
                if (dbYhteys.State == System.Data.ConnectionState.Open)
                {
                    // Query for the previous car (lower price or same price, lower ID)
                    string query = @"
                        SELECT TOP 1 ID 
                        FROM Auto 
                        WHERE (Hinta < @currentPrice) 
                           OR (Hinta = @currentPrice AND ID < @currentID)
                        ORDER BY Hinta DESC, ID DESC";

                    SqlCommand command = new SqlCommand(query, dbYhteys);
                    command.Parameters.AddWithValue("@currentPrice", currentPrice);
                    command.Parameters.AddWithValue("@currentID", currentID);

                    object result = command.ExecuteScalar();

                    // If no previous car is found, wrap to the highest-priced car
                    if (result == null)
                    {
                        query = @"
                            SELECT TOP 1 ID 
                            FROM Auto 
                            ORDER BY Hinta DESC, ID DESC";

                        command = new SqlCommand(query, dbYhteys);
                        result = command.ExecuteScalar();
                    }

                    return result != null ? (int?)result : null;
                }
                else
                {
                    MessageBox.Show("Database connection is not open.");
                    return null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error fetching the previous available Car: " + e.Message);
                return null;
            }
        }

        public List<object> getAllAutoMakersFromDatabase()
        {
            List<string> makers = new List<string>();
            try
            {
                if (dbYhteys.State == System.Data.ConnectionState.Open)
                {
                    string query = "SELECT Merkki FROM AutonMerkki";
                    SqlCommand command = new SqlCommand(query, dbYhteys);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        makers.Add(reader["Merkki"].ToString());
                    }
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error fetching auto makers: " + e.Message);
            }
            return makers.Cast<object>().ToList();
        }

        public List<string> getAutoModelsByMakerId(int makerId)
        {
            // Filter to only list the current maker's models
            List<string> models = new List<string>();
            try
            {
                if (dbYhteys.State == System.Data.ConnectionState.Open)
                {
                    string query = "SELECT Auton_mallin_nimi FROM AutonMallit WHERE AutonMerkkiID = @makerId";
                    SqlCommand command = new SqlCommand(query, dbYhteys);
                    command.Parameters.AddWithValue("@makerId", makerId);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        // Add the model name to the list
                        models.Add(reader["Auton_mallin_nimi"].ToString());
                    }
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error fetching auto models: " + e.Message);
            }
            return models;
        }

        public List<object> getAllColorsFromDatabase()
        {
            List<string> colors = new List<string>();
            try
            {
                if (dbYhteys.State == System.Data.ConnectionState.Open)
                {
                    string query = "SELECT Varin_nimi FROM Varit";
                    SqlCommand command = new SqlCommand(query, dbYhteys);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        colors.Add(reader["Varin_nimi"].ToString());
                    }
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error fetching colors: " + e.Message);
            }
            return colors.Cast<object>().ToList();
        }

        public List<object> getAllFuelsFromDatabase()
        {
            List<string> fuels = new List<string>();
            try
            {
                if (dbYhteys.State == System.Data.ConnectionState.Open)
                {
                    string query = "SELECT Polttoaineen_nimi FROM Polttoaine";
                    SqlCommand command = new SqlCommand(query, dbYhteys);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        fuels.Add(reader["Polttoaineen_nimi"].ToString());
                    }
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error fetching fuels: " + e.Message);
            }
            return fuels.Cast<object>().ToList();
        }

        public Auto GetAutoByID(int id)
        {
            try
            {
                if (dbYhteys.State == System.Data.ConnectionState.Open)
                {
                    string query = "SELECT * FROM Auto WHERE ID = @id";
                    SqlCommand command = new SqlCommand(query, dbYhteys);
                    command.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Auto auto = new Auto
                        {
                            ID = (int)reader["ID"],
                            Hinta = (decimal)reader["Hinta"],
                            Rekisteri_paivamaara = (DateTime)reader["Rekisteri_paivamaara"],
                            Moottorin_tilavuus = (decimal)reader["Moottorin_tilavuus"],
                            Mittarilukema = (int)reader["Mittarilukema"],
                            AutonMerkkiID = (int)reader["AutonMerkkiID"],
                            AutonMalliID = (int)reader["AutonMalliID"],
                            VaritID = (int)reader["VaritID"],
                            PolttoaineID = (int)reader["PolttoaineID"]
                        };
                        reader.Close();
                        return auto;
                    }
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error fetching auto details: " + e.Message);
            }
            return null;
        }

        public int getAutoMakerID(string maker)
        {
            try
            {
                if (dbYhteys.State == System.Data.ConnectionState.Open)
                {
                    string query = "SELECT ID FROM AutonMerkki WHERE Merkki = @maker";
                    SqlCommand command = new SqlCommand(query, dbYhteys);
                    command.Parameters.AddWithValue("@maker", maker);
                    object result = command.ExecuteScalar();
                    return result != null ? (int)result : -1;
                }
                else
                {
                    MessageBox.Show("Database connection is not open.");
                    return -1;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error fetching auto maker ID: " + e.Message);
                return -1;
            }
        }

        public int getAutoModelID(string model)
        {
            try
            {
                if (dbYhteys.State == System.Data.ConnectionState.Open)
                {
                    string query = "SELECT ID FROM AutonMallit WHERE Auton_mallin_nimi = @model";
                    SqlCommand command = new SqlCommand(query, dbYhteys);
                    command.Parameters.AddWithValue("@model", model);
                    object result = command.ExecuteScalar();
                    return result != null ? (int)result : -1;
                }
                else
                {
                    MessageBox.Show("Database connection is not open.");
                    return -1;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error fetching auto model ID: " + e.Message);
                return -1;
            }
        }

        public int getColorID(string color)
        {
            try
            {
                if (dbYhteys.State == System.Data.ConnectionState.Open)
                {
                    string query = "SELECT ID FROM Varit WHERE Varin_nimi = @color";
                    SqlCommand command = new SqlCommand(query, dbYhteys);
                    command.Parameters.AddWithValue("@color", color);
                    object result = command.ExecuteScalar();
                    return result != null ? (int)result : -1;
                }
                else
                {
                    MessageBox.Show("Database connection is not open.");
                    return -1;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error fetching color ID: " + e.Message);
                return -1;
            }
        }

        public int getFuelID(string fuel)
        {
            try
            {
                if (dbYhteys.State == System.Data.ConnectionState.Open)
                {
                    string query = "SELECT ID FROM Polttoaine WHERE Polttoaineen_nimi = @fuel";
                    SqlCommand command = new SqlCommand(query, dbYhteys);
                    command.Parameters.AddWithValue("@fuel", fuel);
                    object result = command.ExecuteScalar();
                    return result != null ? (int)result : -1;
                }
                else
                {
                    MessageBox.Show("Database connection is not open.");
                    return -1;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error fetching fuel ID: " + e.Message);
                return -1;
            }
        }

        // getAutoMakerNameFromID
        public string getAutoMakerNameFromID(int makerID)
        {
            try
            {
                if (dbYhteys.State == System.Data.ConnectionState.Open)
                {
                    string query = "SELECT Merkki FROM AutonMerkki WHERE ID = @makerID";
                    SqlCommand command = new SqlCommand(query, dbYhteys);
                    command.Parameters.AddWithValue("@makerID", makerID);
                    object result = command.ExecuteScalar();
                    return result != null ? result.ToString() : "";
                }
                else
                {
                    MessageBox.Show("Database connection is not open.");
                    return "";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error fetching auto maker name: " + e.Message);
                return "";
            }
        }

        public string getAutoModelNameFromID(int modelID)
        {
            try
            {
                if (dbYhteys.State == System.Data.ConnectionState.Open)
                {
                    string query = "SELECT Auton_mallin_nimi FROM AutonMallit WHERE ID = @modelID";
                    SqlCommand command = new SqlCommand(query, dbYhteys);
                    command.Parameters.AddWithValue("@modelID", modelID);
                    object result = command.ExecuteScalar();
                    return result != null ? result.ToString() : "";
                }
                else
                {
                    MessageBox.Show("Database connection is not open.");
                    return "";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error fetching auto model name: " + e.Message);
                return "";
            }
        }

        public string getColorNameFromID(int colorID)
        {
            try
            {
                if (dbYhteys.State == System.Data.ConnectionState.Open)
                {
                    string query = "SELECT Varin_nimi FROM Varit WHERE ID = @colorID";
                    SqlCommand command = new SqlCommand(query, dbYhteys);
                    command.Parameters.AddWithValue("@colorID", colorID);
                    object result = command.ExecuteScalar();
                    return result != null ? result.ToString() : "";
                }
                else
                {
                    MessageBox.Show("Database connection is not open.");
                    return "";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error fetching color name: " + e.Message);
                return "";
            }
        }

        public string getFuelNameFromID(int fuelID)
        {
            try
            {
                if (dbYhteys.State == System.Data.ConnectionState.Open)
                {
                    string query = "SELECT Polttoaineen_nimi FROM Polttoaine WHERE ID = @fuelID";
                    SqlCommand command = new SqlCommand(query, dbYhteys);
                    command.Parameters.AddWithValue("@fuelID", fuelID);
                    object result = command.ExecuteScalar();
                    return result != null ? result.ToString() : "";
                }
                else
                {
                    MessageBox.Show("Database connection is not open.");
                    return "";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error fetching fuel name: " + e.Message);
                return "";
            }
        }

        public DataTable SearchCarsByBrand(string brand)
        {
            DataTable dt = new DataTable();
            try
            {
                if (dbYhteys.State == ConnectionState.Open)
                {
                    string query = "SELECT * FROM Auto WHERE AutonMerkkiID IN (SELECT ID FROM AutonMerkki WHERE Merkki = @brand)";
                    SqlCommand command = new SqlCommand(query, dbYhteys);
                    command.Parameters.AddWithValue("@brand", brand);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
                else
                {
                    MessageBox.Show("Database connection is not open.");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error fetching cars by brand: " + e.Message);
            }
            return dt;
        }
        public DataTable SearchCarsByPrice(decimal maxPrice)
        {
            DataTable dt = new DataTable();
            try
            {
                if (dbYhteys.State == ConnectionState.Open)
                {
                    string query = @"
                SELECT TOP 20 * 
                FROM Auto 
                WHERE Hinta <= @maxPrice 
                ORDER BY Hinta DESC, ID DESC";
                    SqlCommand command = new SqlCommand(query, dbYhteys);
                    command.Parameters.AddWithValue("@maxPrice", maxPrice);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
                else
                {
                    MessageBox.Show("Database connection is not open.");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error fetching cars by price: " + e.Message);
            }
            return dt;
        }
        public void UpdateAuto(int CurrentID, int makerID, int modelID, int colorID, int fuelID, decimal price, decimal engineVolume, int mileage, DateTime date)
        {
            // Update the car with the given ID
            try
            {
                if (dbYhteys.State == ConnectionState.Open)
                {
                    string query = @"
                        UPDATE Auto 
                        SET Hinta = @price, Rekisteri_paivamaara = @date, Moottorin_tilavuus = @engineVolume, Mittarilukema = @mileage, AutonMerkkiID = @makerID, AutonMalliID = @modelID, VaritID = @colorID, PolttoaineID = @fuelID
                        WHERE ID = @CurrentID";

                    SqlCommand command = new SqlCommand(query, dbYhteys);
                    command.Parameters.AddWithValue("@price", price);
                    command.Parameters.AddWithValue("@date", date);
                    command.Parameters.AddWithValue("@engineVolume", engineVolume);
                    command.Parameters.AddWithValue("@mileage", mileage);
                    command.Parameters.AddWithValue("@makerID", makerID);
                    command.Parameters.AddWithValue("@modelID", modelID);
                    command.Parameters.AddWithValue("@colorID", colorID);
                    command.Parameters.AddWithValue("@fuelID", fuelID);
                    command.Parameters.AddWithValue("@CurrentID", CurrentID);

                    command.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Database connection is not open.");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error updating the car: " + e.Message);
            }
        }

        public void DeleteAuto(int id)
        {
            try
            {
                if (dbYhteys.State == ConnectionState.Open)
                {
                    string query = "DELETE FROM Auto WHERE ID = @id";
                    SqlCommand command = new SqlCommand(query, dbYhteys);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Database connection is not open.");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error deleting the car: " + e.Message);
            }
        }
    }
}
