using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : PlayerState
{
    public MoveState(Player newPlayer) : base(newPlayer)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        Player.PlayerMovementController.MoveToNewSpace();
    }

    public override void LogicProcess()
    {
        base.LogicProcess();
        
        if(Player.transform.position == Player.PlayerMovementController.nextDesiredSpace.position)
        {
            Player.PlayerMovementController.ArriveAtNewSpace(Player.PlayerMovementController.nextDesiredSpace.GetComponent<SpaceController>());
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
