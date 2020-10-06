using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Attestation
{
    class Global
    {
        private static Global instance;
        public List<RowTab> DATA;
        public int Idx { set; get; }

        private Global()
        {
            DATA = new List<RowTab>();
        }
        public static Global getInstance()//*******
        {
            if (instance == null)
                instance = new Global();
            return instance;
        }
    }
}
