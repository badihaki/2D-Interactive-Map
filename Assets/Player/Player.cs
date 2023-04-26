using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: SerializeField, Header("Game Manager")] public GM GameManager { get; private set; }

    // State Machine
    #region State Machine
    public PlayerStateMachine StateMachine { get; private set; }
    public IdleState IdleState { get; private set; }
    public MoveState MoveState { get; private set; }
    #endregion
    // End State Machine

    [field: SerializeField, Header("Directional Helpers")] private GameObject UpArrow;
    [field: SerializeField] private GameObject DownArrow;
    [field: SerializeField] private GameObject LeftArrow;
    [field: SerializeField] private GameObject RightArrow;

    [field: SerializeField, Header("Components")] public PlayerMovement PlayerMovementController { get; private set; }
    [field: SerializeField] public PlayerControls Controls { get; private set; }
    [field: SerializeField] public PlayerSpaceController SpaceController { get; private set; }


    public void InitializePlayer(GM gameMaster, SpaceController startingSpace)
    {
        GameManager = gameMaster;

        PlayerMovementController = GetComponent<PlayerMovement>();
        PlayerMovementController.Initialize(this);
        Controls = GetComponent<PlayerControls>();
        SpaceController = GetComponent<PlayerSpaceController>();

        StateMachine = new PlayerStateMachine();
        IdleState = new IdleState(this);
        MoveState = new MoveState(this);
        StateMachine.InitializeStateMachine(IdleState);

        ResetIcons();

        SpaceController.InitializeController(this);
        SpaceController.SetCurrentSpace(startingSpace);

    }

    // Update is called once per frame
    void Update()
    {
        StateMachine.StateLogicProcess();
    }

    public void ResetIcons()
    {
        UpArrow.SetActive(false);
        DownArrow.SetActive(false);
        LeftArrow.SetActive(false);
        RightArrow.SetActive(false);
    }
    public void SetIcon(string direction)
    {
        switch (direction)
        {
            case "up":
                UpArrow.SetActive(true);
                break;
            case "down":
                DownArrow.SetActive(true);
                break;
            case "left":
                LeftArrow.SetActive(true);
                break;
            case "right":
                RightArrow.SetActive(true);
                break;
        }
    }
}
