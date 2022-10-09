using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandlerComponent : MonoBehaviour
{
    public static InputHandlerComponent Instance { get; private set; }
    public event EventHandler OnShootEvent;
    public Action<KeyCode> OnMoveEvent;
    public Action<KeyCode> OnRotateEvent; // list<function(Keycode a)>
    // Action.invoke ->  forEach function -> function.exec
    public event EventHandler OnJumpEvent;
    public event EventHandler OnReloadEvent;

    //public event EventHandler OnRotationEvent;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            OnShootEvent?.Invoke(this, EventArgs.Empty);
        }
        if (Input.GetKey(KeyCode.W))
        {
            OnMoveEvent?.Invoke(KeyCode.W);
        }

        if (Input.GetKey(KeyCode.A))
        {
            OnMoveEvent?.Invoke(KeyCode.A);
        }
        if (Input.GetKey(KeyCode.S))
        {
            OnMoveEvent?.Invoke(KeyCode.S);
        }
        if (Input.GetKey(KeyCode.D))
        {
            OnMoveEvent?.Invoke(KeyCode.D);
        }


        if (Input.GetKey(KeyCode.Q))
        {
            OnRotateEvent?.Invoke(KeyCode.Q);
        }
        if (Input.GetKey(KeyCode.E))
        {
            OnRotateEvent?.Invoke(KeyCode.E);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            OnJumpEvent?.Invoke(this, EventArgs.Empty);
        }
        if (Input.GetKey(KeyCode.R))
        {
            Debug.Log("Reload");
            OnReloadEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
