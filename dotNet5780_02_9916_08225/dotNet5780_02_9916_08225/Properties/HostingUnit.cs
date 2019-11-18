using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_02_9916_08225.Properties
{
    class HostingUnit
    {
        private static int stSerialKey;
        public readonly int HostingUnitKey;
        bool[,] Diary = new bool[12,31];

        public HostingUnit(bool[,] diary)
        {
            HostingUnitKey = stSerialKey;
            Diary = diary;
        }
        public HostingUnit()//default constructor sets the entire ,atrix to false
        {
            HostingUnitKey = stSerialKey;// sets the host unit to the serial key
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    Diary[i, j] = false;
                }
            }
        }
            public override string ToString()// override for to string print the serial number then the start and end date of each vacation
        {
            Console.WriteLine("serial number: {0}", HostingUnitKey);
            ArrayList Date = VacationDates();// calculatesd the end dates if each function
            for (int i = 0; i < Date.Count; i+=4)
            { 
                Console.WriteLine("Start Date: {0}.{1} , End Date:{2}.{3}", (int)Date[i]+1, (int)Date[i + 1]+1, (int)Date[i + 2]+1, (int)Date[i + 3]+1);

            }
            return base.ToString();
        }
        public bool ApproveRequest(GuestRequest guestReq)//
        {
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
            setVacation(guestReq, length);
            return true;
        }
        public int GetAnnualBusyDays()
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
        private void setVacation(GuestRequest guestReq, int length)
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
        public float GetAnnualBusyPercentage()
        {
            return (GetAnnualBusyDays()/372)*100;
        }
        private ArrayList VacationDates()
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
    }
}
