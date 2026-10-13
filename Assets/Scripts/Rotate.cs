using UnityEngine;

public class Rotate : MonoBehaviour
{

    [SerializeField] private float speedx;
    [SerializeField] private float speedy;
    [SerializeField] private float speedz;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(360 * speedx * Time.deltaTime, 360 * speedy * Time.deltaTime, 360 * speedz * Time.deltaTime);
    }
}
