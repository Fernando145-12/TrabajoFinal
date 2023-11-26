using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MyCharacterMovement : MonoBehaviour
{
    public GameObject aim;
    public float velocity;
    private Rigidbody2D rgb;
    private bool miro;
    private Vector2 punteroMouse;
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
        if (value.performed)
        {
            miro = true;
            //Debug.Log("CAS1"+value.ReadValue<Vector2>());
            //punteroMouse = (new Vector2(value.ReadValue<Vector2>().x+ transform.position.x, value.ReadValue<Vector2>().y + transform.position.y));
            //Debug.Log("CAS2" + punteroMouse.normalized);
            punteroMouse = Camera.main.ScreenToWorldPoint(value.ReadValue<Vector2>());
        }
    }
    private void Update()
    {
        if (miro)
        {
            Vector2 tmp =  punteroMouse ;
            float anguloRadianes = Mathf.Atan2(tmp.y - transform.position.y, tmp.x - transform.position.x);
            float anguloGrados = (180 / Mathf.PI) * anguloRadianes - 90;
            transform.rotation = Quaternion.Euler(0, 0, anguloGrados);
        }
    }
}
