using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PseudoEdu
{
    [Serializable]
    [XmlRoot("course")]
    public class XmlCourse
    {
        [XmlArray]
        public List<Exam> Tests = new List<Exam>();
        [XmlArray]
        public List<Theory> Theorys = new List<Theory>();
    }
}
