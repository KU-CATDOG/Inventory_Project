using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    MonsterClass[] Monsters;
    public int MonsterCount;
    public bool Clear = false;
    // Start is called before the first frame update
    void Start()
    {
        Monsters = GetComponentsInChildren<MonsterClass>();
        MonsterCount = Monsters.Length;
        foreach(MonsterClass m in Monsters)
        {
            m.ec = this;
        }
    }
}
