using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossScript : MonoBehaviour
{
    // Start is called before the first frame update
    public RectTransform bossbar;
    public Image bossbkg;
    public GameObject bossbarBar;
    public Text text;
    public string Name;
    float barFactor;
    enemy Enemy;
    void Start()
    {
        Enemy = GetComponent<enemy>();
        text.text = Name;
        bossbarBar.SetActive(true);
        barFactor = Enemy.health / 600;
    }

    // Update is called once per frame
    void Update()
    {
        bossbar.sizeDelta = new Vector2(Enemy.health / barFactor,bossbar.sizeDelta.y);
    }
    private void OnDestroy()
    {   if(bossbarBar!=null)
        bossbarBar.SetActive(false);
    }
}
