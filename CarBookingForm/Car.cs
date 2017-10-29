using System;

namespace CarBookingForm
{
    public class Car
    {
        public string NameofCar { get; set; }

        public int ID { get; set; }
        private DateTime m_dateTime;
        public int MakeYear
        {
            get
            {
                return this.MakeYear;
            }
            set
            {
                if (value < 2017 && value > 1800)
                    this.MakeYear = value;
            }
        }

        public DateTime dateTime
        {
            get
            {
                return m_dateTime;
            }
          set
          {
                //This statement is not needed as we disabled the date before today
               //if (value > DateTime.Now)
                    m_dateTime = value;
          } 
        }

    }

    //public class CarListAvailable
    //{

        
        
    //}
}


