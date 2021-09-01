using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    private GameObject player;
    public Text HealthUI;
    // Start is called before the first frame update
    void Start()
    {
         player = FindObjectOfType<Player>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        HealthUI.text = "Ã¼·Â:"+((int)player.GetComponent<Player>().health).ToString()+"/" +(player.GetComponent<Player>().maxHealth).ToString();
    }
}
