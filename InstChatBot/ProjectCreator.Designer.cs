namespace InstChatBot
{
    partial class ProjectCreator
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
            this.projList = new System.Windows.Forms.ListBox();
            this.nameText = new System.Windows.Forms.TextBox();
            this.contList = new System.Windows.Forms.ListBox();
            this.persList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.projectAddB = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.clientText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.accAddB = new System.Windows.Forms.Button();
            this.selDialB = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.selLabel = new System.Windows.Forms.Label();
            this.crDialB = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.projectDelB = new System.Windows.Forms.Button();
            this.accDelB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // projList
            // 
            this.projList.FormattingEnabled = true;
            this.projList.Location = new System.Drawing.Point(12, 28);
            this.projList.Name = "projList";
            this.projList.Size = new System.Drawing.Size(229, 537);
            this.projList.TabIndex = 0;
            this.projList.SelectedIndexChanged += new System.EventHandler(this.projList_SelectedIndexChanged);
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(305, 47);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(198, 20);
            this.nameText.TabIndex = 1;
            // 
            // contList
            // 
            this.contList.FormattingEnabled = true;
            this.contList.Location = new System.Drawing.Point(305, 249);
            this.contList.Name = "contList";
            this.contList.Size = new System.Drawing.Size(198, 264);
            this.contList.TabIndex = 3;
            // 
            // persList
            // 
            this.persList.FormattingEnabled = true;
            this.persList.Location = new System.Drawing.Point(554, 28);
            this.persList.Name = "persList";
            this.persList.Size = new System.Drawing.Size(221, 537);
            this.persList.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Список проектов";
            // 
            // projectAddB
            // 
            this.projectAddB.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.projectAddB.Location = new System.Drawing.Point(247, 30);
            this.projectAddB.Name = "projectAddB";
            this.projectAddB.Size = new System.Drawing.Size(40, 40);
            this.projectAddB.TabIndex = 6;
            this.projectAddB.Text = "+";
            this.projectAddB.UseVisualStyleBackColor = true;
            this.projectAddB.Click += new System.EventHandler(this.projectAddB_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(302, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Название";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(302, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Заказчик";
            // 
            // clientText
            // 
            this.clientText.Location = new System.Drawing.Point(305, 94);
            this.clientText.Name = "clientText";
            this.clientText.Size = new System.Drawing.Size(198, 20);
            this.clientText.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(302, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Список контактёров";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(551, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Список персонажей";
            // 
            // accAddB
            // 
            this.accAddB.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.accAddB.Location = new System.Drawing.Point(781, 28);
            this.accAddB.Name = "accAddB";
            this.accAddB.Size = new System.Drawing.Size(40, 40);
            this.accAddB.TabIndex = 12;
            this.accAddB.Text = "+";
            this.accAddB.UseVisualStyleBackColor = true;
            this.accAddB.Click += new System.EventHandler(this.accAddB_Click);
            // 
            // selDialB
            // 
            this.selDialB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.selDialB.Location = new System.Drawing.Point(305, 188);
            this.selDialB.Name = "selDialB";
            this.selDialB.Size = new System.Drawing.Size(96, 23);
            this.selDialB.TabIndex = 13;
            this.selDialB.Text = "Выбрать";
            this.selDialB.UseVisualStyleBackColor = true;
            this.selDialB.Click += new System.EventHandler(this.selDialB_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(302, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "Выбранный диалог:";
            // 
            // selLabel
            // 
            this.selLabel.AutoSize = true;
            this.selLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.selLabel.Location = new System.Drawing.Point(302, 154);
            this.selLabel.Name = "selLabel";
            this.selLabel.Size = new System.Drawing.Size(31, 16);
            this.selLabel.TabIndex = 16;
            this.selLabel.Text = "нет";
            // 
            // crDialB
            // 
            this.crDialB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.crDialB.Location = new System.Drawing.Point(407, 188);
            this.crDialB.Name = "crDialB";
            this.crDialB.Size = new System.Drawing.Size(96, 23);
            this.crDialB.TabIndex = 17;
            this.crDialB.Text = "Создать";
            this.crDialB.UseVisualStyleBackColor = true;
            this.crDialB.Click += new System.EventHandler(this.crDialB_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(305, 545);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 20);
            this.button1.TabIndex = 18;
            this.button1.Text = "Выбрать .txt файл";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(483, 518);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(20, 20);
            this.button2.TabIndex = 19;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(508, 249);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 40);
            this.button3.TabIndex = 20;
            this.button3.Text = "-";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(305, 519);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(172, 20);
            this.textBox1.TabIndex = 21;
            // 
            // projectDelB
            // 
            this.projectDelB.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.projectDelB.Location = new System.Drawing.Point(247, 74);
            this.projectDelB.Name = "projectDelB";
            this.projectDelB.Size = new System.Drawing.Size(40, 40);
            this.projectDelB.TabIndex = 22;
            this.projectDelB.Text = "-";
            this.projectDelB.UseVisualStyleBackColor = true;
            this.projectDelB.Click += new System.EventHandler(this.projectDelB_Click);
            // 
            // accDelB
            // 
            this.accDelB.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.accDelB.Location = new System.Drawing.Point(781, 74);
            this.accDelB.Name = "accDelB";
            this.accDelB.Size = new System.Drawing.Size(40, 40);
            this.accDelB.TabIndex = 23;
            this.accDelB.Text = "-";
            this.accDelB.UseVisualStyleBackColor = true;
            this.accDelB.Click += new System.EventHandler(this.accDelB_Click);
            // 
            // ProjectCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 573);
            this.Controls.Add(this.accDelB);
            this.Controls.Add(this.projectDelB);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.crDialB);
            this.Controls.Add(this.selLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.selDialB);
            this.Controls.Add(this.accAddB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.clientText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.projectAddB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.persList);
            this.Controls.Add(this.contList);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.projList);
            this.Name = "ProjectCreator";
            this.Text = "Редактор базы проектов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProjectCreator_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox projList;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.ListBox contList;
        private System.Windows.Forms.ListBox persList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button projectAddB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox clientText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button accAddB;
        private System.Windows.Forms.Button selDialB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label selLabel;
        private System.Windows.Forms.Button crDialB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button projectDelB;
        private System.Windows.Forms.Button accDelB;
    }
}