using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushOldGuy : MonoBehaviour
{
    #region Push Variables
    public Transform player; 
    public GameObject oldGuy; 
    public float pushForce = 5f; 
    public float interactionDistance = 2f; 
    public LayerMask pushableLayer;
    #endregion

    private Rigidbody _oldGuyRb; 

    #region Unity Methods
    private void Awake()
    {
        InitializeComponents();
    }

    private void FixedUpdate()
    {
        ProcessPushing();
    }
    #endregion

    
    private void InitializeComponents()
    {
        _oldGuyRb = oldGuy.GetComponent<Rigidbody>();
    }
    #region Push Methods
    private void ProcessPushing()
    {
        float distance = Vector3.Distance(player.position, oldGuy.transform.position);

        if (distance <= interactionDistance && IsPushable()) 
        {
            Vector3 direction = oldGuy.transform.position - player.position;
            _oldGuyRb.AddForce(direction.normalized * pushForce, ForceMode.Impulse);
        }
    }
    private bool IsPushable()
    {
        return oldGuy.layer == LayerMask.NameToLayer("Pushable"); 
    }
    #endregion
}