using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceController : MonoBehaviour
{
    [field: SerializeField] public SpaceController CurrentSpace { get; private set; }
    private Player player;
    // Start is called before the first frame update
    public void InitializeController(Player newPlayer)
    {
        player = newPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCurrentSpace(SpaceController space)
    {
        CurrentSpace = space;
        transform.position = CurrentSpace.transform.position;

        if(space.spaceType == SpaceController.SpaceClasses.level)
        {
            SetCurrentSpaceAsLevel((LevelSpaceConroller)space);
        }
        else if(space.spaceType == SpaceController.SpaceClasses.go)
        {
            SetCurrentSpaceAsGo((GoSpaceController)space);
        }
    }

    private void SetCurrentSpaceAsGo(GoSpaceController space)
    {
        switch (space.ForwardSpaceDirection)
        {
            case GoSpaceController.NextDirection.up:
                break;
            case GoSpaceController.NextDirection.down:
                break;
            case GoSpaceController.NextDirection.left:
                break;
            case GoSpaceController.NextDirection.right:
                break;
        }
    }

    private void SetCurrentSpaceAsLevel(LevelSpaceConroller space)
    {
        player.StateMachine.ChangeState(player.IdleState);
        if (space.nextTopSpace)
        {
            player.SetIcon("up");
        }
        if (space.nextBottomSpace)
        {
            player.SetIcon("down");
        }
        if (space.nextLeftSpace)
        {
            player.SetIcon("left");
        }
        if (space.nextRightSpace)
        {
            player.SetIcon("right");

        }
    }
}
