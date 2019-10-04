using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save : MonoBehaviour
{
    public string characterName = "";
    public int Ability_Strength = 0;
    public int Ability_Dexterity = 0;
    public int Ability_Constitution = 0;
    public int Ability_Intelligence = 0;
    public int Ability_Wisdom = 0;
    public int Ability_Charisma = 0;
    public string race = "";
    public string classes = "";
    public string alignment = "";
    public int currentXP = 0;
    public int maxXP = 0;
    public int currentHP = 0;
    public int maxHP = 0;
    public int armorClass = 0;
    public int walkSpeed = 0;
    public int runSpeed = 0;
    public int jumpHeight = 0;
    public List<string> itemList = new List<string>();
}
