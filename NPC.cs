using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum NPCState { Idle, Chase, Attack }

public class NPC : MonoBehaviour
{
    public NPCState currentState = NPCState.Idle;
 
    public NavMeshAgent agent;
    public Transform player;
    public GameObject gameOverText;
 
    public float detectionRange = 10f;
    public float attackRange = 0.5f;
 
    void Start()
    {
        agent  = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gameOverText.SetActive(false);
    }
 
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
 
        NPCState nextState = EvaluateState(distance);
 
        if (nextState != currentState)
            TransitionTo(nextState);
 
        ExecuteState();
    }
 
    NPCState EvaluateState(float distance)
    {
        if (distance <= attackRange)    return NPCState.Attack;
        if (distance <= detectionRange) return NPCState.Chase;
        return NPCState.Idle;
    }
 
    void TransitionTo(NPCState newState)
    {
        currentState = newState;
 
        switch (newState)
        {
            case NPCState.Idle:
                agent.isStopped = true;
                break;
            case NPCState.Chase:
                agent.isStopped = false;
                break;
            case NPCState.Attack:
                agent.isStopped = true;
                 if (gameOverText != null)
                {
                    gameOverText.SetActive(true);
                    Time.timeScale = 0f;
                }
                break;
        }
    }
 
    void ExecuteState()
    {
        if (currentState == NPCState.Chase)
            agent.SetDestination(player.position);
    }
 
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
