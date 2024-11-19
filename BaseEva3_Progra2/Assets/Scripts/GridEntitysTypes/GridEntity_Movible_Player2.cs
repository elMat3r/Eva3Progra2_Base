using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            gridShooter.Shoot(gridPos, Vector2Int.left);
        }
    }

    public override void Move(Vector2Int dir)
    {
        if (isMoving) return;
        Vector2Int newPos = gridPos + dir;
        if (gridManager.IsPosOnArray(newPos))
        {
            if (gridManager.IsPieceWalkablePlayer2(newPos))
            {
                isMoving = true;
                StartCoroutine(MoveCoroutine(newPos));
            }
        }
    }

    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
        //image.fillAmount = currentLife / life;
        if (currentLife == 0)
        {
            SceneManager.LoadScene("03 EndBattle_Player1");
        }
    }
}
