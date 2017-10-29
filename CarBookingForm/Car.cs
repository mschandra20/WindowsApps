using System;

namespace CarBookingForm
{
    public class Car
    {
        public string NameofCar { get; set; }

        public int ID { get; set; }

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
                return this.dateTime;
            }
          set
          {
               if (dateTime > DateTime.Now)
                    this.dateTime = value;
          } 
        }

    }

    //public class CarListAvailable
    //{

        
        
    //}
}


