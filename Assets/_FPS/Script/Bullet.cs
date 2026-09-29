using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 5f;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
