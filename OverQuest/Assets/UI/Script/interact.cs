using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact : MonoBehaviour
{
    [SerializeField] GameObject HeathMonster;
    [SerializeField] GameObject HeathPlayer;
    [SerializeField] GameObject ManaPlayer;
    public GameObject pGO;
    public GameObject mGO;
    public Player p;
    public Monstre m;
    //public GameSet gameSet;
    float hpBarMonster;
    float hpBarPlayer;
    float manaBarPlayer;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        mGO = new GameObject();
        pGO = new GameObject();
        p = pGO.AddComponent<Player>();
        m = mGO.AddComponent<Monstre>();
        p.Initialize(1, 1.0f);
        m.MonstreBasic();
        //gameSet = GetComponent<GameSet>();
        //gameSet.StartBattle();
    }

    public void attaque1()
    {
        float[] attackResult = p.atk1();

        if (attackResult.Length == 2)
        {
            float damage = attackResult[0];
            float manaCost = attackResult[1];

            // Appliquer les dégâts au monstre
            m.hp -= (int)damage;
            if (m.hp <= 0)
            {
                m.hp = 0;
                //gameSet.TransitionToWin();
                if ((p.exp + m.gainsExp) > p.expToLevelUP)
                {
                    float xpSupp = p.exp = (p.exp + m.gainsExp) - p.expToLevelUP;
                    p.levelUP();
                    p.exp = xpSupp;
                }
                else p.exp += m.gainsExp;
            }
            hpBarMonster = (float)m.hp / (float)m.hpMax;

            // Réduire le mana du joueur
            p.mana -= (int)manaCost;
            manaBarPlayer = (float)p.mana / (float)p.manaMax;
        }

        HeathMonster.transform.localScale = new Vector3(hpBarMonster, 1f);
        ManaPlayer.transform.localScale = new Vector3(manaBarPlayer, 1f); // Mise à jour de la barre de mana

        StartCoroutine(AttackCoroutine());
    }

    public void attaque2()
    {
        float[] attackResult = p.atk2();

        if (attackResult.Length == 2)
        {
            float damage = attackResult[0];
            float manaCost = attackResult[1];

            // Appliquer les dégâts au monstre
            m.hp -= (int)damage;
            if (m.hp <= 0)
            {
                m.hp = 0;
                //gameSet.TransitionToWin();
                if ((p.exp + m.gainsExp) > p.expToLevelUP)
                {
                    float xpSupp = p.exp = (p.exp + m.gainsExp) - p.expToLevelUP;
                    p.levelUP();
                    p.exp = xpSupp;
                }
                else p.exp += m.gainsExp;
            }
            hpBarMonster = (float)m.hp / (float)m.hpMax;

            // Réduire le mana du joueur
            p.mana -= (int)manaCost;
            manaBarPlayer = (float)p.mana / (float)p.manaMax;
        }

        HeathMonster.transform.localScale = new Vector3(hpBarMonster, 1f);
        ManaPlayer.transform.localScale = new Vector3(manaBarPlayer, 1f); // Mise à jour de la barre de mana

        StartCoroutine(AttackCoroutine());
    }
    public void heal()
    {
        float[] healResult = p.atk3();

        if (healResult.Length == 2)
        {
            float healAmount = healResult[0];
            float manaCost = healResult[1];

            // Appliquer les soins au joueur
            p.hp += (int)healAmount;
            p.hp = Mathf.Min(p.hp, p.hpMax); // S'assurer que les points de vie ne dépassent pas la limite maximale
            hpBarPlayer = (float)p.hp / (float)p.hpMax;

            // Réduire le mana du joueur
            p.mana -= (int)manaCost;
            manaBarPlayer = (float)p.mana / (float)p.manaMax;
        }

        HeathPlayer.transform.localScale = new Vector3(hpBarPlayer, 1f);
        ManaPlayer.transform.localScale = new Vector3(manaBarPlayer, 1f); // Mise à jour de la barre de mana

        StartCoroutine(AttackCoroutine());
    }

    public void attaquePuissante()
    {
        float[] attackResult = p.atk4();

        if (attackResult.Length == 2)
        {
            float damage = attackResult[0];
            float manaCost = attackResult[1];

            // Appliquer les dégâts au monstre
            m.hp -= (int)damage;
            if (m.hp <= 0)
            {
                m.hp = 0;
                //gameSet.TransitionToWin();
                if ((p.exp + m.gainsExp) > p.expToLevelUP)
                {
                    float xpSupp = p.exp = (p.exp + m.gainsExp) - p.expToLevelUP;
                    p.levelUP();
                    p.exp = xpSupp;
                }
                else p.exp += m.gainsExp;
            }
            hpBarMonster = (float)m.hp / (float)m.hpMax;

            // Réduire le mana du joueur
            p.mana -= (int)manaCost;
            manaBarPlayer = (float)p.mana / (float)p.manaMax;
        }

        HeathMonster.transform.localScale = new Vector3(hpBarMonster, 1f);
        ManaPlayer.transform.localScale = new Vector3(manaBarPlayer, 1f); // Mise à jour de la barre de mana

        StartCoroutine(AttackCoroutine());
    }

    public void attaqueMonster()
    {
        float randomValue = Random.value; // Génère un nombre aléatoire entre 0 et 1

        if (randomValue <= 0.25f) // 25% de chance atk puissante
        {
            int damage = m.atk2();
            p.hp -= damage;
            hpBarPlayer = (float)p.hp / (float)p.hpMax;

            HeathPlayer.transform.localScale = new Vector3(hpBarPlayer, 1f, 1f);

            if (p.hp <= 0)
            {
                p.hp = 0;
                //gameSet.TransitionToLose();
            }
        }
        else
        {
            // Faire une attaque normale
            int damage = m.atk1();
            hpBarPlayer = (float)p.hp / (float)p.hpMax;

            HeathPlayer.transform.localScale = new Vector3(hpBarPlayer, 1f);

            if (p.hp <= 0)
            {
                p.hp = 0;
                //gameSet.TransitionToLose();
            }
        }
    }


    private IEnumerator AttackCoroutine()
    {
        yield return new WaitForSeconds(1.0f); // Attendre 1 seconde

        attaqueMonster();
    }
}