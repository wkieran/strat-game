using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;

    public LayerMask whatStopMovement;

    public Animator animator;

    Vector2 movement;
    
    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;

    }

    // Update is called once per frame
    void Update()
    {

        //hold left shift to sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 10f;
            //speed up animation to look better
            animator.speed = 3;
        }
        else
        {
            moveSpeed = 5f;
            animator.speed = 1;
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f) { //could also say <= 0f

            if (Mathf.Abs(movement.x) == 1f) {

                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(movement.x, 0f, 0f), 0.2f, whatStopMovement)) {
                    
                    movePoint.position += new Vector3(movement.x, 0f, 0f);
                    animator.SetFloat("Vertical", 0f);
                    animator.SetFloat("Horizontal", movement.x);

                }
            } else if (Mathf.Abs(movement.y) == 1f) {

                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, movement.y, 0f), 0.2f, whatStopMovement)) {
                    Debug.Log("gang shit");

                    movePoint.position += new Vector3(0f, movement.y, 0f);
                    animator.SetFloat("Horizontal", 0f);
                    animator.SetFloat("Vertical", movement.y);
                }

            }
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }

        //animator.SetFloat("Speed", 0f);

    }
}
