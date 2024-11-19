using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GridEntity_Movible_Player : GridEntity_Movible
{
    public Image image;
    public GridShooter gridShooter;
    public Vector2Int startPos;

    protected override void Awake2()
    {

    }

    private void Start()
    {
        SetPlayerPos(startPos);
    }

    protected override void Update2()
    {
        if (!isMoving)
        {
            MoveInputs();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gridShooter.Shoot(gridPos, Vector2Int.right);
        }
    }  

    public void SetPlayerPos(Vector2Int pos)
    {
        gridPos = pos;
        gridManager.GetGridPiece(pos).OnEntityEnter(this);
    }

    protected virtual void MoveInputs()
    {
        Vector2Int dir = Vector2Int.zero;

        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
        }

        if (dir.magnitude != 0)
        {
            transform.forward = new Vector3(dir.x, 0, dir.y);
            Move(dir);
        }
    }

    public override void InteractWhitOtherEntity(GridEntity other)
    {
        other.InteractWhitOtherEntity(this);
    }


    protected override void Die()
    {
        print("PlayerDead");
    }

    public override void Move(Vector2Int dir)
    {
        if (isMoving) return;
        Vector2Int newPos = gridPos + dir;
        if (gridManager.IsPosOnArray(newPos))
        {
            if (gridManager.IsPieceWalkablePlayer1(newPos))
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
        if(currentLife == 0)
        {
            SceneManager.LoadScene("04 EndBattle_Player2");
        }
    }


}
