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
            this.SuspendLayout();
            // 
            // glViewer
            // 
            this.glViewer.BackColor = System.Drawing.Color.Black;
            this.glViewer.Location = new System.Drawing.Point(-3, -3);
            this.glViewer.Name = "glViewer";
            this.glViewer.Size = new System.Drawing.Size(759, 545);
            this.glViewer.TabIndex = 0;
            this.glViewer.VSync = false;
            // 
            // Canvas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 542);
            this.Controls.Add(this.glViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Canvas";
            this.Text = "pure.zlo_2";
            this.ResumeLayout(false);

        }

        #endregion

        private OpenTK.GLControl glViewer;
    }
}

