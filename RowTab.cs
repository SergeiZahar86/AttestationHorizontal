﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Attestation
{
    public class RowTab
    {
        public RowTab(int Id, bool isOk, String VagNum, float Tara, float TaraNSI,
            float TaraDelta, Image LeftFoto, Image RightFoto, Image TopFoto)
        {
            this.Id = Id;
            this.isOk = isOk;
            this.VagNum = VagNum;
            this.Tara = Tara;
            this.TaraNSI = TaraNSI;
            this.TaraDelta = TaraDelta;
            this.Video = "Ok";
            this.LeftFoto = LeftFoto;
            this.RightFoto = RightFoto;
            this.TopFoto = TopFoto;
        }
        public int Id { get; set; }
        public bool isOk { get; set; }
        public String VagNum { get; set; }
        public float Tara { get; set; }
        public float TaraNSI { get; set; }
        public float TaraDelta { get; set; }
        public String Video { get; set; }
        public Image LeftFoto { get; set; }
        public Image RightFoto { get; set; }
        public Image TopFoto { get; set; }
    }
}

      