using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Autokauppa.model;
using Autokauppa.controller;


namespace Autokauppa.view
{
    public partial class MainMenu : Form
    {
        private DatabaseHallinta dbHallinta;

        // KaupanLogiikka registerHandler;

        public MainMenu()
        {
            //registerHandler = new KaupanLogiikka();
            InitializeComponent();
            dbHallinta = new DatabaseHallinta();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            bool isConnected = dbHallinta.connectDatabase();
            if (isConnected)
            {
                MessageBox.Show("Yhteys tietokantaan toimii");
                // Fill the comboboxes with data
                FillComboboxSelections();
            }
            else
            {
                MessageBox.Show("Yhteys tietokantaan ei toimi");
            }
        }

        private void FillComboboxSelections()
        {
            // Fill the comboboxes with data
            cbMerkki.DataSource = dbHallinta.getAllAutoMakersFromDatabase();
            cbMalli.DataSource = dbHallinta.getAutoModelsByMakerId(1);
            cbMerkki.SelectedIndexChanged += new EventHandler(cbMerkki_SelectedIndexChanged);
            cbVari.DataSource = dbHallinta.getAllColorsFromDatabase();
            cbPolttoaine.DataSource = dbHallinta.getAllFuelsFromDatabase();
        }

        private void cbMerkki_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the current cbMerkki selected string value, query that from the table AutonMerkki and find the ID
            // then use that ID to get the models from the table AutonMalli
            string selectedMerkki = cbMerkki.Text;
            int makerID = dbHallinta.getAutoMakerID(selectedMerkki);
            cbMalli.DataSource = dbHallinta.getAutoModelsByMakerId(makerID);
        }

        private void testaaTietokantaaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isConnected = dbHallinta.testDatabaseConnection();
            if (isConnected)
            {
                MessageBox.Show("Yhteys tietokantaan toimii");
            }
            else
            {
                MessageBox.Show("Yhteys tietokantaan ei toimi");
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // disconnectDatabase
            dbHallinta.disconnectDatabase();
            Application.Exit();
        }
        private void btnLisaa_Click(object sender, EventArgs e)
        {
            string RegexPattern = @"^\d,\d$";
            string selectedMaker = cbMerkki.Text;
            string selectedModel = cbMalli.Text;
            string selectedColor = cbVari.Text;
            string selectedFuel = cbPolttoaine.Text;
            decimal price = decimal.Parse(tbHinta.Text);
            decimal engineVolume = decimal.Parse(tbTilavuus.Text);
            int mileage = int.Parse(tbMittarilukema.Text);
            DateTime date = dtpPaiva.Value;

            // turn maker, model, color and fuel into their respective IDs
            int makerID = dbHallinta.getAutoMakerID(selectedMaker);
            int modelID = dbHallinta.getAutoModelID(selectedModel);
            int colorID = dbHallinta.getColorID(selectedColor);
            int fuelID = dbHallinta.getFuelID(selectedFuel);

            // check if tilavuus is valid using the regex
            if (!System.Text.RegularExpressions.Regex.IsMatch(tbTilavuus.Text, RegexPattern))
            {
                MessageBox.Show("Moottorin tilavuus on väärässä muodossa.");
                return;
            }

            // we dont use Auto class because it's broken and unnecessary
            // Auto auto = new Auto(0, makerID, modelID, colorID, fuelID, price, engineVolume, mileage, date);
            // we push the values to the database
            dbHallinta.saveAutoIntoDatabase(makerID, modelID, colorID, fuelID, price, engineVolume, mileage, date);
        }



