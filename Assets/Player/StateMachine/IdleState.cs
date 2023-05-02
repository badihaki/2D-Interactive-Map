using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerState
{
    public IdleState(Player newPlayer) : base(newPlayer)
    {
    }

    public override void CheckForStateTransition()
    {
        base.CheckForStateTransition();
    }

    public override void EnterState()
    {
        base.EnterState();

        Player.transform.Translate(Vector2.zero);
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void LogicProcess()
    {
        base.LogicProcess();

        // detect move input
        if (Player.SpaceController.CurrentSpace.spaceType == SpaceController.SpaceClasses.level)
        {
            LevelSpaceConroller thisSpace = Player.SpaceController.CurrentSpace.GetComponent<LevelSpaceConroller>();

            if (thisSpace.nextTopSpace && Player.Controls.MovementInput.Equals(new Vector2(0, 1)))
            {
                Debug.Log("going up");
                Player.PlayerMovementController.SetNextDesiredSpace(thisSpace.nextTopSpace.transform);
            }
            if (thisSpace.nextBottomSpace && Player.Controls.MovementInput.Equals(new Vector2(0, -1)))
            {
                Debug.Log("going down");
                Player.PlayerMovementController.SetNextDesiredSpace(thisSpace.nextBottomSpace.transform);
            }
            if (thisSpace.nextLeftSpace && Player.Controls.MovementInput.Equals(new Vector2(-1, 0)))
            {
                Debug.Log("going left");
                Player.PlayerMovementController.SetNextDesiredSpace(thisSpace.nextLeftSpace.transform);
            }
            if (thisSpace.nextRightSpace && Player.Controls.MovementInput.Equals(new Vector2(1, 0)))
            {
                Debug.Log("going right");
                Player.PlayerMovementController.SetNextDesiredSpace(thisSpace.nextRightSpace.transform);
            }
            if (Player.Controls.AcceptanceInput)
            {
                thisSpace.LoadLevel();
                Player.Controls.UseAccept();
            }
        }
    }
}
