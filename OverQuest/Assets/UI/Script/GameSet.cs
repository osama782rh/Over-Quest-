using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSet : MonoBehaviour
{
    public enum BattleState
    {
        InProgress,
        Win,
        Lose
    }

    private BattleState currentState;

    private void Start()
    {
        // Commencer le combat en cours
        StartBattle();
    }

    private void Update()
    {
        // Vérifier l'état actuel du combat
        switch (currentState)
        {
            case BattleState.InProgress:
                // Mettre à jour le combat en cours
                UpdateBattleInProgress();
                break;
            case BattleState.Win:
                // Gérer l'état de victoire
                HandleWin();
                break;
            case BattleState.Lose:
                // Gérer l'état de défaite
                HandleLose();
                break;
            default:
                break;
        }
    }

    public void StartBattle()
    {
        // Initialiser l'état du combat
        currentState = BattleState.InProgress;

        // Effectuer les actions nécessaires pour commencer le combat
        // ...
    }

    private void UpdateBattleInProgress()
    {
        // Mettre à jour le combat en cours
        // Vérifier les conditions de victoire ou de défaite
        // Par exemple, si le joueur a éliminé tous les ennemis, passer à l'état de victoire (Win)
        // Sinon, si le joueur a perdu tous ses points de vie (PV), passer à l'état de défaite (Lose)
        // ...

        // Pour l'exemple, passons à l'état de victoire après 5 secondes
        Invoke("TransitionToWin", 5f);
    }

    private void HandleWin()
    {
        // Gérer l'état de victoire
        // Afficher un message de victoire, récompenses, etc.
        // ...

        // Pour l'exemple, passons à l'état de défaite après 3 secondes
        Invoke("TransitionToLose", 3f);
    }

    private void HandleLose()
    {
        // Gérer l'état de défaite
        // Afficher un message de défaite, écran de fin de jeu, etc.
        // ...

        // Pour l'exemple, recommencer le combat après 3 secondes
        Invoke("StartBattle", 3f);
    }

    public void TransitionToWin()
    {
        // Passer à l'état de victoire
        currentState = BattleState.Win;
    }

    public void TransitionToLose()
    {
        // Passer à l'état de défaite
        currentState = BattleState.Lose;
    }
}