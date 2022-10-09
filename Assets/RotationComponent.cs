using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationComponent : MonoBehaviour
{
    private float rotY = 0;
    // Start is called before the first frame update
    private void Start()
    {
        InputHandlerComponent.Instance.OnRotateEvent += RotationComponent_OnRotateEvent;
    }

    // Update is called once per frame

    private void RotationComponent_OnRotateEvent(KeyCode inputKey)
    {
        Debug.Log("Rotating" + inputKey);
        switch (inputKey)
        {
            case KeyCode.Q:
                rotY = 1f;
                break;
            case KeyCode.E:
                rotY = -1f;
                break;
        }
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(new Vector3(0, rotY, 0));
    }
}