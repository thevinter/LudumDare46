using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestController : MonoBehaviour
{
    private Rigidbody2D rb; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 directionalInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        rb.MovePosition(
            transform.position + directionalInput * 30 * Time.deltaTime
        );
    }
}
