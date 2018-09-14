using System.Collections;
using System.Collections.Generic;
using LOS.Event;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] private KeyCode moveLeftKey = KeyCode.A;

    [SerializeField] private KeyCode moveRightKey = KeyCode.D;

    [SerializeField] private KeyCode jumpKey = KeyCode.Space;

    [SerializeField] private KeyCode DashKey = KeyCode.LeftShift;

    private PlayerController[] avatars;
    private int avatarIndex;

    private float timeSinceLastInLight = 0;
    private float timeWithoutLightLimit = 0.05f;

    private void Start()
    {
        LightTrigger.Instance.InLight += InLight;
        avatars = GetComponentsInChildren<PlayerController>();
        avatarIndex = 0;
        SwitchAvatar(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (avatars[avatarIndex].isDashing == false)
        {
            if (timeSinceLastInLight < Time.time - timeWithoutLightLimit)
                SwitchAvatar(0);
            else
            {
                SwitchAvatar(1);
            }

            if (Input.GetKeyDown(jumpKey))
            {
                avatars[avatarIndex].Jump();
            }


            if (Input.GetKey(moveRightKey))
            {
                avatars[avatarIndex].Move(1);
            }

            if (Input.GetKey(moveLeftKey))
            {
                avatars[avatarIndex].Move(-1);
            }
        }

        if (Input.GetKeyDown(DashKey) && avatars[avatarIndex].canDash)
        {
            avatars[avatarIndex].Dash();
        }
    }

    public void SwitchAvatar(int index)
    {
        if (index != avatarIndex)
        {
            avatars[avatarIndex].GetComponent<SpriteRenderer>().enabled = false;
            avatars[avatarIndex].GetComponent<BoxCollider2D>().enabled = false;
            avatarIndex = index;
            avatars[avatarIndex].GetComponent<BoxCollider2D>().enabled = true;
            avatars[avatarIndex].GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void InLight()
    {
        if (!avatars[avatarIndex].isDashing)
            timeSinceLastInLight = Time.time;
    }
}