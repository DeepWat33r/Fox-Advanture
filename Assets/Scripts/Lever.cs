using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject objectToMove;
    public Vector3 moveDistance = Vector3.up;
    public Direction direction = Direction.Up;
    public float moveSpeed = 1f;

    private bool canMove = true;
    private bool hasStartedMove = false;
    private Vector3 defaultPosition;
    private Vector3 targetPosition;

    private void Start()
    {
        defaultPosition = objectToMove.transform.position;
        targetPosition = defaultPosition;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hasStartedMove = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hasStartedMove = false;
        }
    }

    private float GetDirectionValue()
    {
        switch (direction)
        {
            case Direction.Up:
                return 1f;
            case Direction.Down:
                return -1f;
            case Direction.Right:
                return 1f;
            case Direction.Left:
                return -1f;
            default:
                return 0f;
        }
    }

    private void Update()
    {
        if (hasStartedMove && canMove && Input.GetKeyDown(KeyCode.E))
        {
            Vector3 directionVector = direction == Direction.Up || direction == Direction.Down ? Vector3.up : Vector3.right;
            targetPosition = objectToMove.transform.position + Vector3.Scale(GetDirectionValue() * moveDistance, directionVector);
            canMove = false;
        }

        if (!canMove)
        {
            float step = moveSpeed * Time.deltaTime;
            objectToMove.transform.position = Vector2.MoveTowards(objectToMove.transform.position, targetPosition, step);

            if (Vector2.Distance(objectToMove.transform.position, targetPosition) < 0.01f)
            {
                canMove = true;
                targetPosition = defaultPosition;
            }
        }
    }

    public enum Direction
    {
        Up,
        Down,
        Right,
        Left
    }
}

