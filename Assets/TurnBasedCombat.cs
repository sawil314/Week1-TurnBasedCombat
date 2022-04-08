using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBasedCombat : MonoBehaviour
{
    int playerHP, enemyHP, attackCounter, enemyArmor, playerArmor;
    bool defend, charge, game;
    static int maxPlayerHP = 10;
    static int maxPlayerArmor = 2; 
    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (game)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
            {
                int rand = 0;
                if (attackCounter < 2)
                {
                    rand = Random.value > 0.15f ? Random.Range(1, 3) : Random.Range(2, 5);
                    enemyHP = Attack(enemyHP, rand, enemyArmor);
                    attackCounter++;
                }
                else
                {
                    rand = 4;
                    enemyHP = Attack(enemyHP, rand, enemyArmor);
                    attackCounter = 0;
                }
                ShowStatus();
                if (rand < 4)
                {
                    EnemyTurn();
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
            {
                playerHP = Heal(playerHP, 2);
                ShowStatus();
                EnemyTurn();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
            {
                Debug.Log("Player is defending");
                defend = true;
                EnemyTurn();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
            {
                if (playerArmor < maxPlayerArmor)
                {
                    Debug.Log("Player now wears a helmet");
                    playerArmor++;
                    EnemyTurn();
                }
                else
                {
                    Debug.Log("A second helmet would look pretty silly. Wouldn't it?");
                }
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Reset();
        }
    }
    void EnemyTurn()
    {
        if (game)
        {
            if (charge)
            {
                if (!defend)
                {
                    playerHP = 0;
                    ShowStatus();
                }
                else
                    Debug.Log("Player defended");
                charge = false;
            }
            else
            {
                if (Random.value > 0.35f)
                {
                    if (!defend)
                    {
                        playerHP = Attack(playerHP, Random.Range(2, 5), playerArmor);
                        ShowStatus();
                    }
                    else
                        Debug.Log("Player defended");
                }
                else
                {
                    Debug.Log("Enemy is charging energy");
                    charge = true;
                }
            }
            defend = false;
        }
    }
    void ShowStatus()
    {
        Debug.Log($"Player HP: \t {playerHP} \n Enemy HP: \t {enemyHP}");
        if (playerHP <= 0)
        {
            Debug.Log("You died. Game over.");
            game = false;
        }
        else if (enemyHP <= 0)
        {
            Debug.Log("Enemy died. You win.");
            game = false;
        }
    }
    int Attack( int target, int value, int armor = 0)
    {
        if (armor < value)
        {
            //Debug.LogWarning($"target {target}");
            target -= value - armor;
            /*Debug.LogWarning($"value {value}");
            Debug.LogWarning($"armor {armor}");
            Debug.LogWarning($"target {target}");*/
            if (target < 0)
                target = 0;
        }
        return target;
    }
    int Heal (int target, int value)
    {
        target = target + value;
        if (target > maxPlayerHP)
            target = maxPlayerHP;
        return target;
    }
    private void Reset()
    {
        attackCounter = 0;
        playerHP = 10;
        enemyHP = Random.Range(8, 13);
        playerArmor = 1;
        enemyArmor = Random.Range(0, 2);
        Debug.Log("(1) attack (2) heal (3) defend (4) wear helmet");
        defend = false;
        charge = false;
        game = true;
    }
}
