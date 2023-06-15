using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Player : MonoBehaviour
{
    public int force;
    public int intel;
    public int armure;
    public int rm;
    public int mana;
    public int manaMax;
    public int hp;
    public int hpMax;
    public int level;
    public float exp;
    public float expToLevelUP;
    public float attaque1;
    public float attaque2;
    public float attaque3;
    public float attaque4;

    
    public void Initialize(int playerLevel, float playerExp)
    {
        level = playerLevel;
        force = 10 + (2 * (level - 1));
        intel = 10 + (2 * (level - 1));
        armure = 10 + (2 * (level - 1));
        rm = 10 + (2 * (level - 1));
        hpMax = 20 + (5 * (level - 1));
        hp = hpMax;
        manaMax = 20 + (2 * (level - 1));
        mana = manaMax;
        exp = playerExp;
        expToLevelUP = 100.0f + Mathf.Exp((level + 1) / level);
        attaque1 = force * 1.1f;
    }

    public Player levelUP()
{
    Player p1 = new Player();
    p1.Initialize(level + 1, exp);
    p1.force += 2;
    p1.intel += 2;
    p1.armure += 2;
    p1.rm += 2;
    p1.hp += 5;
    p1.mana += 2;
    return p1;
}
    public float[] atk1(){
        float[] tabHpMana = new float[2];
        if(mana < 2) return tabHpMana;

        System.Random random = new System.Random();
        float randomValue = (float)random.NextDouble() * 4 + 8;
    
        tabHpMana[0] = randomValue;
        tabHpMana[1] = 2;
    
        return tabHpMana;
    }
    public float[] atk2()
    {
        float[] tabHpMana = new float[2];

        System.Random random = new System.Random();
        float randomValue = (float)random.NextDouble() * 2 + 4;

        tabHpMana[0] = randomValue;
        tabHpMana[1] = 0;

        return tabHpMana;
    }
    public float[] atk3()
    {
        float[] tabHpMana = new float[2];
        if (mana < 3)
        {
            tabHpMana[0] = 0;
            tabHpMana[1] = 0;
            return tabHpMana;
        }

        int maxHeal = hpMax - hp;
        if (maxHeal <= 0)
        {
            tabHpMana[0] = 0;
            tabHpMana[1] = 0;
            return tabHpMana;
        }

        System.Random random = new System.Random();
        float randomValue = (float)random.NextDouble() * (maxHeal / 2) + (maxHeal / 2);

        tabHpMana[0] = randomValue;
        tabHpMana[1] = 3;
        return tabHpMana;
    }
    public float[] atk4()
    {
        float[] tabHpMana = new float[2];
        if (mana < 5)
        {
            tabHpMana[0] = 0;
            tabHpMana[1] = 0;
            return tabHpMana;
        }

        System.Random random = new System.Random();
        float randomValue = (float)random.NextDouble() * 10 + 15;

        tabHpMana[0] = randomValue;
        tabHpMana[1] = 5;

        return tabHpMana;
    }


}
