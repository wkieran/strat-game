using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PlayerStates
{
    public abstract class BaseState : State
    {

        protected GameObject player;
        protected GameObject placer;

        public BaseState(GameObject player)
        {
            this.player = player;
            this.placer = player.transform.Find("Placer").gameObject;
        }

        public virtual void OnEnter()
        {

        }

        public virtual State OnUpdate()
        {
            return this;
        }

        public virtual State OnFixedUpdate()
        {
            return this;
        }
    }

}