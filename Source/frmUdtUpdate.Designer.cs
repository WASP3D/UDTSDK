using System.Windows.Forms;

namespace BeeSys.Wasp3D.Utility
{
    partial class frmUdtUpdate
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.btnUpdateCategory = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageCategory = new System.Windows.Forms.TabPage();
            this.cmbBoxCategory = new System.Windows.Forms.ComboBox();
            this.txtBoxDetailsCategory = new System.Windows.Forms.TextBox();
            this.txtBoxTextCategory = new System.Windows.Forms.TextBox();
            this.lblDetailsCategory = new System.Windows.Forms.Label();
            this.lblSelectCategoryName = new System.Windows.Forms.Label();
            this.lblTextCategory = new System.Windows.Forms.Label();
            this.btnDeleteCategory = new System.Windows.Forms.Button();
            this.tabPageData = new System.Windows.Forms.TabPage();
            this.cmbBoxData = new System.Windows.Forms.ComboBox();
            this.btnDeleteData = new System.Windows.Forms.Button();
            this.btnUpdateData = new System.Windows.Forms.Button();
            this.btnAddData = new System.Windows.Forms.Button();
            this.txtBoxDetailsData = new System.Windows.Forms.TextBox();
            this.txtBoxTextData = new System.Windows.Forms.TextBox();
            this.lbDetailsData = new System.Windows.Forms.Label();
            this.lblSelectNameData = new System.Windows.Forms.Label();
            this.lblTextData = new System.Windows.Forms.Label();
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.lblCatgoryNameData = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabPageCategory.SuspendLayout();
            this.tabPageData.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(191, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(176, 57);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect with KC";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCategory.Location = new System.Drawing.Point(6, 185);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(150, 88);
            this.btnAddCategory.TabIndex = 1;
            this.btnAddCategory.Text = "Add ";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // btnUpdateCategory
            // 
            this.btnUpdateCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateCategory.Location = new System.Drawing.Point(206, 185);
            this.btnUpdateCategory.Name = "btnUpdateCategory";
            this.btnUpdateCategory.Size = new System.Drawing.Size(146, 88);
            this.btnUpdateCategory.TabIndex = 2;
            this.btnUpdateCategory.Text = "Update";
            this.btnUpdateCategory.UseVisualStyleBackColor = true;
            this.btnUpdateCategory.Click += new System.EventHandler(this.btnUpdateCategory_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageCategory);
            this.tabControl.Controls.Add(this.tabPageData);
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(22, 92);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(553, 310);
            this.tabControl.TabIndex = 12;
            // 
            // tabPageCategory
            // 
            this.tabPageCategory.Controls.Add(this.cmbBoxCategory);
            this.tabPageCategory.Controls.Add(this.txtBoxDetailsCategory);
            this.tabPageCategory.Controls.Add(this.txtBoxTextCategory);
            this.tabPageCategory.Controls.Add(this.lblDetailsCategory);
            this.tabPageCategory.Controls.Add(this.lblSelectCategoryName);
            this.tabPageCategory.Controls.Add(this.lblTextCategory);
            this.tabPageCategory.Controls.Add(this.btnDeleteCategory);
            this.tabPageCategory.Controls.Add(this.btnUpdateCategory);
            this.tabPageCategory.Controls.Add(this.btnAddCategory);
            this.tabPageCategory.Location = new System.Drawing.Point(4, 27);
            this.tabPageCategory.Name = "tabPageCategory";
            this.tabPageCategory.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCategory.Size = new System.Drawing.Size(545, 279);
            this.tabPageCategory.TabIndex = 1;
            this.tabPageCategory.Text = "Category";
            this.tabPageCategory.UseVisualStyleBackColor = true;
            // 
            // cmbBoxCategory
            // 
            this.cmbBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxCategory.FormattingEnabled = true;
            this.cmbBoxCategory.Location = new System.Drawing.Point(226, 27);
            this.cmbBoxCategory.Name = "cmbBoxCategory";
            this.cmbBoxCategory.Size = new System.Drawing.Size(248, 26);
            this.cmbBoxCategory.TabIndex = 8;
            this.cmbBoxCategory.SelectedIndexChanged += new System.EventHandler(this.cmbBoxCategory_SelectedIndexChanged);
            // 
            // txtBoxDetailsCategory
            // 
            this.txtBoxDetailsCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxDetailsCategory.Location = new System.Drawing.Point(226, 121);
            this.txtBoxDetailsCategory.Name = "txtBoxDetailsCategory";
            this.txtBoxDetailsCategory.Size = new System.Drawing.Size(248, 24);
            this.txtBoxDetailsCategory.TabIndex = 4;
            // 
            // txtBoxTextCategory
            // 
            this.txtBoxTextCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxTextCategory.Location = new System.Drawing.Point(226, 74);
            this.txtBoxTextCategory.Name = "txtBoxTextCategory";
            this.txtBoxTextCategory.Size = new System.Drawing.Size(248, 24);
            this.txtBoxTextCategory.TabIndex = 3;
            // 
            // lblDetailsCategory
            // 
            this.lblDetailsCategory.AutoSize = true;
            this.lblDetailsCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailsCategory.Location = new System.Drawing.Point(76, 124);
            this.lblDetailsCategory.Name = "lblDetailsCategory";
            this.lblDetailsCategory.Size = new System.Drawing.Size(60, 18);
            this.lblDetailsCategory.TabIndex = 3;
            this.lblDetailsCategory.Text = "Details";
            // 
            // lblSelectCategoryName
            // 
            this.lblSelectCategoryName.AutoSize = true;
            this.lblSelectCategoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectCategoryName.Location = new System.Drawing.Point(76, 30);
            this.lblSelectCategoryName.Name = "lblSelectCategoryName";
            this.lblSelectCategoryName.Size = new System.Drawing.Size(128, 18);
            this.lblSelectCategoryName.TabIndex = 3;
            this.lblSelectCategoryName.Text = "Select Category";
            // 
            // lblTextCategory
            // 
            this.lblTextCategory.AutoSize = true;
            this.lblTextCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextCategory.Location = new System.Drawing.Point(76, 77);
            this.lblTextCategory.Name = "lblTextCategory";
            this.lblTextCategory.Size = new System.Drawing.Size(40, 18);
            this.lblTextCategory.TabIndex = 3;
            this.lblTextCategory.Text = "Text";
            this.lblTextCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCategory.Location = new System.Drawing.Point(393, 185);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(146, 88);
            this.btnDeleteCategory.TabIndex = 7;
            this.btnDeleteCategory.Text = "Delete";
            this.btnDeleteCategory.UseVisualStyleBackColor = true;
            this.btnDeleteCategory.Click += new System.EventHandler(this.btnDeleteCategory_Click);
            // 
            // tabPageData
            // 
            this.tabPageData.Controls.Add(this.cmbBoxData);
            this.tabPageData.Controls.Add(this.btnDeleteData);
            this.tabPageData.Controls.Add(this.btnUpdateData);
            this.tabPageData.Controls.Add(this.btnAddData);
            this.tabPageData.Controls.Add(this.txtBoxDetailsData);
            this.tabPageData.Controls.Add(this.txtBoxTextData);
            this.tabPageData.Controls.Add(this.lbDetailsData);
            this.tabPageData.Controls.Add(this.lblCategoryName);
            this.tabPageData.Controls.Add(this.lblCatgoryNameData);
            this.tabPageData.Controls.Add(this.lblSelectNameData);
            this.tabPageData.Controls.Add(this.lblTextData);
            this.tabPageData.Location = new System.Drawing.Point(4, 27);
            this.tabPageData.Name = "tabPageData";
            this.tabPageData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageData.Size = new System.Drawing.Size(545, 279);
            this.tabPageData.TabIndex = 2;
            this.tabPageData.Text = "Data";
            this.tabPageData.UseVisualStyleBackColor = true;
            // 
            // cmbBoxData
            // 
            this.cmbBoxData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxData.FormattingEnabled = true;
            this.cmbBoxData.Location = new System.Drawing.Point(210, 52);
            this.cmbBoxData.Name = "cmbBoxData";
            this.cmbBoxData.Size = new System.Drawing.Size(226, 26);
            this.cmbBoxData.TabIndex = 7;
            this.cmbBoxData.SelectedIndexChanged += new System.EventHandler(this.cmbBoxData_SelectedIndexChanged);
            // 
            // btnDeleteData
            // 
            this.btnDeleteData.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteData.Location = new System.Drawing.Point(390, 190);
            this.btnDeleteData.Name = "btnDeleteData";
            this.btnDeleteData.Size = new System.Drawing.Size(139, 83);
            this.btnDeleteData.TabIndex = 3;
            this.btnDeleteData.Text = "Delete";
            this.btnDeleteData.Click += new System.EventHandler(this.btnDeleteData_Click);
            // 
            // btnUpdateData
            // 
            this.btnUpdateData.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateData.Location = new System.Drawing.Point(210, 190);
            this.btnUpdateData.Name = "btnUpdateData";
            this.btnUpdateData.Size = new System.Drawing.Size(142, 83);
            this.btnUpdateData.TabIndex = 6;
            this.btnUpdateData.Text = "Update";
            this.btnUpdateData.Click += new System.EventHandler(this.btnUpdateData_Click);
            // 
            // btnAddData
            // 
            this.btnAddData.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddData.Location = new System.Drawing.Point(18, 190);
            this.btnAddData.Name = "btnAddData";
            this.btnAddData.Size = new System.Drawing.Size(155, 83);
            this.btnAddData.TabIndex = 5;
            this.btnAddData.Text = "Add";
            this.btnAddData.Click += new System.EventHandler(this.btnAddData_Click);
            // 
            // txtBoxDetailsData
            // 
            this.txtBoxDetailsData.Location = new System.Drawing.Point(210, 145);
            this.txtBoxDetailsData.Name = "txtBoxDetailsData";
            this.txtBoxDetailsData.Size = new System.Drawing.Size(226, 24);
            this.txtBoxDetailsData.TabIndex = 2;
            // 
            // txtBoxTextData
            // 
            this.txtBoxTextData.Location = new System.Drawing.Point(210, 99);
            this.txtBoxTextData.Name = "txtBoxTextData";
            this.txtBoxTextData.Size = new System.Drawing.Size(226, 24);
            this.txtBoxTextData.TabIndex = 2;
            // 
            // lbDetailsData
            // 
            this.lbDetailsData.AutoSize = true;
            this.lbDetailsData.Location = new System.Drawing.Point(85, 148);
            this.lbDetailsData.Name = "lbDetailsData";
            this.lbDetailsData.Size = new System.Drawing.Size(60, 18);
            this.lbDetailsData.TabIndex = 0;
            this.lbDetailsData.Text = "Details";
            // 
            // lblSelectNameData
            // 
            this.lblSelectNameData.AutoSize = true;
            this.lblSelectNameData.Location = new System.Drawing.Point(85, 52);
            this.lblSelectNameData.Name = "lblSelectNameData";
            this.lblSelectNameData.Size = new System.Drawing.Size(95, 18);
            this.lblSelectNameData.TabIndex = 0;
            this.lblSelectNameData.Text = "Select Data";
            // 
            // lblTextData
            // 
            this.lblTextData.AutoSize = true;
            this.lblTextData.Location = new System.Drawing.Point(85, 105);
            this.lblTextData.Name = "lblTextData";
            this.lblTextData.Size = new System.Drawing.Size(40, 18);
            this.lblTextData.TabIndex = 0;
            this.lblTextData.Text = "Text";
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoryName.Location = new System.Drawing.Point(245, 13);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(0, 20);
            this.lblCategoryName.TabIndex = 0;
            // 
            // lblCatgoryNameData
            // 
            this.lblCatgoryNameData.AutoSize = true;
            this.lblCatgoryNameData.Location = new System.Drawing.Point(85, 13);
            this.lblCatgoryNameData.Name = "lblCatgoryNameData";
            this.lblCatgoryNameData.Size = new System.Drawing.Size(125, 18);
            this.lblCatgoryNameData.TabIndex = 0;
            this.lblCatgoryNameData.Text = "Category Name";
            // 
            // frmUdtUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 414);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnConnect);
            this.Name = "frmUdtUpdate";
            this.Text = "Update UDT";
            this.tabControl.ResumeLayout(false);
            this.tabPageCategory.ResumeLayout(false);
            this.tabPageCategory.PerformLayout();
            this.tabPageData.ResumeLayout(false);
            this.tabPageData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Button btnUpdateCategory;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageCategory;
        private System.Windows.Forms.TextBox txtBoxDetailsCategory;
        private System.Windows.Forms.TextBox txtBoxTextCategory;
        private System.Windows.Forms.Label lblDetailsCategory;
        private System.Windows.Forms.Label lblTextCategory;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.TabPage tabPageData;
        private Button btnDeleteData;
        private Button btnUpdateData;
        private Button btnAddData;
        private System.Windows.Forms.TextBox txtBoxDetailsData;
        private System.Windows.Forms.TextBox txtBoxTextData;
        private System.Windows.Forms.Label lbDetailsData;
        private System.Windows.Forms.Label lblTextData;
        private System.Windows.Forms.ComboBox cmbBoxCategory;
        private System.Windows.Forms.Label lblSelectCategoryName;
        private System.Windows.Forms.ComboBox cmbBoxData;
        private System.Windows.Forms.Label lblSelectNameData;
        private Label lblCategoryName;
        private Label lblCatgoryNameData;
    }
}

