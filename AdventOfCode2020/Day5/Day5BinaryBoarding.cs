using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day5
{

    public class Seat
    {
        string _seatCode;
        public int SeatID { get { return Row * 8 + Column; } }
        public int Row
        {
            get
            {
                var rowCode = _seatCode.Substring(0, 7);
                var row = GetPosition(rowCode, 0, 127, 'F');
                return row;
            }
        }
        public int Column
        {
            get
            {
                var colCode = _seatCode.Substring(7, 3);
                var col = GetPosition(colCode, 0, 7, 'L');
                return col;
            }
        }

        public Seat(string seatCode)
        {
            _seatCode = seatCode;
        }

        private int GetPosition(string positionCode,
                                int head, int tail, char front)
        {
            int index = 0;
            int half;
            do
            {
                half = (tail - head) / 2;
                if (half == 0)
                    return positionCode[index++] == front ? head : tail;
                if (positionCode[index++] == front)
                    tail = head + half;
                else
                    head = head + half + 1;
            } while (half != 0);
            return -1;
        }
    }
    public class Day5BinaryBoarding
    {

        public Day5BinaryBoarding()
        {
            string path = @"C:\Users\amielc1\source\repos\AdventOfCode2020\AdventOfCode2020\Day5\Day5Input.txt";
            var seats = File.ReadAllLines(path).ToList();
            var maxSeat  = seats.Select(s => new Seat(s)).Max(seat =>seat.SeatID);


        }
    }
}
