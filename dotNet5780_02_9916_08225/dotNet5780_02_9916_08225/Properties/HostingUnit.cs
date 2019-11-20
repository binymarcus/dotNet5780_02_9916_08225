using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_02_9916_08225.Properties
{
    class HostingUnit:IComparable
    {
        private static int stSerialKey;  // unit id/ number
        public readonly int HostingUnitKey;  //current hosting unit
        public bool[,] Diary = new bool[12,31];  //matrix, repersent if occupied or vacent

        public HostingUnit(bool[,] diary)
        {
            HostingUnitKey = stSerialKey;
            Diary = diary;
        }
        public HostingUnit()//default constructor sets the entire ,atrix to false
        {
            HostingUnitKey = stSerialKey;// sets the host unit to the serial key
            for (int i = 0; i < 12; i++)  // initializes the matrix as false - all vacent
            {
                for (int j = 0; j < 31; j++)
                {
                    Diary[i, j] = false;
                }
            }
        }
        public override string ToString()// override for tostring, print the serial number then the start and end date of each vacation
        {
            Console.WriteLine("serial number: {0}", HostingUnitKey);
            ArrayList Date = VacationDates();// calculates the end dates of each function
            for (int i = 0; i < Date.Count; i+=4)
            { 
                Console.WriteLine("Start Date: {0}.{1} , End Date:{2}.{3}", (int)Date[i]+1, (int)Date[i + 1]+1, (int)Date[i + 2]+1, (int)Date[i + 3]+1);
                // prints start and end dates for each vacation
            }
            return base.ToString();
        }
        public bool ApproveRequest(GuestRequest guestReq)//checks if dates for vacation or vacent
        {                                                  // if vacent then the requst is accepted
            int length = 31;
            for (int i = 0; i <= guestReq.ReleaseDate[1] - 1; i++)
            {
                if (i == guestReq.ReleaseDate[1] - 1)
                    length = guestReq.ReleaseDate[0] - 1;
                for (int j = 0; j < length; j++)
                {
                    if (Diary[i, j] == true)
                        return false;
                }
            }
            setVacation(guestReq, length); // sets the vaction dates in the matrix
            return true;
        }
        public int GetAnnualBusyPrecentege()//returns amount of days occupied
        {
           int count = 0;
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    if (Diary[i, j] == true)
                        count++;
                }
            }
            return count;
        }  
        private void setVacation(GuestRequest guestReq, int length)// changes the matrix dates to true for the vaction dates
        {
            guestReq.IsApproved = true;
            for (int i = 0; i <= guestReq.ReleaseDate[1] - 1; i++)
            {
                length = 31;
                if (i == guestReq.ReleaseDate[1] - 1)
                    length = guestReq.ReleaseDate[0] - 1;
                for (int j = 0; j < length; j++)
                {
                    Diary[i, j] = true;
                }
            }
        } 
        public float GetAnnualBusyPercentage()//returns the percent of occupied dates
        {
            return (GetAnnualBusyDays()/372)*100;
        } 
        private ArrayList VacationDates()//returns list of dates of occupied days
        {
            bool occupied = false;
            ArrayList Dates = new ArrayList();
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    if (Diary[i, j] != occupied)
                    {
                        Dates.Add(i + 1);
                        Dates.Add(j + 1);
                        occupied = !occupied;
                    }
                }
            }
            return Dates;
        }

        public int CompareTo(Object obj)
        {
            return GetAnnualBusyDays().CompareTo(((HostingUnit)obj).GetAnnualBusyDays());
        }
    }
}
