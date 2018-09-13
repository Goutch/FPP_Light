using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] private KeyCode moveLeftKey;

    [SerializeField] private KeyCode moveRightKey;

    [SerializeField] private KeyCode jumpKey;

    private PlayerController player;

    private void Start()
    {
        player = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            player.Jump();
        }

        if (Input.GetKey(moveRightKey))
        {
            player.Move(1);
        }

        if (Input.GetKey(moveLeftKey))
        {
            player.Move(-1);
        }
    }
}