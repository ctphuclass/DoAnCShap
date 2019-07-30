namespace CaroClient
{
    partial class frmCaroRoom
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbUser1 = new System.Windows.Forms.GroupBox();
            this.gbUser2 = new System.Windows.Forms.GroupBox();
            this.btStart = new System.Windows.Forms.Button();
            this.btReady = new System.Windows.Forms.Button();
            this.pnBoard = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvGameViewer = new System.Windows.Forms.ListView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btReady);
            this.panel1.Controls.Add(this.btStart);
            this.panel1.Controls.Add(this.gbUser2);
            this.panel1.Controls.Add(this.gbUser1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(252, 598);
            this.panel1.TabIndex = 0;
            // 
            // gbUser1
            // 
            this.gbUser1.Location = new System.Drawing.Point(12, 12);
            this.gbUser1.Name = "gbUser1";
            this.gbUser1.Size = new System.Drawing.Size(227, 210);
            this.gbUser1.TabIndex = 0;
            this.gbUser1.TabStop = false;
            this.gbUser1.Text = "UserName1";
            // 
            // gbUser2
            // 
            this.gbUser2.Location = new System.Drawing.Point(12, 376);
            this.gbUser2.Name = "gbUser2";
            this.gbUser2.Size = new System.Drawing.Size(227, 210);
            this.gbUser2.TabIndex = 0;
            this.gbUser2.TabStop = false;
            this.gbUser2.Text = "UserName2";
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(14, 236);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(108, 41);
            this.btStart.TabIndex = 1;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            // 
            // btReady
            // 
            this.btReady.Location = new System.Drawing.Point(131, 236);
            this.btReady.Name = "btReady";
            this.btReady.Size = new System.Drawing.Size(108, 41);
            this.btReady.TabIndex = 2;
            this.btReady.Text = "Ready";
            this.btReady.UseVisualStyleBackColor = true;
            // 
            // pnBoard
            // 
            this.pnBoard.BackColor = System.Drawing.Color.White;
            this.pnBoard.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnBoard.Location = new System.Drawing.Point(252, 0);
            this.pnBoard.Name = "pnBoard";
            this.pnBoard.Size = new System.Drawing.Size(598, 598);
            this.pnBoard.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lvGameViewer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(850, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(263, 598);
            this.panel2.TabIndex = 2;
            // 
            // lvGameViewer
            // 
            this.lvGameViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvGameViewer.Location = new System.Drawing.Point(0, 0);
            this.lvGameViewer.Name = "lvGameViewer";
            this.lvGameViewer.Size = new System.Drawing.Size(263, 598);
            this.lvGameViewer.TabIndex = 0;
            this.lvGameViewer.UseCompatibleStateImageBehavior = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmCaroRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 598);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnBoard);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCaroRoom";
            this.ShowInTaskbar = false;
            this.Text = "frmCaroRoom";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btReady;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.GroupBox gbUser2;
        private System.Windows.Forms.GroupBox gbUser1;
        private System.Windows.Forms.Panel pnBoard;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lvGameViewer;
        private System.Windows.Forms.Timer timer1;
    }
}