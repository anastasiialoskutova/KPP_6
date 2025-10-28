using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            A_matrix_dgv = new DataGridView();
            C_matrix_dgv = new DataGridView();
            B_vector_dgv = new DataGridView();
            X_vector_dgv = new DataGridView();
            BCreateGrid = new Button();
            BClear = new Button();
            BClose = new Button();
            NUD_rozmir = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            comboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)A_matrix_dgv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)C_matrix_dgv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)B_vector_dgv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)X_vector_dgv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_rozmir).BeginInit();
            SuspendLayout();
            // 
            // A_matrix_dgv
            // 
            A_matrix_dgv.AccessibleDescription = "";
            A_matrix_dgv.AccessibleName = "";
            A_matrix_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            A_matrix_dgv.BackgroundColor = Color.FromArgb(255, 192, 255);
            A_matrix_dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            A_matrix_dgv.ColumnHeadersVisible = false;
            A_matrix_dgv.GridColor = Color.DeepPink;
            A_matrix_dgv.Location = new Point(10, 78);
            A_matrix_dgv.Name = "A_matrix_dgv";
            A_matrix_dgv.RowHeadersVisible = false;
            A_matrix_dgv.RowHeadersWidth = 51;
            A_matrix_dgv.Size = new Size(356, 165);
            A_matrix_dgv.TabIndex = 0;
            A_matrix_dgv.CellClick += A_matrix_dgv_CellClick;
            // 
            // C_matrix_dgv
            // 
            C_matrix_dgv.AccessibleName = "";
            C_matrix_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            C_matrix_dgv.BackgroundColor = Color.FromArgb(255, 192, 255);
            C_matrix_dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            C_matrix_dgv.ColumnHeadersVisible = false;
            C_matrix_dgv.GridColor = Color.DeepPink;
            C_matrix_dgv.Location = new Point(10, 269);
            C_matrix_dgv.Name = "C_matrix_dgv";
            C_matrix_dgv.RowHeadersVisible = false;
            C_matrix_dgv.RowHeadersWidth = 51;
            C_matrix_dgv.Size = new Size(356, 179);
            C_matrix_dgv.TabIndex = 1;
            // 
            // B_vector_dgv
            // 
            B_vector_dgv.AccessibleName = "";
            B_vector_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            B_vector_dgv.BackgroundColor = Color.FromArgb(255, 192, 255);
            B_vector_dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            B_vector_dgv.ColumnHeadersVisible = false;
            B_vector_dgv.GridColor = Color.DeepPink;
            B_vector_dgv.Location = new Point(495, 78);
            B_vector_dgv.Name = "B_vector_dgv";
            B_vector_dgv.RowHeadersVisible = false;
            B_vector_dgv.RowHeadersWidth = 51;
            B_vector_dgv.Size = new Size(129, 301);
            B_vector_dgv.TabIndex = 2;
            B_vector_dgv.CellClick += B_vector_dgv_CellClick;
            // 
            // X_vector_dgv
            // 
            X_vector_dgv.AccessibleName = "";
            X_vector_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            X_vector_dgv.BackgroundColor = Color.FromArgb(255, 192, 255);
            X_vector_dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            X_vector_dgv.ColumnHeadersVisible = false;
            X_vector_dgv.GridColor = Color.DeepPink;
            X_vector_dgv.Location = new Point(646, 78);
            X_vector_dgv.Name = "X_vector_dgv";
            X_vector_dgv.ReadOnly = true;
            X_vector_dgv.RowHeadersVisible = false;
            X_vector_dgv.RowHeadersWidth = 51;
            X_vector_dgv.Size = new Size(122, 301);
            X_vector_dgv.TabIndex = 3;
            // 
            // BCreateGrid
            // 
            BCreateGrid.Location = new Point(376, 385);
            BCreateGrid.Name = "BCreateGrid";
            BCreateGrid.Size = new Size(132, 53);
            BCreateGrid.TabIndex = 4;
            BCreateGrid.Text = "Розв'язати";
            BCreateGrid.UseVisualStyleBackColor = true;
            BCreateGrid.Click += BCreateGrid_Click;
            // 
            // BClear
            // 
            BClear.Location = new Point(511, 385);
            BClear.Name = "BClear";
            BClear.Size = new Size(129, 53);
            BClear.TabIndex = 5;
            BClear.Text = "Очистити";
            BClear.UseVisualStyleBackColor = true;
            BClear.Click += BClear_Click;
            // 
            // BClose
            // 
            BClose.Location = new Point(646, 385);
            BClose.Name = "BClose";
            BClose.Size = new Size(137, 53);
            BClose.TabIndex = 6;
            BClose.Text = "Вихід";
            BClose.UseVisualStyleBackColor = true;
            BClose.Click += BClose_Click;
            // 
            // NUD_rozmir
            // 
            NUD_rozmir.Location = new Point(316, 23);
            NUD_rozmir.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            NUD_rozmir.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NUD_rozmir.Name = "NUD_rozmir";
            NUD_rozmir.ReadOnly = true;
            NUD_rozmir.Size = new Size(38, 27);
            NUD_rozmir.TabIndex = 7;
            NUD_rozmir.Value = new decimal(new int[] { 1, 0, 0, 0 });
            NUD_rozmir.ValueChanged += NUD_rozmir_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label1.Location = new Point(53, 23);
            label1.Name = "label1";
            label1.Size = new Size(257, 25);
            label1.TabIndex = 8;
            label1.Text = "Оберіть розмір матриці А";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label2.Location = new Point(20, 55);
            label2.Name = "label2";
            label2.Size = new Size(245, 20);
            label2.TabIndex = 9;
            label2.Text = "Матриця А коефіцієнтів СЛАР";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label3.Location = new Point(9, 246);
            label3.Name = "label3";
            label3.Size = new Size(301, 20);
            label3.TabIndex = 10;
            label3.Text = "Матриця С коефіцієнтів L/U розкладу";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label4.Location = new Point(495, 55);
            label4.Name = "label4";
            label4.Size = new Size(81, 20);
            label4.TabIndex = 11;
            label4.Text = "Вектор В";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label5.Location = new Point(646, 55);
            label5.Name = "label5";
            label5.Size = new Size(81, 20);
            label5.TabIndex = 12;
            label5.Text = "Вектор Х";
            // 
            // comboBox
            // 
            comboBox.FormattingEnabled = true;
            comboBox.Items.AddRange(new object[] { "Метод LU", "Метод Гауса" });
            comboBox.Location = new Point(527, 23);
            comboBox.Name = "comboBox";
            comboBox.Size = new Size(151, 28);
            comboBox.TabIndex = 13;
            comboBox.Text = "Оберіть метод";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(870, 485);
            Controls.Add(comboBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(NUD_rozmir);
            Controls.Add(BClose);
            Controls.Add(BClear);
            Controls.Add(BCreateGrid);
            Controls.Add(X_vector_dgv);
            Controls.Add(B_vector_dgv);
            Controls.Add(C_matrix_dgv);
            Controls.Add(A_matrix_dgv);
            Name = "Form1";
            Text = "ЛАА Метод L/U перетворення для розв'язання СЛАР";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)A_matrix_dgv).EndInit();
            ((System.ComponentModel.ISupportInitialize)C_matrix_dgv).EndInit();
            ((System.ComponentModel.ISupportInitialize)B_vector_dgv).EndInit();
            ((System.ComponentModel.ISupportInitialize)X_vector_dgv).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_rozmir).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView A_matrix_dgv;
        private DataGridView C_matrix_dgv;
        private DataGridView B_vector_dgv;
        private DataGridView X_vector_dgv;
        private Button BCreateGrid;
        private Button BClear;
        private Button BClose;
        private NumericUpDown NUD_rozmir;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox comboBox;
    }
}
