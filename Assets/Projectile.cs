using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float force;
    private Vector3 trajectory;

    public void Setup(float force, Vector3 forward)
    {
        this.force = 1000f;
        this.trajectory = forward;
    }
    private void Start()
    {
        this.force = 100f;
        this.GetComponent<Rigidbody>().AddForce(trajectory * force);
    }
    // Update is called once per frame
    void Update()
    {
        //transform.position += new Vector3(0, 0, 1 * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision other)
    {

        // ToDO check wall hit
        if (other.gameObject.tag.Equals("Wall"))
        {
            Debug.Log("Hit wall");
            Destroy(gameObject);
        }
    }
}
