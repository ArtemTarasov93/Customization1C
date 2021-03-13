
namespace Customization1C
{
    partial class Customization1C
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Customization1C));
            this.StatusID = new System.Windows.Forms.Label();
            this.StatusPC = new System.Windows.Forms.Label();
            this.Instruction = new System.Windows.Forms.Label();
            this.MakeSettings = new System.Windows.Forms.Button();
            this.ClearCache = new System.Windows.Forms.Button();
            this.Helper = new System.Windows.Forms.Button();
            this.StatusPO = new System.Windows.Forms.Label();
            this.StatusOrganization = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StatusID
            // 
            this.StatusID.AutoSize = true;
            this.StatusID.Location = new System.Drawing.Point(12, 9);
            this.StatusID.Name = "StatusID";
            this.StatusID.Size = new System.Drawing.Size(48, 13);
            this.StatusID.TabIndex = 0;
            this.StatusID.Text = "StatusID";
            // 
            // StatusPC
            // 
            this.StatusPC.AutoSize = true;
            this.StatusPC.Location = new System.Drawing.Point(185, 9);
            this.StatusPC.Name = "StatusPC";
            this.StatusPC.Size = new System.Drawing.Size(51, 13);
            this.StatusPC.TabIndex = 2;
            this.StatusPC.Text = "StatusPC";
            // 
            // Instruction
            // 
            this.Instruction.AutoSize = true;
            this.Instruction.Location = new System.Drawing.Point(12, 57);
            this.Instruction.Name = "Instruction";
            this.Instruction.Size = new System.Drawing.Size(56, 13);
            this.Instruction.TabIndex = 3;
            this.Instruction.Text = "Instruction";
            // 
            // MakeSettings
            // 
            this.MakeSettings.Location = new System.Drawing.Point(12, 106);
            this.MakeSettings.Name = "MakeSettings";
            this.MakeSettings.Size = new System.Drawing.Size(148, 23);
            this.MakeSettings.TabIndex = 4;
            this.MakeSettings.Text = "Внести настройки";
            this.MakeSettings.UseVisualStyleBackColor = true;
            this.MakeSettings.Click += new System.EventHandler(this.MakeSettings_Click);
            // 
            // ClearCache
            // 
            this.ClearCache.Location = new System.Drawing.Point(12, 135);
            this.ClearCache.Name = "ClearCache";
            this.ClearCache.Size = new System.Drawing.Size(148, 23);
            this.ClearCache.TabIndex = 5;
            this.ClearCache.Text = "Очистить кеш 1С";
            this.ClearCache.UseVisualStyleBackColor = true;
            this.ClearCache.Click += new System.EventHandler(this.ClearCache_Click);
            // 
            // Helper
            // 
            this.Helper.Location = new System.Drawing.Point(312, 9);
            this.Helper.Name = "Helper";
            this.Helper.Size = new System.Drawing.Size(24, 23);
            this.Helper.TabIndex = 7;
            this.Helper.Text = "?";
            this.Helper.UseVisualStyleBackColor = true;
            this.Helper.Click += new System.EventHandler(this.Helper_Click);
            // 
            // StatusPO
            // 
            this.StatusPO.AutoSize = true;
            this.StatusPO.Location = new System.Drawing.Point(258, 145);
            this.StatusPO.Name = "StatusPO";
            this.StatusPO.Size = new System.Drawing.Size(52, 13);
            this.StatusPO.TabIndex = 8;
            this.StatusPO.Text = "StatusPO";
            // 
            // StatusOrganization
            // 
            this.StatusOrganization.AutoSize = true;
            this.StatusOrganization.Location = new System.Drawing.Point(12, 34);
            this.StatusOrganization.Name = "StatusOrganization";
            this.StatusOrganization.Size = new System.Drawing.Size(96, 13);
            this.StatusOrganization.TabIndex = 9;
            this.StatusOrganization.Text = "StatusOrganization";
            // 
            // Customization1C
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 167);
            this.Controls.Add(this.StatusOrganization);
            this.Controls.Add(this.StatusPO);
            this.Controls.Add(this.Helper);
            this.Controls.Add(this.ClearCache);
            this.Controls.Add(this.MakeSettings);
            this.Controls.Add(this.Instruction);
            this.Controls.Add(this.StatusPC);
            this.Controls.Add(this.StatusID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Customization1C";
            this.Text = "Настройка 1С";
            this.Load += new System.EventHandler(this.Customization1C_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StatusID;
        private System.Windows.Forms.Label StatusPC;
        private System.Windows.Forms.Label Instruction;
        private System.Windows.Forms.Button MakeSettings;
        private System.Windows.Forms.Button ClearCache;
        private System.Windows.Forms.Button Helper;
        private System.Windows.Forms.Label StatusPO;
        private System.Windows.Forms.Label StatusOrganization;
    }
}

