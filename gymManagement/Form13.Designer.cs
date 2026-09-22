namespace gymManagement
{
    partial class Form13
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form13));
            this.txtTid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTrainer = new System.Windows.Forms.DataGridView();
            this.btnRe = new System.Windows.Forms.Button();
            this.pictureBoxSearch = new System.Windows.Forms.PictureBox();
            this.btnMenu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTid
            // 
            this.txtTid.Font = new System.Drawing.Font("Lucida Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTid.Location = new System.Drawing.Point(345, 84);
            this.txtTid.Name = "txtTid";
            this.txtTid.Size = new System.Drawing.Size(358, 35);
            this.txtTid.TabIndex = 9;
            this.txtTid.TextChanged += new System.EventHandler(this.txtTid_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(173, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 26);
            this.label1.TabIndex = 8;
            this.label1.Text = "TrainerID";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgvTrainer
            // 
            this.dgvTrainer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTrainer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrainer.Location = new System.Drawing.Point(12, 171);
            this.dgvTrainer.Name = "dgvTrainer";
            this.dgvTrainer.RowHeadersWidth = 51;
            this.dgvTrainer.RowTemplate.Height = 24;
            this.dgvTrainer.Size = new System.Drawing.Size(913, 287);
            this.dgvTrainer.TabIndex = 6;
            this.dgvTrainer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTrainer_CellContentClick);
            // 
            // btnRe
            // 
            this.btnRe.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRe.BackgroundImage")));
            this.btnRe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRe.Location = new System.Drawing.Point(807, 62);
            this.btnRe.Name = "btnRe";
            this.btnRe.Size = new System.Drawing.Size(69, 57);
            this.btnRe.TabIndex = 11;
            this.btnRe.Text = "Refresh";
            this.btnRe.UseVisualStyleBackColor = true;
            this.btnRe.Click += new System.EventHandler(this.btnRe_Click);
            // 
            // pictureBoxSearch
            // 
            this.pictureBoxSearch.BackColor = System.Drawing.Color.Silver;
            this.pictureBoxSearch.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSearch.Image")));
            this.pictureBoxSearch.Location = new System.Drawing.Point(662, 84);
            this.pictureBoxSearch.Name = "pictureBoxSearch";
            this.pictureBoxSearch.Size = new System.Drawing.Size(41, 35);
            this.pictureBoxSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSearch.TabIndex = 10;
            this.pictureBoxSearch.TabStop = false;
            this.pictureBoxSearch.Click += new System.EventHandler(this.pictureBoxSearch_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMenu.BackgroundImage")));
            this.btnMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMenu.Location = new System.Drawing.Point(29, 62);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(69, 57);
            this.btnMenu.TabIndex = 7;
            this.btnMenu.Text = "Menu";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // Form13
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.ClientSize = new System.Drawing.Size(935, 558);
            this.Controls.Add(this.btnRe);
            this.Controls.Add(this.pictureBoxSearch);
            this.Controls.Add(this.txtTid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.dgvTrainer);
            this.Name = "Form13";
            this.Text = "Form13";
            this.Load += new System.EventHandler(this.Form13_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRe;
        private System.Windows.Forms.PictureBox pictureBoxSearch;
        private System.Windows.Forms.TextBox txtTid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.DataGridView dgvTrainer;
    }
}