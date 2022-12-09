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
    public partial class CourseSelector : Form {
        private CourseDTO selectedCourse;
        public CourseSelector() {
            InitializeComponent();
            cmbCourses.DisplayMember = "Title";
            cmbCourses.ValueMember = "Id";
        }

        public CourseDTO GetSelectedCourse() {
            return selectedCourse;
        }

        public void OpenModalWindow(List<CourseDTO> courses) {
            cmbCourses.Items.Clear();

            foreach (CourseDTO course in courses) {
                cmbCourses.Items.Add(course);
            }

            ShowDialog();
        }

        private void btnCourseSelect_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
        }

        private void cmbCourses_SelectedIndexChanged(object sender, EventArgs e) {
            selectedCourse = (CourseDTO)cmbCourses.SelectedItem;
        }
    }
}
