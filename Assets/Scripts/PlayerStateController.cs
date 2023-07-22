using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    private PlayerStates.State state;


    private void Start()
    {
        state = new PlayerStates.MovingState(gameObject);
    }

    private void Update()
    {
        HandleNewState(state.OnUpdate(), state);
    }
    //Handle the changing of states in the state machine
    void HandleNewState(PlayerStates.State newState, PlayerStates.State oldState)
    {
        if (newState != oldState)
        {
            state = newState;
            state.OnEnter();
        }
    }
}