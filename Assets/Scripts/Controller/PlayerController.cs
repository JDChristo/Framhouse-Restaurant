using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseClass
{
    private PlayerView playerView;
    private PlayerModel playerModel;

    private Vector2 playerDirection = Vector2.zero;

    private bool bindUp = false;
    private bool bindDown = false;
    private bool bindRight = false;
    private bool bindLeft = false;

    private void Awake() => SetComponents();
    private void Start() => Init();
    private void Update() => UpdateController();
    private void FixedUpdate() => FixedUpateConotroller();

    private void Init()
    {
        playerView.Init();
    }
    private void SetComponents()
    {
        playerView = SetView<PlayerView>();
        playerModel = SetModel<PlayerModel>();
    }

    private void UpdateController()
    {
        HandleInput();
        GameManager.Instance.CameraMovement(playerView.PlayerOne, playerView.PlayerTwo);
    }

    private void FixedUpateConotroller()
    {
        playerView.PlayerMovement(playerDirection);
    }
    public void HandleInput()
    {
        if (GameManager.Instance.GetInput)
        {
            WallCheck();

            int xAxis = 0;
            int yAxis = 0;

            yAxis = GetKeyAxis(playerModel.UpKey, playerModel.DownKey, bindUp, bindDown);
            xAxis = GetKeyAxis(playerModel.LeftKey, playerModel.RightKey, bindLeft, bindRight);

            playerDirection = new Vector2(xAxis, yAxis);
            playerDirection = playerDirection.normalized * playerModel.PlayerSpeed;

            if (Input.GetKeyDown(playerModel.PickUpKey))
            {

            }
            if (Input.GetKeyDown(playerModel.DropDownKey))
            {

            }
            if (Input.GetKeyDown(playerModel.ChangePlayerKey))
            {
                playerView.SwitchPlayer();
            }
        }
    }

    private int GetKeyAxis(KeyCode positive, KeyCode negative, bool bindPos, bool bindNeg)
    {
        if (Input.GetKey(negative) && bindNeg == false)
        {
            return -1;
        }
        else if (Input.GetKey(positive) && bindPos == false)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    private void WallCheck()
    {
        float offset = 0.4f;
        float min_offset = 0.9f;
        float max_offset = 1f;

        bindDown = Physics2D.OverlapArea(new Vector2(playerView.CurrentPlayer.position.x - offset, playerView.CurrentPlayer.position.y - min_offset), new Vector2(playerView.CurrentPlayer.position.x + offset, playerView.CurrentPlayer.position.y - max_offset), playerModel.WallLayer);
        bindUp = Physics2D.OverlapArea(new Vector2(playerView.CurrentPlayer.position.x + offset, playerView.CurrentPlayer.position.y + min_offset), new Vector2(playerView.CurrentPlayer.position.x - offset, playerView.CurrentPlayer.position.y + max_offset), playerModel.WallLayer);
        bindRight = Physics2D.OverlapArea(new Vector2(playerView.CurrentPlayer.position.x - min_offset, playerView.CurrentPlayer.position.y - offset), new Vector2(playerView.CurrentPlayer.position.x - max_offset, playerView.CurrentPlayer.position.y + offset), playerModel.WallLayer);
        bindLeft = Physics2D.OverlapArea(new Vector2(playerView.CurrentPlayer.position.x + min_offset, playerView.CurrentPlayer.position.y + offset), new Vector2(playerView.CurrentPlayer.position.x + max_offset, playerView.CurrentPlayer.position.y - offset), playerModel.WallLayer);

    }
}
