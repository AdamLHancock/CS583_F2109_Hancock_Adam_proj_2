using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadInFromPrefs : MonoBehaviour
{
    public int[] AS = new int[6];
    private void Awake()
    {
        AS[0] = PlayerPrefs.GetInt("Strength");
        AS[1] = PlayerPrefs.GetInt("Dexterity");
        AS[2] = PlayerPrefs.GetInt("Constitution");
        AS[3] = PlayerPrefs.GetInt("Intelligence");
        AS[4] = PlayerPrefs.GetInt("Wisdom");
        AS[5] = PlayerPrefs.GetInt("Charisma");
    }

    public void displayValues()
    {
        abilityDisplay();
        modDisplay();
    }

    public void racialBonus()
    {
        switch (GameObject.Find("BasicInfo/Race").GetComponent<Dropdown>().value)
        {
            case 1:
                AS[0] += 2;
                AS[1] = PlayerPrefs.GetInt("Dexterity");
                AS[2] += 1;
                AS[3] = PlayerPrefs.GetInt("Intelligence");
                AS[4] = PlayerPrefs.GetInt("Wisdom");
                AS[5] = PlayerPrefs.GetInt("Charisma");
                break;
            case 2:
                AS[0] = PlayerPrefs.GetInt("Strength");
                AS[1] = PlayerPrefs.GetInt("Dexterity");
                AS[2] += 2;
                AS[3] = PlayerPrefs.GetInt("Intelligence");
                AS[4] = PlayerPrefs.GetInt("Wisdom");
                AS[5] = PlayerPrefs.GetInt("Charisma");
                break;
            case 3:
                AS[0] = PlayerPrefs.GetInt("Strength");
                AS[1] += 2;
                AS[2] = PlayerPrefs.GetInt("Constitution");
                AS[3] = PlayerPrefs.GetInt("Intelligence");
                AS[4] = PlayerPrefs.GetInt("Wisdom");
                AS[5] = PlayerPrefs.GetInt("Charisma");
                break;
            case 4:
                AS[0] = PlayerPrefs.GetInt("Strength");
                AS[1] = PlayerPrefs.GetInt("Dexterity");
                AS[2] = PlayerPrefs.GetInt("Constitution");
                AS[3] += 2;
                AS[4] = PlayerPrefs.GetInt("Wisdom");
                AS[5] = PlayerPrefs.GetInt("Charisma");
                break;
            case 5:
                AS[0] = PlayerPrefs.GetInt("Strength");
                AS[1] += 1;
                AS[2] += 1;
                AS[3] = PlayerPrefs.GetInt("Intelligence");
                AS[4] = PlayerPrefs.GetInt("Wisdom");
                AS[5] += 2;
                break;
            case 6:
                AS[0] = PlayerPrefs.GetInt("Strength");
                AS[1] += 2;
                AS[2] = PlayerPrefs.GetInt("Constitution");
                AS[3] = PlayerPrefs.GetInt("Intelligence");
                AS[4] = PlayerPrefs.GetInt("Wisdom");
                AS[5] = PlayerPrefs.GetInt("Charisma");
                break;
            case 7:
                AS[0] += 2;
                AS[1] = PlayerPrefs.GetInt("Dexterity");
                AS[2] += 1;
                AS[3] = PlayerPrefs.GetInt("Intelligence");
                AS[4] = PlayerPrefs.GetInt("Wisdom");
                AS[5] = PlayerPrefs.GetInt("Charisma");
                break;
            case 8:
                AS[0] += 1;
                AS[1] += 1;
                AS[2] += 1;
                AS[3] += 1;
                AS[4] += 1;
                AS[5] += 1;
                break;
            case 9:
                AS[0] = PlayerPrefs.GetInt("Strength");
                AS[1] = PlayerPrefs.GetInt("Dexterity");
                AS[2] = PlayerPrefs.GetInt("Constitution");
                AS[3] += 1;
                AS[4] = PlayerPrefs.GetInt("Wisdom");
                AS[5] += 2;
                break;
            case 0:
                AS[0] = PlayerPrefs.GetInt("Strength");
                AS[1] = PlayerPrefs.GetInt("Dexterity");
                AS[2] = PlayerPrefs.GetInt("Constitution");
                AS[3] = PlayerPrefs.GetInt("Intelligence");
                AS[4] = PlayerPrefs.GetInt("Wisdom");
                AS[5] = PlayerPrefs.GetInt("Charisma");
                break;
            default: break;
        }
        abilityDisplay();
        modDisplay();
    }

    private void abilityDisplay()
    {
        Text str = GameObject.Find("AbilityScores/Strength/Value").GetComponent<Text>();
        str.text = AS[0].ToString();
        Text dex = GameObject.Find("AbilityScores/Dexterity/Value").GetComponent<Text>();
        dex.text = AS[1].ToString();
        Text con = GameObject.Find("AbilityScores/Constitution/Value").GetComponent<Text>();
        con.text = AS[2].ToString();
        Text inte = GameObject.Find("AbilityScores/Intelligence/Value").GetComponent<Text>();
        inte.text = AS[3].ToString();
        Text wis = GameObject.Find("AbilityScores/Wisdom/Value").GetComponent<Text>();
        wis.text = AS[4].ToString();
        Text cha = GameObject.Find("AbilityScores/Charisma/Value").GetComponent<Text>();
        cha.text = AS[5].ToString();
    }

    private void modDisplay()
    {
        Text str = GameObject.Find("AbilityScores/Strength/Modifier").GetComponent<Text>();
        str.text = calculateMod(AS[0]).ToString();
        Text dex = GameObject.Find("AbilityScores/Dexterity/Modifier").GetComponent<Text>();
        dex.text = calculateMod(AS[1]).ToString();
        Text con = GameObject.Find("AbilityScores/Constitution/Modifier").GetComponent<Text>();
        con.text = calculateMod(AS[2]).ToString();
        Text inte = GameObject.Find("AbilityScores/Intelligence/Modifier").GetComponent<Text>();
        inte.text = calculateMod(AS[3]).ToString();
        Text wis = GameObject.Find("AbilityScores/Wisdom/Modifier").GetComponent<Text>();
        wis.text = calculateMod(AS[4]).ToString();
        Text cha = GameObject.Find("AbilityScores/Charisma/Modifier").GetComponent<Text>();
        cha.text = calculateMod(AS[5]).ToString();
    }

    private string calculateMod(int sum)
    {
        int mod = 0;
        if (sum >= 10)
        {
            mod = Mathf.FloorToInt((sum - 10) / 2);
        }
        else
        {
            if (sum % 2 == 1)
            {
                mod--;
            }
            mod += Mathf.CeilToInt((sum - 10) / 2);
        }
        string modi = mod.ToString();
        if (mod >= 0)
        {
            modi = "+" + modi;
        }
        return modi;
    }

    public void addToEquipment()
    {
        string forEquip = GameObject.Find("Equipment/ForEquipment").GetComponent<InputField>().text;
        GameObject.Find("Equipment/ItemList").GetComponent<Text>().text += "\n" + forEquip;
    }

    public void SaveAsJSON()
    {
        Save save = CreateSaveGameObject();
        string json = JsonUtility.ToJson(save);
        File.WriteAllText(Application.dataPath + "/" + save.race + save.classes + ".json", json);
        Debug.Log(Application.dataPath + "/" + save.race + save.classes + ".json");
    }

    private Save CreateSaveGameObject()
    {
        Save save = new Save();
        save.characterName = GameObject.Find("BasicInfo/Name").GetComponent<InputField>().text;
        save.Ability_Strength = getInt(GameObject.Find("AbilityScores/Strength/Value").GetComponent<Text>().text);
        save.Ability_Dexterity = getInt(GameObject.Find("AbilityScores/Dexterity/Value").GetComponent<Text>().text);
        save.Ability_Constitution = getInt(GameObject.Find("AbilityScores/Constitution/Value").GetComponent<Text>().text);
        save.Ability_Intelligence = getInt(GameObject.Find("AbilityScores/Intelligence/Value").GetComponent<Text>().text);
        save.Ability_Wisdom = getInt(GameObject.Find("AbilityScores/Wisdom/Value").GetComponent<Text>().text);
        save.Ability_Charisma = getInt(GameObject.Find("AbilityScores/Charisma/Value").GetComponent<Text>().text);
        save.race = getRace(GameObject.Find("BasicInfo/Race").GetComponent<Dropdown>().value);
        save.classes = getClass(GameObject.Find("BasicInfo/Class").GetComponent<Dropdown>().value);
        save.alignment = getAlignment(GameObject.Find("BasicInfo/Alignment").GetComponent<Dropdown>().value);
        save.currentXP = getInt(GameObject.Find("BasicInfo/CurrentXP").GetComponent<InputField>().text);
        save.maxXP = getInt(GameObject.Find("BasicInfo/Level20").GetComponent<Text>().text);
        save.currentHP = getInt(GameObject.Find("AbilityScores/HealthPoints/CurrentHP").GetComponent<InputField>().text);
        save.maxHP = getInt(GameObject.Find("AbilityScores/HealthPoints/MaxHP").GetComponent<InputField>().text);
        save.armorClass = getInt(GameObject.Find("AbilityScores/ArmorClass/Value").GetComponent<InputField>().text);
        save.walkSpeed = getInt(GameObject.Find("AbilityScores/Speed/InputField").GetComponent<InputField>().text);
        save.runSpeed = save.walkSpeed * 2;
        save.jumpHeight = 3 + getInt(GameObject.Find("AbilityScores/Strength/Modifier").GetComponent<Text>().text);
        return save;
    }

    private string getRace(int place)
    {
        switch (place)
        {
            case 0: return "";
            case 1: return "Dragonborn";
            case 2: return "Dwarf";
            case 3: return "Elf";
            case 4: return "Gnome";
            case 5: return "Half-Elf";
            case 6: return "Half-Orc";
            case 7: return "Halfling";
            case 8: return "Human";
            case 9: return "Tiefling";
            default: return "";
        }
    }

    private string getClass(int place)
    {
        switch (place)
        {
            case 1: return "Barbarian";
            case 2: return "Bard";
            case 3: return "Cleric";
            case 4: return "Druid";
            case 5: return "Fighter";
            case 6: return "Monk";
            case 7: return "Ranger";
            case 8: return "Rogue";
            case 9: return "Sorcerer";
            case 10: return "Warlock";
            case 11: return "Wizard";
            case 0: return "";
            default: return "";
        }
    }

    private string getAlignment(int place)
    {
        switch (place)
        {
            case 1: return "Chaotic Good";
            case 2: return "Neutral Good";
            case 3: return "Lawful Good";
            case 4: return "Chaotic Neutral";
            case 5: return "True Neutral";
            case 6: return "Lawful Neutral";
            case 7: return "Chaotic Evil";
            case 8: return "Neutral Evil";
            case 9: return "Lawful Evil";
            case 0: return "";
            default: return "";
        }
    }

    private int getInt(string toInt)
    {
        int number;
        if (System.Int32.TryParse(toInt, out number))
        {
            return number;
        } else
        {
            return 0;

        }
    }
}
