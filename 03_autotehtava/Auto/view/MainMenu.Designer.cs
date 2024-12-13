namespace Autokauppa.view
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            btnSeuraava = new System.Windows.Forms.Button();
            gbAuto = new System.Windows.Forms.GroupBox();
            poistaNappi = new System.Windows.Forms.Button();
            tallennaNappi = new System.Windows.Forms.Button();
            btnLisaa = new System.Windows.Forms.Button();
            btnEdellinen = new System.Windows.Forms.Button();
            label9 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            cbPolttoaine = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            cbVari = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            cbMalli = new System.Windows.Forms.ComboBox();
            dtpPaiva = new System.Windows.Forms.DateTimePicker();
            tbMittarilukema = new System.Windows.Forms.TextBox();
            tbTilavuus = new System.Windows.Forms.TextBox();
            tbHinta = new System.Windows.Forms.TextBox();
            tbId = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            cbMerkki = new System.Windows.Forms.ComboBox();
            numMaxPrice = new System.Windows.Forms.NumericUpDown();
            tbMerkki = new System.Windows.Forms.TextBox();
            btnSearchByPrice = new System.Windows.Forms.Button();
            btnSearchByBrand = new System.Windows.Forms.Button();
            dgvCars = new System.Windows.Forms.DataGridView();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            testaaTietokantaaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            gbAuto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMaxPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCars).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnSeuraava
            // 
            btnSeuraava.Location = new System.Drawing.Point(659, 254);
            btnSeuraava.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnSeuraava.Name = "btnSeuraava";
            btnSeuraava.Size = new System.Drawing.Size(89, 41);
            btnSeuraava.TabIndex = 17;
            btnSeuraava.Text = "Seuraava";
            btnSeuraava.UseVisualStyleBackColor = true;
            btnSeuraava.Click += btnSeuraava_Click;
            // 
            // gbAuto
            // 
            gbAuto.Controls.Add(poistaNappi);
            gbAuto.Controls.Add(tallennaNappi);
            gbAuto.Controls.Add(btnLisaa);
            gbAuto.Controls.Add(btnEdellinen);
            gbAuto.Controls.Add(btnSeuraava);
            gbAuto.Controls.Add(label9);
            gbAuto.Controls.Add(label8);
            gbAuto.Controls.Add(label7);
            gbAuto.Controls.Add(label6);
            gbAuto.Controls.Add(label5);
            gbAuto.Controls.Add(label4);
            gbAuto.Controls.Add(cbPolttoaine);
            gbAuto.Controls.Add(label3);
            gbAuto.Controls.Add(cbVari);
            gbAuto.Controls.Add(label2);
            gbAuto.Controls.Add(cbMalli);
            gbAuto.Controls.Add(dtpPaiva);
            gbAuto.Controls.Add(tbMittarilukema);
            gbAuto.Controls.Add(tbTilavuus);
            gbAuto.Controls.Add(tbHinta);
            gbAuto.Controls.Add(tbId);
            gbAuto.Controls.Add(label1);
            gbAuto.Controls.Add(cbMerkki);
            gbAuto.Location = new System.Drawing.Point(11, 45);
            gbAuto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            gbAuto.Name = "gbAuto";
            gbAuto.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            gbAuto.Size = new System.Drawing.Size(1083, 335);
            gbAuto.TabIndex = 18;
            gbAuto.TabStop = false;
            gbAuto.Text = "Auton tiedot";
            gbAuto.Enter += gbAuto_Enter;
            // 
            // poistaNappi
            // 
            poistaNappi.Location = new System.Drawing.Point(988, 254);
            poistaNappi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            poistaNappi.Name = "poistaNappi";
            poistaNappi.Size = new System.Drawing.Size(89, 41);
            poistaNappi.TabIndex = 36;
            poistaNappi.Text = "Poista";
            poistaNappi.UseVisualStyleBackColor = true;
            poistaNappi.Click += poistaNappi_Click;
            // 
            // tallennaNappi
            // 
            tallennaNappi.Location = new System.Drawing.Point(887, 254);
            tallennaNappi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tallennaNappi.Name = "tallennaNappi";
            tallennaNappi.Size = new System.Drawing.Size(89, 41);
            tallennaNappi.TabIndex = 35;
            tallennaNappi.Text = "Tallenna";
            tallennaNappi.UseVisualStyleBackColor = true;
            tallennaNappi.Click += tallennaNappi_Click;
            // 
            // btnLisaa
            // 
            btnLisaa.Location = new System.Drawing.Point(777, 254);
            btnLisaa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnLisaa.Name = "btnLisaa";
            btnLisaa.Size = new System.Drawing.Size(89, 41);
            btnLisaa.TabIndex = 21;
            btnLisaa.Text = "Lisää";
            btnLisaa.UseVisualStyleBackColor = true;
            btnLisaa.Click += btnLisaa_Click;
            // 
            // btnEdellinen
            // 
            btnEdellinen.Location = new System.Drawing.Point(544, 254);
            btnEdellinen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnEdellinen.Name = "btnEdellinen";
            btnEdellinen.Size = new System.Drawing.Size(93, 41);
            btnEdellinen.TabIndex = 19;
            btnEdellinen.Text = "Edellinen";
            btnEdellinen.UseVisualStyleBackColor = true;
            btnEdellinen.Click += btnEdellinen_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(952, 145);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(24, 20);
            label9.TabIndex = 34;
            label9.Text = "ID";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(821, 145);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(95, 20);
            label8.TabIndex = 33;
            label8.Text = "RekisteriPVM";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(693, 145);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(101, 20);
            label7.TabIndex = 32;
            label7.Text = "Mittarilukema";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(947, 83);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(62, 20);
            label6.TabIndex = 31;
            label6.Text = "Tilavuus";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(821, 83);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(45, 20);
            label5.TabIndex = 30;
            label5.Text = "Hinta";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(693, 83);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(76, 20);
            label4.TabIndex = 29;
            label4.Text = "Polttoaine";
            // 
            // cbPolttoaine
            // 
            cbPolttoaine.FormattingEnabled = true;
            cbPolttoaine.Location = new System.Drawing.Point(693, 111);
            cbPolttoaine.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            cbPolttoaine.Name = "cbPolttoaine";
            cbPolttoaine.Size = new System.Drawing.Size(121, 28);
            cbPolttoaine.TabIndex = 28;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(947, 25);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(34, 20);
            label3.TabIndex = 27;
            label3.Text = "Väri";
            // 
            // cbVari
            // 
            cbVari.FormattingEnabled = true;
            cbVari.Location = new System.Drawing.Point(947, 49);
            cbVari.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            cbVari.Name = "cbVari";
            cbVari.Size = new System.Drawing.Size(121, 28);
            cbVari.TabIndex = 26;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(821, 25);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(42, 20);
            label2.TabIndex = 25;
            label2.Text = "Malli";
            // 
            // cbMalli
            // 
            cbMalli.FormattingEnabled = true;
            cbMalli.Location = new System.Drawing.Point(821, 49);
            cbMalli.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            cbMalli.Name = "cbMalli";
            cbMalli.Size = new System.Drawing.Size(121, 28);
            cbMalli.TabIndex = 24;
            // 
            // dtpPaiva
            // 
            dtpPaiva.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpPaiva.Location = new System.Drawing.Point(825, 169);
            dtpPaiva.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            dtpPaiva.Name = "dtpPaiva";
            dtpPaiva.Size = new System.Drawing.Size(116, 27);
            dtpPaiva.TabIndex = 23;
            // 
            // tbMittarilukema
            // 
            tbMittarilukema.Location = new System.Drawing.Point(693, 169);
            tbMittarilukema.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tbMittarilukema.Name = "tbMittarilukema";
            tbMittarilukema.Size = new System.Drawing.Size(116, 27);
            tbMittarilukema.TabIndex = 22;
            // 
            // tbTilavuus
            // 
            tbTilavuus.Location = new System.Drawing.Point(947, 112);
            tbTilavuus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tbTilavuus.Name = "tbTilavuus";
            tbTilavuus.Size = new System.Drawing.Size(116, 27);
            tbTilavuus.TabIndex = 21;
            // 
            // tbHinta
            // 
            tbHinta.Location = new System.Drawing.Point(825, 112);
            tbHinta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tbHinta.Name = "tbHinta";
            tbHinta.PlaceholderText = "1";
            tbHinta.Size = new System.Drawing.Size(116, 27);
            tbHinta.TabIndex = 20;
            tbHinta.Text = "1";
            // 
            // tbId
            // 
            tbId.Location = new System.Drawing.Point(952, 169);
            tbId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tbId.Name = "tbId";
            tbId.ReadOnly = true;
            tbId.Size = new System.Drawing.Size(116, 27);
            tbId.TabIndex = 19;
            tbId.Text = "1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(693, 25);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(85, 20);
            label1.TabIndex = 18;
            label1.Text = "Automerkki";
            // 
            // cbMerkki
            // 
            cbMerkki.FormattingEnabled = true;
            cbMerkki.Location = new System.Drawing.Point(693, 49);
            cbMerkki.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            cbMerkki.Name = "cbMerkki";
            cbMerkki.Size = new System.Drawing.Size(121, 28);
            cbMerkki.TabIndex = 17;
            cbMerkki.SelectedIndexChanged += cbMerkki_SelectedIndexChanged;
            // 
            // numMaxPrice
            // 
            numMaxPrice.Location = new System.Drawing.Point(161, 671);
            numMaxPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            numMaxPrice.Maximum = new decimal(new int[] { 16777215, 0, 0, 0 });
            numMaxPrice.Name = "numMaxPrice";
            numMaxPrice.Size = new System.Drawing.Size(114, 27);
            numMaxPrice.TabIndex = 38;
            // 
            // tbMerkki
            // 
            tbMerkki.Location = new System.Drawing.Point(161, 633);
            tbMerkki.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tbMerkki.Name = "tbMerkki";
            tbMerkki.Size = new System.Drawing.Size(114, 27);
            tbMerkki.TabIndex = 37;
            // 
            // btnSearchByPrice
            // 
            btnSearchByPrice.Location = new System.Drawing.Point(14, 671);
            btnSearchByPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnSearchByPrice.Name = "btnSearchByPrice";
            btnSearchByPrice.Size = new System.Drawing.Size(141, 31);
            btnSearchByPrice.TabIndex = 36;
            btnSearchByPrice.Text = "Hae Maks. Hinnalla";
            btnSearchByPrice.UseVisualStyleBackColor = true;
            btnSearchByPrice.Click += btnSearchByPrice_Click;
            // 
            // btnSearchByBrand
            // 
            btnSearchByBrand.Location = new System.Drawing.Point(14, 632);
            btnSearchByBrand.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnSearchByBrand.Name = "btnSearchByBrand";
            btnSearchByBrand.Size = new System.Drawing.Size(141, 31);
            btnSearchByBrand.TabIndex = 35;
            btnSearchByBrand.Text = "Hae Merkillä";
            btnSearchByBrand.UseVisualStyleBackColor = true;
            btnSearchByBrand.Click += btnSearchByBrand_Click;
            // 
            // dgvCars
            // 
            dgvCars.AllowUserToAddRows = false;
            dgvCars.AllowUserToDeleteRows = false;
            dgvCars.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvCars.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCars.Location = new System.Drawing.Point(14, 388);
            dgvCars.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            dgvCars.Name = "dgvCars";
            dgvCars.ReadOnly = true;
            dgvCars.RowHeadersWidth = 51;
            dgvCars.RowTemplate.Height = 25;
            dgvCars.Size = new System.Drawing.Size(1081, 212);
            dgvCars.TabIndex = 22;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { exitToolStripMenuItem, aboutToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            menuStrip1.Size = new System.Drawing.Size(1109, 30);
            menuStrip1.TabIndex = 20;
            menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { exitToolStripMenuItem1 });
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            exitToolStripMenuItem.Text = "Tiedosto";
            // 
            // exitToolStripMenuItem1
            // 
            exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            exitToolStripMenuItem1.Size = new System.Drawing.Size(131, 26);
            exitToolStripMenuItem1.Text = "Poistu";
            exitToolStripMenuItem1.Click += exitToolStripMenuItem1_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { testaaTietokantaaToolStripMenuItem });
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            aboutToolStripMenuItem.Text = "Muuta...";
            // 
            // testaaTietokantaaToolStripMenuItem
            // 
            testaaTietokantaaToolStripMenuItem.Name = "testaaTietokantaaToolStripMenuItem";
            testaaTietokantaaToolStripMenuItem.Size = new System.Drawing.Size(213, 26);
            testaaTietokantaaToolStripMenuItem.Text = "Testaa tietokantaa";
            testaaTietokantaaToolStripMenuItem.Click += testaaTietokantaaToolStripMenuItem_Click;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1109, 733);
            Controls.Add(gbAuto);
            Controls.Add(dgvCars);
            Controls.Add(numMaxPrice);
            Controls.Add(menuStrip1);
            Controls.Add(tbMerkki);
            Controls.Add(btnSearchByPrice);
            Controls.Add(btnSearchByBrand);
            MainMenuStrip = menuStrip1;
            Margin = new System.Windows.Forms.Padding(5);
            Name = "MainMenu";
            Text = "MainMenu";
            Load += MainMenu_Load;
            gbAuto.ResumeLayout(false);
            gbAuto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMaxPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCars).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button btnSeuraava;
        private System.Windows.Forms.GroupBox gbAuto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbPolttoaine;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbVari;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMalli;
        private System.Windows.Forms.DateTimePicker dtpPaiva;
        private System.Windows.Forms.TextBox tbMittarilukema;
        private System.Windows.Forms.TextBox tbTilavuus;
        private System.Windows.Forms.TextBox tbHinta;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMerkki;
        private System.Windows.Forms.Button btnEdellinen;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testaaTietokantaaToolStripMenuItem;
        private System.Windows.Forms.Button btnLisaa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvCars;
        private System.Windows.Forms.NumericUpDown numMaxPrice;
        private System.Windows.Forms.TextBox tbMerkki;
        private System.Windows.Forms.Button btnSearchByPrice;
        private System.Windows.Forms.Button btnSearchByBrand;
        private System.Windows.Forms.Button tallennaNappi;
        private System.Windows.Forms.Button poistaNappi;
    }
}