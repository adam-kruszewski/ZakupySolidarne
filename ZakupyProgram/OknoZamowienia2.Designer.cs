namespace ZakupyProgram
{
    partial class OknoZamowienia2
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanelSuma = new System.Windows.Forms.FlowLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanelZamknij = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonZamknij = new System.Windows.Forms.Button();
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanelSuma.SuspendLayout();
            this.flowLayoutPanelZamknij.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanelSuma, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanelZamknij, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.objectListView1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(380, 397);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanelSuma
            // 
            this.flowLayoutPanelSuma.Controls.Add(this.textBox1);
            this.flowLayoutPanelSuma.Controls.Add(this.label1);
            this.flowLayoutPanelSuma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelSuma.Location = new System.Drawing.Point(3, 320);
            this.flowLayoutPanelSuma.Name = "flowLayoutPanelSuma";
            this.flowLayoutPanelSuma.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanelSuma.Size = new System.Drawing.Size(374, 34);
            this.flowLayoutPanelSuma.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(202, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(169, 20);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Wartość zamówienia";
            // 
            // flowLayoutPanelZamknij
            // 
            this.flowLayoutPanelZamknij.Controls.Add(this.buttonZamknij);
            this.flowLayoutPanelZamknij.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelZamknij.Location = new System.Drawing.Point(3, 360);
            this.flowLayoutPanelZamknij.Name = "flowLayoutPanelZamknij";
            this.flowLayoutPanelZamknij.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanelZamknij.Size = new System.Drawing.Size(374, 34);
            this.flowLayoutPanelZamknij.TabIndex = 1;
            // 
            // buttonZamknij
            // 
            this.buttonZamknij.Location = new System.Drawing.Point(296, 3);
            this.buttonZamknij.Name = "buttonZamknij";
            this.buttonZamknij.Size = new System.Drawing.Size(75, 23);
            this.buttonZamknij.TabIndex = 0;
            this.buttonZamknij.Text = "&Zamknij";
            this.buttonZamknij.UseVisualStyleBackColor = true;
            this.buttonZamknij.Click += new System.EventHandler(this.buttonZamknij_Click);
            // 
            // objectListView1
            // 
            this.objectListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListView1.FullRowSelect = true;
            this.objectListView1.IsSearchOnSortColumn = false;
            this.objectListView1.Location = new System.Drawing.Point(3, 3);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.ShowSortIndicators = false;
            this.objectListView1.Size = new System.Drawing.Size(374, 311);
            this.objectListView1.SortGroupItemsByPrimaryColumn = false;
            this.objectListView1.TabIndex = 2;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "Cena";
            this.olvColumn4.DisplayIndex = 3;
            this.olvColumn4.Text = "Cena";
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "Nazwa";
            this.olvColumn3.DisplayIndex = 2;
            this.olvColumn3.Text = "Nazwa";
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "Napis2";
            this.olvColumn2.DisplayIndex = 1;
            this.olvColumn2.Text = "Napis 2";
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Napis";
            this.olvColumn1.DisplayIndex = 0;
            this.olvColumn1.Groupable = false;
            this.olvColumn1.Text = "Nagłówek";
            // 
            // OknoZamowienia2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 397);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "OknoZamowienia2";
            this.Text = "OknoZamowienia2";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanelSuma.ResumeLayout(false);
            this.flowLayoutPanelSuma.PerformLayout();
            this.flowLayoutPanelZamknij.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSuma;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelZamknij;
        private System.Windows.Forms.Button buttonZamknij;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private BrightIdeasSoftware.ObjectListView objectListView1;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
    }
}