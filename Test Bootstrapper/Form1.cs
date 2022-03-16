using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_Bootstrapper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void log_in_Click(object sender, EventArgs e)
        {
            //installation:
            WebClient wc = new WebClient();//strings the webclient to wc
            String program = "Test";//ur exe name or what ever ur downloading
            String link = "https://raw.githubusercontent.com/FabiFNA/pastes/main/DL%20Link%20%22TestApp%22";//ur .exe link in RAW
            String download = wc.DownloadString(link);//reads the data of the link
            String path = @"TEST-DATA\" + program + ".exe";//change the txt to exe or what ever u wanna auto download
            String patch = (@"TEST-DATA\");//strings directory name
            Directory.CreateDirectory(patch);//creates the directory.
            wc.DownloadFile(download, path);//downloads the actual file

            //creates workspace folder
            String path_workspace = @"TEST-Data\workspace\";
            Directory.CreateDirectory(path_workspace);

            //creates bin folder
            String path_bin = @"TEST-Data\bin\";
            Directory.CreateDirectory(path_bin);

            //opens install where "TEST" is located (optional)
            System.Diagnostics.Process.Start("explorer.exe", @"TEST-DATA\");
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        int mov;
        int movX;
        int movY;

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void label3_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var key = string.Empty;
            using (var webClient = new System.Net.WebClient())
            {
                key = webClient.DownloadString("https://pastebin.com/raw/p1QfDWnf"); //Enter the link of your pastebin raw file
            }

            label2.Text = key;
        }
    }
}
