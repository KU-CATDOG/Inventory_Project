using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public ClearJudge clearJudge;
    public Transform shield;
    public Transform armor;
    public Transform shoes;
    public Transform sword;
    public Transform accessories;
    Player player; 
    int count;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (clearJudge.Clear == true&&count==0)
        {
            dropDifferentItem();
            count++;
        }
    }
    private void dropDifferentItem()
    {

        int a, b;

        a = Random.Range(0, 5);
        switch (a)
        {
            case 0:
                Instantiate(shield);
                break;

            case 1:
                Instantiate(armor);
                break;

            case 2:
                Instantiate(shoes);
                break;

            case 3:
                Instantiate(sword);
                break;

            case 4:
                Instantiate(accessories);
                break;
        }
        do
        {
            b = Random.Range(0, 5);
        } while (a == b);
        switch (b)
        {
            case 0:
                Instantiate(shield);
                break;

            case 1:
                Instantiate(armor);
                break;

            case 2:
                Instantiate(shoes);
                break;

            case 3:
                Instantiate(sword);
                break;

            case 4:
                Instantiate(accessories);
                break;
        }
    }
}
