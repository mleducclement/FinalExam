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
    public partial class MainWindow : Form {
        private MainService mainService;
        private CreateNewStudentWindow newStudentWindow;
        private CourseSelector courseSelector;
        private StudentDTO selectedStudent;
        private CourseDTO selectedCourse;

        public MainWindow() {
            InitializeComponent();
            mainService = MainService.GetInstance();
            newStudentWindow = new CreateNewStudentWindow();
            courseSelector = new CourseSelector();

            Setup();
        }

        public void Setup() {
            cmbStudents.DisplayMember = "StudentCode";
            cmbStudents.ValueMember = "Id";

            UpdateStudentCombobox(mainService.GetStudentService().GetAllStudents());
        }

        public void UpdateStudentCombobox(List<StudentDTO> students) {
            cmbStudents.Items.Clear();

            foreach (StudentDTO student in students) {
                cmbStudents.Items.Add(student);
            }
        }

        public void LoadStudentInfo(StudentDTO student) {

            txtId.Text = student.Id.ToString();
            txtStudentCode.Text = student.StudentCode.ToString();
            txtFirstName.Text = student.FirstName;
            txtLastName.Text = student.LastName;

            List<CourseDTO> courses = mainService.GetStudentCoursesService().GetAllCourseByStudent(student.Id);

            lstCourses.Items.Clear();

            foreach (CourseDTO course in courses) {
                AddCourseToListView(course);
            }
        }

        public void AddCourseToListView(CourseDTO course) {
            ListViewItem listViewItem = new ListViewItem(course.Title);
            listViewItem.Tag = course.Id;
            lstCourses.Items.Add(listViewItem);
        }

        public void RemoveCourseFromListView(CourseDTO course) {
            foreach (ListViewItem listViewItem in lstCourses.Items) {
                if (((int)listViewItem.Tag) == course.Id) {
                    lstCourses.Items.Remove(listViewItem);
                }
            }
        }

        public StudentDTO GetSelectedStudent() {
            return selectedStudent;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            newStudentWindow.ShowDialog();

            if (newStudentWindow.DialogResult == DialogResult.OK) {
                StudentDTO student = newStudentWindow.GetCreatedStudent();
                UpdateStudentCombobox(mainService.GetStudentService().GetAllStudents());
                cmbStudents.SelectedItem = student;
                cmbStudents.SelectedIndex = cmbStudents.Items.Count - 1;
            }
        }

        private void cmbStudents_SelectedIndexChanged(object sender, EventArgs e) {
            selectedStudent = (StudentDTO)cmbStudents.Items[cmbStudents.SelectedIndex];
            mainService.SetSelectedStudent(selectedStudent);

            if (selectedStudent != null) {
                LoadStudentInfo(selectedStudent);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e) {
            if (selectedStudent is not null) {
                mainService.GetStudentService().Update(
                    Convert.ToInt32(txtStudentCode.Text),
                    txtFirstName.Text,
                    txtLastName.Text
                );
            }

            ResetFields();
            UpdateStudentCombobox(mainService.GetStudentService().GetAllStudents());

            selectedStudent = null;
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            if (selectedStudent is not null) {
                mainService.GetStudentService().Delete(selectedStudent);
            }

            ResetFields();
            UpdateStudentCombobox(mainService.GetStudentService().GetAllStudents());

            selectedStudent = null;
        }

        private void ResetFields() {
            txtId.Text = string.Empty;
            txtStudentCode.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
        }

        private void btnAddCourse_Click(object sender, EventArgs e) {
            if (selectedStudent is not null) {
                List<CourseDTO> courses = mainService.GetCourseService().GetCourses();
                List<CourseDTO> assignedCourses = mainService.GetStudentCoursesService().GetAllCourseByStudent(selectedStudent.Id);
                List<CourseDTO> filteredCourses = new List<CourseDTO>();

                foreach (CourseDTO course in filteredCourses) {
                    Console.WriteLine(course.Title);
                }

                foreach (CourseDTO course in courses) {
                    if (!assignedCourses.Contains(course)) {
                        filteredCourses.Add(course);
                    }
                }

                courseSelector.OpenModalWindow(filteredCourses);

                if (courseSelector.DialogResult == DialogResult.OK) {
                    CourseDTO selectedCourse = courseSelector.GetSelectedCourse();
                    Console.WriteLine($"course : {selectedCourse.Title} / student : {selectedStudent.StudentCode}");
                    mainService.GetStudentCoursesService().CreateNewStudentCourse(selectedCourse.Id, selectedStudent.Id);
                    AddCourseToListView(selectedCourse);
                }
            }
        }

        private void btnRemoveCourse_Click(object sender, EventArgs e) {
            if (selectedStudent is not null) {
                List<CourseDTO> assignedCourses = mainService.GetStudentCoursesService().GetAllCourseByStudent(selectedStudent.Id);

                courseSelector.OpenModalWindow(assignedCourses);

                if (courseSelector.DialogResult == DialogResult.OK) {
                    CourseDTO selectedCourse = courseSelector.GetSelectedCourse();
                    mainService.GetStudentCoursesService().DeleteStudentCourse(selectedStudent.Id, selectedCourse.Id);
                    RemoveCourseFromListView(selectedCourse);
                }
            }
        }

        private void btnQuit_Click(object sender, EventArgs e) {
            mainService.ExitApp();
        }
    }
}
