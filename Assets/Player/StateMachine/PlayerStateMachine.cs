using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    public Player Player { get; private set; }
    public PlayerState CurrentState { get; private set; }

    public void InitializeStateMachine(PlayerState state)
    {
        CurrentState = state;
        CurrentState.EnterState();
    }

    public void ChangeState(PlayerState newState)
    {
        CurrentState.ExitState();
        CurrentState = newState;
        CurrentState.EnterState();
    }

    public void StateLogicProcess()
    {
        CurrentState.LogicProcess();
    }
}
