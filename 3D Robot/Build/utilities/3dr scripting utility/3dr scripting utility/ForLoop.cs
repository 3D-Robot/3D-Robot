using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3dr_scripting_utility
{
    public partial class ForLoop : Form
    {
        public ForLoop()
        {
            InitializeComponent();
        }

        private void okbutton_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();

            for(int i = 0; i < int.Parse(arraylegnthtext[0].Text);i++)
            {
                for(int j = 0; j < int.Parse(arraylegnthtext[1].Text);j++)
                {
                   f.createobject();
                }
            }
        }


        int numofdimensions;
        System.Windows.Forms.TextBox[] textbox = new TextBox[0];
        Label[] variablelabel = new Label[0];
        Label[] arraylegnth = new Label[0];
        TextBox[] arraylegnthtext = new TextBox[0];

        private void dimensionokbutton_Click(object sender, EventArgs e)
        {
            numofdimensions = int.Parse(dimensiontext.Text);
            textbox = new TextBox[numofdimensions];
            variablelabel = new Label[numofdimensions];
            arraylegnth = new Label[numofdimensions];
            arraylegnthtext = new TextBox[numofdimensions];

            for (int i = 0; i < numofdimensions;i++)
            {
                textbox[i] = new TextBox();
                textbox[i].Location = new Point(12, 100 + i*50);
                textbox[i].Size = new Size(100,22);
                this.Controls.Add(textbox[i]);
                textbox[i].Enabled = true;
                textbox[i].Visible = true;

                variablelabel[i] = new Label();
                variablelabel[i].Location = new Point(12, 85 + i * 50);
                variablelabel[i].Size = new Size(150, 20);
                this.Controls.Add(variablelabel[i]);
                variablelabel[i].Enabled = true;
                variablelabel[i].Visible = true;
                variablelabel[i].Text = "enter variable #" + i;

                arraylegnth[i] = new Label();
                arraylegnth[i].Location = new Point(12, 85 + i * 50 + (50 * numofdimensions));
                arraylegnth[i].Size = new Size(150, 20);
                this.Controls.Add(arraylegnth[i]);
                arraylegnth[i].Enabled = true;
                arraylegnth[i].Visible = true;
                arraylegnth[i].Text = "enter the legnth of array #" + i;


                arraylegnthtext[i] = new TextBox();
                arraylegnthtext[i].Location = new Point(12, 110 + i * 50 + (50*numofdimensions));
                arraylegnthtext[i].Size = new Size(100, 22);
                this.Controls.Add(arraylegnthtext[i]);
                arraylegnthtext[i].Enabled = true;
                arraylegnthtext[i].Visible = true;
            }
        }
    }
}
