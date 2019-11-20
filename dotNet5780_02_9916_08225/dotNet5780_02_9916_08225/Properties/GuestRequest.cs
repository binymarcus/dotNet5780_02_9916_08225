using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_02_9916_08225.Properties
{
    class GuestRequest
    {
        public DateTime EntryDate = new DateTime();
        public int[] ReleaseDate = new int[3];
        public bool IsApproved;

        public GuestRequest(int[] entryDate, int[] releaseDate, bool isApproved)
        {
            EntryDate = entryDate;
            ReleaseDate = releaseDate;
            IsApproved = isApproved;
        }

        public GuestRequest()
        {
            EntryDate = new int[3] { 1, 1, 2020 };
            ReleaseDate = new int[3] { 2, 1, 2020 };
            IsApproved = false;
        }
        public override string ToString()
        {
            Console.WriteLine("Entry Date: {0}.{1}.{2} Release Date: {3}.{4}.{5} is approved: {6}", EntryDate[0], EntryDate[1], EntryDate[2], ReleaseDate[0], ReleaseDate[1], ReleaseDate[2], IsApproved);
            return base.ToString();
        }
    }
}