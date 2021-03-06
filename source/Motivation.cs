﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpunk2020Library
{
    [Serializable]
    public class Motivation
    {   
        string _personalityTraits;
        string _mostValuedPerson;
        string _mostValued;
        string _feelingAbout;
        string _mostValuedPossesion;

        /// <summary>
        /// Randomly generates a Motivation
        /// </summary>
        /// <returns></returns>
        public static Motivation RandomlyGenerateMotivation()
        {
            Random rnd = new Random();
            Motivation temp = new Motivation();
            //Reads text file full of motivations
            string[] lines = Properties.Resources.Motivation.Split('\n');
            int random = rnd.Next(1,10);
            temp._personalityTraits = lines[random];
            random = rnd.Next(1, 10);
            temp._mostValuedPerson = lines[random+10];
            random = rnd.Next(1, 10);
            temp._mostValued = lines[random+20];
            random = rnd.Next(1, 10);
            temp._feelingAbout = lines[random + 30];
            random = rnd.Next(1, 10);
            temp._mostValuedPossesion = lines[random + 40];
            return temp;
        }

    }
}
