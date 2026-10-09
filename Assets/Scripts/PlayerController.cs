using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody _rb;

    public Material _playerMat;

    public float _moveSpeed = 8;
    public float _jumpHeight = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
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

        if (Input.GetKey(KeyCode.W))
        {
            _rb.AddForce(Vector3.up * _jumpHeight, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            _playerMat.SetFloat("PlayerHit", 1);
        }
    }
}
