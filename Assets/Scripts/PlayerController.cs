using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private BulletSpawner _bulletSpawner;

    private float ShootingCooldown => 1f / _bulletsPerSecond;

    private float _timeToShoot = 0f;

    [SerializeField]
    private int _bulletsPerSecond = 3;

    [SerializeField]
    private float _initialSpeed = 5f;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _speedIncrease = 1.5f;

    void Start()
    {
        _speed = _initialSpeed;
        _bulletSpawner = gameObject.GetComponentInChildren<BulletSpawner>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time >= _timeToShoot)
            {
                _timeToShoot = Time.time + ShootingCooldown;
                _bulletSpawner.SpawnBullet();
            }
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            Move(transform.forward.normalized);
        }

        var directionX = Input.GetAxis("Horizontal");

        Rotate(directionX);
    }

    private void Move(Vector3 direction)
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _speed *= _speedIncrease;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _speed = _initialSpeed;
        }
        transform.position += _speed * direction * Time.deltaTime;
    }

    private void Rotate(float direction)
    {
        transform.Rotate(new Vector3(0f,direction,0f));
    }
}