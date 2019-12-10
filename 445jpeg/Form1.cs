using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _445jpeg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog of = new OpenFileDialog();
            //For any other formats
            of.Filter = "Image Files (*.jpg;*.jpeg;)|*.JPG;*.JPEG;";
            if (of.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.ImageLocation = of.FileName;

                //code below is from https://www.dreamincode.net/forums/topic/231165-how-to-read-image-metadata-in-c%23/
                // i changed the code to display in listbox1
                

                Bitmap image = new Bitmap(of.FileName);
                PropertyItem[] propItems = image.PropertyItems;
                int count = 0;
                foreach (PropertyItem item in propItems)
                {
                    listBox1.Items.Add("Property Item " + count.ToString());
                    listBox1.Items.Add("iD: 0x" + item.Id.ToString("x"));
                    count++;
                }

                ASCIIEncoding encodings = new ASCIIEncoding();
                try
                {
                    string make = encodings.GetString(propItems[1].Value);
                    listBox1.Items.Add("The equipment make is " + make + ".");
                }
                catch
                {
                    listBox1.Items.Add("no Meta Data Found");
                }
                try
                {
                    string model = encodings.GetString(propItems[2].Value);
                    listBox1.Items.Add("The model is " + model + ".");
                }
                catch
                {
                    listBox1.Items.Add("no Model Found");
                }
                try
                {
                    string DT = encodings.GetString(propItems[15].Value);
                    listBox1.Items.Add("The Date & Time is " + DT + ".");
                }
                catch
                {
                    listBox1.Items.Add("no date Found");
                }
                // end of reused code
            }

           





            

        }
       
    

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }

}
