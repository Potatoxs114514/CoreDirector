using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 自动设置程序相关性
{
    public partial class Form1 : Form
    {

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filepath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retval, int size, string filePath);
        private string cfgPath = System.Windows.Forms.Application.StartupPath + "\\Config.ini";
        private string strSec = "Config";
        private string processRecord = System.Windows.Forms.Application.StartupPath + "\\ProcessRecord";

        string powerMode = "";

        public Form1()
        {
            InitializeComponent();
        }

        private string ContentValue(string Section, string key, string path)
        {
            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(Section, key, "", temp, 1024, path);
            return temp.ToString();
        }

        private void ProcessSelectBox_Click(object sender, EventArgs e)
        {
            GetProcessList();
            ProcessSelectBox.SelectionStart = ProcessSelectBox.Text.Length;
        }

        ArrayList _process;

        string[] systemProcess = { "ServiceHub.IntellicodeModelService", "svchost", "RuntimeBroker", "services", "SystemSettingsBroker", "StartMenuExperienceHost", "conhost",
            "ServiceHub.DataWarehouseHost", "Microsoft.ServiceHub.Controller", "PhoneExperienceHost", "Registry", "SecurityHealthService", "wininit", "dllhost", "ShellExperienceHost",
            "NVIDIA Web Helper", "lsass", "Widgets", "fontdrvhost", "WidgetService", "audiodg", "Idle", "StandardCollector.Service", "System", "ServiceHub.Host.AnyCPU", "WUDFHost", "Memory Compression",
            "ServiceHub.Host.dotnet.x64", "ServiceHub.Host.netfx.x86", "SearchProtocolHost", "ServiceHub.ThreadedWaitDialog", "LockApp", "SearchFilterHost", "jhi_service", "msedgewebview2", "explorer",
            "IDMMsgHost", "NVDisplay.Container", "WifiAutoInstallSrv", "ServiceHub.VSDetouredHost", "Video.UI", "ChsIME", "NVIDIA Share", "unsecapp", "ctfmon", "winlogon", "smss",
            "csrss", "FileSyncHelper", "ServiceHub.SettingsHost", "sihost", "taskhostw", "nvcontainer", "SystemSettings", "EncoderServer", "WmiPrvSE", "PerfWatson2",
            "MSBuild", "WebViewHost", "SgrmBroker", "TextInputHost", "FileCoAuth", "ServiceHub.TestWindowStoreHost", "ServiceHub.IndexingService", "WMIRegistrationService", "SearchIndexer",
            "wsctrlsvc", "smartscreen", "spoolsv", "rundll32", "msvsmon", "VBCSCompiler", "nvsphelper64", "ServiceHub.RoslynCodeAnalysisService", "AdAppMgrSvc", "dwm",
            "mDNSResponder", "pservice", "AggregatorHost", "ApplicationFrameHost", "dasHost", "SearchHost", "wmpnetwk", "DataExchangeHost", "TabTip", "MoUsoCoreWorker", "MoNotificationUx",
            "ServiceHub.IdentityHost", "", "", "", "", "", ""};

        private void AddLog(string text)
        {
            Log.AppendText(DateTime.Now.ToString("[yyyy.MM.dd HH:mm:ss]\r\n") + text + "\r\n");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            AddLog("界面初始化...");
            //关闭线程检测
            Control.CheckForIllegalCrossThreadCalls = false;
            //创建核心数控件
            for (int i = 0; i < Environment.ProcessorCount && i < 64; i++)
            {
                CoreList.Items.Add("CPU[" + i + "]");
                CoreList.SetItemChecked(i, true);
            }
            //初始化文件夹
            if (!Directory.Exists(processRecord))
                Directory.CreateDirectory(processRecord);
            //初始化设置
            if (ContentValue(strSec, "BootStartup", cfgPath) == "true")
                开机启动ToolStripMenuItem.Checked = true;
            if (ContentValue(strSec, "PowerMode", cfgPath) == "0")
            {
                平衡ToolStripMenuItem.Checked = true;
                默认ToolStripMenuItem.Checked = false;
            }
            if (ContentValue(strSec, "PowerMode", cfgPath) == "1")
            {
                高性能ToolStripMenuItem.Checked = true;
                默认ToolStripMenuItem.Checked = false;
            }
            //加载程序列表
            LoadProcessList();
        }

        private void LoadProcessList()
        {
            DirectoryInfo directory = new DirectoryInfo(processRecord + "\\");
            foreach (FileInfo info in directory.GetFiles("*.*"))
            {
                AddLog("加载进程配置[" + info.Name + "]");
                ProcessList.Items.Add(info.Name);
            }
        }

        private void GetProcessList()
        {
            ProcessSelectBox.Items.Clear();
            _process = new ArrayList();
            Process[] pro = Process.GetProcesses();
            foreach (Process process in pro)
            {
                var pn = process.ProcessName;
                //过滤系统进程
                foreach (string sp in systemProcess)
                {
                    if (pn != sp) continue;
                    pn = "";
                    break;
                }
                //过滤同名进程
                foreach (string p in _process)
                {
                    if (pn != p) continue;
                    pn = "";
                    break;
                }

                if (pn == "") continue;
                var pid = process.Id;
                _process.Add(pn);
                ProcessSelectBox.Items.Add(pn + " [" + pid + "]");
            }
        }

        private void SetCoreButton_Click(object sender, EventArgs e)
        {
            try
            {
                string processName = _process[ProcessSelectBox.SelectedIndex].ToString();
                foreach (var item in ProcessList.Items)
                {
                    if (item.ToString().ToLower() != processName.ToLower()) continue;
                    MessageBox.Show("你不能添加重复的进程", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                using (System.IO.File.Create(processRecord + "\\" + processName)) { };
                ProcessList.Items.Add(processName);
                string recordPath = processRecord + "\\" + processName;
                WritePrivateProfileString("Record", "CPU", GetCPUHex(), recordPath);
                AddLog("添加进程[" + processName + "]");
                ProcessSelectBox.Items.Clear();
            }
            catch { }
        }

        private void CoreList_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => {
                Thread.Sleep(50);
                GetCPUHex();
            });
            thread.Start();
        }

        private string GetCPUHex()
        {
            int group = 0;
            string hex = "0x";
            //每四个核心一组 过滤多余的分组
            for (int i = 15; i > 0; i--)
            {
                if (i * 4 >= Environment.ProcessorCount)
                {
                    hex += "0";
                    group = i;
                }
            }
            //单独计算每组核心的HexMask
            for (int g = group; g > 0; g--)
            {
                int num = 0;
                for (int core = (g - 1) * 4; core < g * 4; core++)
                {
                    try
                    {
                        foreach (var item in CoreList.CheckedItems)
                        {
                            int checkedCore = int.Parse(item.ToString().Replace("CPU[", "").Replace("]", ""));
                            if (checkedCore == core)
                            {
                                if (core % 4 == 0)
                                    num += 1;
                                if (core % 4 == 1)
                                    num += 2;
                                if (core % 4 == 2)
                                    num += 4;
                                if (core % 4 == 3)
                                    num += 8;
                            }
                        }
                    }
                    catch { }
                }
                hex += num.ToString("X");
            }
            CPUHexMask.Text = hex;
            return hex;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void ICON_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }

        private void ExecuteTimer_Tick(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                //设置每个进程的CPU相关性
                try 
                {
                    //进程部分
                    foreach (var item in ProcessList.Items)
                    {
                        string processName = item.ToString();
                        foreach (var process in Process.GetProcessesByName(processName))
                        {
                            Thread.Sleep(10);
                            string recordPath = processRecord + "\\" + processName;
                            if (process.ProcessorAffinity.ToInt64() != Convert.ToInt64(ContentValue("Record", "CPU", recordPath).Replace("0x", ""), 16))
                                process.ProcessorAffinity = new IntPtr(Convert.ToInt64(ContentValue("Record", "CPU", recordPath).Replace("0x", ""), 16));
                        }
                        Thread.Sleep(100);
                    }
                    //电源计划
                    GetPowerMode("powercfg /getactivescheme");
                    if (平衡ToolStripMenuItem.Checked && powerMode != "0")
                        ChangePowerMode("powercfg -s 381b4222-f694-41f0-9685-ff5bb260df2e");
                    if (高性能ToolStripMenuItem.Checked && powerMode != "1")
                        ChangePowerMode("powercfg -s 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c");
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            });
            thread.Start();
        }

        private void 启用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = System.Windows.Forms.Application.ExecutablePath;
            RegistryKey rk = Registry.LocalMachine;
            RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
            //注册表添加开机自启
            rk2.SetValue("CoreDirector", path + " -a");
            rk2.Close();
            rk.Close();
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = System.Windows.Forms.Application.ExecutablePath;
            RegistryKey rk = Registry.LocalMachine;
            RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
            //注册表删除开机自启
            rk2.DeleteValue("CoreDirector", false);
            rk2.Close();
            rk.Close();
        }

        private void 默认ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            默认ToolStripMenuItem.Checked = true;
            平衡ToolStripMenuItem.Checked = false;
            高性能ToolStripMenuItem.Checked = false;
            WritePrivateProfileString(strSec, "PowerMode", "", cfgPath);
        }

        private void 高性能ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            默认ToolStripMenuItem.Checked = false;
            平衡ToolStripMenuItem.Checked = false;
            高性能ToolStripMenuItem.Checked = true;
            WritePrivateProfileString(strSec, "PowerMode", "1", cfgPath);
        }

        private void 平衡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            默认ToolStripMenuItem.Checked = false;
            平衡ToolStripMenuItem.Checked = true;
            高性能ToolStripMenuItem.Checked = false;
            WritePrivateProfileString(strSec, "PowerMode", "0", cfgPath);
        }

        private void CPUHexMask_TextChanged(object sender, EventArgs e)
        {
            if (ProcessList.SelectedIndex == -1) return;
            string recordPath = processRecord + "\\" + ProcessList.SelectedItem.ToString();
            WritePrivateProfileString("Record", "CPU", CPUHexMask.Text, recordPath);
        }

        private void ProcessList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProcessList.SelectedIndex == -1) return;
            string recordPath = processRecord + "\\" + ProcessList.SelectedItem.ToString();
            CPUHexMask.Text = ContentValue("Record", "CPU", recordPath);
            //显示CPU相关性
            string hex = new string(ContentValue("Record", "CPU", recordPath).Replace("0x", "").Reverse().ToArray());
            for (int group = 0; group < 16; group++)
            {
                if (group * 4 >= Environment.ProcessorCount) break;
                if (hex == "") continue;
                string _hex = hex.Substring(group, 1);
                int hexNum = Convert.ToInt32(_hex, 16);
                if (hexNum >= 8)
                {
                    CoreList.SetItemChecked((group + 1) * 4 - 1, true);
                    hexNum -= 8;
                }
                else
                {
                    CoreList.SetItemChecked((group + 1) * 4 - 1, false);
                }
                if (hexNum >= 4)
                {
                    CoreList.SetItemChecked((group + 1) * 4 - 2, true);
                    hexNum -= 4;
                }
                else
                {
                    CoreList.SetItemChecked((group + 1) * 4 - 2, false);
                }
                if (hexNum >= 2)
                {
                    CoreList.SetItemChecked((group + 1) * 4 - 3, true);
                    hexNum -= 2;
                }
                else
                {
                    CoreList.SetItemChecked((group + 1) * 4 - 3, false);
                }
                if (hexNum >= 1)
                {
                    CoreList.SetItemChecked((group + 1) * 4 - 4, true);
                    hexNum -= 1;
                }
                else
                {
                    CoreList.SetItemChecked((group + 1) * 4 - 4, false);
                }
            }
        }

        private void ProcessList_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode.ToString() != "Delete") return;
            if (ProcessList.SelectedIndex == -1) return;
            DialogResult dr = MessageBox.Show("是否移除该进程?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string processName = ProcessList.SelectedItem.ToString();
                System.IO.File.Delete(processRecord + "\\" + processName);
                ProcessList.Items.Remove(ProcessList.Items[ProcessList.SelectedIndex]);
                AddLog("删除配置[" + processName + "]");
            }
        }

        private void 开机启动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = System.Windows.Forms.Application.ExecutablePath;
            RegistryKey rk = Registry.LocalMachine;
            RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
            if (!开机启动ToolStripMenuItem.Checked)
            {
                开机启动ToolStripMenuItem.Checked = true;
                WritePrivateProfileString(strSec, "BootStartup", "true", cfgPath);
                //注册表添加开机自启
                rk2.SetValue("CoreDirector", path + " -a");
                rk2.Close();
                rk.Close();
            }
            else
            {
                开机启动ToolStripMenuItem.Checked = false;
                WritePrivateProfileString(strSec, "BootStartup", "false", cfgPath);
                //注册表删除开机自启
                rk2.DeleteValue("CoreDirector", false);
                rk2.Close();
                rk.Close();
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }

        public async Task<string> GetPowerMode(params string[] cmds)
        {
            // 创建一个新的进程以执行PowerShell命令
            var process = new Process();
            process.StartInfo.FileName = "powershell.exe";
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();

            // 将命令发送到PowerShell进程并执行
            var streamWriter = process.StandardInput;
            var streamReader = process.StandardOutput;
            foreach (var cmd in cmds)
            {
                await streamWriter.WriteLineAsync(cmd);
            }
            await streamWriter.WriteLineAsync("exit");
            // 读取PowerShell输出并将其打印到控制台
            string output = process.StandardOutput.ReadToEnd();
            if (output.IndexOf("381b4222-f694-41f0-9685-ff5bb260df2e") != -1)
            {
                //平衡模式
                powerMode = "0";
            }
            else if (output.IndexOf("8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c") != -1)
            {
                //高性能模式
                powerMode = "1";
            }
            process.WaitForExit();
            return output;
        }

        public async Task<string> ChangePowerMode(params string[] cmds)
        {
            // 创建一个新的进程以执行PowerShell命令
            var process = new Process();
            process.StartInfo.FileName = "powershell.exe";
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();

            // 将命令发送到PowerShell进程并执行
            var streamWriter = process.StandardInput;
            foreach (var cmd in cmds)
            {
                await streamWriter.WriteLineAsync(cmd);
            }
            await streamWriter.WriteLineAsync("exit");
            return "";
        }

        private void CoreList_MouseUp(object sender, MouseEventArgs e)
        {
            CoreList.SelectedIndex = -1;
        }

    }
}

