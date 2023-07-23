using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlacementMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Transform player;
    public Transform movePoint;

    public LayerMask whatStopMovement;

    Vector2 movement;


    private void OnEnable()
    {
        //This makes it so that the placer is always ontop of the player when placing mode is activated

        
        movePoint.localPosition = player.position;
       
        
    }

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        movePoint.localPosition = player.position;
    }

    // Update is called once per frame
    void Update()
    {

        //hold left shift to sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 10f;
            //speed up animation to look better
           
        }
        else
        {
            moveSpeed = 5f;
           
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        { //could also say <= 0f

            if (Mathf.Abs(movement.x) == 1f)
            {

                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(movement.x, 0f, 0f), 0.2f, whatStopMovement))
                {

                    movePoint.position += new Vector3(movement.x, 0f, 0f);
                   

                }
            }
            else if (Mathf.Abs(movement.y) == 1f)
            {

                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, movement.y, 0f), 0.2f, whatStopMovement))
                {


                    movePoint.position += new Vector3(0f, movement.y, 0f);
                   
                }

            }
           
        }

        //animator.SetFloat("Speed", 0f);


    }


}
