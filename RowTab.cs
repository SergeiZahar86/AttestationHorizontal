using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attestation
{
    class RowTab
    {
        public RowTab(int Id, bool isOk, String VagNum, float Tara, float TaraNSI, float TaraDelta)
        {
            this.Id = Id;
            this.isOk = isOk;
            this.VagNum = VagNum;
            this.Tara = Tara;
            this.TaraNSI = TaraNSI;
            this.TaraDelta = TaraDelta;
            this.Video = "Ok";
        }
        public int Id { get; set; }
        public bool isOk { get; set; }
        public String VagNum { get; set; }
        public float Tara { get; set; }
        public float TaraNSI { get; set; }
        public float TaraDelta { get; set; }
        public String Video { get; set; }
    }
}

      