using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace _3dr_scripting_utility
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void createobjectbutton_Click(object sender, EventArgs e)
        {
            fulltext.Text = createobject();

            objecttext.Text = "";
            materialtext.Text = "";
            posxtext.Text = "";
            posytext.Text = "";
            posztext.Text = "";
            rotxtext.Text = "";
            rotytext.Text = "";
            rotztext.Text = "";
            sizextext.Text = "";
            sizeytext.Text = "";
            sizeztext.Text = "";
            prioritytext.Text = "";
            nametext.Text = "";
        }

        private void forloopbutton_Click(object sender, EventArgs e)
        {

            //we allow them to enter in a interator variable (as many dimensions as they want)
            //and we go through it updating the number as they want (we do support multidimensional for loops)
            ForLoop forLoop = new ForLoop();
            forLoop.Show();
            
            string input = "";
            /*
            int numoftimes = int.Parse(input);
            for(int i = 0; i < numoftimes;i++)
            {
                fulltext.Text = createobject();
            }
            */
        }

        public string createobject()
        {
            string objectstring = "";
            string objecttype = objecttext.Text;
            string material = materialtext.Text;
            string posx = posxtext.Text;
            string posy = posytext.Text;
            string posz = posztext.Text;
            string rotx = rotxtext.Text;
            string roty = rotytext.Text;
            string rotz = rotztext.Text;
            string sizex = sizextext.Text;
            string sizey = sizeytext.Text;
            string sizez = sizeztext.Text;
            string priority = prioritytext.Text;
            string username = nametext.Text;

            //set defualt priority based on material which is crutial
            if(priority == "")
            {
                switch(material)
                {
                    case "pla":
                        priority = "100";
                        break;
                    case "plastic":
                        priority = "100";
                        break;
                    case "aluminum":
                        priority = "400";
                        break;
                    case "copper":
                        priority = "500";
                        break;
                    case "steel":
                        priority = "600";
                        break;
                    case "wood":
                        priority = "300";
                        break;
                    case "glass":
                        priority = "700";
                        break;
                    case "nothing":
                        priority = "10000";
                        break;
                    case "air":
                        priority = "0";
                        break;
                    default:
                        priority = "400";
                        break;
                }
            }

            objectstring = Environment.NewLine + "object" + Environment.NewLine +
            "material " + material + Environment.NewLine +
            "position(" + posx + " ," + posy + "," + posz + ")" + Environment.NewLine +
            "rotation(" + rotx + "," + roty + "," + rotz + ")" + Environment.NewLine +
             objecttype +"(" + sizex + "," + sizey + "," + sizez + ")" + Environment.NewLine + 
            "Priority = " + priority + Environment.NewLine + 
            "name = " + username + Environment.NewLine;

            return fulltext.Text + objectstring;
        }

        private void objecttext_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
