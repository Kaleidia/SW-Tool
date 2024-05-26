﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SW_Tool
{
    public class Character : INotifyPropertyChanged
    {
        private string _name;
        private string _type;
        private string _desc;
        private Species _species;
        private Attribute dexterity = new Attribute("Dexterity",0);
        private Attribute perception = new Attribute("Perception",0);
        private Attribute knowledge = new Attribute("Knowledge",0);
        private Attribute strength = new Attribute("Strength", 0);
        private Attribute mechanical = new Attribute("Mechanical", 0);
        private Attribute technical = new Attribute("Technical", 0);

        private Attribute control = new Attribute("Control", 0);
        private Attribute sense = new Attribute("Sense", 0);
        private Attribute alter = new Attribute("Alter", 0);

        private int move;
        private int ap = 18 * 3;
        private int sp = 7 * 3;
        private int cp = 0;
        private int fp = 1;

        private bool _force = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get => _name; set { _name = value; RaiseNotifyChanged("Name"); } }
        public string Description
        {
            get => _desc; set
            {
                _desc = value;
                RaiseNotifyChanged("Description");
            }
        }

        public Species Species { get => _species; set { _species = value; RaiseNotifyChanged("Species"); } }
        public Attribute Dexterity { get => dexterity; set => dexterity = value; }
        public Attribute Perception { get => perception; set => perception = value; }
        public Attribute Knowledge { get => knowledge; set => knowledge = value; }
        public Attribute Strength { get => strength; set => strength = value; }
        public Attribute Mechanical { get => mechanical; set => mechanical = value; }
        public Attribute Technical { get => technical; set => technical = value; }

        public List<Skill> dexList { get; set; }
        public List<Skill> percList { get; set; }
        public List<Skill> knowList { get; set; }
        public List<Skill> strList { get; set; }
        public List<Skill> mechList { get; set; }
        public List<Skill> techList { get; set; }
        public int Ap { get => ap; set { ap = value; RaiseNotifyChanged("Ap"); } }
        public int Sp { get => sp; set => sp = value; }
        public int Move { get => move; set => move = value; }
        public bool Force { get => _force; set => _force = value; }
        public Attribute Control { get => control; set => control = value; }
        public Attribute Sense { get => sense; set => sense = value; }
        public Attribute Alter { get => alter; set => alter = value; }
        public string Type { get => _type; set => _type = value; }
        public int CharacterPoints { get => cp; set => cp = value; }
        public int ForcePoints { get => fp; set => fp = value; }

        public Character(string name, string type, string descr, Species species, bool force)
        {
            _name = name;
            _type = type;
            _desc = descr;
            _species = species;
            _force = force;

            if (species != null)
            {
                dexterity.Value = species.DexMin;
                ap -= species.DexMin;
                perception.Value = species.PercMin;
                ap -= species.PercMin;
                knowledge.Value = species.KnowMin;
                ap -= species.KnowMin;
                strength.Value = species.StrMin;
                ap -= species.StrMin;
                mechanical.Value = species.MechMin;
                ap -= species.MechMin;
                technical.Value = species.TechMin;
                ap -= species.TechMin;
                move = species.MoveMin;
            }
        }

        public Character()
        {
            _name = "Give your character a cool name!";
            _type = "What template or character type is the character?";
            _desc = "write a description!";
        }
        private void RaiseNotifyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}