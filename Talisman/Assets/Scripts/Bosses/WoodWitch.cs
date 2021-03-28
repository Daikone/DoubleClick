using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodWitch : MonoBehaviour
{
    enemy enemy;
    GameObject Player;
    int phase = 1;
    //Time / movement
    public float time;
    public float time2;
    float enemyHoriginal;
    public float speed;
    public Vector2 target;
    Rigidbody2D rigi;
    EnemyPool pool;
    //bossbar
    GameObject bossbar;

    void Awake()
    {
        enemy = GetComponent<enemy>();
        Player = GameObject.FindGameObjectWithTag("Player");
        enemyHoriginal = enemy.health;
        rigi = GetComponent<Rigidbody2D>();
        pool = GetComponent<EnemyPool>();



    }

    // Update is called once per frame
    void Update()
    {
        

        time -= Time.deltaTime;
        if (time <= 0)
        {
            switch (phase)
            {
                case 1:
                    phase = 2;
                    if (enemy.health <= enemyHoriginal / 2)
                        phase = 3;
                    time = 7;
                    break;
                case 2:
                    phase = 1;
                    if (enemy.health <= enemyHoriginal / 2)
                        phase = 4;
                    time = 5;
                    break;
                case 3:
                    phase = 4;
                    time = 2f;
                    break;
                case 4:
                    phase = 3;
                    time = 2f;
                    break;
                default: break;
            }

        }
        switch (phase)
        {
            case 1:

                transform.position = Vector2.MoveTowards(this.transform.position, target, speed * 2 * Time.deltaTime);
                time2 -= Time.deltaTime;
                if (time2 <= 0)
                {
                    target = Player.transform.position;
                    time2 = 3;
                }
                break;
            case 2:

                break;
            case 3:
                transform.position = Vector2.MoveTowards(this.transform.position, target, speed * 6 * Time.deltaTime);
                time2 -= Time.deltaTime;
                if (time2 <= 0)
                {
                    target = Player.transform.position;
                    time2 = 1.5f;
                }
                break;
            case 4:
                
                break;
            default: break;
        }
    }
}
