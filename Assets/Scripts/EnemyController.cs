using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(findPath());
        StartCoroutine(detectPlayer());
    }

    IEnumerator detectPlayer()
    {
        while (true)
        {
            if (player == null) break;
            if (Vector3.Distance(transform.position, player.position) < 1f)
            {
                attack();
                break;
            }
            yield return new WaitForSeconds(.5f);
        }
    }

    IEnumerator findPath()
    {
        while (true)
        {
            if (player != null)
                agent.SetDestination(player.position);
            else break;
            yield return new WaitForSeconds(2f);
        }
    }

    public void damage()
    {
        StopAllCoroutines();
        agent.enabled = false;
        animator.SetTrigger("die");
        gameObject.GetComponent<CapsuleCollider>().enabled = false;   
        Destroy(gameObject, 2f);
        Game_Manager.instance.deadUnit(gameObject);

    }

    void attack()
    {
        animator.SetBool("attack", true);
        player.gameObject.BroadcastMessage("damage");
    }

    void Update()
    {

    }
}
