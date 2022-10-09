namespace Game
{
    partial class RenderForm
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
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.screen = new Game.Viewport();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // screen
            // 
            this.screen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.screen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screen.Location = new System.Drawing.Point(0, 0);
            this.screen.Name = "screen";
            this.screen.Size = new System.Drawing.Size(493, 438);
            this.screen.TabIndex = 0;
            this.screen.Paint += new System.Windows.Forms.PaintEventHandler(this.screen_Paint);
            this.screen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.screen_MouseDown);
            // 
            // RenderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 438);
            this.Controls.Add(this.screen);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RenderForm";
            this.ShowIcon = false;
            this.Text = "Game";
            this.Load += new System.EventHandler(this.RenderForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Viewport screen;
        private System.Windows.Forms.Timer timer;
    }
}

