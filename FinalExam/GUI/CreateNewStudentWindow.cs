using FinalExam.Business.Services;
using FinalExam.DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalExam.GUI {
    public partial class CreateNewStudentWindow : Form {
        private StudentDTO newStudent;

        public CreateNewStudentWindow() {
            InitializeComponent();
        }

        public void OpenNewMovieModal() {
            ShowDialog();

            txtStudentCode.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
        }

        public StudentDTO GetCreatedStudent() {
            return newStudent;
        }

        private void btnCreate_Click(object sender, EventArgs e) {
            MainService.GetInstance().GetStudentService().Create(
                    Convert.ToInt32(txtStudentCode.Text),
                    txtFirstName.Text,
                    txtLastName.Text
                );

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
