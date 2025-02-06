using PacMan.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Assets
{
    //0 - enemy up/down movement
    //1 - enemy left/right movement
    internal static class Maps
    {
        public static MapBlueprint Map2 = new MapBlueprint()
        {
            Map =
            [
            "XXXXXXXXXX" ,
            "X    XP 0X" ,
            "XXX   XX X" ,
            "X1  X X  X" ,
            "XXX X XX X" ,
            "X   X XX X" ,
            "X   X    X" ,
            "XXX XXX  X" ,
            "XT  X1   X" ,
            "XXXXXXXXXX" ,
            ],

            LengthX = 10,
            LengthY = 10,
        };
        public static MapBlueprint Map1 = new MapBlueprint()
        {
            Map =
            [
            "XXXXXXXXXX" ,
            "X****XP*0X" ,
            "XXX***XX*X" ,
            "X1**X*X**X" ,
            "XXX*X*XX*X" ,
            "X **X*XX*X" ,
            "X***X****X" ,
            "XXX*XXX**X" ,
            "XT**X1***X" ,
            "XXXXXXXXXX" ,
            ],

            LengthX = 10,
            LengthY = 10,
        };

    }
}
