using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CarBookingForm
{
    public partial class Form1 : Form
    {
        #region variables and stacks
        //Creating stacks
        Stack<Car> HBStack = new Stack<Car>(10);
        Stack<Car> SEDANStack = new Stack<Car>(10);
        Stack<Car> SUVStack = new Stack<Car>(10);

        Stack<Car> BookingList = new Stack<Car>();

        private int HBCount = 0;
        private int SEDANCount = 0;
        private int SUVCount = 0;

        private bool button1Clicked = false;
        private bool button2Clicked = false;
        private bool button3Clicked = false;
        #endregion

        #region Constructor
        //Constructor
        public Form1()
        {

            InitializeComponent();
            InitializeStack();

            dateTimePicker1.Enabled = false;

            button5.Enabled = false;
            button7.Enabled = false;

            label1.Text = "Hatch Back Car";
            label2.Text = "Sedan";
            label3.Text = "SUV";

        }
        #endregion

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

        //////////////////////////////////////////////////////////////////
        
        //Check Availability buttons
        private void button1_Click(object sender, EventArgs e)
        {
            button1Clicked = true;

            CheckAvailability();
            button1Clicked = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            button2Clicked = true;

            CheckAvailability();
            button2Clicked = false;


        }
        private void button3_Click(object sender, EventArgs e)
        {
            button3Clicked = true;

            CheckAvailability();
            button3Clicked = false;
        }

        //BookNow Button
        private void button5_Click(object sender, EventArgs e)
        {
            Enabler();
            BookNow();
        }

        //Submit Button
        private void button7_Click(object sender, EventArgs e)
        {
            //Thread workThread = new Thread(Submission);
            //workThread.Start();
            //label4.Text = st.ElapsedTicks.ToString();
        }

        #endregion

        #region User Defined methods

        private void InitializeStack()
        {
            for (int i = 0; i < 10; i++)
            {
                Car HB = new Car() { ID = i, NameofCar = "HatchBackFiat" };
                HBStack.Push(HB);
            }
            for (int i = 0; i <10; i++)
            {
                Car SEDAN = new Car() { ID = i, NameofCar = "SedanHonda" };
                SEDANStack.Push(SEDAN);
            }
            for (int i = 0; i < 10; i++)
            {
                Car SUV = new Car() { ID = i, NameofCar = "SUVToyota" };
                SUVStack.Push(SUV);
            }
        }
        private void CheckAvailability()
        {

            if (button1Clicked)
            {
                if (HBStack.Count > 0)
                {
                    Availability_Display.Text = "Yes! This car is available." +
                          "\nClick below To Book Now";
                    HBCount++;
                }
                else
                    Availability_Display.Text = "Sorry! This car is not available." +
                        "Please checkout other cars";
            
                button5.Enabled = true;
            }
            if (button2Clicked)
            {
                if (SEDANStack.Count > 0)
                {
                    Availability_Display.Text = "Yes! This car is available." +
                          "\nClick below To Book Now";
                    SEDANCount++;
                }
                else
                    Availability_Display.Text = "Sorry! This car is not available." +
                        "Please checkout other cars";

                button5.Enabled = true;
            }
            if (button3Clicked)
            {
                if (SUVStack.Count > 0)
                {
                    Availability_Display.Text = "Yes! This car is available." +
                          "\nClick below To Book Now";
                    SUVCount++;
                }
                else
                    Availability_Display.Text = "Sorry! This car is not available." +
                        "Please checkout other cars";

                button5.Enabled = true;
            }
                      
        }
        private void BookNow()
        {
            int MaxCount=Math.Max(Math.Max(HBCount, SEDANCount), SUVCount);
            if (MaxCount == HBCount)
                BookingList.Push(BookNowHB());
            if (MaxCount == SEDANCount)
                BookingList.Push(BookNowSEDAN());
            if (MaxCount == SUVCount)
                BookingList.Push(BookNowSUV());

            label4.Text = BookingList.Count.ToString();
        }

        private Car BookNowHB()
        {
            return HBStack.Pop();
        }
        private Car BookNowSEDAN()
        {
            return SEDANStack.Pop();
        }
        private Car BookNowSUV()
        {
            return SUVStack.Pop();
        }

        private void Enabler()
        {
            dateTimePicker1.Enabled = true;
            button7.Enabled = true;
        }

        //private void Submission()
        // {
        //BookNow();
        //label4.Text = "You Have Succesfully Booked Your Car ! :)";

        //Thread.Sleep(10000);
        //CarBookedList.Clear();
        //int num = CarBookedList.Capacity;
        //label4.Text = num.ToString();
        //label4.Text = Convert.ToString(num);
        //}
        #endregion

        #region Unused methods

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {


        }

        /////////////////////////////////////////////////////////////////

        #endregion

    }

}

