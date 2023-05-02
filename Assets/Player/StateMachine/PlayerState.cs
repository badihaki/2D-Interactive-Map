using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Player Player { get; private set; }
    protected float enterTime;
    protected bool isExitingState = false;

    public PlayerState(Player newPlayer)
    {
        Player = newPlayer;
    }

    public virtual void EnterState()
    {
        enterTime = Time.time;
        isExitingState = false;
        if (Player.Controls.AcceptanceInput) Player.Controls.UseAccept();
    }

    public virtual void ExitState()
    {
        isExitingState = true;
    }
    public virtual void LogicProcess()
    {
        CheckForStateTransition();
    }

    public virtual void CheckForStateTransition()
    {
        // State transitions go here
    }
}
