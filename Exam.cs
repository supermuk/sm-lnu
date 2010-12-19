using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PseudoEdu
{
    [Serializable]
    public class Exam
    {
        [XmlElement]
        public string Name;
        [XmlElement]
        public string Url;
        [XmlElement]
        public int Points;
        [XmlElement]
        public List<string> Choises;
        [XmlAttribute]
        public int CorrectAnswer;
    }
}
