using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody _rb;

    public Material _playerMat;

    public float _moveSpeed = 8;
    public float _jumpHeight = 10;

    public Transform _spawn;

    bool _paused = false;
    public float _deathPause = 0.8f;
    float _pauseTimer = 0;

    bool _lambert;
    bool _ambient;
    bool _specular;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Lighting();
        if (_paused)
        {
            _pauseTimer += Time.deltaTime;
            if (_pauseTimer >= _deathPause)
            {
                _paused = false;
                _playerMat.SetFloat("_PlayerHit", 0);
            }
        }
        else Move();
    }

    void Lighting()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (_lambert) _playerMat.SetFloat("_Lambert", 0);
            else _playerMat.SetFloat("_Lambert", 1);
            _lambert = !_lambert;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (_ambient) _playerMat.SetFloat("_Ambient", 0);
            else _playerMat.SetFloat("_Ambient", 1);
            _ambient = !_ambient;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (_specular) _playerMat.SetFloat("_Specular", 0);
            else _playerMat.SetFloat("_Specular", 1);
            _specular = !_specular;
        }
    }

    void Move()
    {
        float moveX = 0;
        if (Input.GetKey(KeyCode.A))
        {
            moveX--;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX++;
        }
        //_rb.linearVelocity.x = moveX;
        _rb.linearVelocity = new Vector3(moveX * _moveSpeed, _rb.linearVelocity.y, 0);

        if (Input.GetKeyDown(KeyCode.W))
        {
            _rb.AddForce(Vector3.up * _jumpHeight, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            _playerMat.SetFloat("_PlayerHit", 1);
            gameObject.transform.position = _spawn.transform.position;
            _pauseTimer = 0;
            _paused = true;
        }
    }
}
