namespace pavleperic
{
    partial class Form1
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
            this.kreiraj_tabele = new System.Windows.Forms.Button();
            this.napuni_tabele = new System.Windows.Forms.Button();
            this.izvrsi_upite = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // kreiraj_tabele
            // 
            this.kreiraj_tabele.Location = new System.Drawing.Point(113, 51);
            this.kreiraj_tabele.Name = "kreiraj_tabele";
            this.kreiraj_tabele.Size = new System.Drawing.Size(75, 23);
            this.kreiraj_tabele.TabIndex = 0;
            this.kreiraj_tabele.Text = "Kreiraj tabele";
            this.kreiraj_tabele.UseVisualStyleBackColor = true;
            this.kreiraj_tabele.Click += new System.EventHandler(this.kreiraj_tabele_Click);
            // 
            // napuni_tabele
            // 
            this.napuni_tabele.Location = new System.Drawing.Point(312, 51);
            this.napuni_tabele.Name = "napuni_tabele";
            this.napuni_tabele.Size = new System.Drawing.Size(75, 23);
            this.napuni_tabele.TabIndex = 1;
            this.napuni_tabele.Text = "Napuni tabele";
            this.napuni_tabele.UseVisualStyleBackColor = true;
            this.napuni_tabele.Click += new System.EventHandler(this.napuni_tabele_Click);
            // 
            // izvrsi_upite
            // 
            this.izvrsi_upite.Location = new System.Drawing.Point(497, 51);
            this.izvrsi_upite.Name = "izvrsi_upite";
            this.izvrsi_upite.Size = new System.Drawing.Size(75, 23);
            this.izvrsi_upite.TabIndex = 2;
            this.izvrsi_upite.Text = "Izvrsi upite";
            this.izvrsi_upite.UseVisualStyleBackColor = true;
            this.izvrsi_upite.Click += new System.EventHandler(this.izvrsi_upite_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[]
            {
                "1. Navesti grad u kome je fabrika imala najvecu zaradu u 2018. godini.",
                "2. Koliki je procenat prodaje OTC(lekovi bez recepta) preparata?",
                "3. Navesti prosecne plate zaposlenih po gradovima.",
                "4. Koji distributer omogucava najvise robe?",
                "5. Navesti prosecne cene suplemenata u fabrici u Novom Sadu.",
                "6. Navesti masine za izradu koje su najvise bile u upotrebi.",
                "7. Koje PAM(povrsinski aktivne materije) su bile najcesce koriscene kao lekovite supstance?",
                "8. Navesti prosecnu starost kupaca koji su kupovali antihipertezive.",
                "9. Navesti gradove u kojima je prosek starosti zaposlenih veci od 40 godina.",
                "10. Koji lek je bio najprodavaniji na trzistu?",
                "11. Navesti imena kupaca koji su kupili tablete izradjene magistralnom izradom.",
                "12. Koliki je broj zaposlenih u galenskim laboratorijskim fabrikama.",
                "13. Navesti lekovite supstance koje su praskastog oblika.",
                "14. Koje lekovite supstance su najcesce koriscene za izradu infuzije?",
                "15. Ispisati imena kupaca koji su kupili suplemente.",
                "16. Navesti sva etarska ulju koja su koriscena kao lekovite supstance.",
                "17. Ispisati ime zaposlenog koji ima najmanju zaradu.",
                "18. Ispisati ime lekovitu supstancu koja je zelatinoznog oblika.",
                "19. Koji prirucnik za izradu napisan u Londonu je najmladji?",
                "20. Na kom leku je fabrika najvise zaradila?",
                "21. Da li je profit firme veci u 2018. ili u 2017. godini?",
                "22. U kom gradu je fabrika imala najvecu zaradu u 2017. godini?",
                "23. Da li je prodato vise suplemenata u 2018. godini ili u 2017. godini i ako jeste koliko?",
                "24. Da li je i kolika je razlika profita 2018.godine u odnosu na 2017. godinu u fabrici u Beogradu?",
                "25. Koja je razlika u zaradi u prvoj i drugoj polovini 2018. godine u Novom Sadu?",
                "26. Na kojoj vrsti lekova(suplementi, antihipertezivi, magistralne tablete) je najveci prihoh u 2018. godini i koliko on iznosi?",
                "27. Na kojoj vrsti lekova(suplementi, antihipertezivi, magistralne tablete) je najveci prihoh u 2017. godini i koliko on iznosi?",
                "28. Kolika je razlika u zaradi fabrike u Novom Sadu i fabrike u Nisu u 2018. godine?"



            });
            this.listBox1.Location = new System.Drawing.Point(113, 110);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(491, 160);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(113, 288);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(491, 78);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.izvrsi_upite);
            this.Controls.Add(this.napuni_tabele);
            this.Controls.Add(this.kreiraj_tabele);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button kreiraj_tabele;
        private System.Windows.Forms.Button napuni_tabele;
        private System.Windows.Forms.Button izvrsi_upite;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

