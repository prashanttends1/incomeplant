using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mlmStudio.ModelDto.Tree
{
    public class Attributes
    {
        public string p1 { get; set; }
        public string p2 { get; set; }
    }

    public class Child
    {
        public int id { get; set; }
        public string text { get; set; }
        public string state { get; set; }
        public Attributes attributes { get; set; }
        public bool? @checked { get; set; }
        public List<Child> children { get; set; }
    }

    public class RootObject
    {
        public int id { get; set; }
        public string text { get; set; }
        public bool? @checked { get; set; }
        public List<Child> children { get; set; }
    }

}