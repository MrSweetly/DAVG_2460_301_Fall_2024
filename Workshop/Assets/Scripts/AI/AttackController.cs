using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class AttackController : MonoBehaviour
{
    public float attackRange = 2f;
    public float activationDelay = 1f; // Time before enabling the attack collider
    public float executionPauseTime = 1f; // Time to pause during attack execution
    public float recoveryTime = 1f; // Time to recover after the attack
    public Collider attackCollider; // The collider to enable for the attack

    private Transform player;
    private bool isAttacking;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        player = PlayerManager.Instance.player.transform;
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (attackCollider != null)
        {
            attackCollider.enabled = false;
        }
        // End of if
    }
    // End of Start

    void Update()
    {
        if (!isAttacking && IsPlayerInRange())
        {
            StartCoroutine(AttackCycle());
        }
        // End of if
    }
    // End of Update

    private bool IsPlayerInRange()
    {
        return Vector3.Distance(player.position, transform.position) <= attackRange;
    }
    // End of IsPlayerInRange

    // ReSharper disable Unity.PerformanceAnalysis
    private IEnumerator AttackCycle()
    {
        isAttacking = true;

        StopMovement();
        //
        Debug.Log("Attack Preparation");
        //

        yield return new WaitForSeconds(activationDelay);

        ExecuteAttack();

        // Pause after executing attack
        yield return new WaitForSeconds(executionPauseTime);

        DisableAttackCollider();

        yield return new WaitForSeconds(recoveryTime);

        ResumeMovement();
        isAttacking = false; // Reset for the next attack cycle
        //
        Debug.Log("Attack Cycle Reset");
        //
    }
    // End of AttackCycle

    private void StopMovement()
    {
        if (navMeshAgent)
        {
            navMeshAgent.isStopped = true;
            navMeshAgent.velocity = Vector3.zero;
            navMeshAgent.enabled = false;
        }
        // End of if
    }
    // End of StopMovement

    private void ResumeMovement()
    {
        if (navMeshAgent)
        {
            navMeshAgent.enabled = true;
            navMeshAgent.isStopped = false;
        }
        // End of if
    }
    // End of ResumeMovement

    private void ExecuteAttack()
    {
        if (attackCollider != null)
        {
            attackCollider.enabled = true;
            //
            Debug.Log("Attack Executed");
            //
        }
        // End of if
    }
    // End of ExecuteAttack

    private void DisableAttackCollider()
    {
        if (attackCollider)
        {
            attackCollider.enabled = false;
        }
        // End of if
    }
    // End of DisableAttackCollider
}