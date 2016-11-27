namespace FoodManagementsystem
{
    partial class FavouritesList
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
            this.favouriteback = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.favouriteback)).BeginInit();
            this.SuspendLayout();
            // 
            // favouriteback
            // 
            this.favouriteback.AllowUserToAddRows = false;
            this.favouriteback.AllowUserToDeleteRows = false;
            this.favouriteback.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.favouriteback.Location = new System.Drawing.Point(0, 0);
            this.favouriteback.MultiSelect = false;
            this.favouriteback.Name = "favouriteback";
            this.favouriteback.ReadOnly = true;
            this.favouriteback.Size = new System.Drawing.Size(608, 465);
            this.favouriteback.TabIndex = 4;
            this.favouriteback.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.deleteitem_CellContentClick);
            // 
            // FavouritesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 465);
            this.Controls.Add(this.favouriteback);
            this.Name = "FavouritesList";
            this.Text = "FavouritesList";
            ((System.ComponentModel.ISupportInitialize)(this.favouriteback)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView favouriteback;
    }
}