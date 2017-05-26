using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestMVC
{
    public class NotificationConstant
    {
        public const string LevelUp = "LevelUp";
        public const string LevelChange = "LevelChange";
    }

    public class CharacterInfo
    {
        public int Level { get; set; }
        public int Hp { get; set; }

        public CharacterInfo()
        {

        }

        public CharacterInfo(int level, int hp)
        {
            Level = level;
            Hp = hp;
        }
    }
}

