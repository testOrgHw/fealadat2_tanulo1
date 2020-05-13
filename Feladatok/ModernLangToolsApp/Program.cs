using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;

namespace ModernLangToolsApp
{
    class Program
    {
        static void MessageReceived(string message) //ezt a függvényt iratkoztatjuk fel a JediCouncil értesítéseire
        {
            Console.WriteLine(message);
        }
        static void fillCouncil(JediCouncil council) //feltölt teszteléshez egy adott JediCouncilt
        {
            Jedi[] jedis = new Jedi[3];
            string[] names = { "Anakin", "Obiwan", "High ground" };
            int[] counts = { 250, 2000, 9998 };
            


            for(int i =0;i<3;i++)
            {
                jedis[i] = new Jedi();
                jedis[i].Name = names[i];
                jedis[i].MidiChlorianCount = counts[i];
                council.Add(jedis[i]);
            }
        }

        [Description("Feladat2")]     //Clone attribútum
        static void Clone()         //klónoz egy jedit
        {
            //létrehozás
            Jedi jedi = new Jedi();
            jedi.Name = "Anakin";
            jedi.MidiChlorianCount = 10000;
            //kiírás
            XmlSerializer serializer = new XmlSerializer(typeof(Jedi));
            FileStream stream = new FileStream("jedi.txt", FileMode.Create);
            serializer.Serialize(stream, jedi);
            stream.Close();
            //visszatöltés
            XmlSerializer ser = new XmlSerializer(typeof(Jedi));
            FileStream fs = new FileStream("jedi.txt", FileMode.Open);
            Jedi clone = (Jedi)ser.Deserialize(fs);
            fs.Close();


        }

        [Description("Feladat3")]       //testCouncil attribútum
        static void testCouncil()       //Teszteli a JediCouncilt
        {
            JediCouncil council = new JediCouncil();
            council.CouncilChanged += MessageReceived;

            council.Add(new Jedi());
            council.Add(new Jedi());

            council.Remove();
            council.Remove();
        }
        [Description("Feladat4")]
        static void testBeginners()     //Teszteli a JediCouncil GetBeginners() függvényét
        {
            //feltöltünk egy Councilt
            JediCouncil council = new JediCouncil();
            fillCouncil(council);
            //Megszerezzük a kezdőket
            List <Jedi> list= council.GetBeginners();
            //Ha minden jól ment "Anakin" jelenik meg a konzolban.
            for(int n =0;n<list.Count;n++)
            {
                Console.WriteLine(list[n].Name);
            }
        }
        static void Main(string[] args)
        {
            //második feladat tesztelése
            Clone();
            //harmadik feladat tesztelése
            testCouncil();
            //negyedik feladat tesztelése
            testBeginners();
        }
    }
}
