﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpunk2020CharacterCreator
{
    class Character
    {

        //All life events
        public Dictionary<int, string> lifeEvents;

        //Age
        public int age;

        //Money
        public int Eurodollars;

        //Name for the Character
        public string name;

        //If false, its female
        public bool male;

        //The class/role of the Character
        public Role role;

        //Dictionary full of the skills
        Skills skills = new Skills();

        //Stats for the Character
        public Stats stats = new Stats();

        //Inventory, it says in the name of the class.
        public Inventory inv = new Inventory();

        public Body body = new Body();

        //The Character's Style
        public Style style = new Style();
        public Motivation motivation;
        public Dictionary<Character,Relationship> relationships = new Dictionary<Character, Relationship>();
        public bool NPC;

        /// <summary>
        /// Generates random Character using all of the other functions in this class
        /// </summary>
        public Character()
        {
            characters.Add(this);
        }

        public Character(string name, bool npc)
        {
            this.name = name;
            characters.Add(this);
            this.NPC = npc;
        }

        public void EquipItem(object item)
        {
            inv.EquipItem(item,this);
        }

        public void UnEquipItem(object item)
        {
            inv.UnEquipItem(item, this);
        }

        public void EquipItem(Weapon t)
        {
            inv.AddItemToInventory(t);
        }
        public void EquipItem(Cybernetic t)
        {
            inv.AddItemToInventory(t);
        }
        public void EquipItem(Armor t)
        {
            inv.AddItemToInventory(t);
        }
        public void EquipItem(IItem t)
        {
            inv.AddItemToInventory(t);
        }

        public void RemoveItemFromInventory(object item)
        {
            inv.RemoveItemFromInventory(item);
        }

        /// <summary>
        /// Generates random Character using all of the other functions in this class
        /// </summary>
        /// <returns>Character</returns>
        public static Character GenerateRandomNPC(int points)
        {
            Character temp = new Character();
            Random rnd = new Random();
            if (rnd.Next(1,10) < 6)
            {
                temp.male = false;
            }
            temp.name = RandomNameGenerator(temp.male);
            
            if (points == 0)
            {
                points = rnd.Next(30, 65);
            }
            temp.style.RandomlySelectStyle();
            temp.motivation = Motivation.RandomlyGenerateMotivation();
            rnd.Next(1, 10);
            temp.role = Role.roles[Role.IntToRoleName(rnd.Next(1, 10)).ToLower()];
            temp.stats = Stats.GenerateStatsForNpc(points, temp);
            temp.NPC = true;

            temp.age = 16 + rnd.Next(1, 6) + rnd.Next(1, 6);
            return temp;
        }

        /// <summary>
        /// Randomly generates a name based on if the name needed is male or not
        /// </summary>
        /// <returns>string</returns>
        public static string RandomNameGenerator (bool male)
        {
            string name;
            Random rnd = new Random();
            int random = rnd.Next(1,1002);
            if (male)
            {
                name = System.IO.File.ReadAllLines("MaleNames.txt")[random].Trim(); 
            }
            else
            {
                name = System.IO.File.ReadAllLines("FemaleNames.txt")[random].Trim();
            }
            random = rnd.Next(1, 972);
            name += " " + System.IO.File.ReadAllLines("Surnames.txt")[random].Trim();
            return name;
        }

        /// <summary>
        /// Randomly generates a name without thinking about gender
        /// </summary>
        /// <returns>string</returns>
        public static string RandomNameGenerator()
        {
            string name;
            Random rnd = new Random();
            int random = rnd.Next(1, 2004);
            if (random < 1003)
            {
                name = System.IO.File.ReadAllLines("MaleNames.txt")[random].Trim();
            }
            else
            {
                name = System.IO.File.ReadAllLines("FemaleNames.txt")[random-1002].Trim();
            }
            random = rnd.Next(1, 972);
            name += " " + System.IO.File.ReadAllLines("Surnames.txt")[random].Trim();
            return name;
        }

        public static Character MakeQuickRelation(Character npc, Relationship.QuickRelation relation)
        {
            Character temp = GenerateRandomNPC(0);
            Relationship rel = new Relationship();
            
            switch (relation)
            {
                case Relationship.QuickRelation.Enemy:
                    rel.Enemy = true;
                    break;

                case Relationship.QuickRelation.Family:
                    rel.Family = true;
                    break;

                case Relationship.QuickRelation.Friend:
                    rel.Friend = true;
                    break;

                case Relationship.QuickRelation.Acquantance:
                    rel.acquaintance = true;
                    break;
            }

            temp.relationships.Add(npc,rel);
            npc.relationships.Add(temp,rel);
            return temp;
        }

        //A character array containing all characters.
        static List<Character> characters = new List<Character>();

        public static Character[] Characters
        {
            get
            {
                List<Character> chars = new List<Character>();
                foreach (Character c in characters)
                {
                    if (!c.NPC)
                    {
                        chars.Add(c);
                    }
                }
                return chars.ToArray();
            }
        }
        public static Character[] NPCs
        {
            get
            {
                List<Character> chars = new List<Character>();
                foreach (Character c in characters)
                {
                    if (c.NPC)
                    {
                        chars.Add(c);
                    }
                }
                return chars.ToArray();
            }
        }

    }
}
