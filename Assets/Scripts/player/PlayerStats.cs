using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int strength;
    public int dexterity;
    public int intelligence;
    public int vitality;
    public int level;
    public int experience;
    public int experienceToNextLevel;

    public int CalculateMaxHP()
    {
        return vitality * 10;
    }

    public int CalculateDamage()
    {
        return strength * 2;
    }
}
