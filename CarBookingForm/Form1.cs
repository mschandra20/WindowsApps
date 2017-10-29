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
        Stack<Car> HBStack = new Stack<Car>(10);
        Stack<Car> SEDANStack = new Stack<Car>(10);
        Stack<Car> SUVStack = new Stack<Car>(10);
       
        

        private bool button1Clicked = false;
        private bool button2Clicked = false;
        private bool button3Clicked = false;

        /// <summary>
        /// Constructor
        /// </summary>

        public Form1()
        {

            InitializeComponent();
            InitializeStack();
            dateTimePicker1.Enabled = false;
            button5.Enabled = false;
            button7.Enabled = false;
            label1.Text = "Hatch Back Car."; label2.Text = "Sedan."; label3.Text = "SUV.";

        }

        private void InitializeStack()
        {
            for (int i = 0; i < HBStack.Count; i++)
            {
                Car HB = new Car() { ID=i,NameofCar="HatchBackFiat" };
            }
            for (int i = 0; i < SEDANStack.Count; i++)
            {
                Car SEDAN = new Car() { ID = i, NameofCar = "SedanHonda" };
            }
            for (int i = 0; i < SUVStack.Count; i++)
            {
                Car SUV = new Car() { ID = i, NameofCar = "SUVToyota" };
            }
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
            button1Clicked = true;

            CheckAvailability();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2Clicked = true;

            CheckAvailability();
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3Clicked = true;

            CheckAvailability();

        }

     

        private void button5_Click(object sender, EventArgs e)
        {
            Enabler();
            if (button1Clicked) BookNowHB();
            if (button2Clicked) BookNowSEDAN();
            if (button3Clicked) BookNowSUV();

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

