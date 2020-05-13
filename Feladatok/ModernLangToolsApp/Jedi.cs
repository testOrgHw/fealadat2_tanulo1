using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;

namespace ModernLangToolsApp
{
    [XmlRoot("Jedi")]                               //root attribútum
    public class Jedi
    {
        
        private string name;
        private int midiChlorianCount;

        [XmlAttribute("Nev")]                       //Namehez tartózó attribútum
        public string Name                          // name property
        {
            get { return name; }
            set { name = value; }
        }

        [XmlAttribute("MidiChlorianSzam")]          //MidiChlorianCounthoz tartózó attribútum
        public int MidiChlorianCount               //midiChlorianCount property
        {
            get { return midiChlorianCount; }
            set { 
                if(value <=10) { throw new ArgumentException("You are not a true jedi!"); } 

                midiChlorianCount = value;
            }
        }
        public Jedi()
        {

        }
    }
}
