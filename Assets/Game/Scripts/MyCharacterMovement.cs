using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MyCharacterMovement : MonoBehaviour
{
    public GameObject aim;
    public float velocity;
    private Rigidbody2D rgb;
    private void Awake()
    {
        rgb = GetComponent<Rigidbody2D>();       
    }
    private void Start()
    {
        Debug.Log("Estamos");
    }
 
    public void OnMove(InputAction.CallbackContext value)
    {
        Debug.Log("OnMove");
        if (value.performed)
        {
            Vector2 tmp = value.ReadValue<Vector2>();
            Debug.Log(value);
            rgb.velocity = new Vector2(tmp.x,tmp.y)*velocity;
        }
        else
        {
            rgb.velocity = Vector2.zero;
        }
    }
    public void Attack1(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            Debug.Log("Attack1");
        }
      
    }
    public void Attack2(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            Debug.Log("Attack2");
        }
    }
    public void Aim(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            Debug.Log("Rotarrr");
            Vector2 tmp = value.ReadValue<Vector2>();
            aim.transform.forward = Camera.main.ScreenToViewportPoint(tmp);
        }
    }
}
