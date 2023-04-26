using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Player player;
    [SerializeField] private bool isMoving;
    [SerializeField] private float desiredMovementDuration;
    [SerializeField] private float elapsedTimeWhileMoving;
    [field: SerializeField] public Transform nextDesiredSpace { get; private set; }

    public void Initialize(Player newPlayer)
    {
        player = newPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            elapsedTimeWhileMoving+=Time.deltaTime;
            float percentageDistanceCompleted = elapsedTimeWhileMoving/desiredMovementDuration;

            transform.position = Vector3.Lerp(transform.position, nextDesiredSpace.position, percentageDistanceCompleted);
        }
    }
    public void SetNextDesiredSpace(Transform space)
    {
        nextDesiredSpace = space;
        player.StateMachine.ChangeState(player.MoveState);
    }
    public void MoveToNewSpace()
    {
        isMoving = true;
    }
    public void ArriveAtNewSpace(SpaceController space)
    {
        if (space.GetComponent<LevelSpaceConroller>())
        {
            isMoving = false;
            nextDesiredSpace = null;

            player.SpaceController.SetCurrentSpace(space);

            player.StateMachine.ChangeState(player.IdleState);
        }
        else
        {
            GoSpaceController spaceController = space.GetComponent<GoSpaceController>();
            SetNextDesiredSpace(spaceController.NextSpace.transform);
            spaceController.PassGoSpace();
        }
        elapsedTimeWhileMoving = 0.0f;
    }
}
