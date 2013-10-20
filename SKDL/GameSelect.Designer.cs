namespace SKDL {
    partial class GameSelect {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameSelect));
            this.lvGames = new System.Windows.Forms.ListView();
            this.btPlay = new System.Windows.Forms.Button();
            this.btLoad = new System.Windows.Forms.Button();
            this.lbStatus = new System.Windows.Forms.Label();
            this.btReferense = new System.Windows.Forms.Button();
            this.btReferencePreview = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvGames
            // 
            this.lvGames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvGames.FullRowSelect = true;
            this.lvGames.Location = new System.Drawing.Point(13, 13);
            this.lvGames.Name = "lvGames";
            this.lvGames.Size = new System.Drawing.Size(438, 520);
            this.lvGames.TabIndex = 0;
            this.lvGames.UseCompatibleStateImageBehavior = false;
            this.lvGames.View = System.Windows.Forms.View.List;
            this.lvGames.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
            // 
            // btPlay
            // 
            this.btPlay.Enabled = false;
            this.btPlay.Location = new System.Drawing.Point(378, 539);
            this.btPlay.Name = "btPlay";
            this.btPlay.Size = new System.Drawing.Size(75, 23);
            this.btPlay.TabIndex = 1;
            this.btPlay.Text = "Play";
            this.btPlay.UseVisualStyleBackColor = true;
            this.btPlay.Click += new System.EventHandler(this.btPlay_Click);
            // 
            // btLoad
            // 
            this.btLoad.Enabled = false;
            this.btLoad.Location = new System.Drawing.Point(13, 540);
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(75, 23);
            this.btLoad.TabIndex = 2;
            this.btLoad.Text = "Load game";
            this.btLoad.UseVisualStyleBackColor = true;
            this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(12, 566);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(37, 13);
            this.lbStatus.TabIndex = 3;
            this.lbStatus.Text = "Status";
            // 
            // btReferense
            // 
            this.btReferense.Enabled = false;
            this.btReferense.Location = new System.Drawing.Point(297, 540);
            this.btReferense.Name = "btReferense";
            this.btReferense.Size = new System.Drawing.Size(75, 23);
            this.btReferense.TabIndex = 4;
            this.btReferense.Text = "Reference";
            this.btReferense.UseVisualStyleBackColor = true;
            this.btReferense.Click += new System.EventHandler(this.btReferense_Click);
            // 
            // btReferencePreview
            // 
            this.btReferencePreview.Enabled = false;
            this.btReferencePreview.Location = new System.Drawing.Point(182, 540);
            this.btReferencePreview.Name = "btReferencePreview";
            this.btReferencePreview.Size = new System.Drawing.Size(109, 23);
            this.btReferencePreview.TabIndex = 5;
            this.btReferencePreview.Text = "ReferencePreview";
            this.btReferencePreview.UseVisualStyleBackColor = true;
            this.btReferencePreview.Click += new System.EventHandler(this.brReferencePreview_Click);
            // 
            // GameSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 586);
            this.Controls.Add(this.btReferencePreview);
            this.Controls.Add(this.btReferense);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.btLoad);
            this.Controls.Add(this.btPlay);
            this.Controls.Add(this.lvGames);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameSelect";
            this.Text = "GameSelect";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvGames;
        private System.Windows.Forms.Button btPlay;
        private System.Windows.Forms.Button btLoad;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Button btReferense;
        private System.Windows.Forms.Button btReferencePreview;
    }
}