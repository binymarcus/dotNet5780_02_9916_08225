using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_02_9916_08225.Properties
{
    class Host:IEnumerable
    {
        public int HostKey;
        List<HostingUnit> HostingUnitCollection;

        public Host(int hostKey, int NumberOfUnits)// constructor recieves hostkey and number of units and sets all units to empty
        {
            HostKey = hostKey;
            HostingUnitCollection = new List<HostingUnit>(NumberOfUnits);
            for (int i = 0; i < NumberOfUnits; i++)
            {
                HostingUnitCollection[i] = new HostingUnit();
            }
        }
        public override string ToString()// override for Tostring that prints
        {
            foreach(HostingUnit item in HostingUnitCollection)
            {
                item.ToString();
            }
            return base.ToString(); 
        }
        private long SubmitRequest(GuestRequest guestReq)// gets a request for a vacation and finds the first availeble hotel
        {
            foreach (HostingUnit item in HostingUnitCollection)
            {
                if (item.ApproveRequest(guestReq))
                    return item.HostingUnitKey;
            }
            return -1;// if none avaoleble returns -1
        }
        public int GetHostAnnualBusyDays()// returns the sum total of days in all hotels
        {
            int sum = 0;
            foreach (HostingUnit item in HostingUnitCollection)
            {
                sum += item.GetAnnualBusyDays();
            }
            return sum;
        }
        public void SortUnits()// sorts the entire collection by number of vacancies.least first
        {
            HostingUnitCollection.Sort();
        }
        public bool AssignRequests(params GuestRequest[] GuestList)// assigns a changing number of guests to vacations
        {
            bool flag = true;
            for (int i = 0; i < GuestList.Length; i++)
            {
                if (SubmitRequest(GuestList[i]) == -1)
                    flag=false;
            }
            return flag;
        }

        public IEnumerator GetEnumerator()//ask goldshmit
        {
            return MyEnumerator();
      }

        public int this[int indexer]//help
        {// what the hell do u want
      
          
        }

            }
}
