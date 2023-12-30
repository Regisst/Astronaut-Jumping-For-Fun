using JetBrains.Annotations;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    [SerializeField] Vector3 targetPos;
    [SerializeField] int healthPoint;
    [SerializeField] bool immortal = false;

    public int HealtPoint { get; private set; }

    private bool _isMoving = false;
    
    //Rigidbody _rb;

    private void Start()
    {
        // _rb = GetComponent<Rigidbody>();
        HealtPoint = healthPoint;
    }

    private void Update()
    {
        if(_isMoving == false)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                SetTargetPosY(2f);
                _isMoving = true;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                SetTargetPosY(-2f);
                _isMoving = true;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                SetTargetPosX(-2f);
                _isMoving = true;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                SetTargetPosX(2f);
                _isMoving = true;
            }
        }

        if (_isMoving)
        {
            Jump();
        }
    }
    private void SetTargetPosX(float direction)
    {
        targetPos = new Vector3(transform.position.x + direction, transform.position.y, transform.position.z);
    }
    private void SetTargetPosY(float direction)
    {
        targetPos = new Vector3(transform.position.x, transform.position.y + direction, transform.position.z);
    }
    private void Jump()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if(transform.position == targetPos)
        {
            _isMoving = false;
        }
    }

    public void GetDamage(int damage)
    {
        if (!immortal)
        {
            healthPoint -= damage;

            HealtPoint = healthPoint;

            Debug.Log(healthPoint);

            if (healthPoint <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
