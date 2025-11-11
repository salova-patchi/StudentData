using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using StudentData.Data;
using StudentData.Models;

namespace StudentData
{
    public partial class Form1 : Form
    {
        // For draggable borderless window
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        public Form1()
        {
            InitializeComponent();
            // Enable double buffering for smooth rendering
            this.DoubleBuffered = true;
            // Rounded corners for modern look (Windows 11)
            if (Environment.OSVersion.Version.Major >= 10)
            {
                this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            }
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadStudents();
            UpdateRecordCount();

            // Add alternating row colors
            dataGridViewStudents.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);

            // Add fade-in animation
            this.Opacity = 0;
            System.Windows.Forms.Timer fadeIn = new System.Windows.Forms.Timer();
            fadeIn.Interval = 10;
            fadeIn.Tick += (s, args) =>
            {
                if (this.Opacity < 1)
                    this.Opacity += 0.05;
                else
                    fadeIn.Stop();
            };
            fadeIn.Start();
        }

        #region Helper Methods

        private void ClearForm()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox1.ReadOnly = false;
            textBox1.Focus();

            // Visual feedback
            FlashControl(btnClear, System.Drawing.Color.FromArgb(149, 165, 166));
        }

        private void LoadStudents()
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var students = context.Students.ToList();
                    dataGridViewStudents.DataSource = students;

                    // Format DataGridView headers
                    if (dataGridViewStudents.Columns.Count > 0)
                    {
                        dataGridViewStudents.Columns[0].HeaderText = "ID";
                        dataGridViewStudents.Columns[1].HeaderText = "Student Name";
                        dataGridViewStudents.Columns[2].HeaderText = "Specialty";
                    }
                }
                UpdateRecordCount();
            }
            catch (Exception ex)
            {
                ShowModernMessageBox($"Error loading students: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private void UpdateRecordCount()
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    int count = context.Students.Count();
                    lblRecordCount.Text = $"Total Records: {count}";
                }
            }
            catch { }
        }

        private void FlashControl(Control control, System.Drawing.Color color)
        {
            var originalColor = control.BackColor;
            control.BackColor = System.Drawing.Color.White;
            System.Windows.Forms.Timer flashTimer = new System.Windows.Forms.Timer { Interval = 100 };
            int count = 0;
            flashTimer.Tick += (s, args) =>
            {
                control.BackColor = count % 2 == 0 ? System.Drawing.Color.White : color;
                count++;
                if (count > 3)
                {
                    control.BackColor = originalColor;
                    flashTimer.Stop();
                }
            };
            flashTimer.Start();
        }

        private void ShowModernMessageBox(string message, string title, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }

        #endregion

        #region CRUD Operations

        private void button1_Click(object sender, EventArgs e)
        {
            // Add New Student
            if (textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "")
            {
                ShowModernMessageBox("Please enter a Name and Specialty.", "Validation Error", MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var newStudent = new Student
                    {
                        Name = textBox2.Text.Trim(),
                        Speciality = textBox3.Text.Trim()
                    };

                    context.Students.Add(newStudent);
                    context.SaveChanges();

                    ShowModernMessageBox($"✓ Student '{newStudent.Name}' added successfully!", "Success", MessageBoxIcon.Information);
                    LoadStudents();
                    ClearForm();
                    FlashControl(button1, System.Drawing.Color.FromArgb(46, 204, 113));
                }
            }
            catch (Exception ex)
            {
                ShowModernMessageBox($"Error adding student: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Find Student
            if (!int.TryParse(textBox1.Text, out int studentId))
            {
                ShowModernMessageBox("Please enter a valid numeric ID to search.", "Validation Error", MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var student = context.Students.Find(studentId);

                    if (student != null)
                    {
                        textBox2.Text = student.Name;
                        textBox3.Text = student.Speciality;
                        ShowModernMessageBox($"✓ Student found: {student.Name}", "Success", MessageBoxIcon.Information);
                        FlashControl(button2, System.Drawing.Color.FromArgb(52, 152, 219));
                    }
                    else
                    {
                        ShowModernMessageBox("ID NOT FOUND!", "Not Found", MessageBoxIcon.Warning);
                        ClearForm();
                        textBox1.Text = studentId.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowModernMessageBox($"Error searching for student: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Refresh All
            LoadStudents();
            ShowModernMessageBox("✓ Student list refreshed!", "Success", MessageBoxIcon.Information);
            FlashControl(button3, System.Drawing.Color.FromArgb(155, 89, 182));
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Update Student
            if (!int.TryParse(textBox1.Text, out int studentId))
            {
                ShowModernMessageBox("Please enter a valid numeric ID to update.", "Validation Error", MessageBoxIcon.Warning);
                return;
            }

            if (textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "")
            {
                ShowModernMessageBox("Name and Specialty cannot be empty.", "Validation Error", MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var studentToUpdate = context.Students.Find(studentId);

                    if (studentToUpdate == null)
                    {
                        ShowModernMessageBox("Student not found. Cannot update.", "Error", MessageBoxIcon.Error);
                        return;
                    }

                    studentToUpdate.Name = textBox2.Text.Trim();
                    studentToUpdate.Speciality = textBox3.Text.Trim();

                    context.SaveChanges();

                    ShowModernMessageBox($"✓ Student '{studentToUpdate.Name}' updated successfully!", "Success", MessageBoxIcon.Information);
                    LoadStudents();
                    ClearForm();
                    FlashControl(btnUpdate, System.Drawing.Color.FromArgb(241, 196, 15));
                }
            }
            catch (Exception ex)
            {
                ShowModernMessageBox($"Error updating student: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Delete Student
            if (!int.TryParse(textBox1.Text, out int studentId))
            {
                ShowModernMessageBox("Please enter a valid numeric ID to delete.", "Validation Error", MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show(
                $"⚠️ Are you sure you want to delete student with ID {studentId}?\n\nThis action cannot be undone.",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.No)
            {
                return;
            }

            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var studentToDelete = context.Students.Find(studentId);

                    if (studentToDelete == null)
                    {
                        ShowModernMessageBox("Student not found. Cannot delete.", "Error", MessageBoxIcon.Error);
                        return;
                    }

                    string studentName = studentToDelete.Name;
                    context.Students.Remove(studentToDelete);
                    context.SaveChanges();

                    ShowModernMessageBox($"✓ Student '{studentName}' deleted successfully!", "Success", MessageBoxIcon.Information);
                    LoadStudents();
                    ClearForm();
                    FlashControl(btnDelete, System.Drawing.Color.FromArgb(231, 76, 60));
                }
            }
            catch (Exception ex)
            {
                ShowModernMessageBox($"Error deleting student: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        #endregion

        #region New Features

        private void BtnExport_Click(object sender, EventArgs e)
        {
            // Export to CSV
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                    FileName = $"Students_Export_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
                    Title = "Export Students to CSV"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var context = new ApplicationDbContext())
                    {
                        var students = context.Students.ToList();
                        using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                        {
                            // Write header
                            sw.WriteLine("ID,Name,Specialty");

                            // Write data
                            foreach (var student in students)
                            {
                                sw.WriteLine($"{student.Id},\"{student.Name}\",\"{student.Speciality}\"");
                            }
                        }
                    }

                    ShowModernMessageBox($"✓ Successfully exported {dataGridViewStudents.Rows.Count} records to:\n{saveFileDialog.FileName}", "Export Successful", MessageBoxIcon.Information);
                    FlashControl(btnExport, System.Drawing.Color.FromArgb(22, 160, 133));
                }
            }
            catch (Exception ex)
            {
                ShowModernMessageBox($"Error exporting to CSV: {ex.Message}", "Export Error", MessageBoxIcon.Error);
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            // Real-time search/filter
            string searchText = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadStudents();
                return;
            }

            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var filteredStudents = context.Students
                        .Where(s => s.Id.ToString().Contains(searchText) ||
                                    s.Name.ToLower().Contains(searchText) ||
                                    s.Speciality.ToLower().Contains(searchText))
                        .ToList();

                    dataGridViewStudents.DataSource = filteredStudents;
                    lblRecordCount.Text = $"Showing {filteredStudents.Count} of {context.Students.Count()} records";
                }
            }
            catch (Exception ex)
            {
                ShowModernMessageBox($"Error searching: {ex.Message}", "Search Error", MessageBoxIcon.Error);
            }
        }

        private void dataGridViewStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dataGridViewStudents.Rows[e.RowIndex].Cells[0].Value != null)
            {
                try
                {
                    textBox1.Text = dataGridViewStudents.Rows[e.RowIndex].Cells[0].Value.ToString();
                    textBox2.Text = dataGridViewStudents.Rows[e.RowIndex].Cells[1].Value.ToString();
                    textBox3.Text = dataGridViewStudents.Rows[e.RowIndex].Cells[2].Value.ToString();

                    textBox1.ReadOnly = true;
                }
                catch (Exception ex)
                {
                    ShowModernMessageBox($"Error loading data from grid: {ex.Message}", "Error", MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region UI Event Handlers

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy  HH:mm:ss");
        }

        private void PanelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            // Fade out animation
            System.Windows.Forms.Timer fadeOut = new System.Windows.Forms.Timer();
            fadeOut.Interval = 10;
            fadeOut.Tick += (s, args) =>
            {
                if (this.Opacity > 0)
                    this.Opacity -= 0.05;
                else
                {
                    fadeOut.Stop();
                    this.Hide();
                    notifyIcon1.ShowBalloonTip(2000, "Student Manager", "Application minimized to system tray", ToolTipIcon.Info);
                }
            };
            fadeOut.Start();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Restore from tray with fade-in
            this.Show();
            this.Opacity = 0;
            this.WindowState = FormWindowState.Normal;

            System.Windows.Forms.Timer fadeIn = new System.Windows.Forms.Timer();
            fadeIn.Interval = 10;
            fadeIn.Tick += (s, args) =>
            {
                if (this.Opacity < 1)
                    this.Opacity += 0.05;
                else
                    fadeIn.Stop();
            };
            fadeIn.Start();
        }

        #endregion

        #region Button Hover Effects

        private void ButtonAction_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.Font = new System.Drawing.Font(btn.Font.FontFamily, btn.Font.Size, System.Drawing.FontStyle.Bold);
                btn.Cursor = Cursors.Hand;
            }
        }

        private void ButtonAction_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.Font = new System.Drawing.Font(btn.Font.FontFamily, btn.Font.Size, System.Drawing.FontStyle.Bold);
            }
        }

        private void Btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn == btnMinimize)
            {
                btn.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            }
        }

        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn == btnMinimize)
            {
                btn.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            }
        }

        private void BtnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
        }

        private void BtnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Unused
        }

        #endregion
    }
}