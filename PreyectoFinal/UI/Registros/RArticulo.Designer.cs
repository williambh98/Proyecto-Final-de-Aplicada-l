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
            this.EliminarButton = new System.Windows.Forms.Button();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.NuevoButton = new System.Windows.Forms.Button();
            this.CostoTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DescripcionTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ArticuloIdNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.BuscarButton = new System.Windows.Forms.Button();
            this.Addbutton = new System.Windows.Forms.Button();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.ProvedorCOmbobox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tipoButton = new System.Windows.Forms.Button();
            this.TipoCombox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PrecioTextBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cantidad = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ArticuloIdNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // DepartamentoComboBox
            // 
            this.DepartamentoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DepartamentoComboBox.FormattingEnabled = true;
            this.DepartamentoComboBox.Location = new System.Drawing.Point(125, 77);
            this.DepartamentoComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.DepartamentoComboBox.Name = "DepartamentoComboBox";
            this.DepartamentoComboBox.Size = new System.Drawing.Size(285, 24);
            this.DepartamentoComboBox.TabIndex = 99;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 80);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 17);
            this.label8.TabIndex = 98;
            this.label8.Text = "Departamento";
            // 
            // EliminarButton
            // 
            this.EliminarButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.EliminarButton.Location = new System.Drawing.Point(312, 298);
            this.EliminarButton.Margin = new System.Windows.Forms.Padding(4);
            this.EliminarButton.Name = "EliminarButton";
            this.EliminarButton.Size = new System.Drawing.Size(107, 41);
            this.EliminarButton.TabIndex = 97;
            this.EliminarButton.Text = "Eliminar";
            this.EliminarButton.UseVisualStyleBackColor = true;
            this.EliminarButton.Click += new System.EventHandler(this.EliminarButton_Click);
            // 
            // GuardarButton
            // 
            this.GuardarButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.GuardarButton.Location = new System.Drawing.Point(163, 298);
            this.GuardarButton.Margin = new System.Windows.Forms.Padding(4);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(100, 41);
            this.GuardarButton.TabIndex = 96;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // NuevoButton
            // 
            this.NuevoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.NuevoButton.Location = new System.Drawing.Point(31, 298);
            this.NuevoButton.Margin = new System.Windows.Forms.Padding(4);
            this.NuevoButton.Name = "NuevoButton";
            this.NuevoButton.Size = new System.Drawing.Size(97, 41);
            this.NuevoButton.TabIndex = 95;
            this.NuevoButton.Text = "Nuevo";
            this.NuevoButton.UseVisualStyleBackColor = true;
            this.NuevoButton.Click += new System.EventHandler(this.NuevoButton_Click);
            // 
            // CostoTextBox
            // 
            this.CostoTextBox.Location = new System.Drawing.Point(125, 234);
            this.CostoTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.CostoTextBox.Name = "CostoTextBox";
            this.CostoTextBox.Size = new System.Drawing.Size(99, 22);
            this.CostoTextBox.TabIndex = 86;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 237);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 85;
            this.label3.Text = "Costo";
            // 
            // DescripcionTextBox
            // 
            this.DescripcionTextBox.Location = new System.Drawing.Point(125, 194);
            this.DescripcionTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.DescripcionTextBox.Name = "DescripcionTextBox";
            this.DescripcionTextBox.Size = new System.Drawing.Size(285, 22);
            this.DescripcionTextBox.TabIndex = 84;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 197);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 83;
            this.label2.Text = "Descripción";
            // 
            // ArticuloIdNumericUpDown
            // 
            this.ArticuloIdNumericUpDown.Location = new System.Drawing.Point(125, 33);
            this.ArticuloIdNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.ArticuloIdNumericUpDown.Name = "ArticuloIdNumericUpDown";
            this.ArticuloIdNumericUpDown.Size = new System.Drawing.Size(138, 22);
            this.ArticuloIdNumericUpDown.TabIndex = 82;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 81;
            this.label1.Text = "ProductoId";
            // 
            // BuscarButton
            // 
            this.BuscarButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BuscarButton.Location = new System.Drawing.Point(270, 29);
            this.BuscarButton.Margin = new System.Windows.Forms.Padding(4);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(140, 28);
            this.BuscarButton.TabIndex = 80;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // Addbutton
            // 
            this.Addbutton.Location = new System.Drawing.Point(431, 78);
            this.Addbutton.Name = "Addbutton";
            this.Addbutton.Size = new System.Drawing.Size(33, 23);
            this.Addbutton.TabIndex = 100;
            this.Addbutton.Text = "+";
            this.Addbutton.UseVisualStyleBackColor = true;
            this.Addbutton.Click += new System.EventHandler(this.Addbutton_Click);
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(431, 158);
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
            this.ProvedorCOmbobox.Location = new System.Drawing.Point(125, 157);
            this.ProvedorCOmbobox.Margin = new System.Windows.Forms.Padding(4);
            this.ProvedorCOmbobox.Name = "ProvedorCOmbobox";
            this.ProvedorCOmbobox.Size = new System.Drawing.Size(285, 24);
            this.ProvedorCOmbobox.TabIndex = 102;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 157);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 17);
            this.label9.TabIndex = 101;
            this.label9.Text = "Proveedor";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // tipoButton
            // 
            this.tipoButton.Location = new System.Drawing.Point(431, 119);
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
            this.TipoCombox.Location = new System.Drawing.Point(125, 116);
            this.TipoCombox.Margin = new System.Windows.Forms.Padding(4);
            this.TipoCombox.Name = "TipoCombox";
            this.TipoCombox.Size = new System.Drawing.Size(285, 24);
            this.TipoCombox.TabIndex = 105;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 119);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 17);
            this.label10.TabIndex = 104;
            this.label10.Text = "Tipo Articulo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(229, 239);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 87;
            this.label4.Text = "Precio";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // PrecioTextBox
            // 
            this.PrecioTextBox.Location = new System.Drawing.Point(285, 237);
            this.PrecioTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.PrecioTextBox.Name = "PrecioTextBox";
            this.PrecioTextBox.Size = new System.Drawing.Size(125, 22);
            this.PrecioTextBox.TabIndex = 108;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(285, 264);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 22);
            this.textBox1.TabIndex = 110;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // cantidad
            // 
            this.cantidad.AutoSize = true;
            this.cantidad.Location = new System.Drawing.Point(122, 267);
            this.cantidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cantidad.Name = "cantidad";
            this.cantidad.Size = new System.Drawing.Size(150, 17);
            this.cantidad.TabIndex = 109;
            this.cantidad.Text = "Cantidad en inventario";
            // 
            // RArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(472, 388);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cantidad);
            this.Controls.Add(this.PrecioTextBox);
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
            this.Controls.Add(this.CostoTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DescripcionTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ArticuloIdNumericUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BuscarButton);
            this.Name = "RArticulo";
            this.Text = "RArticulo";
            this.Load += new System.EventHandler(this.RArticulo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ArticuloIdNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox DepartamentoComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button EliminarButton;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.Button NuevoButton;
        private System.Windows.Forms.TextBox CostoTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DescripcionTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown ArticuloIdNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.Button Addbutton;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox ProvedorCOmbobox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button tipoButton;
        private System.Windows.Forms.ComboBox TipoCombox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox PrecioTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label cantidad;
    }
}