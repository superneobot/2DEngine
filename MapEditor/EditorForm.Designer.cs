namespace MapEditor
{
    partial class EditorForm
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
            this.left_panel = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tiles_page = new System.Windows.Forms.TabPage();
            this.objects_page = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.preview_tile = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tile = new System.Windows.Forms.Panel();
            this.top_panel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.clear_btn = new System.Windows.Forms.Button();
            this.save_btn = new System.Windows.Forms.Button();
            this.load_btn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.addPlayerStart = new System.Windows.Forms.Button();
            this.addExit = new System.Windows.Forms.Button();
            this.addBlock = new System.Windows.Forms.Button();
            this.addEnemy = new System.Windows.Forms.Button();
            this.addManaBottle = new System.Windows.Forms.Button();
            this.addHealthBottle = new System.Windows.Forms.Button();
            this.screen = new Game.Viewport();
            this.panel = new Game.Viewport();
            this.left_panel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tiles_page.SuspendLayout();
            this.objects_page.SuspendLayout();
            this.top_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // left_panel
            // 
            this.left_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.left_panel.Controls.Add(this.tabControl1);
            this.left_panel.Controls.Add(this.label2);
            this.left_panel.Controls.Add(this.preview_tile);
            this.left_panel.Controls.Add(this.label1);
            this.left_panel.Controls.Add(this.tile);
            this.left_panel.Controls.Add(this.top_panel);
            this.left_panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.left_panel.Location = new System.Drawing.Point(0, 0);
            this.left_panel.Name = "left_panel";
            this.left_panel.Size = new System.Drawing.Size(274, 1041);
            this.left_panel.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tiles_page);
            this.tabControl1.Controls.Add(this.objects_page);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 72);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(272, 712);
            this.tabControl1.TabIndex = 7;
            // 
            // tiles_page
            // 
            this.tiles_page.Controls.Add(this.panel);
            this.tiles_page.Location = new System.Drawing.Point(4, 22);
            this.tiles_page.Name = "tiles_page";
            this.tiles_page.Padding = new System.Windows.Forms.Padding(3);
            this.tiles_page.Size = new System.Drawing.Size(264, 686);
            this.tiles_page.TabIndex = 0;
            this.tiles_page.Text = "Tiles";
            this.tiles_page.UseVisualStyleBackColor = true;
            // 
            // objects_page
            // 
            this.objects_page.Controls.Add(this.label8);
            this.objects_page.Controls.Add(this.addPlayerStart);
            this.objects_page.Controls.Add(this.label7);
            this.objects_page.Controls.Add(this.label6);
            this.objects_page.Controls.Add(this.label5);
            this.objects_page.Controls.Add(this.label4);
            this.objects_page.Controls.Add(this.label3);
            this.objects_page.Controls.Add(this.addExit);
            this.objects_page.Controls.Add(this.addBlock);
            this.objects_page.Controls.Add(this.addEnemy);
            this.objects_page.Controls.Add(this.addManaBottle);
            this.objects_page.Controls.Add(this.addHealthBottle);
            this.objects_page.Location = new System.Drawing.Point(4, 22);
            this.objects_page.Name = "objects_page";
            this.objects_page.Padding = new System.Windows.Forms.Padding(3);
            this.objects_page.Size = new System.Drawing.Size(264, 686);
            this.objects_page.TabIndex = 1;
            this.objects_page.Text = "Objects";
            this.objects_page.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Exit";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Block";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Enemy";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Mana bottle";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Health bottle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 837);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Preview";
            // 
            // preview_tile
            // 
            this.preview_tile.Location = new System.Drawing.Point(11, 828);
            this.preview_tile.Name = "preview_tile";
            this.preview_tile.Size = new System.Drawing.Size(32, 32);
            this.preview_tile.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 799);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Selected tile";
            // 
            // tile
            // 
            this.tile.Location = new System.Drawing.Point(11, 790);
            this.tile.Name = "tile";
            this.tile.Size = new System.Drawing.Size(32, 32);
            this.tile.TabIndex = 3;
            // 
            // top_panel
            // 
            this.top_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.top_panel.Controls.Add(this.button1);
            this.top_panel.Controls.Add(this.clear_btn);
            this.top_panel.Controls.Add(this.save_btn);
            this.top_panel.Controls.Add(this.load_btn);
            this.top_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_panel.Location = new System.Drawing.Point(0, 0);
            this.top_panel.Name = "top_panel";
            this.top_panel.Size = new System.Drawing.Size(272, 72);
            this.top_panel.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Load tiles";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // clear_btn
            // 
            this.clear_btn.Location = new System.Drawing.Point(172, 10);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.Size = new System.Drawing.Size(75, 23);
            this.clear_btn.TabIndex = 2;
            this.clear_btn.Text = "Clear";
            this.clear_btn.UseVisualStyleBackColor = true;
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(91, 10);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(75, 23);
            this.save_btn.TabIndex = 1;
            this.save_btn.Text = "Save";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // load_btn
            // 
            this.load_btn.Location = new System.Drawing.Point(10, 10);
            this.load_btn.Name = "load_btn";
            this.load_btn.Size = new System.Drawing.Size(75, 23);
            this.load_btn.TabIndex = 0;
            this.load_btn.Text = "Load";
            this.load_btn.UseVisualStyleBackColor = true;
            this.load_btn.Click += new System.EventHandler(this.load_btn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(47, 206);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Player start";
            // 
            // addPlayerStart
            // 
            this.addPlayerStart.BackgroundImage = global::MapEditor.Properties.Resources.pl_start;
            this.addPlayerStart.FlatAppearance.BorderSize = 0;
            this.addPlayerStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addPlayerStart.Location = new System.Drawing.Point(7, 196);
            this.addPlayerStart.Name = "addPlayerStart";
            this.addPlayerStart.Size = new System.Drawing.Size(32, 32);
            this.addPlayerStart.TabIndex = 6;
            this.addPlayerStart.UseVisualStyleBackColor = false;
            this.addPlayerStart.Click += new System.EventHandler(this.addPlayerStart_Click);
            // 
            // addExit
            // 
            this.addExit.BackgroundImage = global::MapEditor.Properties.Resources.exit;
            this.addExit.FlatAppearance.BorderSize = 0;
            this.addExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addExit.Location = new System.Drawing.Point(7, 158);
            this.addExit.Name = "addExit";
            this.addExit.Size = new System.Drawing.Size(32, 32);
            this.addExit.TabIndex = 0;
            this.addExit.UseVisualStyleBackColor = false;
            this.addExit.Click += new System.EventHandler(this.addExit_Click);
            // 
            // addBlock
            // 
            this.addBlock.BackgroundImage = global::MapEditor.Properties.Resources.block;
            this.addBlock.FlatAppearance.BorderSize = 0;
            this.addBlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBlock.Location = new System.Drawing.Point(6, 120);
            this.addBlock.Name = "addBlock";
            this.addBlock.Size = new System.Drawing.Size(32, 32);
            this.addBlock.TabIndex = 0;
            this.addBlock.UseVisualStyleBackColor = false;
            this.addBlock.Click += new System.EventHandler(this.addBlock_Click);
            // 
            // addEnemy
            // 
            this.addEnemy.BackgroundImage = global::MapEditor.Properties.Resources.enemy;
            this.addEnemy.FlatAppearance.BorderSize = 0;
            this.addEnemy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addEnemy.Location = new System.Drawing.Point(6, 82);
            this.addEnemy.Name = "addEnemy";
            this.addEnemy.Size = new System.Drawing.Size(32, 32);
            this.addEnemy.TabIndex = 0;
            this.addEnemy.UseVisualStyleBackColor = false;
            this.addEnemy.Click += new System.EventHandler(this.addEnemy_Click);
            // 
            // addManaBottle
            // 
            this.addManaBottle.BackgroundImage = global::MapEditor.Properties.Resources.mana;
            this.addManaBottle.FlatAppearance.BorderSize = 0;
            this.addManaBottle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addManaBottle.Location = new System.Drawing.Point(7, 44);
            this.addManaBottle.Name = "addManaBottle";
            this.addManaBottle.Size = new System.Drawing.Size(32, 32);
            this.addManaBottle.TabIndex = 0;
            this.addManaBottle.UseVisualStyleBackColor = false;
            this.addManaBottle.Click += new System.EventHandler(this.addManaBottle_Click);
            // 
            // addHealthBottle
            // 
            this.addHealthBottle.BackgroundImage = global::MapEditor.Properties.Resources.health;
            this.addHealthBottle.FlatAppearance.BorderSize = 0;
            this.addHealthBottle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addHealthBottle.Location = new System.Drawing.Point(7, 6);
            this.addHealthBottle.Name = "addHealthBottle";
            this.addHealthBottle.Size = new System.Drawing.Size(32, 32);
            this.addHealthBottle.TabIndex = 0;
            this.addHealthBottle.UseVisualStyleBackColor = false;
            this.addHealthBottle.Click += new System.EventHandler(this.addHealthBottle_Click);
            // 
            // screen
            // 
            this.screen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.screen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screen.Location = new System.Drawing.Point(274, 0);
            this.screen.Name = "screen";
            this.screen.Size = new System.Drawing.Size(1300, 1041);
            this.screen.TabIndex = 1;
            this.screen.Paint += new System.Windows.Forms.PaintEventHandler(this.screen_Paint);
            this.screen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.screen_MouseDown);
            this.screen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.screen_MouseMove);
            this.screen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.screen_MouseUp);
            // 
            // panel
            // 
            this.panel.BackgroundImage = global::MapEditor.Properties.Resources.set_1;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel.Location = new System.Drawing.Point(3, 3);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(258, 672);
            this.panel.TabIndex = 3;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            this.panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            this.panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_MouseMove);
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1574, 1041);
            this.Controls.Add(this.screen);
            this.Controls.Add(this.left_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditorForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Map Editor";
            this.Load += new System.EventHandler(this.EditorForm_Load);
            this.left_panel.ResumeLayout(false);
            this.left_panel.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tiles_page.ResumeLayout(false);
            this.objects_page.ResumeLayout(false);
            this.objects_page.PerformLayout();
            this.top_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel left_panel;
        private System.Windows.Forms.Panel top_panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel tile;
        private System.Windows.Forms.Button clear_btn;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button load_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel preview_tile;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tiles_page;
        private Game.Viewport panel;
        private System.Windows.Forms.TabPage objects_page;
        private System.Windows.Forms.Button button1;
        private Game.Viewport screen;
        private System.Windows.Forms.Button addExit;
        private System.Windows.Forms.Button addBlock;
        private System.Windows.Forms.Button addEnemy;
        private System.Windows.Forms.Button addManaBottle;
        private System.Windows.Forms.Button addHealthBottle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button addPlayerStart;
    }                    
}

