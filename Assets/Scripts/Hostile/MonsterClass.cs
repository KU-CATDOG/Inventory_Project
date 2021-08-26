using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterClass : MonoBehaviour
{

    protected Coroutine CurrentRoutine { get; private set; }
    private Queue<IEnumerator> nextRoutines = new Queue<IEnumerator>();

    public float Health { get; protected set; }
    public float MaxHealth { get; protected set; }
    public float AttackDamage { get; protected set; }
    public float MovementSpeed { get; protected set; }
    public float Range { get; protected set; }
    public float Size { get; protected set; }

    protected virtual void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    private void Update()
    {
        if (CurrentRoutine == null)
        {
            NextRoutine();
        }
    }
    public virtual void GetDamaged(float damage)
    {
        if(GameObject.Find("ArmorArtifact") != null && gameObject.name != "ArmorArtifact")
        {

        }
        else
        {
            Health -= damage;
            Debug.Log("Enemy damage taken " + damage);
        }
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    protected Vector3 GetObjectPos()    // ���� ������Ʈ ����3 ��ȯ
    {
        return gameObject.transform.position;
    }
    protected Vector3 GetPlayerPos()    // �÷��̾� ����3 ��ȯ; �÷��̾ ����ִ��� ���� Ȯ���ؾ���
    {
        return FindObjectOfType<Player>().transform.position;
    }
    

    protected float distToPlayer()    // ������Ʈ�� �÷��̾� �Ÿ� ��ȯ; �÷��̾ ����ִ��� ���� Ȯ���ؾ���
    {
        return (GetObjectPos() - GetPlayerPos()).magnitude;
    }
   
    private void NextRoutine()
    {
        if (nextRoutines.Count <= 0)
        {
            nextRoutines = DecideNextRoutine();
        }
        StartCoroutineUnit(nextRoutines.Dequeue());
    }
    protected abstract Queue<IEnumerator> DecideNextRoutine();
    private void StartCoroutineUnit(IEnumerator coroutine)
    {
        if (CurrentRoutine != null)
        {
            StopCoroutine(CurrentRoutine);
        }
        CurrentRoutine = StartCoroutine(coroutine);
    }
    protected IEnumerator NewActionRoutine(IEnumerator action)
    {
        yield return action;
        CurrentRoutine = null;
    }
    protected IEnumerator MoveRoutine(Vector3 destination, float time)
    {
        yield return MoveRoutine(destination, time, AnimationCurve.Linear(0, 0, 1, 1));
    }
    protected IEnumerator MoveRoutine(Vector3 destination, float time, AnimationCurve curve)
    {
        Vector3 startPosition = transform.position;
        //Debug.Log(startPosition);
        for (float t = 0; t <= time; t += Time.deltaTime)
        {
            transform.position =
                Vector3.Lerp(startPosition, destination, curve.Evaluate(t / time));
            yield return null;
        }
        transform.position = destination;
    }
    protected IEnumerator WaitRoutine(float time)
    {
        yield return new WaitForSeconds(time);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "player")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

}
