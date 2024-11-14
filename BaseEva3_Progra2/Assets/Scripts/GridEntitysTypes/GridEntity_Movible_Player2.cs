using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridEntity_Movible_Player2 : GridEntity_Movible_Player
{

    protected override void MoveInputs()
    {
        Vector2Int dir = Vector2Int.zero;

        if (Input.GetKey(KeyCode.Keypad8))
        {
            dir.y = 1;
        }
        else if (Input.GetKey(KeyCode.Keypad5))
        {
            dir.y = -1;
        }
        else if (Input.GetKey(KeyCode.Keypad4))
        {
            dir.x = -1;
        }
        else if (Input.GetKey(KeyCode.Keypad6))
        {
            dir.x = 1;
        }

        if (dir.magnitude != 0)
        {
            transform.forward = new Vector3(dir.x, 0, dir.y);
            Move(dir);
        }
    }
    protected override void Update2()
    {
        if (!isMoving)
        {
            MoveInputs();
        }

        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            gridShooter.Shoot(gridPos);
        }
    }
}
