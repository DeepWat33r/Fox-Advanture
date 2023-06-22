using System;
using UnityEngine;

namespace Objects
{
    public class Lever : MonoBehaviour
    {
        public enum Directions
        {
            Up,
            Down,
            Left,
            Right
        }
        public GameObject objectToMove;
        public Directions directions = Directions.Up;
        public Animator animator;
        public Canvas canvas;
    
        public float moveDistance = 1f;
        public float moveSpeed = 1f;
        private bool _isPlayer;
        private bool _isMoving = false;
        private bool _isActive = false;
        private Vector3 _defaultPosition;

        public void Start()
        {
            _defaultPosition = objectToMove.transform.position;
        }

        public void Update()
        {
            if (_isPlayer && !_isMoving && Input.GetKeyDown(KeyCode.E))
            {
                _isMoving = true;
                if (!_isActive) animator.SetBool("IsActive", true);
                else animator.SetBool("IsActive", false);
                _isActive = !_isActive;
            }

            if (_isMoving)
            {
                MovingObject();
            }
        }
        private void OnTriggerStay2D(Collider2D other)
        {
            canvas.gameObject.SetActive(true);
            if (other.gameObject.CompareTag("Player"))
            {
                _isPlayer = true;
            }
        }
    
        private void OnTriggerExit2D(Collider2D other)
        {
            canvas.gameObject.SetActive(false);
            if (other.gameObject.CompareTag("Player"))
            {
                _isPlayer = false;
            }
        }

        private void MovingObject()
        {
            switch (directions)
            {
                case Directions.Up:
                    MovingUp();
                    break;
                case Directions.Down:
                    MovingDown();
                    break;
                case Directions.Left:
                    MovingLeft();
                    break;
                case Directions.Right:
                    MovingRight();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    
        private void MovingUp()
        {
            if (Vector3.Distance(objectToMove.transform.position, _defaultPosition) < moveDistance)
            {
                objectToMove.transform.Translate(Vector3.up * (moveSpeed * Time.deltaTime));
                directions = Directions.Up;
            }
            else
            {
                _isMoving = false;
                _defaultPosition = objectToMove.transform.position;
                directions = Directions.Down;
            }
        }
        private void MovingDown()
        {
            if (Vector3.Distance(objectToMove.transform.position, _defaultPosition) < moveDistance)
            {
                objectToMove.transform.Translate(Vector3.down * (moveSpeed * Time.deltaTime));
                directions = Directions.Down;
            }
            else
            {
                _isMoving = false;
                _defaultPosition = objectToMove.transform.position;
                directions = Directions.Up;
            }
        }
        private void MovingRight()
        {
            if (Vector3.Distance(objectToMove.transform.position, _defaultPosition) < moveDistance)
            {
                objectToMove.transform.Translate(Vector3.right * (moveSpeed * Time.deltaTime));
                directions = Directions.Right;
            }
            else
            {
                _isMoving = false;
                _defaultPosition = objectToMove.transform.position;
                directions = Directions.Left;
            }
        }    
        private void MovingLeft()
        {
            if (Vector3.Distance(objectToMove.transform.position, _defaultPosition) < moveDistance)
            {
                objectToMove.transform.Translate(Vector3.left * (moveSpeed * Time.deltaTime));
                directions = Directions.Left;
            }
            else
            {
                _isMoving = false;
                _defaultPosition = objectToMove.transform.position;
                directions = Directions.Right;
            }
        }
    }
}

