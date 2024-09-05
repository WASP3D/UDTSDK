using System.Windows.Forms;

namespace UDTUpdate
{
    partial class ctrlUdtUpdate
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
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.btnUpdateCategory = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageCategory = new System.Windows.Forms.TabPage();
            this.cmbBoxCategory = new System.Windows.Forms.ComboBox();
            this.txtBoxTextCategory = new System.Windows.Forms.TextBox();
            this.lblSelectCategoryName = new System.Windows.Forms.Label();
            this.lblTextCategory = new System.Windows.Forms.Label();
            this.btnDeleteCategory = new System.Windows.Forms.Button();
            this.tabPageData = new System.Windows.Forms.TabPage();
            this.cmbBoxData = new System.Windows.Forms.ComboBox();
            this.btnDeleteData = new System.Windows.Forms.Button();
            this.btnUpdateData = new System.Windows.Forms.Button();
            this.btnAddData = new System.Windows.Forms.Button();
            this.txtBoxTextData = new System.Windows.Forms.TextBox();
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.lblCatgoryNameData = new System.Windows.Forms.Label();
            this.lblSelectNameData = new System.Windows.Forms.Label();
            this.lblTextData = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabPageCategory.SuspendLayout();
            this.tabPageData.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCategory.Location = new System.Drawing.Point(12, 124);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(139, 31);
            this.btnAddCategory.TabIndex = 1;
            this.btnAddCategory.Text = "Add ";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // btnUpdateCategory
            // 
            this.btnUpdateCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateCategory.Location = new System.Drawing.Point(208, 124);
            this.btnUpdateCategory.Name = "btnUpdateCategory";
            this.btnUpdateCategory.Size = new System.Drawing.Size(139, 31);
            this.btnUpdateCategory.TabIndex = 2;
            this.btnUpdateCategory.Text = "Update";
            this.btnUpdateCategory.UseVisualStyleBackColor = true;
            this.btnUpdateCategory.Click += new System.EventHandler(this.btnUpdateCategory_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageCategory);
            this.tabControl.Controls.Add(this.tabPageData);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(545, 207);
            this.tabControl.TabIndex = 12;
            // 
            // tabPageCategory
            // 
            this.tabPageCategory.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageCategory.Controls.Add(this.cmbBoxCategory);
            this.tabPageCategory.Controls.Add(this.txtBoxTextCategory);
            this.tabPageCategory.Controls.Add(this.lblSelectCategoryName);
            this.tabPageCategory.Controls.Add(this.lblTextCategory);
            this.tabPageCategory.Controls.Add(this.btnDeleteCategory);
            this.tabPageCategory.Controls.Add(this.btnUpdateCategory);
            this.tabPageCategory.Controls.Add(this.btnAddCategory);
            this.tabPageCategory.Location = new System.Drawing.Point(4, 27);
            this.tabPageCategory.Name = "tabPageCategory";
            this.tabPageCategory.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCategory.Size = new System.Drawing.Size(537, 176);
            this.tabPageCategory.TabIndex = 1;
            this.tabPageCategory.Text = "Category";
            // 
            // cmbBoxCategory
            // 
            this.cmbBoxCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxCategory.FormattingEnabled = true;
            this.cmbBoxCategory.Location = new System.Drawing.Point(166, 16);
            this.cmbBoxCategory.Name = "cmbBoxCategory";
            this.cmbBoxCategory.Size = new System.Drawing.Size(365, 26);
            this.cmbBoxCategory.TabIndex = 8;
            this.cmbBoxCategory.SelectedIndexChanged += new System.EventHandler(this.cmbBoxCategory_SelectedIndexChanged);
            // 
            // txtBoxTextCategory
            // 
            this.txtBoxTextCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxTextCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxTextCategory.Location = new System.Drawing.Point(166, 53);
            this.txtBoxTextCategory.Name = "txtBoxTextCategory";
            this.txtBoxTextCategory.Size = new System.Drawing.Size(365, 24);
            this.txtBoxTextCategory.TabIndex = 3;
            // 
            // lblSelectCategoryName
            // 
            this.lblSelectCategoryName.AutoSize = true;
            this.lblSelectCategoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectCategoryName.Location = new System.Drawing.Point(16, 19);
            this.lblSelectCategoryName.Name = "lblSelectCategoryName";
            this.lblSelectCategoryName.Size = new System.Drawing.Size(128, 18);
            this.lblSelectCategoryName.TabIndex = 3;
            this.lblSelectCategoryName.Text = "Select Category";
            // 
            // lblTextCategory
            // 
            this.lblTextCategory.AutoSize = true;
            this.lblTextCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextCategory.Location = new System.Drawing.Point(16, 53);
            this.lblTextCategory.Name = "lblTextCategory";
            this.lblTextCategory.Size = new System.Drawing.Size(40, 18);
            this.lblTextCategory.TabIndex = 3;
            this.lblTextCategory.Text = "Text";
            this.lblTextCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCategory.Location = new System.Drawing.Point(392, 124);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(139, 31);
            this.btnDeleteCategory.TabIndex = 7;
            this.btnDeleteCategory.Text = "Delete";
            this.btnDeleteCategory.UseVisualStyleBackColor = true;
            this.btnDeleteCategory.Click += new System.EventHandler(this.btnDeleteCategory_Click);
            // 
            // tabPageData
            // 
            this.tabPageData.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageData.Controls.Add(this.cmbBoxData);
            this.tabPageData.Controls.Add(this.btnDeleteData);
            this.tabPageData.Controls.Add(this.btnUpdateData);
            this.tabPageData.Controls.Add(this.btnAddData);
            this.tabPageData.Controls.Add(this.txtBoxTextData);
            this.tabPageData.Controls.Add(this.lblCategoryName);
            this.tabPageData.Controls.Add(this.lblCatgoryNameData);
            this.tabPageData.Controls.Add(this.lblSelectNameData);
            this.tabPageData.Controls.Add(this.lblTextData);
            this.tabPageData.Location = new System.Drawing.Point(4, 27);
            this.tabPageData.Name = "tabPageData";
            this.tabPageData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageData.Size = new System.Drawing.Size(537, 176);
            this.tabPageData.TabIndex = 2;
            this.tabPageData.Text = "Data";
            // 
            // cmbBoxData
            // 
            this.cmbBoxData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxData.FormattingEnabled = true;
            this.cmbBoxData.Location = new System.Drawing.Point(142, 50);
            this.cmbBoxData.Name = "cmbBoxData";
            this.cmbBoxData.Size = new System.Drawing.Size(389, 26);
            this.cmbBoxData.TabIndex = 7;
            this.cmbBoxData.SelectedIndexChanged += new System.EventHandler(this.cmbBoxData_SelectedIndexChanged);
            // 
            // btnDeleteData
            // 
            this.btnDeleteData.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteData.Location = new System.Drawing.Point(394, 139);
            this.btnDeleteData.Name = "btnDeleteData";
            this.btnDeleteData.Size = new System.Drawing.Size(139, 31);
            this.btnDeleteData.TabIndex = 3;
            this.btnDeleteData.Text = "Delete";
            this.btnDeleteData.Click += new System.EventHandler(this.btnDeleteData_Click);
            // 
            // btnUpdateData
            // 
            this.btnUpdateData.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateData.Location = new System.Drawing.Point(214, 139);
            this.btnUpdateData.Name = "btnUpdateData";
            this.btnUpdateData.Size = new System.Drawing.Size(142, 31);
            this.btnUpdateData.TabIndex = 6;
            this.btnUpdateData.Text = "Update";
            this.btnUpdateData.Click += new System.EventHandler(this.btnUpdateData_Click);
            // 
            // btnAddData
            // 
            this.btnAddData.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddData.Location = new System.Drawing.Point(20, 139);
            this.btnAddData.Name = "btnAddData";
            this.btnAddData.Size = new System.Drawing.Size(155, 31);
            this.btnAddData.TabIndex = 5;
            this.btnAddData.Text = "Add";
            this.btnAddData.Click += new System.EventHandler(this.btnAddData_Click);
            // 
            // txtBoxTextData
            // 
            this.txtBoxTextData.Location = new System.Drawing.Point(142, 97);
            this.txtBoxTextData.Name = "txtBoxTextData";
            this.txtBoxTextData.Size = new System.Drawing.Size(389, 24);
            this.txtBoxTextData.TabIndex = 2;
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoryName.Location = new System.Drawing.Point(177, 11);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(0, 20);
            this.lblCategoryName.TabIndex = 0;
            // 
            // lblCatgoryNameData
            // 
            this.lblCatgoryNameData.AutoSize = true;
            this.lblCatgoryNameData.Location = new System.Drawing.Point(17, 11);
            this.lblCatgoryNameData.Name = "lblCatgoryNameData";
            this.lblCatgoryNameData.Size = new System.Drawing.Size(125, 18);
            this.lblCatgoryNameData.TabIndex = 0;
            this.lblCatgoryNameData.Text = "Category Name";
            // 
            // lblSelectNameData
            // 
            this.lblSelectNameData.AutoSize = true;
            this.lblSelectNameData.Location = new System.Drawing.Point(17, 50);
            this.lblSelectNameData.Name = "lblSelectNameData";
            this.lblSelectNameData.Size = new System.Drawing.Size(95, 18);
            this.lblSelectNameData.TabIndex = 0;
            this.lblSelectNameData.Text = "Select Data";
            // 
            // lblTextData
            // 
            this.lblTextData.AutoSize = true;
            this.lblTextData.Location = new System.Drawing.Point(17, 103);
            this.lblTextData.Name = "lblTextData";
            this.lblTextData.Size = new System.Drawing.Size(40, 18);
            this.lblTextData.TabIndex = 0;
            this.lblTextData.Text = "Text";
            // 
            // ctrlUdtUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Name = "ctrlUdtUpdate";
            this.Size = new System.Drawing.Size(545, 207);
            this.tabControl.ResumeLayout(false);
            this.tabPageCategory.ResumeLayout(false);
            this.tabPageCategory.PerformLayout();
            this.tabPageData.ResumeLayout(false);
            this.tabPageData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Button btnUpdateCategory;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageCategory;
        private System.Windows.Forms.TextBox txtBoxTextCategory;
        private System.Windows.Forms.Label lblTextCategory;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.TabPage tabPageData;
        private Button btnDeleteData;
        private Button btnUpdateData;
        private Button btnAddData;
        private System.Windows.Forms.TextBox txtBoxTextData;
        private System.Windows.Forms.Label lblTextData;
        private System.Windows.Forms.ComboBox cmbBoxCategory;
        private System.Windows.Forms.Label lblSelectCategoryName;
        private System.Windows.Forms.ComboBox cmbBoxData;
        private System.Windows.Forms.Label lblSelectNameData;
        private Label lblCategoryName;
        private Label lblCatgoryNameData;
    }
}

