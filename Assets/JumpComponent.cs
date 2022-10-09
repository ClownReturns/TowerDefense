using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JumpComponent : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float jumpForce;
    private bool isGrounded;
    // Start is called before the first frame update
    private void Start()
    {
        isGrounded = true;
        InputHandlerComponent.Instance.OnJumpEvent += JumpComponent_OnJumpEvent;
    }

    // Update is called once per frame

    private void JumpComponent_OnJumpEvent(object sender, EventArgs args)
    {
        Debug.Log(isGrounded);
        if (isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Floor"))
        {
            isGrounded = true;
        }
        
    }
}
