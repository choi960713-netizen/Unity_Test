using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletFactory;
    public Transform FirePoint;
    void Update()
    {
        Fire();
    }
    void Fire()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletFactory, FirePoint.position, FirePoint.rotation);
        }
    }
}
