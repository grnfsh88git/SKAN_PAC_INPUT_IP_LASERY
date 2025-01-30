namespace SKAN_PAC_INPUT_IP_LASERY
{
    partial class skaner
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PACinput = new TabControl();
            tabPage1 = new TabPage();
            dataGridView1 = new DataGridView();
            tab_konfiguracja = new TabPage();
            l_wersja = new Label();
            t_interwal = new TextBox();
            textBox1 = new TextBox();
            b_skanuj_pac_ZATRZYMAJ = new Button();
            l_pobierz = new Label();
            b_skanuj_pac = new Button();
            tab_listarobotow = new TabPage();
            dataGridView_listarobotow = new DataGridView();
            b_lista_robotow_pobierz = new Button();
            tabPage3 = new TabPage();
            t_log1 = new TextBox();
            PACinput.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tab_konfiguracja.SuspendLayout();
            tab_listarobotow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_listarobotow).BeginInit();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // PACinput
            // 
            PACinput.Controls.Add(tabPage1);
            PACinput.Controls.Add(tab_konfiguracja);
            PACinput.Controls.Add(tab_listarobotow);
            PACinput.Controls.Add(tabPage3);
            PACinput.Dock = DockStyle.Fill;
            PACinput.Location = new Point(0, 0);
            PACinput.Name = "PACinput";
            PACinput.SelectedIndex = 0;
            PACinput.Size = new Size(800, 450);
            PACinput.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(792, 422);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "PAC input";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(786, 416);
            dataGridView1.TabIndex = 0;
            // 
            // tab_konfiguracja
            // 
            tab_konfiguracja.Controls.Add(l_wersja);
            tab_konfiguracja.Controls.Add(t_interwal);
            tab_konfiguracja.Controls.Add(textBox1);
            tab_konfiguracja.Controls.Add(b_skanuj_pac_ZATRZYMAJ);
            tab_konfiguracja.Controls.Add(l_pobierz);
            tab_konfiguracja.Controls.Add(b_skanuj_pac);
            tab_konfiguracja.Location = new Point(4, 24);
            tab_konfiguracja.Name = "tab_konfiguracja";
            tab_konfiguracja.Padding = new Padding(3);
            tab_konfiguracja.Size = new Size(792, 422);
            tab_konfiguracja.TabIndex = 1;
            tab_konfiguracja.Text = "konfiguracja";
            tab_konfiguracja.UseVisualStyleBackColor = true;
            // 
            // l_wersja
            // 
            l_wersja.AutoSize = true;
            l_wersja.Location = new Point(30, 396);
            l_wersja.Name = "l_wersja";
            l_wersja.Size = new Size(112, 15);
            l_wersja.TabIndex = 5;
            l_wersja.Text = "V1.5 rownoleglosc 5";
            l_wersja.Click += label1_Click;
            // 
            // t_interwal
            // 
            t_interwal.Location = new Point(370, 36);
            t_interwal.Name = "t_interwal";
            t_interwal.Size = new Size(100, 23);
            t_interwal.TabIndex = 4;
            t_interwal.TabStop = false;
            t_interwal.TextChanged += t_interwal_TextChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(3, 118);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Both;
            textBox1.Size = new Size(726, 243);
            textBox1.TabIndex = 3;
            // 
            // b_skanuj_pac_ZATRZYMAJ
            // 
            b_skanuj_pac_ZATRZYMAJ.Location = new Point(6, 35);
            b_skanuj_pac_ZATRZYMAJ.Name = "b_skanuj_pac_ZATRZYMAJ";
            b_skanuj_pac_ZATRZYMAJ.Size = new Size(219, 23);
            b_skanuj_pac_ZATRZYMAJ.TabIndex = 2;
            b_skanuj_pac_ZATRZYMAJ.Text = "Zatrzymaj skanowanie";
            b_skanuj_pac_ZATRZYMAJ.UseVisualStyleBackColor = true;
            b_skanuj_pac_ZATRZYMAJ.Click += b_skanuj_pac_ZATRZYMAJ_Click;
            // 
            // l_pobierz
            // 
            l_pobierz.AutoSize = true;
            l_pobierz.Location = new Point(8, 72);
            l_pobierz.Name = "l_pobierz";
            l_pobierz.Size = new Size(38, 15);
            l_pobierz.TabIndex = 1;
            l_pobierz.Text = "label1";
            // 
            // b_skanuj_pac
            // 
            b_skanuj_pac.Location = new Point(6, 6);
            b_skanuj_pac.Name = "b_skanuj_pac";
            b_skanuj_pac.Size = new Size(762, 23);
            b_skanuj_pac.TabIndex = 0;
            b_skanuj_pac.Text = "SKANUJ PAC";
            b_skanuj_pac.UseVisualStyleBackColor = true;
            b_skanuj_pac.Click += b_skanuj_pac_Click;
            // 
            // tab_listarobotow
            // 
            tab_listarobotow.Controls.Add(dataGridView_listarobotow);
            tab_listarobotow.Controls.Add(b_lista_robotow_pobierz);
            tab_listarobotow.Location = new Point(4, 24);
            tab_listarobotow.Name = "tab_listarobotow";
            tab_listarobotow.Padding = new Padding(3);
            tab_listarobotow.Size = new Size(792, 422);
            tab_listarobotow.TabIndex = 2;
            tab_listarobotow.Text = "Lista Robotów";
            tab_listarobotow.UseVisualStyleBackColor = true;
            // 
            // dataGridView_listarobotow
            // 
            dataGridView_listarobotow.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_listarobotow.Dock = DockStyle.Fill;
            dataGridView_listarobotow.Location = new Point(3, 26);
            dataGridView_listarobotow.Name = "dataGridView_listarobotow";
            dataGridView_listarobotow.RowTemplate.Height = 25;
            dataGridView_listarobotow.Size = new Size(786, 393);
            dataGridView_listarobotow.TabIndex = 1;
            // 
            // b_lista_robotow_pobierz
            // 
            b_lista_robotow_pobierz.Dock = DockStyle.Top;
            b_lista_robotow_pobierz.Location = new Point(3, 3);
            b_lista_robotow_pobierz.Name = "b_lista_robotow_pobierz";
            b_lista_robotow_pobierz.Size = new Size(786, 23);
            b_lista_robotow_pobierz.TabIndex = 0;
            b_lista_robotow_pobierz.Text = "Pobierz";
            b_lista_robotow_pobierz.UseVisualStyleBackColor = true;
            b_lista_robotow_pobierz.Click += b_lista_robotow_pobierz_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(t_log1);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(792, 422);
            tabPage3.TabIndex = 3;
            tabPage3.Text = "LOGI";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // t_log1
            // 
            t_log1.Dock = DockStyle.Fill;
            t_log1.Location = new Point(3, 3);
            t_log1.Multiline = true;
            t_log1.Name = "t_log1";
            t_log1.ScrollBars = ScrollBars.Both;
            t_log1.Size = new Size(786, 416);
            t_log1.TabIndex = 0;
            // 
            // skaner
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(PACinput);
            Name = "skaner";
            Text = "Skaner";
            PACinput.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tab_konfiguracja.ResumeLayout(false);
            tab_konfiguracja.PerformLayout();
            tab_listarobotow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView_listarobotow).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl PACinput;
        private TabPage tabPage1;
        private TabPage tab_konfiguracja;
        private TabPage tab_listarobotow;
        private TabPage tabPage3;
        private DataGridView dataGridView1;
        private Button b_skanuj_pac;
        private DataGridView dataGridView_listarobotow;
        private Button b_lista_robotow_pobierz;
        private Label l_pobierz;
        private Button b_skanuj_pac_ZATRZYMAJ;
        private TextBox textBox1;
        private TextBox t_interwal;
        private Label l_wersja;
        private TextBox t_log1;
    }
}
