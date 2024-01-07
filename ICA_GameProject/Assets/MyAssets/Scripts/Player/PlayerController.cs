using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

//using tutorial: https://www.youtube.com/watch?v=LVu3_IVCzys

public class PlayerClickController : MonoBehaviour
{
    
    //animation variables
    const string IDLE = "Idle";
    const string WALK = "Walk";

    //input variables
    CustomActions input;

    //movement variables
    NavMeshAgent agent;
    Animator animator;

    //click effect variables
    [Header("Movement")]
    [SerializeField] ParticleSystem clickEffect;
    [SerializeField] LayerMask clickableLayers;

    //rotation variables
    float lookRotationSpeed = 8f;
    
    //game over variables
    [Header("Game Over")]
    public GameObject gameOverCanvas;
    
    //on awake get components
    void Awake() 
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        input = new CustomActions();
        AssignInputs();
    }

    //assign inputs
    void AssignInputs()
    {
        input.Main.Move.performed += ctx => ClickToMove();
    }

    //click to move
    void ClickToMove()
    {
        //raycast to mouse position
        RaycastHit hit;
        //if raycast hits something move to that position
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayers)) 
        {
            agent.destination = hit.point;
            if(clickEffect != null)
            { Instantiate(clickEffect, hit.point + new Vector3(0, 0.1f, 0), clickEffect.transform.rotation); }
        }
    }

    //enable and disable inputs
    void OnEnable() 
    { input.Enable(); }

    //enable and disable inputs
    void OnDisable() 
    { input.Disable();}

    //on update face target and set animations
    void Update() 
    {
        FaceTarget();
        SetAnimations();
    }

    //face target
    void FaceTarget()
    {
        //get direction of movement
        Vector3 moveDirection = agent.velocity.normalized;

        //if there is movement rotate towards movement direction
        if (moveDirection != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0, moveDirection.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookRotationSpeed);
        }
    }


    //set animations
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