namespace PreyectoFinal.UI.Registros
{
    partial class RArticulo
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
            this.components = new System.ComponentModel.Container();
            this.DepartamentoComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DescripcionTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ArticuloIdNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.Addbutton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ProvedorCOmbobox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tipoButton = new System.Windows.Forms.Button();
            this.TipoCombox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.FechadateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.EliminarButton = new System.Windows.Forms.Button();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.NuevoButton = new System.Windows.Forms.Button();
            this.BuscarButton = new System.Windows.Forms.Button();
            this.PreciotextBox = new System.Windows.Forms.TextBox();
            this.CostotextBox = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.CantidadTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ArticuloIdNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // DepartamentoComboBox
            // 
            this.DepartamentoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DepartamentoComboBox.FormattingEnabled = true;
            this.DepartamentoComboBox.Location = new System.Drawing.Point(117, 88);
            this.DepartamentoComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.DepartamentoComboBox.Name = "DepartamentoComboBox";
            this.DepartamentoComboBox.Size = new System.Drawing.Size(285, 24);
            this.DepartamentoComboBox.TabIndex = 99;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 91);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 17);
            this.label8.TabIndex = 98;
            this.label8.Text = "Departamento:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 248);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 85;
            this.label3.Text = "Costo:";
            // 
            // DescripcionTextBox
            // 
            this.DescripcionTextBox.Location = new System.Drawing.Point(117, 205);
            this.DescripcionTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.DescripcionTextBox.Name = "DescripcionTextBox";
            this.DescripcionTextBox.Size = new System.Drawing.Size(285, 22);
            this.DescripcionTextBox.TabIndex = 84;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 208);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 83;
            this.label2.Text = "Descripción:";
            // 
            // ArticuloIdNumericUpDown
            // 
            this.ArticuloIdNumericUpDown.Location = new System.Drawing.Point(117, 44);
            this.ArticuloIdNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.ArticuloIdNumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.ArticuloIdNumericUpDown.Name = "ArticuloIdNumericUpDown";
            this.ArticuloIdNumericUpDown.Size = new System.Drawing.Size(138, 22);
            this.ArticuloIdNumericUpDown.TabIndex = 82;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 81;
            this.label1.Text = "ProductoId:";
            // 
            // Addbutton
            // 
            this.Addbutton.Location = new System.Drawing.Point(423, 89);
            this.Addbutton.Name = "Addbutton";
            this.Addbutton.Size = new System.Drawing.Size(33, 23);
            this.Addbutton.TabIndex = 100;
            this.Addbutton.Text = "+";
            this.Addbutton.UseVisualStyleBackColor = true;
            this.Addbutton.Click += new System.EventHandler(this.Addbutton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(423, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 23);
            this.button1.TabIndex = 103;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProvedorCOmbobox
            // 
            this.ProvedorCOmbobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProvedorCOmbobox.FormattingEnabled = true;
            this.ProvedorCOmbobox.Location = new System.Drawing.Point(117, 168);
            this.ProvedorCOmbobox.Margin = new System.Windows.Forms.Padding(4);
            this.ProvedorCOmbobox.Name = "ProvedorCOmbobox";
            this.ProvedorCOmbobox.Size = new System.Drawing.Size(285, 24);
            this.ProvedorCOmbobox.TabIndex = 102;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 168);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 17);
            this.label9.TabIndex = 101;
            this.label9.Text = "Proveedor:";
            // 
            // tipoButton
            // 
            this.tipoButton.Location = new System.Drawing.Point(423, 130);
            this.tipoButton.Name = "tipoButton";
            this.tipoButton.Size = new System.Drawing.Size(33, 23);
            this.tipoButton.TabIndex = 106;
            this.tipoButton.Text = "+";
            this.tipoButton.UseVisualStyleBackColor = true;
            this.tipoButton.Click += new System.EventHandler(this.tipoButton_Click);
            // 
            // TipoCombox
            // 
            this.TipoCombox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipoCombox.FormattingEnabled = true;
            this.TipoCombox.Location = new System.Drawing.Point(117, 127);
            this.TipoCombox.Margin = new System.Windows.Forms.Padding(4);
            this.TipoCombox.Name = "TipoCombox";
            this.TipoCombox.Size = new System.Drawing.Size(285, 24);
            this.TipoCombox.TabIndex = 105;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 130);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 17);
            this.label10.TabIndex = 104;
            this.label10.Text = "Categoria:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(221, 248);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 17);
            this.label4.TabIndex = 87;
            this.label4.Text = "Precio:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(221, 290);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 17);
            this.label5.TabIndex = 110;
            this.label5.Text = "Fecha:";
            // 
            // FechadateTimePicker
            // 
            this.FechadateTimePicker.Enabled = false;
            this.FechadateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechadateTimePicker.Location = new System.Drawing.Point(281, 287);
            this.FechadateTimePicker.Name = "FechadateTimePicker";
            this.FechadateTimePicker.Size = new System.Drawing.Size(123, 22);
            this.FechadateTimePicker.TabIndex = 111;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::PreyectoFinal.Properties.Resources.images;
            this.pictureBox1.Location = new System.Drawing.Point(411, 199);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(126, 139);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 109;
            this.pictureBox1.TabStop = false;
            // 
            // EliminarButton
            // 
            this.EliminarButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.EliminarButton.Image = global::PreyectoFinal.Properties.Resources.Eliminar;
            this.EliminarButton.Location = new System.Drawing.Point(296, 344);
            this.EliminarButton.Margin = new System.Windows.Forms.Padding(4);
            this.EliminarButton.Name = "EliminarButton";
            this.EliminarButton.Size = new System.Drawing.Size(107, 61);
            this.EliminarButton.TabIndex = 97;
            this.EliminarButton.UseVisualStyleBackColor = true;
            this.EliminarButton.Click += new System.EventHandler(this.EliminarButton_Click);
            // 
            // GuardarButton
            // 
            this.GuardarButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.GuardarButton.Image = global::PreyectoFinal.Properties.Resources.icons8_guardar_48;
            this.GuardarButton.Location = new System.Drawing.Point(155, 344);
            this.GuardarButton.Margin = new System.Windows.Forms.Padding(4);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(100, 61);
            this.GuardarButton.TabIndex = 96;
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // NuevoButton
            // 
            this.NuevoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.NuevoButton.Image = global::PreyectoFinal.Properties.Resources.icons8_nuevo_48;
            this.NuevoButton.Location = new System.Drawing.Point(18, 344);
            this.NuevoButton.Margin = new System.Windows.Forms.Padding(4);
            this.NuevoButton.Name = "NuevoButton";
            this.NuevoButton.Size = new System.Drawing.Size(95, 61);
            this.NuevoButton.TabIndex = 95;
            this.NuevoButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.NuevoButton.UseVisualStyleBackColor = true;
            this.NuevoButton.Click += new System.EventHandler(this.NuevoButton_Click);
            // 
            // BuscarButton
            // 
            this.BuscarButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BuscarButton.Image = global::PreyectoFinal.Properties.Resources.icons8_google_web_search_32;
            this.BuscarButton.Location = new System.Drawing.Point(262, 33);
            this.BuscarButton.Margin = new System.Windows.Forms.Padding(4);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(140, 53);
            this.BuscarButton.TabIndex = 80;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // PreciotextBox
            // 
            this.PreciotextBox.Location = new System.Drawing.Point(281, 245);
            this.PreciotextBox.Margin = new System.Windows.Forms.Padding(4);
            this.PreciotextBox.Name = "PreciotextBox";
            this.PreciotextBox.Size = new System.Drawing.Size(122, 22);
            this.PreciotextBox.TabIndex = 114;
            this.PreciotextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PreciotextBox_KeyPress);
            // 
            // CostotextBox
            // 
            this.CostotextBox.Location = new System.Drawing.Point(117, 243);
            this.CostotextBox.Margin = new System.Windows.Forms.Padding(4);
            this.CostotextBox.Name = "CostotextBox";
            this.CostotextBox.Size = new System.Drawing.Size(96, 22);
            this.CostotextBox.TabIndex = 115;
            this.CostotextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CostotextBox_KeyPress_1);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // CantidadTextBox
            // 
            this.CantidadTextBox.Enabled = false;
            this.CantidadTextBox.Location = new System.Drawing.Point(117, 287);
            this.CantidadTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.CantidadTextBox.Name = "CantidadTextBox";
            this.CantidadTextBox.Size = new System.Drawing.Size(96, 22);
            this.CantidadTextBox.TabIndex = 117;
            this.CantidadTextBox.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 287);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 116;
            this.label6.Text = "Cantidad:";
            // 
            // RArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.BackgroundImage = global::PreyectoFinal.Properties.Resources.william2;
            this.ClientSize = new System.Drawing.Size(549, 418);
            this.Controls.Add(this.CantidadTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CostotextBox);
            this.Controls.Add(this.PreciotextBox);
            this.Controls.Add(this.FechadateTimePicker);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tipoButton);
            this.Controls.Add(this.TipoCombox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ProvedorCOmbobox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Addbutton);
            this.Controls.Add(this.DepartamentoComboBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.EliminarButton);
            this.Controls.Add(this.GuardarButton);
            this.Controls.Add(this.NuevoButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DescripcionTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ArticuloIdNumericUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BuscarButton);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "RArticulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro Articulo";
            ((System.ComponentModel.ISupportInitialize)(this.ArticuloIdNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox DepartamentoComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button EliminarButton;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.Button NuevoButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DescripcionTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown ArticuloIdNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.Button Addbutton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox ProvedorCOmbobox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button tipoButton;
        private System.Windows.Forms.ComboBox TipoCombox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DateTimePicker FechadateTimePicker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox CostotextBox;
        private System.Windows.Forms.TextBox PreciotextBox;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox CantidadTextBox;
        private System.Windows.Forms.Label label6;
    }
}