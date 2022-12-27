using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image hpbar;
    float value = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        hpbar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
	    PlayerHPbar();
    }
    public void PlayerHPbar( ) 
    {
        float HP = player.health; //캐릭터 hp를 받아옴
        value = Mathf.Lerp(value, HP/10.0f, Time.deltaTime * 10);
        hpbar.fillAmount = value;
    }
}
