
namespace Pragados_Project
{
    partial class frmCar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCar));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAddCarBrand = new System.Windows.Forms.Button();
            this.btnReloadCarBrand = new System.Windows.Forms.Button();
            this.cmbCarBrand = new System.Windows.Forms.ComboBox();
            this.dgvCar = new System.Windows.Forms.DataGridView();
            this.btnImage = new FontAwesome.Sharp.IconButton();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.btnAddPenalty = new System.Windows.Forms.Button();
            this.btnReloadPenalty = new System.Windows.Forms.Button();
            this.cmbPenalty = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbAvail = new System.Windows.Forms.ComboBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCarModel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAutoCarID = new System.Windows.Forms.TextBox();
            this.lblAutoCarID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCarID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCarName = new System.Windows.Forms.TextBox();
            this.Car = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Login = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblUserType = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(36)))), ((int)(((byte)(35)))));
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnAddCarBrand);
            this.panel1.Controls.Add(this.btnReloadCarBrand);
            this.panel1.Controls.Add(this.cmbCarBrand);
            this.panel1.Controls.Add(this.dgvCar);
            this.panel1.Controls.Add(this.btnImage);
            this.panel1.Controls.Add(this.pbImage);
            this.panel1.Controls.Add(this.btnAddPenalty);
            this.panel1.Controls.Add(this.btnReloadPenalty);
            this.panel1.Controls.Add(this.cmbPenalty);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.cmbAvail);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnRemove);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtPrice);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtCarModel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtAutoCarID);
            this.panel1.Controls.Add(this.lblAutoCarID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCarID);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtCarName);
            this.panel1.Controls.Add(this.Car);
            this.panel1.Location = new System.Drawing.Point(-13, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1040, 522);
            this.panel1.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gold;
            this.label6.Location = new System.Drawing.Point(417, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 25);
            this.label6.TabIndex = 91;
            this.label6.Text = "Cars";
            // 
            // btnAddCarBrand
            // 
            this.btnAddCarBrand.BackColor = System.Drawing.Color.Gold;
            this.btnAddCarBrand.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddCarBrand.BackgroundImage")));
            this.btnAddCarBrand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddCarBrand.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddCarBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCarBrand.Location = new System.Drawing.Point(345, 302);
            this.btnAddCarBrand.Name = "btnAddCarBrand";
            this.btnAddCarBrand.Size = new System.Drawing.Size(21, 19);
            this.btnAddCarBrand.TabIndex = 90;
            this.btnAddCarBrand.UseVisualStyleBackColor = false;
            this.btnAddCarBrand.Click += new System.EventHandler(this.btnAddCarBrand_Click);
            // 
            // btnReloadCarBrand
            // 
            this.btnReloadCarBrand.BackColor = System.Drawing.Color.Gold;
            this.btnReloadCarBrand.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReloadCarBrand.BackgroundImage")));
            this.btnReloadCarBrand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReloadCarBrand.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReloadCarBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReloadCarBrand.Location = new System.Drawing.Point(372, 302);
            this.btnReloadCarBrand.Name = "btnReloadCarBrand";
            this.btnReloadCarBrand.Size = new System.Drawing.Size(28, 19);
            this.btnReloadCarBrand.TabIndex = 89;
            this.btnReloadCarBrand.UseVisualStyleBackColor = false;
            this.btnReloadCarBrand.Click += new System.EventHandler(this.btnReloadCarBrand_Click);
            // 
            // cmbCarBrand
            // 
            this.cmbCarBrand.FormattingEnabled = true;
            this.cmbCarBrand.Location = new System.Drawing.Point(171, 300);
            this.cmbCarBrand.Name = "cmbCarBrand";
            this.cmbCarBrand.Size = new System.Drawing.Size(168, 21);
            this.cmbCarBrand.TabIndex = 88;
            // 
            // dgvCar
            // 
            this.dgvCar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCar.Location = new System.Drawing.Point(422, 56);
            this.dgvCar.Name = "dgvCar";
            this.dgvCar.Size = new System.Drawing.Size(604, 332);
            this.dgvCar.TabIndex = 87;
            this.dgvCar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCar_CellClick);
            this.dgvCar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCar_CellContentClick);
            // 
            // btnImage
            // 
            this.btnImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImage.IconChar = FontAwesome.Sharp.IconChar.Pen;
            this.btnImage.IconColor = System.Drawing.Color.Gold;
            this.btnImage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImage.IconSize = 20;
            this.btnImage.Location = new System.Drawing.Point(383, 200);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(33, 28);
            this.btnImage.TabIndex = 86;
            this.btnImage.Tag = "Add/Edit";
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // pbImage
            // 
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbImage.Location = new System.Drawing.Point(29, 12);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(348, 210);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage.TabIndex = 85;
            this.pbImage.TabStop = false;
            // 
            // btnAddPenalty
            // 
            this.btnAddPenalty.BackColor = System.Drawing.Color.Gold;
            this.btnAddPenalty.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddPenalty.BackgroundImage")));
            this.btnAddPenalty.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddPenalty.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddPenalty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPenalty.Location = new System.Drawing.Point(298, 435);
            this.btnAddPenalty.Name = "btnAddPenalty";
            this.btnAddPenalty.Size = new System.Drawing.Size(21, 19);
            this.btnAddPenalty.TabIndex = 84;
            this.btnAddPenalty.UseVisualStyleBackColor = false;
            this.btnAddPenalty.Click += new System.EventHandler(this.btnAddPenalty_Click);
            // 
            // btnReloadPenalty
            // 
            this.btnReloadPenalty.BackColor = System.Drawing.Color.Gold;
            this.btnReloadPenalty.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReloadPenalty.BackgroundImage")));
            this.btnReloadPenalty.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReloadPenalty.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReloadPenalty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReloadPenalty.Location = new System.Drawing.Point(325, 435);
            this.btnReloadPenalty.Name = "btnReloadPenalty";
            this.btnReloadPenalty.Size = new System.Drawing.Size(28, 19);
            this.btnReloadPenalty.TabIndex = 83;
            this.btnReloadPenalty.UseVisualStyleBackColor = false;
            this.btnReloadPenalty.Click += new System.EventHandler(this.btnReloadPenalty_Click);
            // 
            // cmbPenalty
            // 
            this.cmbPenalty.FormattingEnabled = true;
            this.cmbPenalty.Location = new System.Drawing.Point(171, 435);
            this.cmbPenalty.Name = "cmbPenalty";
            this.cmbPenalty.Size = new System.Drawing.Size(121, 21);
            this.cmbPenalty.TabIndex = 82;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(480, 27);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(168, 24);
            this.txtSearch.TabIndex = 81;
            this.txtSearch.Text = "Search";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // cmbAvail
            // 
            this.cmbAvail.FormattingEnabled = true;
            this.cmbAvail.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cmbAvail.Location = new System.Drawing.Point(171, 408);
            this.cmbAvail.Name = "cmbAvail";
            this.cmbAvail.Size = new System.Drawing.Size(50, 21);
            this.cmbAvail.TabIndex = 80;
            this.cmbAvail.Text = "Yes";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Gold;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(620, 449);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(68, 30);
            this.btnBack.TabIndex = 78;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Gold;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(670, 413);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(67, 30);
            this.btnClear.TabIndex = 77;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.Gold;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(743, 413);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(81, 30);
            this.btnRemove.TabIndex = 76;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Gold;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(596, 413);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(68, 30);
            this.btnUpdate.TabIndex = 75;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Gold;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(500, 413);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(88, 30);
            this.btnAdd.TabIndex = 74;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gold;
            this.label5.Location = new System.Drawing.Point(79, 431);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 25);
            this.label5.TabIndex = 71;
            this.label5.Text = "Penalty:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gold;
            this.label3.Location = new System.Drawing.Point(48, 404);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 25);
            this.label3.TabIndex = 69;
            this.label3.Text = "Availability:";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(172, 366);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(168, 20);
            this.txtPrice.TabIndex = 68;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gold;
            this.label4.Location = new System.Drawing.Point(61, 363);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 25);
            this.label4.TabIndex = 67;
            this.label4.Text = "Price/day:";
            // 
            // txtCarModel
            // 
            this.txtCarModel.Location = new System.Drawing.Point(172, 334);
            this.txtCarModel.Name = "txtCarModel";
            this.txtCarModel.Size = new System.Drawing.Size(168, 20);
            this.txtCarModel.TabIndex = 66;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(52, 331);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 25);
            this.label1.TabIndex = 65;
            this.label1.Text = "Car Model:";
            // 
            // txtAutoCarID
            // 
            this.txtAutoCarID.Location = new System.Drawing.Point(213, 468);
            this.txtAutoCarID.Name = "txtAutoCarID";
            this.txtAutoCarID.Size = new System.Drawing.Size(79, 20);
            this.txtAutoCarID.TabIndex = 64;
            this.txtAutoCarID.Visible = false;
            // 
            // lblAutoCarID
            // 
            this.lblAutoCarID.AutoSize = true;
            this.lblAutoCarID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoCarID.ForeColor = System.Drawing.Color.Gold;
            this.lblAutoCarID.Location = new System.Drawing.Point(79, 466);
            this.lblAutoCarID.Name = "lblAutoCarID";
            this.lblAutoCarID.Size = new System.Drawing.Size(128, 25);
            this.lblAutoCarID.TabIndex = 63;
            this.lblAutoCarID.Text = "AutoCar ID :";
            this.lblAutoCarID.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(54, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 25);
            this.label2.TabIndex = 61;
            this.label2.Text = "Car Brand:";
            // 
            // txtCarID
            // 
            this.txtCarID.Location = new System.Drawing.Point(171, 241);
            this.txtCarID.Name = "txtCarID";
            this.txtCarID.Size = new System.Drawing.Size(79, 20);
            this.txtCarID.TabIndex = 60;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gold;
            this.label8.Location = new System.Drawing.Point(84, 238);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 25);
            this.label8.TabIndex = 59;
            this.label8.Text = "Car ID :";
            // 
            // txtCarName
            // 
            this.txtCarName.Location = new System.Drawing.Point(171, 269);
            this.txtCarName.Name = "txtCarName";
            this.txtCarName.Size = new System.Drawing.Size(168, 20);
            this.txtCarName.TabIndex = 58;
            // 
            // Car
            // 
            this.Car.AutoSize = true;
            this.Car.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Car.ForeColor = System.Drawing.Color.Gold;
            this.Car.Location = new System.Drawing.Point(54, 266);
            this.Car.Name = "Car";
            this.Car.Size = new System.Drawing.Size(114, 25);
            this.Car.TabIndex = 57;
            this.Car.Text = "Car Name:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(36)))), ((int)(((byte)(35)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(382, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(268, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 99;
            this.pictureBox1.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(36)))), ((int)(((byte)(35)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Gold;
            this.btnExit.Location = new System.Drawing.Point(949, 10);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(48, 36);
            this.btnExit.TabIndex = 98;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gold;
            this.panel2.Controls.Add(this.lblUser);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.lblUserType);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.Login);
            this.panel2.Location = new System.Drawing.Point(1, -3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1045, 122);
            this.panel2.TabIndex = 5;
            // 
            // Login
            // 
            this.Login.AutoSize = true;
            this.Login.BackColor = System.Drawing.Color.Gold;
            this.Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login.Location = new System.Drawing.Point(398, 76);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(220, 37);
            this.Login.TabIndex = 0;
            this.Login.Text = "Manage Cars";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(36)))), ((int)(((byte)(35)))));
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.Gold;
            this.lblUser.Location = new System.Drawing.Point(930, 85);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(57, 25);
            this.lblUser.TabIndex = 102;
            this.lblUser.Text = "User";
            // 
            // lblUserType
            // 
            this.lblUserType.AutoSize = true;
            this.lblUserType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(36)))), ((int)(((byte)(35)))));
            this.lblUserType.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserType.ForeColor = System.Drawing.Color.Gold;
            this.lblUserType.Location = new System.Drawing.Point(807, 85);
            this.lblUserType.Name = "lblUserType";
            this.lblUserType.Size = new System.Drawing.Size(117, 25);
            this.lblUserType.TabIndex = 101;
            this.lblUserType.Text = "User Type:";
            this.lblUserType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 625);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCar";
            this.Load += new System.EventHandler(this.frmCar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtAutoCarID;
        private System.Windows.Forms.Label lblAutoCarID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCarID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCarName;
        private System.Windows.Forms.Label Car;
        private System.Windows.Forms.Label Login;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCarModel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cmbAvail;
        private System.Windows.Forms.Button btnAddPenalty;
        private System.Windows.Forms.Button btnReloadPenalty;
        private System.Windows.Forms.ComboBox cmbPenalty;
        private System.Windows.Forms.PictureBox pbImage;
        private FontAwesome.Sharp.IconButton btnImage;
        private System.Windows.Forms.DataGridView dgvCar;
        private System.Windows.Forms.ComboBox cmbCarBrand;
        private System.Windows.Forms.Button btnAddCarBrand;
        private System.Windows.Forms.Button btnReloadCarBrand;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblUserType;
    }
}