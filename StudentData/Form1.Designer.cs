using System.Drawing;
using System.Windows.Forms;

namespace StudentData
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            
            // Header Panel
            panelHeader = new Panel();
            lab1 = new Label();
            lblDateTime = new Label();
            btnMinimize = new Button();
            btnClose = new Button();
            
            // Input Panel
            panelInput = new Panel();
            labID = new Label();
            labName = new Label();
            labSpe = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            lblRecordCount = new Label();
            
            // Button Panel
            panelButtons = new Panel();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            btnExport = new Button();
            
            // Search Panel
            panelSearch = new Panel();
            txtSearch = new TextBox();
            lblSearch = new Label();
            
            // DataGridView
            dataGridViewStudents = new DataGridView();
            
            toolTip1 = new ToolTip(components);
            timer1 = new System.Windows.Forms.Timer(components);
            notifyIcon1 = new NotifyIcon(components);

            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).BeginInit();
            panelHeader.SuspendLayout();
            panelInput.SuspendLayout();
            panelButtons.SuspendLayout();
            panelSearch.SuspendLayout();
            SuspendLayout();

            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(41, 128, 185);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1000, 80);
            panelHeader.TabIndex = 0;
            panelHeader.Controls.Add(lab1);
            panelHeader.Controls.Add(lblDateTime);
            panelHeader.Controls.Add(btnMinimize);
            panelHeader.Controls.Add(btnClose);
            panelHeader.MouseDown += PanelHeader_MouseDown;
            
            // 
            // lab1
            // 
            lab1.AutoSize = true;
            lab1.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lab1.ForeColor = Color.White;
            lab1.Location = new Point(20, 15);
            lab1.Name = "lab1";
            lab1.Size = new Size(350, 51);
            lab1.TabIndex = 0;
            lab1.Text = "📚 Student Manager";
            
            // 
            // lblDateTime
            // 
            lblDateTime.AutoSize = true;
            lblDateTime.Font = new Font("Segoe UI", 11F);
            lblDateTime.ForeColor = Color.White;
            lblDateTime.Location = new Point(450, 30);
            lblDateTime.Name = "lblDateTime";
            lblDateTime.Size = new Size(120, 20);
            lblDateTime.TabIndex = 1;
            lblDateTime.Text = "";
            
            // 
            // btnMinimize
            // 
            btnMinimize.BackColor = Color.FromArgb(52, 152, 219);
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnMinimize.ForeColor = Color.White;
            btnMinimize.Location = new Point(900, 15);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(40, 40);
            btnMinimize.TabIndex = 2;
            btnMinimize.Text = "─";
            btnMinimize.UseVisualStyleBackColor = false;
            btnMinimize.Click += BtnMinimize_Click;
            btnMinimize.MouseEnter += Btn_MouseEnter;
            btnMinimize.MouseLeave += Btn_MouseLeave;
            
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(231, 76, 60);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(945, 15);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(40, 40);
            btnClose.TabIndex = 3;
            btnClose.Text = "✕";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += BtnClose_Click;
            btnClose.MouseEnter += BtnClose_MouseEnter;
            btnClose.MouseLeave += BtnClose_MouseLeave;
            
            // 
            // panelInput
            // 
            panelInput.BackColor = Color.White;
            panelInput.BorderStyle = BorderStyle.FixedSingle;
            panelInput.Location = new Point(20, 100);
            panelInput.Name = "panelInput";
            panelInput.Size = new Size(460, 260);
            panelInput.TabIndex = 1;
            panelInput.Controls.Add(labID);
            panelInput.Controls.Add(labName);
            panelInput.Controls.Add(labSpe);
            panelInput.Controls.Add(textBox1);
            panelInput.Controls.Add(textBox2);
            panelInput.Controls.Add(textBox3);
            
            // 
            // labID
            // 
            labID.AutoSize = true;
            labID.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labID.ForeColor = Color.FromArgb(52, 73, 94);
            labID.Location = new Point(20, 30);
            labID.Name = "labID";
            labID.Size = new Size(100, 21);
            labID.TabIndex = 0;
            labID.Text = "Student ID:";
            
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(236, 240, 241);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 12F);
            textBox1.Location = new Point(150, 25);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(280, 27);
            textBox1.TabIndex = 1;
            textBox1.Padding = new Padding(10, 5, 10, 5);
            toolTip1.SetToolTip(textBox1, "Enter student ID (auto-generated for new students)");
            
            // 
            // labName
            // 
            labName.AutoSize = true;
            labName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labName.ForeColor = Color.FromArgb(52, 73, 94);
            labName.Location = new Point(20, 95);
            labName.Name = "labName";
            labName.Size = new Size(60, 21);
            labName.TabIndex = 2;
            labName.Text = "Name:";
            
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(236, 240, 241);
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Segoe UI", 12F);
            textBox2.Location = new Point(150, 90);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(280, 27);
            textBox2.TabIndex = 3;
            textBox2.Padding = new Padding(10, 5, 10, 5);
            toolTip1.SetToolTip(textBox2, "Enter student full name");
            
            // 
            // labSpe
            // 
            labSpe.AutoSize = true;
            labSpe.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labSpe.ForeColor = Color.FromArgb(52, 73, 94);
            labSpe.Location = new Point(20, 160);
            labSpe.Name = "labSpe";
            labSpe.Size = new Size(85, 21);
            labSpe.TabIndex = 4;
            labSpe.Text = "Specialty:";
            
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.FromArgb(236, 240, 241);
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Font = new Font("Segoe UI", 12F);
            textBox3.Location = new Point(150, 155);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(280, 27);
            textBox3.TabIndex = 5;
            textBox3.Padding = new Padding(10, 5, 10, 5);
            toolTip1.SetToolTip(textBox3, "Enter student specialty/major");
            
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.White;
            panelButtons.BorderStyle = BorderStyle.FixedSingle;
            panelButtons.Location = new Point(500, 100);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(480, 260);
            panelButtons.TabIndex = 2;
            panelButtons.Controls.Add(button1);
            panelButtons.Controls.Add(button2);
            panelButtons.Controls.Add(button3);
            panelButtons.Controls.Add(btnUpdate);
            panelButtons.Controls.Add(btnDelete);
            panelButtons.Controls.Add(btnClear);
            panelButtons.Controls.Add(btnExport);
            panelButtons.Controls.Add(lblRecordCount);
            
            // 
            // button1 (Add New)
            // 
            button1.BackColor = Color.FromArgb(46, 204, 113);
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(20, 25);
            button1.Name = "button1";
            button1.Size = new Size(140, 45);
            button1.TabIndex = 0;
            button1.Text = "➕ Add New";
            toolTip1.SetToolTip(button1, "Add a new student record");
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            button1.MouseEnter += ButtonAction_MouseEnter;
            button1.MouseLeave += ButtonAction_MouseLeave;
            
            // 
            // button2 (Find)
            // 
            button2.BackColor = Color.FromArgb(52, 152, 219);
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(170, 25);
            button2.Name = "button2";
            button2.Size = new Size(140, 45);
            button2.TabIndex = 1;
            button2.Text = "🔍 Find";
            toolTip1.SetToolTip(button2, "Find student by ID");
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            button2.MouseEnter += ButtonAction_MouseEnter;
            button2.MouseLeave += ButtonAction_MouseLeave;
            
            // 
            // button3 (Refresh)
            // 
            button3.BackColor = Color.FromArgb(155, 89, 182);
            button3.Cursor = Cursors.Hand;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button3.ForeColor = Color.White;
            button3.Location = new Point(320, 25);
            button3.Name = "button3";
            button3.Size = new Size(140, 45);
            button3.TabIndex = 2;
            button3.Text = "🔄 Refresh";
            toolTip1.SetToolTip(button3, "Refresh student list");
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            button3.MouseEnter += ButtonAction_MouseEnter;
            button3.MouseLeave += ButtonAction_MouseLeave;
            
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(241, 196, 15);
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(20, 90);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(140, 45);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "✏️ Update";
            toolTip1.SetToolTip(btnUpdate, "Update selected student");
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            btnUpdate.MouseEnter += ButtonAction_MouseEnter;
            btnUpdate.MouseLeave += ButtonAction_MouseLeave;
            
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(170, 90);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(140, 45);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "🗑️ Delete";
            toolTip1.SetToolTip(btnDelete, "Delete selected student");
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            btnDelete.MouseEnter += ButtonAction_MouseEnter;
            btnDelete.MouseLeave += ButtonAction_MouseLeave;
            
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(149, 165, 166);
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(320, 90);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(140, 45);
            btnClear.TabIndex = 5;
            btnClear.Text = "🧹 Clear";
            toolTip1.SetToolTip(btnClear, "Clear all fields");
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            btnClear.MouseEnter += ButtonAction_MouseEnter;
            btnClear.MouseLeave += ButtonAction_MouseLeave;
            
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(22, 160, 133);
            btnExport.Cursor = Cursors.Hand;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(20, 155);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(440, 45);
            btnExport.TabIndex = 6;
            btnExport.Text = "📥 Export to CSV";
            toolTip1.SetToolTip(btnExport, "Export all students to CSV file");
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += BtnExport_Click;
            btnExport.MouseEnter += ButtonAction_MouseEnter;
            btnExport.MouseLeave += ButtonAction_MouseLeave;
            
            // 
            // lblRecordCount
            // 
            lblRecordCount.AutoSize = true;
            lblRecordCount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRecordCount.ForeColor = Color.FromArgb(52, 73, 94);
            lblRecordCount.Location = new Point(20, 220);
            lblRecordCount.Name = "lblRecordCount";
            lblRecordCount.Size = new Size(150, 19);
            lblRecordCount.TabIndex = 7;
            lblRecordCount.Text = "Total Records: 0";
            
            // 
            // panelSearch
            // 
            panelSearch.BackColor = Color.White;
            panelSearch.BorderStyle = BorderStyle.FixedSingle;
            panelSearch.Location = new Point(20, 380);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(960, 60);
            panelSearch.TabIndex = 3;
            panelSearch.Controls.Add(lblSearch);
            panelSearch.Controls.Add(txtSearch);
            
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSearch.ForeColor = Color.FromArgb(52, 73, 94);
            lblSearch.Location = new Point(20, 17);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(150, 21);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "🔎 Quick Search:";
            
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(236, 240, 241);
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 12F);
            txtSearch.Location = new Point(200, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(730, 27);
            txtSearch.TabIndex = 1;
            txtSearch.Padding = new Padding(10, 5, 10, 5);
            toolTip1.SetToolTip(txtSearch, "Search by ID, Name, or Specialty");
            txtSearch.TextChanged += TxtSearch_TextChanged;
            
            // 
            // dataGridViewStudents
            // 
            dataGridViewStudents.AllowUserToAddRows = false;
            dataGridViewStudents.AllowUserToDeleteRows = false;
            dataGridViewStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewStudents.BackgroundColor = Color.White;
            dataGridViewStudents.BorderStyle = BorderStyle.None;
            dataGridViewStudents.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dataGridViewStudents.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dataGridViewStudents.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewStudents.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 73, 94);
            dataGridViewStudents.ColumnHeadersHeight = 40;
            dataGridViewStudents.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dataGridViewStudents.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dataGridViewStudents.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridViewStudents.EnableHeadersVisualStyles = false;
            dataGridViewStudents.Location = new Point(20, 460);
            dataGridViewStudents.MultiSelect = false;
            dataGridViewStudents.Name = "dataGridViewStudents";
            dataGridViewStudents.ReadOnly = true;
            dataGridViewStudents.RowHeadersVisible = false;
            dataGridViewStudents.RowTemplate.Height = 35;
            dataGridViewStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewStudents.Size = new Size(960, 280);
            dataGridViewStudents.TabIndex = 4;
            dataGridViewStudents.CellClick += dataGridViewStudents_CellClick;
            
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            
            // 
            // notifyIcon1
            // 
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "Student Manager";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1000, 760);
            Controls.Add(dataGridViewStudents);
            Controls.Add(panelSearch);
            Controls.Add(panelButtons);
            Controls.Add(panelInput);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Student Manager";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;

            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelInput.ResumeLayout(false);
            panelInput.PerformLayout();
            panelButtons.ResumeLayout(false);
            panelButtons.PerformLayout();
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lab1;
        private Label lblDateTime;
        private Button btnMinimize;
        private Button btnClose;
        private Panel panelInput;
        private Label labID;
        private Label labName;
        private Label labSpe;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Panel panelButtons;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Button btnExport;
        private Label lblRecordCount;
        private Panel panelSearch;
        private Label lblSearch;
        private TextBox txtSearch;
        private DataGridView dataGridViewStudents;
        private ToolTip toolTip1;
        private System.Windows.Forms.Timer timer1;
        private NotifyIcon notifyIcon1;
    }
}