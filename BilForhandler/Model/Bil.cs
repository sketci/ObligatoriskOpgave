﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilForhandler.Model
{
    public class Bil
    {
     
        public Guid BilId { get; set; }
        public string Navn { get; set; }

        public string Mærke { get; set; }
        public string Model { get; set; }

        public int År { get; set; }

        public Bil() { }
        public Bil(string navn, string mærke, string model, int år)
        {
            BilId = Guid.NewGuid();
            this.Navn = navn;
            this.Mærke = mærke;
            this.Model = model;
            this.År = år;
        }

        public override string ToString()
        {
            return BilId + " " + Navn + " " + Mærke + " " + Model + " " + År;
        }
    }
}
