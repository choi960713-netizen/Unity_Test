using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 5.0f;
    public float jump = 3.0f;
    float posX, posY;
    // Update is called once per frame
    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0f, v).normalized;

        transform.position += dir * speed * Time.deltaTime;
       
        if(Input.GetKey(KeyCode.Space))
        {
            transform.position += Vector3.up * jump*Time.deltaTime;
        }

        
    }
}
