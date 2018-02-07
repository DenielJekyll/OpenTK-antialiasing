namespace pure.zlo_2
{
    partial class Canvas
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Canvas));
            this.glViewer = new OpenTK.GLControl();
            this.dashbord = new System.Windows.Forms.Panel();
            this.color_button = new System.Windows.Forms.Button();
            this.textureChoose_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.currentId_comboBox = new System.Windows.Forms.ComboBox();
            this.XOR_radioButton = new System.Windows.Forms.RadioButton();
            this.notXOR_radioButton = new System.Windows.Forms.RadioButton();
            this.noLogic_radioButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.color_checkBox = new System.Windows.Forms.CheckBox();
            this.rastr_checkBox = new System.Windows.Forms.CheckBox();
            this.borders_checkBox = new System.Windows.Forms.CheckBox();
            this.cellSize_lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cellSize_trackBar = new System.Windows.Forms.TrackBar();
            this.dashbord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cellSize_trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // glViewer
            // 
            this.glViewer.BackColor = System.Drawing.Color.Black;
            this.glViewer.Location = new System.Drawing.Point(-3, -3);
            this.glViewer.Name = "glViewer";
            this.glViewer.Size = new System.Drawing.Size(801, 545);
            this.glViewer.TabIndex = 0;
            this.glViewer.VSync = false;
            this.glViewer.Load += new System.EventHandler(this.glViewer_Load);
            this.glViewer.Paint += new System.Windows.Forms.PaintEventHandler(this.glViewer_Paint);
            this.glViewer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glViewer_MouseDown);
            this.glViewer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glViewer_MouseMove);
            this.glViewer.Resize += new System.EventHandler(this.glViewer_Resize);
            // 
            // dashbord
            // 
            this.dashbord.Controls.Add(this.color_button);
            this.dashbord.Controls.Add(this.textureChoose_button);
            this.dashbord.Controls.Add(this.label3);
            this.dashbord.Controls.Add(this.currentId_comboBox);
            this.dashbord.Controls.Add(this.XOR_radioButton);
            this.dashbord.Controls.Add(this.notXOR_radioButton);
            this.dashbord.Controls.Add(this.noLogic_radioButton);
            this.dashbord.Controls.Add(this.label2);
            this.dashbord.Controls.Add(this.color_checkBox);
            this.dashbord.Controls.Add(this.rastr_checkBox);
            this.dashbord.Controls.Add(this.borders_checkBox);
            this.dashbord.Controls.Add(this.cellSize_lbl);
            this.dashbord.Controls.Add(this.label1);
            this.dashbord.Controls.Add(this.cellSize_trackBar);
            this.dashbord.Location = new System.Drawing.Point(797, -3);
            this.dashbord.Name = "dashbord";
            this.dashbord.Size = new System.Drawing.Size(196, 556);
            this.dashbord.TabIndex = 1;
            // 
            // color_button
            // 
            this.color_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.color_button.Location = new System.Drawing.Point(3, 480);
            this.color_button.Name = "color_button";
            this.color_button.Size = new System.Drawing.Size(98, 23);
            this.color_button.TabIndex = 14;
            this.color_button.Text = "Color";
            this.color_button.UseVisualStyleBackColor = true;
            this.color_button.Click += new System.EventHandler(this.color_button_Click);
            // 
            // textureChoose_button
            // 
            this.textureChoose_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.textureChoose_button.Location = new System.Drawing.Point(107, 480);
            this.textureChoose_button.Name = "textureChoose_button";
            this.textureChoose_button.Size = new System.Drawing.Size(86, 23);
            this.textureChoose_button.TabIndex = 13;
            this.textureChoose_button.Text = "Texture";
            this.textureChoose_button.UseVisualStyleBackColor = true;
            this.textureChoose_button.Click += new System.EventHandler(this.textureChoose_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 518);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Current figure:";
            // 
            // currentId_comboBox
            // 
            this.currentId_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.currentId_comboBox.FormattingEnabled = true;
            this.currentId_comboBox.Location = new System.Drawing.Point(76, 515);
            this.currentId_comboBox.Name = "currentId_comboBox";
            this.currentId_comboBox.Size = new System.Drawing.Size(117, 21);
            this.currentId_comboBox.TabIndex = 11;
            // 
            // XOR_radioButton
            // 
            this.XOR_radioButton.AutoSize = true;
            this.XOR_radioButton.Location = new System.Drawing.Point(91, 5);
            this.XOR_radioButton.Name = "XOR_radioButton";
            this.XOR_radioButton.Size = new System.Drawing.Size(48, 17);
            this.XOR_radioButton.TabIndex = 10;
            this.XOR_radioButton.Tag = "1";
            this.XOR_radioButton.Text = "XOR";
            this.XOR_radioButton.UseVisualStyleBackColor = true;
            this.XOR_radioButton.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // notXOR_radioButton
            // 
            this.notXOR_radioButton.AutoSize = true;
            this.notXOR_radioButton.Location = new System.Drawing.Point(139, 5);
            this.notXOR_radioButton.Name = "notXOR_radioButton";
            this.notXOR_radioButton.Size = new System.Drawing.Size(51, 17);
            this.notXOR_radioButton.TabIndex = 9;
            this.notXOR_radioButton.Tag = "2";
            this.notXOR_radioButton.Text = "!XOR";
            this.notXOR_radioButton.UseVisualStyleBackColor = true;
            this.notXOR_radioButton.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // noLogic_radioButton
            // 
            this.noLogic_radioButton.AutoSize = true;
            this.noLogic_radioButton.Checked = true;
            this.noLogic_radioButton.Location = new System.Drawing.Point(51, 5);
            this.noLogic_radioButton.Name = "noLogic_radioButton";
            this.noLogic_radioButton.Size = new System.Drawing.Size(41, 17);
            this.noLogic_radioButton.TabIndex = 8;
            this.noLogic_radioButton.TabStop = true;
            this.noLogic_radioButton.Tag = "0";
            this.noLogic_radioButton.Text = "NO";
            this.noLogic_radioButton.UseVisualStyleBackColor = true;
            this.noLogic_radioButton.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.7F);
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mode:";
            // 
            // color_checkBox
            // 
            this.color_checkBox.AutoSize = true;
            this.color_checkBox.Location = new System.Drawing.Point(76, 35);
            this.color_checkBox.Name = "color_checkBox";
            this.color_checkBox.Size = new System.Drawing.Size(50, 17);
            this.color_checkBox.TabIndex = 5;
            this.color_checkBox.Tag = "2";
            this.color_checkBox.Text = "Color";
            this.color_checkBox.UseVisualStyleBackColor = true;
            this.color_checkBox.CheckedChanged += new System.EventHandler(this.checkBoxChanged);
            // 
            // rastr_checkBox
            // 
            this.rastr_checkBox.AutoSize = true;
            this.rastr_checkBox.Location = new System.Drawing.Point(132, 35);
            this.rastr_checkBox.Name = "rastr_checkBox";
            this.rastr_checkBox.Size = new System.Drawing.Size(51, 17);
            this.rastr_checkBox.TabIndex = 4;
            this.rastr_checkBox.Tag = "1";
            this.rastr_checkBox.Text = "Rastr";
            this.rastr_checkBox.UseVisualStyleBackColor = true;
            this.rastr_checkBox.CheckedChanged += new System.EventHandler(this.checkBoxChanged);
            // 
            // borders_checkBox
            // 
            this.borders_checkBox.AutoSize = true;
            this.borders_checkBox.Location = new System.Drawing.Point(8, 35);
            this.borders_checkBox.Name = "borders_checkBox";
            this.borders_checkBox.Size = new System.Drawing.Size(62, 17);
            this.borders_checkBox.TabIndex = 3;
            this.borders_checkBox.Tag = "0";
            this.borders_checkBox.Text = "Borders";
            this.borders_checkBox.UseVisualStyleBackColor = true;
            this.borders_checkBox.CheckedChanged += new System.EventHandler(this.checkBoxChanged);
            // 
            // cellSize_lbl
            // 
            this.cellSize_lbl.AutoSize = true;
            this.cellSize_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.7F);
            this.cellSize_lbl.Location = new System.Drawing.Point(56, 66);
            this.cellSize_lbl.Name = "cellSize_lbl";
            this.cellSize_lbl.Size = new System.Drawing.Size(14, 15);
            this.cellSize_lbl.TabIndex = 2;
            this.cellSize_lbl.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.7F);
            this.label1.Location = new System.Drawing.Point(3, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cell size:";
            // 
            // cellSize_trackBar
            // 
            this.cellSize_trackBar.LargeChange = 1;
            this.cellSize_trackBar.Location = new System.Drawing.Point(0, 84);
            this.cellSize_trackBar.Maximum = 30;
            this.cellSize_trackBar.Minimum = 5;
            this.cellSize_trackBar.Name = "cellSize_trackBar";
            this.cellSize_trackBar.Size = new System.Drawing.Size(196, 45);
            this.cellSize_trackBar.TabIndex = 0;
            this.cellSize_trackBar.Value = 5;
            this.cellSize_trackBar.Scroll += new System.EventHandler(this.cellSize_trackBar_Scroll);
            // 
            // Canvas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(992, 542);
            this.Controls.Add(this.dashbord);
            this.Controls.Add(this.glViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Canvas";
            this.Text = "pure.zlo_2";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Canvas_KeyDown);
            this.dashbord.ResumeLayout(false);
            this.dashbord.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cellSize_trackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OpenTK.GLControl glViewer;
        private System.Windows.Forms.Panel dashbord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox color_checkBox;
        private System.Windows.Forms.CheckBox rastr_checkBox;
        private System.Windows.Forms.CheckBox borders_checkBox;
        private System.Windows.Forms.Label cellSize_lbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar cellSize_trackBar;
        private System.Windows.Forms.RadioButton XOR_radioButton;
        private System.Windows.Forms.RadioButton notXOR_radioButton;
        private System.Windows.Forms.RadioButton noLogic_radioButton;
        private System.Windows.Forms.Button color_button;
        private System.Windows.Forms.Button textureChoose_button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox currentId_comboBox;
    }
}

