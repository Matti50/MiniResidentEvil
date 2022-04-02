using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10f;

    [SerializeField]
    private int _lifeTime = 1;

    private float _timeToGetDestroyed;

    private void Start()
    {
        _timeToGetDestroyed = Time.time + _lifeTime;
    }

    void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;

        if (Time.time >= _timeToGetDestroyed)
        {
            Destroy(gameObject);
        }
    }
}
