using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StartDecoder
{
    class searchSignaling
    {
        public BitArray Preamble_P1 = new BitArray(new bool[12]
            {false, false, true, true, false, false, true, false, false, false, true, true});

        public BitArray Preamble_P2 = new BitArray(new bool[12]
            {true, false, false, true, true, false, true, false, true, false, false, true});

        public BitArray Preamble_P3 = new BitArray(new bool[12]
            {false, false, false, true, false, true, false, false, false, true, true, true});

        public BitArray CorectSequerens_1 = new BitArray(new bool[22]
        {
            true, true, false, true, false, false, false, false, true, true, true, false, true, false, false, true,
            true, true, false, true, false, false
        });

        BitArray CorectSequerens_2 = new BitArray(new bool[22]
        {
            false, true, true, true, true, false, true, false, false, true, false, false, false, false, true, true,
            false, true, true, true, true, false
        });

        public BitArray synshSequerense = new BitArray(new bool[38]
        {
            true, true, false, false, false, false, false, true, true, false, false, true, true, true, false, false,
            true, true, true, false, true, false, false, true, true, true, false, false, false, false, false, true,
            true, false, false, true, true, true
        });

        public BitArray sequerensFreaquencyCorection = new BitArray(new bool[80]
        {
            true, true, true, true, true, true, true, true, false, false, false, false, false, false, false,
            false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
            false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
            false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
            false, false, false, false, false, false, false, false, false, false, false, false, true, true, true,
            true, true, true, true, true
        });

        public BitArray phaseBit = new BitArray(new bool[2]);
        public BitArray tailBit = new BitArray(new bool[2]{ false , false });

    }
}

