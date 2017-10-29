using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace CarBookingForm
{
    public partial class Form1 : Form
    {
        //Stopwatch st = new Stopwatch();
        //Creating a list
        List<Car> CarBookedList = new List<Car>();

        /// <summary>
        /// Constructor
        /// </summary>

        public Form1()
        {

            InitializeComponent();
            dateTimePicker1.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            label1.Text = "Hatch Back Car."; label2.Text = "Sedan."; label3.Text = "SUV.";
        }

        
        #region EventHandlers
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            label1.Text = "Hatch Back Car.\nClick below for availability";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            label2.Text = "Sedan.\nClick below for availability";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            label3.Text = "SUV.\nClick below for availability";
        }
        


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckAvailability();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CheckAvailability();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            CheckAvailability();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Enabler();
            button5.Enabled = false;
            button6.Enabled = false;
            BookNowHB();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Enabler();
            if(button1_Click( )
            BookNowSEDAN();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Enabler();
            button4.Enabled = false;
            button5.Enabled = false;
            BookNowSUV();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)//Submit
        {
            Thread workThread = new Thread(Submission);
            workThread.Start();
            label4.Text = st.ElapsedTicks.ToString();
        }

        #endregion

        #region User Defined methods

        private void CheckAvailability()
        {
            if (CarBookedList.Contains(new Car().NameofCar == ""))       /*(a=>a.DateTime=="")||CarBookedList==null)*/
            {
                Availability_Display.Text = "Yes! This car is Available." +
                    "\nClick below To Book Now";
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
            }
            else///HERE EXCEPTION IS OCCURING
            {
                int i = CarBookedList.FindIndex(a => a.DateTime < DateTime.Now);

                Availability_Display.Text = "Sorry the selected type of car is not available right now!\nIt will be available after" + CarBookedList[i].ToString();
                ;// +
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                //        
            }
        }
        private void BookNow()
        {

            int index = CarBookedList.FindIndex(c => c.DateTime < DateTime.Now);
            if (index != -1)
            {
                string theDate = dateTimePicker1.Value.ToString("dd-hh-mm-ss");
                CarBookedList[index] = new Car() { DateTime = theDate };
            }

        }
        private void BookNowHB()
        {
            Car hb = new Car()
            {
                NameOfTheCar = "HB",
                DateTime = DateTime.Now
            };
            CarBookedList.Add(hb);
        }
        private void BookNowSEDAN()
        {
            Car sedan = new Car()
            {
                NameOfTheCar = "SEDAN",
                DateTime = DateTime.Now
            };
            CarBookedList.Add(sedan);
        }
        private void BookNowSUV()
        {
            Car suv = new Car()
            {
                NameOfTheCar = "SUV",
                DateTime = DateTime.Now
            };
            CarBookedList.Add(suv);
        }
        private void Enabler()
        {
            dateTimePicker1.Enabled = true;
            button7.Enabled = true;
        }
        private void Submission()
        {
            BookNow();
            label4.Text = "You Have Succesfully Booked Your Car ! :)";

            Thread.Sleep(10000);
            CarBookedList.Clear();
            int num = CarBookedList.Capacity;
            label4.Text = num.ToString();
            label4.Text = Convert.ToString(num);
        }
        #endregion

    }

}

