using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleport : MonoBehaviour
{

    public MapTag Tag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            if (Tag.tag == 0) SceneManager.LoadScene("map2");
            if(Tag.tag == 1) SceneManager.LoadScene("map2");
            if (Tag.tag == 2) SceneManager.LoadScene("map1");
        }
        Debug.Log("test");
    }
}
