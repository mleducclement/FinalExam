namespace FinalExam.GUI {
    partial class CourseSelector {
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
            this.cmbCourses = new System.Windows.Forms.ComboBox();
            this.btnCourseSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbCourses
            // 
            this.cmbCourses.FormattingEnabled = true;
            this.cmbCourses.Location = new System.Drawing.Point(12, 12);
            this.cmbCourses.Name = "cmbCourses";
            this.cmbCourses.Size = new System.Drawing.Size(239, 23);
            this.cmbCourses.TabIndex = 0;
            this.cmbCourses.SelectedIndexChanged += new System.EventHandler(this.cmbCourses_SelectedIndexChanged);
            // 
            // btnCourseSelect
            // 
            this.btnCourseSelect.Location = new System.Drawing.Point(86, 50);
            this.btnCourseSelect.Name = "btnCourseSelect";
            this.btnCourseSelect.Size = new System.Drawing.Size(75, 23);
            this.btnCourseSelect.TabIndex = 1;
            this.btnCourseSelect.Text = "Select";
            this.btnCourseSelect.UseVisualStyleBackColor = true;
            this.btnCourseSelect.Click += new System.EventHandler(this.btnCourseSelect_Click);
            // 
            // CourseSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 88);
            this.Controls.Add(this.btnCourseSelect);
            this.Controls.Add(this.cmbCourses);
            this.Name = "CourseSelector";
            this.Text = "CourseSelector";
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox cmbCourses;
        private Button btnCourseSelect;
    }
}