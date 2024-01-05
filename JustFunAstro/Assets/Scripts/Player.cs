using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    [SerializeField] float offset;
    [SerializeField] Vector3 targetPos;
    //hphphpphph
    [SerializeField] int healthPoint;
    [SerializeField] bool immortal = false;
    [SerializeField] HPUI hPUI;
    [SerializeField] float longJumpSpeed;

    public int HealtPoint { get; private set; }
    public Vector3 LongTarget;
    public bool IsLongJumping = false;
    private bool _isMoving = false;


    private void Start()
    {
        HealtPoint = healthPoint;
    }

    private void Update()
    {
        if(_isMoving == false && IsLongJumping == false)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                SetTargetPosY(offset);
                _isMoving = true;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                SetTargetPosY(-offset);
                _isMoving = true;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                SetTargetPosX(-offset);
                _isMoving = true;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                SetTargetPosX(offset);
                _isMoving = true;
            }
        }

        if (_isMoving)
        {
            Jump();
        }

        if (IsLongJumping)
        {
            LongJump();
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

    public void LongJump()
    {
        Vector3 target = new Vector3(LongTarget.x, LongTarget.y + 0.6f, LongTarget.z);
        transform.position = Vector3.MoveTowards(transform.position, target, longJumpSpeed * Time.deltaTime);

        if (transform.position == target)
        {
            IsLongJumping = false;
        }
    }

    public void GetDamage(int damage)
    {
        if (!immortal)
        {
            if(damage > 3)
            {
                damage = 3;
            }

            healthPoint -= damage;
            HealtPoint = healthPoint;
            hPUI.SubtractHP(HealtPoint);

            Debug.Log(healthPoint);

            if (healthPoint <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
