using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    public enum PlayerWho
    {
        player1,
        player2
    };
    public PlayerWho playerWho;
    public Transform[] playerRulletObject = new Transform[2];



    private float rulletTimer;

    bool isTurn = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (playerWho)
        {
            case PlayerWho.player1:
                RulletUpdate(0);
                break;
            case PlayerWho.player2:
                RulletUpdate(1);
                break;

        }
    }

    void RulletUpdate(int index)
    {
        playerRulletObject[index].Rotate(0, 0, rulletTimer);
        if (Input.GetMouseButtonDown(0) && !isTurn)
        {
            rulletTimer += 10;
            isTurn = true;
        }
        else
        {
            if (rulletTimer < 0f && isTurn)
            {
                rulletTimer = 0f;
                isTurn = false;

                switch (playerWho)
                {
                    case PlayerWho.player1:
                        playerWho = PlayerWho.player2;
                        break;
                    case PlayerWho.player2:
                        playerWho = PlayerWho.player1;
                        break;
                }
            }
            else if(rulletTimer > 0f)
            {
                rulletTimer -= Time.deltaTime;
            }
        }
    }
}