        private void btnSeuraava_Click(object sender, EventArgs e)
        {
            try
            {
                decimal currentPrice = decimal.Parse(tbHinta.Text);
                int currentID = int.Parse(tbId.Text);

                int? nextCarID = dbHallinta.GetNextLowestByPrice(currentPrice, currentID);
                if (nextCarID.HasValue)
                {
                    tbId.Text = nextCarID.ToString();

                    Auto auto = dbHallinta.GetAutoByID(nextCarID.Value);
                    if (auto != null)
                    {
                        cbMerkki.Text = dbHallinta.getAutoMakerNameFromID(auto.AutonMerkkiID);
                        cbMalli.Text = dbHallinta.getAutoModelNameFromID(auto.AutonMalliID);
                        cbVari.Text = dbHallinta.getColorNameFromID(auto.VaritID);
                        cbPolttoaine.Text = dbHallinta.getFuelNameFromID(auto.PolttoaineID);
                        tbHinta.Text = auto.Hinta.ToString();
                        tbTilavuus.Text = auto.Moottorin_tilavuus.ToString();
                        tbMittarilukema.Text = auto.Mittarilukema.ToString();
                        dtpPaiva.Text = auto.Rekisteri_paivamaara.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        MessageBox.Show("Auto with the specified ID not found.");
                    }
                }
                else
                {
                    MessageBox.Show("No higher ID available.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid price format.");
            }
        }

        private void btnEdellinen_Click(object sender, EventArgs e)
        {
            try
            {
                decimal currentPrice = decimal.Parse(tbHinta.Text);
                int currentID = int.Parse(tbId.Text);

                int? previousCarID = dbHallinta.GetPreviousLowestByPrice(currentPrice, currentID);
                if (previousCarID.HasValue)
                {
                    tbId.Text = previousCarID.ToString();

                    Auto auto = dbHallinta.GetAutoByID(previousCarID.Value);
                    if (auto != null)
                    {
                        cbMerkki.Text = dbHallinta.getAutoMakerNameFromID(auto.AutonMerkkiID);
                        cbMalli.Text = dbHallinta.getAutoModelNameFromID(auto.AutonMalliID);
                        cbVari.Text = dbHallinta.getColorNameFromID(auto.VaritID);
                        cbPolttoaine.Text = dbHallinta.getFuelNameFromID(auto.PolttoaineID);
                        tbHinta.Text = auto.Hinta.ToString();
                        tbTilavuus.Text = auto.Moottorin_tilavuus.ToString();
                        tbMittarilukema.Text = auto.Mittarilukema.ToString();
                        dtpPaiva.Text = auto.Rekisteri_paivamaara.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        MessageBox.Show("Auto with the specified ID not found.");
                    }
                }
                else
                {
                    MessageBox.Show("No previous car available.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid price or ID format.");
            }
        }

        private void btnSearchByBrand_Click(object sender, EventArgs e)
        {
            string brand = tbMerkki.Text.Trim();
            if (!string.IsNullOrEmpty(brand))
            {
                DataTable results = dbHallinta.SearchCarsByBrand(brand);
                dgvCars.DataSource = results;

                if (results.Rows.Count == 0)
                {
                    MessageBox.Show("No cars found for the specified brand.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid brand.");
            }
        }

        private void btnSearchByPrice_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(numMaxPrice.Text, out decimal maxPrice) && maxPrice > 0)
            {
                DataTable results = dbHallinta.SearchCarsByPrice(maxPrice);
                dgvCars.DataSource = results;

                if (results.Rows.Count == 0)
                {
                    MessageBox.Show("No cars found under the specified price.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid price.");
            }
        }

        private void gbAuto_Enter(object sender, EventArgs e)
        {

        }

        private void tallennaNappi_Click(object sender, EventArgs e)
        {
            int CurrentID = int.Parse(tbId.Text);
            string selectedMaker = cbMerkki.Text;
            string selectedModel = cbMalli.Text;
            string selectedColor = cbVari.Text;
            string selectedFuel = cbPolttoaine.Text;
            decimal price = decimal.Parse(tbHinta.Text);
            decimal engineVolume = decimal.Parse(tbTilavuus.Text);
            int mileage = int.Parse(tbMittarilukema.Text);
            DateTime date = dtpPaiva.Value;

            int makerID = dbHallinta.getAutoMakerID(selectedMaker);
            int modelID = dbHallinta.getAutoModelID(selectedModel);
            int colorID = dbHallinta.getColorID(selectedColor);
            int fuelID = dbHallinta.getFuelID(selectedFuel);

            dbHallinta.UpdateAuto(CurrentID, makerID, modelID, colorID, fuelID, price, engineVolume, mileage, date);
        }

        private void poistaNappi_Click(object sender, EventArgs e)
        {
            int CurrentID = int.Parse(tbId.Text);
            dbHallinta.DeleteAuto(CurrentID);
            // call the GetNextLowestByPrice method to get the next car
            decimal currentPrice = decimal.Parse(tbHinta.Text);
            int? nextCarID = dbHallinta.GetNextLowestByPrice(currentPrice, CurrentID);
            if (nextCarID.HasValue)
            {
                tbId.Text = nextCarID.ToString();

                Auto auto = dbHallinta.GetAutoByID(nextCarID.Value);
                if (auto != null)
                {
                    cbMerkki.Text = dbHallinta.getAutoMakerNameFromID(auto.AutonMerkkiID);
                    cbMalli.Text = dbHallinta.getAutoModelNameFromID(auto.AutonMalliID);
                    cbVari.Text = dbHallinta.getColorNameFromID(auto.VaritID);
                    cbPolttoaine.Text = dbHallinta.getFuelNameFromID(auto.PolttoaineID);
                    tbHinta.Text = auto.Hinta.ToString();
                    tbTilavuus.Text = auto.Moottorin_tilavuus.ToString();
                    tbMittarilukema.Text = auto.Mittarilukema.ToString();
                    dtpPaiva.Text = auto.Rekisteri_paivamaara.ToString("yyyy-MM-dd");
                }
                else
                {
                    MessageBox.Show("Auto with the specified ID not found.");
                }
            }
            else
            {
                MessageBox.Show("No higher ID available.");
            }
        }
    }
}
