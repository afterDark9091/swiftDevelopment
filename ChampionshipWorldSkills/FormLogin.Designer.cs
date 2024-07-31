
namespace ChampionshipWorldSkills
{
    partial class FormLogin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxRememberMe = new System.Windows.Forms.CheckBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelError);
            this.panel1.Controls.Add(this.buttonLogin);
            this.panel1.Controls.Add(this.checkBoxRememberMe);
            this.panel1.Controls.Add(this.textBoxPassword);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxLogin);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(64, 13);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(393, 304);
            this.panel1.TabIndex = 0;
            // 
            // checkBoxRememberMe
            // 
            this.checkBoxRememberMe.AutoSize = true;
            this.checkBoxRememberMe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxRememberMe.Location = new System.Drawing.Point(124, 226);
            this.checkBoxRememberMe.Name = "checkBoxRememberMe";
            this.checkBoxRememberMe.Size = new System.Drawing.Size(128, 23);
            this.checkBoxRememberMe.TabIndex = 5;
            this.checkBoxRememberMe.Text = "Запомни меня";
            this.checkBoxRememberMe.UseVisualStyleBackColor = true;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPassword.Location = new System.Drawing.Point(68, 146);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(254, 27);
            this.textBoxPassword.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Пароль";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxLogin.Location = new System.Drawing.Point(68, 88);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(254, 27);
            this.textBoxLogin.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Логин";
            // 
            // labelError
            // 
            this.labelError.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::ChampionshipWorldSkills.Properties.Settings.Default, "Red", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelError.ForeColor = global::ChampionshipWorldSkills.Properties.Settings.Default.Red;
            this.labelError.Location = new System.Drawing.Point(3, 181);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(385, 42);
            this.labelError.TabIndex = 7;
            this.labelError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = global::ChampionshipWorldSkills.Properties.Settings.Default.Blue;
            this.buttonLogin.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::ChampionshipWorldSkills.Properties.Settings.Default, "Blue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.buttonLogin.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::ChampionshipWorldSkills.Properties.Settings.Default, "White", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.buttonLogin.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::ChampionshipWorldSkills.Properties.Settings.Default, "FontSubcaption", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = global::ChampionshipWorldSkills.Properties.Settings.Default.FontSubcaption;
            this.buttonLogin.ForeColor = global::ChampionshipWorldSkills.Properties.Settings.Default.White;
            this.buttonLogin.Location = new System.Drawing.Point(67, 258);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(255, 34);
            this.buttonLogin.TabIndex = 6;
            this.buttonLogin.Text = "Логин";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // label1
            // 
            this.label1.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::ChampionshipWorldSkills.Properties.Settings.Default, "FontCaption", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label1.Font = global::ChampionshipWorldSkills.Properties.Settings.Default.FontCaption;
            this.label1.Location = new System.Drawing.Point(68, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Авторизация";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 322);
            this.Controls.Add(this.panel1);
            this.Name = "FormLogin";
            this.Text = "Авторизация";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBoxRememberMe;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label labelError;
    }
}

