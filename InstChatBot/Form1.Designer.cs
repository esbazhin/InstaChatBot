namespace InstChatBot
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.projectsButton = new System.Windows.Forms.Button();
            this.accsButton = new System.Windows.Forms.Button();
            this.dialogsButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loginDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passwordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.msgCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.projGrid = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dialogDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dialCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isRunDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startB = new System.Windows.Forms.DataGridViewButtonColumn();
            this.projectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.contList = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // projectsButton
            // 
            this.projectsButton.Location = new System.Drawing.Point(12, 12);
            this.projectsButton.Name = "projectsButton";
            this.projectsButton.Size = new System.Drawing.Size(155, 54);
            this.projectsButton.TabIndex = 0;
            this.projectsButton.Text = "Редактор базы проектов";
            this.projectsButton.UseVisualStyleBackColor = true;
            this.projectsButton.Click += new System.EventHandler(this.projectsButton_Click);
            // 
            // accsButton
            // 
            this.accsButton.Location = new System.Drawing.Point(173, 12);
            this.accsButton.Name = "accsButton";
            this.accsButton.Size = new System.Drawing.Size(155, 54);
            this.accsButton.TabIndex = 1;
            this.accsButton.Text = "Редактор базы аккаунтов";
            this.accsButton.UseVisualStyleBackColor = true;
            this.accsButton.Click += new System.EventHandler(this.accsButton_Click);
            // 
            // dialogsButton
            // 
            this.dialogsButton.Location = new System.Drawing.Point(334, 12);
            this.dialogsButton.Name = "dialogsButton";
            this.dialogsButton.Size = new System.Drawing.Size(155, 54);
            this.dialogsButton.TabIndex = 2;
            this.dialogsButton.Text = "Редактор диалогов";
            this.dialogsButton.UseVisualStyleBackColor = true;
            this.dialogsButton.Click += new System.EventHandler(this.dialogsButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stopButton.Location = new System.Drawing.Point(1057, 11);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(128, 54);
            this.stopButton.TabIndex = 3;
            this.stopButton.Text = "Общий стоп";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startButton.Location = new System.Drawing.Point(923, 11);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(128, 54);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Общий старт";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.loginDataGridViewTextBoxColumn,
            this.passwordDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.operDataGridViewTextBoxColumn,
            this.projectDataGridViewTextBoxColumn,
            this.msgCountDataGridViewTextBoxColumn});
            this.grid.Location = new System.Drawing.Point(11, 511);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.Size = new System.Drawing.Size(929, 419);
            this.grid.TabIndex = 28;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Имя";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // loginDataGridViewTextBoxColumn
            // 
            this.loginDataGridViewTextBoxColumn.DataPropertyName = "Login";
            this.loginDataGridViewTextBoxColumn.HeaderText = "Логин";
            this.loginDataGridViewTextBoxColumn.Name = "loginDataGridViewTextBoxColumn";
            this.loginDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // passwordDataGridViewTextBoxColumn
            // 
            this.passwordDataGridViewTextBoxColumn.DataPropertyName = "Password";
            this.passwordDataGridViewTextBoxColumn.HeaderText = "Пароль";
            this.passwordDataGridViewTextBoxColumn.Name = "passwordDataGridViewTextBoxColumn";
            this.passwordDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Самоописание";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // operDataGridViewTextBoxColumn
            // 
            this.operDataGridViewTextBoxColumn.DataPropertyName = "Oper";
            this.operDataGridViewTextBoxColumn.HeaderText = "Оператор";
            this.operDataGridViewTextBoxColumn.Name = "operDataGridViewTextBoxColumn";
            this.operDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // projectDataGridViewTextBoxColumn
            // 
            this.projectDataGridViewTextBoxColumn.DataPropertyName = "Project";
            this.projectDataGridViewTextBoxColumn.HeaderText = "Проект";
            this.projectDataGridViewTextBoxColumn.Name = "projectDataGridViewTextBoxColumn";
            this.projectDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // msgCountDataGridViewTextBoxColumn
            // 
            this.msgCountDataGridViewTextBoxColumn.DataPropertyName = "msgCount";
            this.msgCountDataGridViewTextBoxColumn.HeaderText = "Кол-во сообщений";
            this.msgCountDataGridViewTextBoxColumn.Name = "msgCountDataGridViewTextBoxColumn";
            this.msgCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(9, 492);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(277, 16);
            this.label4.TabIndex = 31;
            this.label4.Text = "Список персонажей выбранного проекта";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 32;
            this.label1.Text = "Список проектов";
            // 
            // projGrid
            // 
            this.projGrid.AllowUserToAddRows = false;
            this.projGrid.AllowUserToDeleteRows = false;
            this.projGrid.AutoGenerateColumns = false;
            this.projGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.projGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.projGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn1,
            this.clientDataGridViewTextBoxColumn,
            this.dialogDataGridViewTextBoxColumn,
            this.dialCountDataGridViewTextBoxColumn,
            this.isRunDataGridViewTextBoxColumn,
            this.startB});
            this.projGrid.DataSource = this.projectBindingSource;
            this.projGrid.Location = new System.Drawing.Point(12, 104);
            this.projGrid.MultiSelect = false;
            this.projGrid.Name = "projGrid";
            this.projGrid.ReadOnly = true;
            this.projGrid.Size = new System.Drawing.Size(1173, 385);
            this.projGrid.TabIndex = 35;
            this.projGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.projGrid_CellContentClick);
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "Название";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            this.nameDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // clientDataGridViewTextBoxColumn
            // 
            this.clientDataGridViewTextBoxColumn.DataPropertyName = "Client";
            this.clientDataGridViewTextBoxColumn.HeaderText = "Клиент";
            this.clientDataGridViewTextBoxColumn.Name = "clientDataGridViewTextBoxColumn";
            this.clientDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dialogDataGridViewTextBoxColumn
            // 
            this.dialogDataGridViewTextBoxColumn.DataPropertyName = "Dialog";
            this.dialogDataGridViewTextBoxColumn.HeaderText = "Диалог";
            this.dialogDataGridViewTextBoxColumn.Name = "dialogDataGridViewTextBoxColumn";
            this.dialogDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dialCountDataGridViewTextBoxColumn
            // 
            this.dialCountDataGridViewTextBoxColumn.DataPropertyName = "DialCount";
            this.dialCountDataGridViewTextBoxColumn.HeaderText = "Кол-во пройденных диалогов";
            this.dialCountDataGridViewTextBoxColumn.Name = "dialCountDataGridViewTextBoxColumn";
            this.dialCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isRunDataGridViewTextBoxColumn
            // 
            this.isRunDataGridViewTextBoxColumn.DataPropertyName = "IsRun";
            this.isRunDataGridViewTextBoxColumn.HeaderText = "Состояние работы";
            this.isRunDataGridViewTextBoxColumn.Name = "isRunDataGridViewTextBoxColumn";
            this.isRunDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // startB
            // 
            this.startB.HeaderText = "Запустить/остановить";
            this.startB.Name = "startB";
            this.startB.ReadOnly = true;
            this.startB.UseColumnTextForButtonValue = true;
            // 
            // projectBindingSource
            // 
            this.projectBindingSource.DataSource = typeof(InstChatBot.Project);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(886, 492);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(299, 16);
            this.label2.TabIndex = 37;
            this.label2.Text = "Список контактёров выбранного персонажа";
            // 
            // contList
            // 
            this.contList.FormattingEnabled = true;
            this.contList.Location = new System.Drawing.Point(946, 511);
            this.contList.Name = "contList";
            this.contList.Size = new System.Drawing.Size(239, 420);
            this.contList.TabIndex = 36;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 942);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.contList);
            this.Controls.Add(this.projGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.dialogsButton);
            this.Controls.Add(this.accsButton);
            this.Controls.Add(this.projectsButton);
            this.Name = "Form1";
            this.Text = "InstaChatBot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button projectsButton;
        private System.Windows.Forms.Button accsButton;
        private System.Windows.Forms.Button dialogsButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loginDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn operDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn msgCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView projGrid;
        private System.Windows.Forms.BindingSource projectBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dialogDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dialCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isRunDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn startB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox contList;
        private System.Windows.Forms.Timer timer1;
    }
}

