using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    private GameObject player;
    public Text DamageUI;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        DamageUI.text = "°ø°Ý·Â:" + (player.GetComponent<Player>().additionalDMG).ToString();
    }
}
