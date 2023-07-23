using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PlayerStates
{
    public class PlacingState : BaseState
    {

        BuildingManager buildingManager;

        public PlacingState(GameObject player) : base(player) 
        {
            Debug.Log("Switched to placing state");
            player.GetComponent<PlayerController>().enabled = false;
            buildingManager = LevelManager.GetComponent<BuildingManager>();

            
            placer.SetActive(true);
            placer.transform.localPosition = Vector3.zero;
            
        }

        public override void OnEnter()
        {
           
        }

        public override State OnUpdate()
        {
            if(Input.GetKeyDown("e")) 
            {
                //Move to the moving state if E is pressed
                return new MovingState(player); 
            }

            if (Input.GetMouseButtonDown(0))
            {
                buildingManager.placeFarm(placer.transform.position);
            }

            

            return this;
        }

        public override State OnFixedUpdate()
        {
            return this;
        }
    }

}