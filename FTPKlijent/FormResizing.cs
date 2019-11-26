using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTPKlijent
{
    static class FormResizing
    {
        static int glavnaForma_pocetno_Width;          // pocetna duljina FlavnaForma
        static int glavnaForma_pocetno_Height;         // pocetna visina FlavnaForma

        static int treeView_lokalniDiskovi_pocetno_Width;
        static int treeView_lokalniDiskovi_pocetno_Height;

        static int richTextBox_FTPDisplay_pocetno_Width;
        static int richTextBox_FTPDisplay_pocetno_Height;

        static int treeView_Server_pocetno_Width;
        static int treeView_Server_pocetno_Height;
        static int treeView_Server_pocetno_LocationX;
        static int treeView_Server_pocetno_LocationY;

        static int listviewContentLocal_pocetno_Height;
        static int listviewContentLocal_pocetno_Width;
        static int listviewContentLocal_pocetno_LocationX;
        static int listviewContentLocal_pocetno_LocationY;

        static int listviewContentServer_pocetno_Width;
        static int listviewContentServer_pocetno_Height;
        static int listviewContentServer_pocetno_LocationX;
        static int listviewContentServer_pocetno_LocationY;

        static int panel1_pocetno_Width;
        static int panel1_pocetno_Height;

        static int panel2_pocetno_Width;
        static int panel2_pocetno_Height;
        static int panel2_pocetno_LocationX;
        static int panel2_pocetno_LocationY;

        static int panel3_pocetno_Width;
        static int panel3_pocetno_Height;
        static int panel3_pocetno_LocationX;
        static int panel3_pocetno_LocationY;




        public static void Dimenzije(Form_Glavna mainForm)
        {
            glavnaForma_pocetno_Width = mainForm.Width;     // pocetna duljina FlavnaForma
            glavnaForma_pocetno_Height = mainForm.Height;   // pocetna visina FlavnaForma

            richTextBox_FTPDisplay_pocetno_Width = mainForm.richTextBox_FTPDisplay.Width;
            richTextBox_FTPDisplay_pocetno_Height = mainForm.richTextBox_FTPDisplay.Height;


            treeView_lokalniDiskovi_pocetno_Width = mainForm.treeView_lokalniDiskovi.Width;
            treeView_lokalniDiskovi_pocetno_Height = mainForm.treeView_lokalniDiskovi.Height;

            treeView_Server_pocetno_Width = mainForm.treeView_Server.Width;
            treeView_Server_pocetno_Height = mainForm.treeView_Server.Height;
            treeView_Server_pocetno_LocationX = mainForm.treeView_Server.Location.X;
            treeView_Server_pocetno_LocationY = mainForm.treeView_Server.Location.Y;


            listviewContentLocal_pocetno_Height = mainForm.listviewContentLocal.Height;
            listviewContentLocal_pocetno_Width = mainForm.listviewContentLocal.Width;
            listviewContentLocal_pocetno_LocationX = mainForm.listviewContentLocal.Location.X;
            listviewContentLocal_pocetno_LocationY = mainForm.listviewContentLocal.Location.Y;

            listviewContentServer_pocetno_Width = mainForm.listviewContentServer.Width;
            listviewContentServer_pocetno_Height = mainForm.listviewContentServer.Height;
            listviewContentServer_pocetno_LocationX = mainForm.listviewContentServer.Location.X;
            listviewContentServer_pocetno_LocationY = mainForm.listviewContentServer.Location.Y;

            panel1_pocetno_Width = mainForm.panel1.Width;
            panel1_pocetno_Height = mainForm.panel1.Height;

            panel2_pocetno_Width = mainForm.panel2.Width;
            panel2_pocetno_Height = mainForm.panel2.Height;
            panel2_pocetno_LocationX = mainForm.panel2.Location.X;
            panel2_pocetno_LocationY = mainForm.panel2.Location.Y;

            panel3_pocetno_Width = mainForm.panel3.Width;
            panel3_pocetno_Height = mainForm.panel3.Height;
            panel3_pocetno_LocationX = mainForm.panel3.Location.X;
            panel3_pocetno_LocationY = mainForm.panel3.Location.Y;
        }





        public static void Resize(Form_Glavna mainForm)
        {
            int novo_glavnaForma_Width = mainForm.Width;
            int novo_glavnaForma_Height = mainForm.Height;
            int razlikaGlavnaForma_Width = novo_glavnaForma_Width - glavnaForma_pocetno_Width;
            int razlikaGlavnaForma_Height = novo_glavnaForma_Height - glavnaForma_pocetno_Height;

            // richTextBox_FTPDisplay
            mainForm.richTextBox_FTPDisplay.Width = richTextBox_FTPDisplay_pocetno_Width + razlikaGlavnaForma_Width;


            // treeView_lokalniDiskovi
            mainForm.treeView_lokalniDiskovi.Width = treeView_lokalniDiskovi_pocetno_Width + razlikaGlavnaForma_Width / 2;
            mainForm.treeView_lokalniDiskovi.Height = treeView_lokalniDiskovi_pocetno_Height + razlikaGlavnaForma_Height / 3;

            // treeView_Server
            mainForm.treeView_Server.Location = new Point(treeView_Server_pocetno_LocationX + razlikaGlavnaForma_Width / 2, treeView_Server_pocetno_LocationY);
            mainForm.treeView_Server.Width = treeView_Server_pocetno_Width + razlikaGlavnaForma_Width / 2;
            mainForm.treeView_Server.Height = treeView_Server_pocetno_Height + razlikaGlavnaForma_Height / 3;

            // listviewContentLocal
            mainForm.listviewContentLocal.Width = listviewContentLocal_pocetno_Width + razlikaGlavnaForma_Width / 2;
            mainForm.listviewContentLocal.Height = listviewContentLocal_pocetno_Height + razlikaGlavnaForma_Height / 3;
            mainForm.listviewContentLocal.Location = new Point(listviewContentLocal_pocetno_LocationX, listviewContentLocal_pocetno_LocationY + razlikaGlavnaForma_Height / 3);


            // listviewContentServer
            mainForm.listviewContentServer.Location = new Point(listviewContentServer_pocetno_LocationX + razlikaGlavnaForma_Width / 2, listviewContentServer_pocetno_LocationY + razlikaGlavnaForma_Height / 3);
            mainForm.listviewContentServer.Width = listviewContentServer_pocetno_Width + razlikaGlavnaForma_Width / 2;
            mainForm.listviewContentServer.Height = listviewContentServer_pocetno_Height + razlikaGlavnaForma_Height / 3;

            // panel1
            mainForm.panel1.Width = panel1_pocetno_Width + razlikaGlavnaForma_Width / 2;

            // panel2
            mainForm.panel2.Width = panel2_pocetno_Width + razlikaGlavnaForma_Width / 2;
            mainForm.panel2.Location = new Point(panel2_pocetno_LocationX + razlikaGlavnaForma_Width / 2, panel2_pocetno_LocationY);

            // panel3
            mainForm.panel3.Location = new Point(panel3_pocetno_LocationX + razlikaGlavnaForma_Width / 2, panel3_pocetno_LocationY + razlikaGlavnaForma_Height / 3);
        }









    }
}
