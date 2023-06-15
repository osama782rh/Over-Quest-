using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstre : MonoBehaviour
{
    public int force;
    public int armure;
    public int rm;
    public int hp;
    public int hpMax;
    public int level;
    public float gainsExp;

    public void MonstreBasic()
    {
        this.force = 5;
        this.armure = 5;
        this.rm = 5;
        this.hp = 20;
        this.hpMax = 20;
        this.gainsExp = 20;
        this.level = 1;
    }
    public void MonstreSup()
    {
        this.force = 8;
        this.armure = 8;
        this.rm = 8;
        this.hp = 35;
        this.hpMax = 35;
        this.gainsExp = 30;
        this.level = 2;
    }

    public int atk1()
    {
        int baseDamage = 4;
        int randomDamage = UnityEngine.Random.Range(0, 3); // Génère un nombre aléatoire entre 0 et 2

        int totalDamage = baseDamage + randomDamage;

        return totalDamage;
    }

    public int atk2()
    {
        int baseDamage = 8;
        int randomDamage = UnityEngine.Random.Range(0, 5); // Génère un nombre aléatoire entre 0 et 4

        int totalDamage = baseDamage + randomDamage;

        return totalDamage;
    }



}
