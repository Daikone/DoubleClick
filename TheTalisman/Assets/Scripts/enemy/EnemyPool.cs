using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    List<GameObject> projectiles;
    public GameObject projBlueprint;
    public int nrProjectiles;
    public float time = 3;
    float direction;
    public float range;
    Transform player;
    
    // Start is called before the first frame update

    void Start()
    {
        projectiles = new List<GameObject>();
        direction = 360 / nrProjectiles;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        for (int i = 1; i <= nrProjectiles; i++)
        {
            GameObject obj = Instantiate(projBlueprint) as GameObject;
            obj.GetComponent<projScript>().SetAngle(direction * i);
            obj.SetActive(false);
            
            projectiles.Add(obj);

            setBack();
        }

    }

    // Update is called once per frame
    void Update()
    {   if (Vector2.Distance(player.position, transform.position) <= range)
        {
            
            time -= Time.deltaTime;
            if (time <= 0)
            {
                setBack();
                time = 3;
            }
        }
        else
            notActive();

        

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    public void Active()
    {
        for (int i = 0; i < projectiles.Count; i++)
        {
            projectiles[i].SetActive(true);

        }
    }
    public void SetSpeed(float s)
    {
        for (int i = 1; i <= nrProjectiles; i++)
        {
            projectiles[i].GetComponent<projScript>().speed=s;
        }
    }

    public void notActive()
    {
        for (int i = 0; i < projectiles.Count; i++)
        {
            projectiles[i].SetActive(false);

        }
    }
    private void OnDestroy()
    {
        for (int i = 0; i < projectiles.Count; i++)
        {
            Destroy(projectiles[i].gameObject);

        }
    }
    public void setBack()
    {
        for (int i = 0; i < projectiles.Count; i++)
        {
            projectiles[i].transform.position = transform.position;
            projectiles[i].SetActive(true);
        }
    }
}
