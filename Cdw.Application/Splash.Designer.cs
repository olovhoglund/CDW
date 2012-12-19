namespace Cdw.App
{
    partial class Splash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.loadinglabel = new System.Windows.Forms.Label();
            this.ajaxloader = new System.Windows.Forms.PictureBox();
            this.loadingpanel = new System.Windows.Forms.Panel();
            this.statuspanel = new System.Windows.Forms.Panel();
            this.statuslabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.retrybutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ajaxloader)).BeginInit();
            this.loadingpanel.SuspendLayout();
            this.statuspanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "System Center Configuration Manager";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(11, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(405, 41);
            this.label2.TabIndex = 3;
            this.label2.Text = "Computer Deployment Wizard";
            // 
            // loadinglabel
            // 
            this.loadinglabel.AutoSize = true;
            this.loadinglabel.Font = new System.Drawing.Font("Segoe UI Light", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadinglabel.Location = new System.Drawing.Point(70, 37);
            this.loadinglabel.Name = "loadinglabel";
            this.loadinglabel.Size = new System.Drawing.Size(241, 31);
            this.loadinglabel.TabIndex = 4;
            this.loadinglabel.Text = "downloading settings ...";
            // 
            // ajaxloader
            // 
            this.ajaxloader.Image = ((System.Drawing.Image)(resources.GetObject("ajaxloader.Image")));
            this.ajaxloader.InitialImage = ((System.Drawing.Image)(resources.GetObject("ajaxloader.InitialImage")));
            this.ajaxloader.Location = new System.Drawing.Point(19, 29);
            this.ajaxloader.Name = "ajaxloader";
            this.ajaxloader.Size = new System.Drawing.Size(48, 48);
            this.ajaxloader.TabIndex = 5;
            this.ajaxloader.TabStop = false;
            // 
            // loadingpanel
            // 
            this.loadingpanel.Controls.Add(this.loadinglabel);
            this.loadingpanel.Controls.Add(this.ajaxloader);
            this.loadingpanel.Location = new System.Drawing.Point(148, 95);
            this.loadingpanel.Name = "loadingpanel";
            this.loadingpanel.Size = new System.Drawing.Size(325, 100);
            this.loadingpanel.TabIndex = 6;
            // 
            // statuspanel
            // 
            this.statuspanel.Controls.Add(this.statuslabel);
            this.statuspanel.Controls.Add(this.label4);
            this.statuspanel.Location = new System.Drawing.Point(121, 202);
            this.statuspanel.Name = "statuspanel";
            this.statuspanel.Size = new System.Drawing.Size(401, 114);
            this.statuspanel.TabIndex = 7;
            // 
            // statuslabel
            // 
            this.statuslabel.AutoSize = true;
            this.statuslabel.Location = new System.Drawing.Point(13, 27);
            this.statuslabel.Name = "statuslabel";
            this.statuslabel.Size = new System.Drawing.Size(0, 13);
            this.statuslabel.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(9, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "ERROR DESCRIPTION";
            // 
            // retrybutton
            // 
            this.retrybutton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.retrybutton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.retrybutton.Location = new System.Drawing.Point(508, 345);
            this.retrybutton.Name = "retrybutton";
            this.retrybutton.Size = new System.Drawing.Size(111, 33);
            this.retrybutton.TabIndex = 7;
            this.retrybutton.Text = "RETRY";
            this.retrybutton.UseVisualStyleBackColor = false;
            this.retrybutton.Click += new System.EventHandler(this.retrybutton_Click);
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(631, 390);
            this.Controls.Add(this.statuspanel);
            this.Controls.Add(this.retrybutton);
            this.Controls.Add(this.loadingpanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Splash";
            this.Text = "Splash";
            this.Load += new System.EventHandler(this.Splash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ajaxloader)).EndInit();
            this.loadingpanel.ResumeLayout(false);
            this.loadingpanel.PerformLayout();
            this.statuspanel.ResumeLayout(false);
            this.statuspanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label loadinglabel;
        private System.Windows.Forms.PictureBox ajaxloader;
        private System.Windows.Forms.Panel loadingpanel;
        private System.Windows.Forms.Panel statuspanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label statuslabel;
        private System.Windows.Forms.Button retrybutton;
    }
}