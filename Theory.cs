using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PseudoEdu
{
    [Serializable]
    public class Theory
    {
        [XmlElement]
        public string Name;
        [XmlElement]
        public string Url;
    }
}
