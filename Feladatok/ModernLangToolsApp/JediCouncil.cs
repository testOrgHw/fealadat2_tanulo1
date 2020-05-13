using System;
using System.Collections.Generic;
using System.Text;

namespace ModernLangToolsApp
{
    public delegate void CouncilChangedDelegate(string message);
    class JediCouncil
    {
        public event CouncilChangedDelegate CouncilChanged;
        //Jediket tartalmazó lista
        List<Jedi> members = new List<Jedi>();
        public void Add(Jedi newJedi)
        {
            //Hozzáadja a listához az adott Jedit
            members.Add(newJedi);
            //Értesítés küldése
            if (CouncilChanged != null)
                CouncilChanged("Új taggal bővültünk");
        }
        public void Remove()
        {
            //Eltávolítja a lista utolsó elemét
            members.RemoveAt(members.Count - 1);
            //Kétféle értesítést küld, ha üres a lista és ha nem
            if(CouncilChanged!=null)
            {
                //ha nem üres a lista
                if (members.Count > 0)
                    CouncilChanged("Zavart érzek az erőben");
                //ha üres a lista
                else
                    CouncilChanged("A tanács elesett!");
            }
        }
        static bool JediFilter(Jedi jedi)       //Ezt a függvényt adjuk a members FindAll függvényének, hogy eszerint keressen
        {
            //Ha kevesebb mint 300, akkor kezdő
            if(jedi.MidiChlorianCount < 300)
                return true;
            else
                return false;
        }
        public List<Jedi> GetBeginners()        //A FindAll segítségével visszadja a kezdő jedik listáját
        {
            List<Jedi> list = members.FindAll(JediFilter);
            return list;
        }
    }
}
