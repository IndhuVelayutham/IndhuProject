using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    class Program
    {

        static List<char> box = new List<char> { 'a', 'a', 'b', 'b', 'c', 'c', 'd', 'd', 'e', 'e', 'f', 'f', 'g', 'g', 'h', 'h', 'i', 'i', 'j', 'j' };
        static void Main(string[] args)
        {

            int userChance = 40, prevIndex, currIndex, indexer = 1;
            prevIndex = currIndex = 0;
            bool win = false;
            //User Chances
            while (userChance > 0)
            {
                prevIndex = currIndex;
                Console.WriteLine("Please select a box from below:");
                indexer = 1;
                //display available boxes to User
                foreach (char item in box)
                {
                    Console.WriteLine("Box: {0}", indexer);
                    indexer++;
                }

                //User Selected box
                currIndex = Convert.ToInt32(Console.ReadLine());
                if (prevIndex > 0)
                {
                    if (box[prevIndex - 1].Equals(box[currIndex - 1]))
                    {
                        box.RemoveAt(currIndex - 1);
                        box.RemoveAt(prevIndex - 1);
                        prevIndex = currIndex = 0;
                    }
                }

                //User chance gets Reduced
                userChance--;

                //Deciding game status
                if (box.Count == 0)
                {
                    win = true;
                    break;
                }

            }
            // display game status to user
            if (win)
                Console.WriteLine("User wins");
            else
                Console.WriteLine("User Lost");
            Console.ReadKey();
        }
    }
}
