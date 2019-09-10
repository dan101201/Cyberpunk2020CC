﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpunk2020CharacterCreator
{
    interface IItem
    {
        string Name { get;}
        double Weight { get;}
        string Desc { get;}
        double Cost { get;}

    }
}
