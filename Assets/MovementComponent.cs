using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    [SerializeField] private float speed;
    private float xComp, zComp = 0;
    // Start is called before the first frame update
    void Start()
    {
        InputHandlerComponent.Instance.OnMoveEvent += MovementComponent_OnMoveEvent;

    }

    // Update is called once per frame
    void MovementComponent_OnMoveEvent(KeyCode inputKey)
    {
        switch (inputKey)
        {
            case KeyCode.W:
                zComp = 1f;
                xComp = 0f;
                break;
            case KeyCode.A:
                xComp = -1f;
                zComp = 0f;
                break;
            case KeyCode.S:
                zComp = -1f;
                xComp = 0f;
                break;
            case KeyCode.D:
                xComp = 1f;
                zComp = 0f;
                break;
        }
        Move();
    }


    void Move()
    {
        transform.Translate(new Vector3(xComp * speed * Time.deltaTime, 0, zComp * speed * Time.deltaTime));
    }
}
