using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorArtifact : MonsterClass
{

    protected override void Start()
    {
        base.Start();
        MaxHealth = Health = 50f;
    }
    public override void GetDamaged(float damage)
    {
        base.GetDamaged(damage);
    }
    protected override Queue<IEnumerator> DecideNextRoutine()
    {
        Queue<IEnumerator> nextRoutines = new Queue<IEnumerator>();

        nextRoutines.Enqueue(NewActionRoutine(WaitRoutine(10f)));

        return nextRoutines;
    }

}
