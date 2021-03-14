using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Data.OleDb;
using System.IO;
using System.Diagnostics;

namespace Customization1C
{
    public partial class Customization1C : Form
    {
        readonly string AppDataLocal = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
        readonly string AppDataRamming = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
        readonly string Shara = @"\\office\service\LanDesk\Soft\Softnolandesk\KKM";
        string StrGuid = "";
        string Organization = "";
        public Customization1C()
        {
            InitializeComponent();
        }

        private void Customization1C_Load(object sender, EventArgs e) //Инициализация формы
        {
            string VersionPO = "2.0.0.0";
            if (Directory.Exists(Shara))
            {
                string VersionPOShara = FileVersionInfo.GetVersionInfo(Shara + "\\Настройка 1С.exe").ProductVersion;
                if (VersionPOShara != VersionPO)
                {
                    Process.Start(Shara + "\\UpdaterCustomization1C.exe");
                    Application.Exit();
                }
            }
            string ComputerName = Dns.GetHostName();
            string LogFile = $@"C:\Files\KKM\{ComputerName}_Customization1C.txt";
            string TimePC = $"{DateTime.Now:HH:mm:ss}";
            string IdPvz = "";
            OleDbConnection OleDbConnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\office\service\LanDesk\Soft\Softnolandesk\KKM\DatabaseKKM.mdb");
            StatusPO.Text = $"Версия: {VersionPO}";
            StatusPC.Text = $"Имя компьютера:\r\n"+ ComputerName;
            string OleBdSelect = $"SELECT Computers.Computer_name, " +
                $"Computers.Id_Pvz, " +
                $"Computers.[Guid], " +
                $"Adress.Organization " +
                $"FROM(Computers INNER JOIN Adress ON Computers.Id_Pvz = Adress.Id_Pvz) " +
                $"WHERE(Computers.Computer_name = '{ComputerName}')";
            OleDbCommand SelectCommand = new OleDbCommand(OleBdSelect, OleDbConnection);
            if (Directory.Exists(Shara))
            {
                OleDbConnection.Open();
                OleDbDataReader DataReader = SelectCommand.ExecuteReader();
                try
                {
                    while (DataReader.Read())
                    {
                        IdPvz = Convert.ToString(DataReader["Id_Pvz"]);
                        StrGuid = Convert.ToString(DataReader["Guid"]);
                        Organization = Convert.ToString(DataReader["Organization"]);
                    }
                }
                catch (Exception ex)
                {
                    if (!Directory.Exists(@"C:\Files\KKM"))
                    {
                        Directory.CreateDirectory(@"C:\Files\KKM");
                    }
                    File.AppendAllText(LogFile, $"{TimePC} {ex.Message}\r\n");
                }
                finally
                {
                    if (DataReader != null && !DataReader.IsClosed)
                    {
                        DataReader.Close();
                    }
                    OleDbConnection.Close();
                }
                if (IdPvz != "")
                {
                    StatusID.ForeColor = Color.Green;
                    Instruction.ForeColor = Color.Green;
                    StatusOrganization.ForeColor = Color.Green;
                    StatusID.Text = "ID ПВЗ: " + IdPvz;
                    if (Organization == "kupishoes")
                    {
                        StatusOrganization.Text = "Организация: Купишуз";
                    }
                    else if (Organization == "puru")
                    {
                        StatusOrganization.Text = "Организация: Пикап";
                    }
                    Instruction.Text = "Нажмите кнопку Внести настройки";
                }
                else
                {
                    MakeSettings.Enabled = false;
                    StatusID.Text = "";
                    StatusOrganization.Text = "";
                    Instruction.ForeColor = Color.Red;
                    Instruction.Text = "Пвз или компьютер не найден в базе.\r\nОбратитесь в 6911";
                }
            }
            else
            {
                MakeSettings.Enabled = false;
                StatusID.Text = "";
                StatusOrganization.Text = "";
                Instruction.ForeColor = Color.Red;
                Instruction.Text = "Нет доступа к шаре\r\nПодключитесь к корпоративной сети\r\nи перезагрузите программу";
            }
        }

        private void MakeSettings_Click(object sender, EventArgs e) //Кнопка "Внести настройки"
        {
            if (!Directory.Exists(AppDataLocal+ "\\1C\\1cv8"))
            {
                Directory.CreateDirectory(AppDataLocal + "\\1C\\1cv8");
            }
            File.WriteAllText(AppDataLocal + "\\1C\\1cv8\\1cv8u.pfl", "" +
                "{\r\n" +
                "{\"\"},\r\n" +
                "{\r\n" +
                "{\"Universal\",\r\n" +
                "{\"ClientID\",\r\n" +
                "{\"#\",fc01b5df-97fe-449b-83d4-218a090e681e," + StrGuid + "},\"\"},\r\n" +
                "{\r\n" +
                "{\"\"}\r\n" +
                "}\r\n" +
                "},\r\n" +
                "{\"\"}\r\n" +
                "}\r\n" +
                "}");
            if (!Directory.Exists(AppDataRamming + "\\1C\\1CEStart"))
            {
                Directory.CreateDirectory(AppDataRamming + "\\1C\\1CEStart");
            }
            switch (Organization)
            {
                case "":
                    MessageBox.Show("Произошла ошибка. Обратитесь в 6911", "Настройка 1С");
                    break;
                case "kupishoes":
                    File.Copy(Shara + "\\kupishoes.v8i", AppDataRamming + "\\1C\\1CEStart\\ibases.v8i", true);
                    MessageBox.Show("Настройки внесены", "Настройка 1С");
                    break;
                case "puru":
                    File.Copy(Shara + "\\puru.v8i", AppDataRamming + "\\1C\\1CEStart\\ibases.v8i", true);
                    MessageBox.Show("Настройки внесены", "Настройка 1С");
                    break;
            }
        }

        private void ClearCache_Click(object sender, EventArgs e) //Кнопка "Очистить кеш"
        {
            switch (MessageBox.Show("Программа 1С Предприятие закроется!\r\nПродолжить?", "Настройка 1С", MessageBoxButtons.YesNo))
            {
                case DialogResult.Yes:
                    foreach (Process proc in Process.GetProcessesByName("1cv8s"))
                    {
                        proc.Kill();
                    }
                    string[] Cache = Directory.GetDirectories(AppDataLocal + "\\1C\\1cv8");
                    for (int i = 0; i < Cache.Count(); i++)
                    {
                        Directory.Delete(Cache[i], true);
                    }
                    MessageBox.Show("Кеш приложения отчищен", "Настройка 1С");
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void Helper_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(@"C:\Files\1s"))
            {
                Directory.CreateDirectory(@"C:\Files\1s");
            }
            if (!File.Exists(@"C:\Files\1s\tutorial.docx"))
            {
                File.Copy(Shara + "\\tutorial.docx", @"C:\Files\1s\tutorial.docx");
            }
            Process.Start(@"C:\Files\1s\tutorial.docx");
        }
    }
}
