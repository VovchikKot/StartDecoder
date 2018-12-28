using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StartDecoder
{
    class searchSignaling
    {
        BitArray Preamble_P1 = new BitArray(new bool[12]
        {
            false, false, true, true,false, false, true, false,false,false,true,true
        });
        BitArray Preamble_P2 = new BitArray(new bool[12]
        {
            true, false, false, true,true, false, true, false,true,false,false,true
        });
        BitArray Preamble_P3 = new BitArray(new bool[12]
        {
            false, false, false, true,false, true, false, false,false,true,true,true
        });
        BitArray CorectSequerens = new BitArray(new bool[12]
        {
            false, false, false, true,false, true, false, false,false,true,true,true
        });


    }
}
