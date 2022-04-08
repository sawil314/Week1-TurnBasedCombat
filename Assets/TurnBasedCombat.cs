using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBasedCombat : MonoBehaviour
{
    Player player;
    Enemy enemy1;
    int attackCounter;
    bool game;
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
                    Attack(enemy1, rand);
                    attackCounter++;
                }
                else
                {
                    rand = 4;
                    Attack(enemy1, rand);
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
                Heal(player, 3);
                ShowStatus();
                EnemyTurn();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
            {
                Debug.Log("Player is defending");
                player.Defend = true;
                EnemyTurn();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
            {
                if (!player.Helmet)
                {
                    Debug.Log("Player now wears a helmet");
                    player.Helmet = true;
                    player.Armor++;
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
            if (enemy1.Charge)
            {
                if (!player.Defend)
                {
                    player.HP = 0;
                    ShowStatus();
                }
                else
                    Debug.Log("Player defended");
                enemy1.Charge = false;
            }
            else
            {
                if (Random.value > 0.35f)
                {
                    if (!player.Defend)
                    {
                        Attack(player, Random.Range(2, 5));
                        ShowStatus();
                    }
                    else
                        Debug.Log("Player defended");
                }
                else
                {
                    Debug.Log("Enemy is charging energy");
                    enemy1.Charge = true;
                }
            }
            player.Defend = false;
        }
    }
    void ShowStatus()
    {
        Debug.Log($"Player HP: \t {player.HP} \n Enemy HP: \t {enemy1.HP}");
        if (player.HP <= 0)
        {
            Debug.Log("You died. Game over.");
            game = false;
        }
        else if (enemy1.HP <= 0)
        {
            Debug.Log("Enemy died. You win.");
            game = false;
        }
    }
    void Attack( Creature target, int value)
    {
        if (target.Armor < value)
        {
            //Debug.LogWarning($"target {target}");
            target.HP -= value - target.Armor;
            /*Debug.LogWarning($"value {value}");
            Debug.LogWarning($"armor {armor}");
            Debug.LogWarning($"target {target}");*/
            if (target.HP < 0)
                target.HP = 0;
        }
    }
    void Heal (Creature target, int value)
    {
        target.HP = target.HP + value;
        if (target.HP > target.MaxHP)
            target.HP = target.MaxHP;
    }
    private void Reset()
    {
        player = new Player(10, 1);
        enemy1 = new Enemy(Random.Range(8, 13), Random.Range(0, 2));
        attackCounter = 0;
        Debug.Log("(1) attack (2) heal (3) defend (4) wear helmet");
        game = true;
    }
}
