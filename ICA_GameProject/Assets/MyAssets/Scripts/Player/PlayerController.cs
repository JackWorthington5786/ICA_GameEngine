using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

//using tutorial: https://www.youtube.com/watch?v=LVu3_IVCzys

public class PlayerClickController : MonoBehaviour
{
    const string IDLE = "Idle";
    const string WALK = "Walk";

    CustomActions input;

    NavMeshAgent agent;
    Animator animator;

    [Header("Movement")]
    [SerializeField] ParticleSystem clickEffect;
    [SerializeField] LayerMask clickableLayers;

    float lookRotationSpeed = 8f;
    
    [Header("Game Over")]
    public GameObject gameOverCanvas;
    
    void Awake() 
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        input = new CustomActions();
        AssignInputs();
    }

    void AssignInputs()
    {
        input.Main.Move.performed += ctx => ClickToMove();
    }

    void ClickToMove()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayers)) 
        {
            agent.destination = hit.point;
            if(clickEffect != null)
            { Instantiate(clickEffect, hit.point + new Vector3(0, 0.1f, 0), clickEffect.transform.rotation); }
        }
    }

    void OnEnable() 
    { input.Enable(); }

    void OnDisable() 
    { input.Disable();}

    void Update() 
    {
        FaceTarget();
        SetAnimations();
    }

    void FaceTarget()
    {
        Vector3 moveDirection = agent.velocity.normalized;

        if (moveDirection != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0, moveDirection.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookRotationSpeed);
        }
    }


    void SetAnimations()
    {
        if(agent.velocity == Vector3.zero)
        { animator.Play(IDLE); }
        else
        { animator.Play(WALK); }
    }
    
    //if player collides with enemy or enemyProjectile set canvas to game over
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyProjectile"))
        {
            gameOverCanvas.SetActive(true);
        }
    }
    
}