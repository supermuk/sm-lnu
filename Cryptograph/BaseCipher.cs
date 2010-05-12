using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cryptograph
{
    public abstract class BaseCipher
    {
        private GroupBox keyBox;
        public GroupBox KeyBox 
        {
            get
            {
                return keyBox;
            }
            set
            {
                keyBox = value;
                Initialize();
            }
        }
        public Alphabets alphabet;
        public Alphabets Alphabet 
        {
            get
            {
                return alphabet;
            }
            set
            {
                alphabet = value;
                Initialize();
            }
        }


        public abstract void Initialize();

        public abstract string Encode(string M);
        public abstract string Decode(string C);
        public abstract string Hack(string C);
    }
    public enum Alphabets
    {
        [StringValue(" abcdefghijklmnopqrstuvwxyz")]
        Latin,
        [StringValue(" абвгґдеєжзиіїйклмноперстуфхчшщьюя")]
        Ukrainian
    }
}
