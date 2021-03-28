using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class symbolPool : MonoBehaviour
{
    List<GameObject> projectiles;
    public GameObject[] projBlueprints;
    public int nrProjectiles;
    public float time = 3;
    float direction;
    public float range;


    // Start is called before the first frame update
    private void Awake()
    {
        this.enabled = GameManager.EnableProj;
    }
    void Start()
    {
       
        projectiles = new List<GameObject>();
        direction = 360 / nrProjectiles;
        
        for (int i = 1; i <= nrProjectiles; i++)
        {
            GameObject obj = Instantiate(projBlueprints[GameManager.projIndex]) as GameObject;
            obj.GetComponent<PlayerProj>().SetAngle(direction * i);
            obj.SetActive(false);

            projectiles.Add(obj);

            setBack();
        }

    }

    // Update is called once per frame
    void Update()
    {
        this.enabled = GameManager.EnableProj;
        
        time -= Time.deltaTime;
            if (time <= 0)
            {
                setBack();
                time = 3;
            }
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
            projectiles[i].GetComponent<projScript>().speed = s;
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
        if(projectiles.Count>=0)
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
