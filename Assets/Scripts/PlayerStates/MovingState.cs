using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PlayerStates
{
    public class MovingState : BaseState
    {


        public MovingState(GameObject player) : base(player)
        {
            Debug.Log("Entering Moving State");
            player.GetComponent<PlayerController>().enabled = true;
            placer.SetActive(false);
        }

        public override void OnEnter()
        {
            
        }

        public override State OnUpdate()
        {
            if (Input.GetKeyDown("e"))
            {
                //Move to the placing state if E is pressed
                return new PlacingState(player);
            }

            return this;
        }

        public override State OnFixedUpdate()
        {
            return this;
        }
    }

}