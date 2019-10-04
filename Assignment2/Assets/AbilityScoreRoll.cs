using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityScoreRoll : MonoBehaviour
{
    public Text[] AS = new Text[6];
    public Text[] Mod = new Text[6];
    private int[] AbilityScore = new int[6];
    private System.Random rnd = new System.Random();

    public void roll()
    {
        for(int i = 0; i < 6; i++)
        {
            int sum = 0;
            int min = 7;
            for (int j = 0; j < 4; j++)
            {
                int roll = rnd.Next(1, 6);
                if (roll < min)
                {
                    min = roll;
                }
                sum += roll;
            }
            sum -= min;
            AbilityScore[i] = sum;
            AS[i].text = sum.ToString();
            Mod[i].text = calculateMod(sum);
        }
    }

    private string calculateMod(int sum)
    {
        int mod = 0;
        if (sum >= 10)
        {
            mod = Mathf.FloorToInt((sum - 10) / 2);
        } else
        {
            if (sum%2 == 1)
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

    public void addToPrefs()
    {
        PlayerPrefs.SetInt(getAS(GameObject.Find("AS1/Ability").GetComponent<Dropdown>().value), AbilityScore[0]);
        PlayerPrefs.SetInt(getAS(GameObject.Find("AS2/Ability").GetComponent<Dropdown>().value), AbilityScore[1]);
        PlayerPrefs.SetInt(getAS(GameObject.Find("AS3/Ability").GetComponent<Dropdown>().value), AbilityScore[2]);
        PlayerPrefs.SetInt(getAS(GameObject.Find("AS4/Ability").GetComponent<Dropdown>().value), AbilityScore[3]);
        PlayerPrefs.SetInt(getAS(GameObject.Find("AS5/Ability").GetComponent<Dropdown>().value), AbilityScore[4]);
        PlayerPrefs.SetInt(getAS(GameObject.Find("AS6/Ability").GetComponent<Dropdown>().value), AbilityScore[5]);
    }

    private string getAS(int dropdownValue)
    {
        
        switch (dropdownValue)
        {
            case 0: return "Strength";
            case 1: return "Dexterity";
            case 2: return "Constitution";
            case 3: return "Intelligence";
            case 4: return "Wisdom";
            case 5: return "Charisma";
            default: break;
        }
        return "None";
    }
}
