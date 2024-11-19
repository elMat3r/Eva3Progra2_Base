using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridEntity_Movible_Bullet : GridEntity_Movible
{
    public Vector2Int bulletDir;
    public float dmg;
    bool lePegueAlcohino;
    GridEntity cochinoGolpeado;

    protected override void Awake2()
    {

    }

    public void SetBullet(Vector2Int dir, Vector2Int bulletPos, GridManager gridManager)
    {
        gridPos = bulletPos;
        GridPiece piece = gridManager.GetGridPiece(gridPos);
        transform.position = new Vector3(gridPos.x, yPos, gridPos.y);
        this.gridManager = gridManager;
        bulletDir = dir;
        if (piece.pieceType == GridPieceType.Wall)
        {
            OnWallImpact(piece);
        }
        else
        {
            piece.OnEntityEnter(this);
        }
    }

    protected override void Update2()
    {
        if (!isMoving)
        {
            Move(bulletDir);
        }
    }

    public override void Move(Vector2Int dir)
    {
        if (isMoving) return;
        Vector2Int newPos = gridPos + dir;
        isMoving = true;
        StartCoroutine(MoveCoroutine(newPos));
    }

    protected override void OnMovementEnd(GridPiece gridPiece)
    {
        if (gridPiece.pieceType == GridPieceType.Wall)
        {
            OnWallImpact(gridPiece);
        }
        if(lePegueAlcohino)
        {
            gridPiece.isEmpty = false;
            gridPiece.currentGridEntity = cochinoGolpeado;
        }
    }

    public override void InteractWhitOtherEntity(GridEntity other)
    {
        if(other.entityType == EntityType.Player || other.entityType == EntityType.Player2)
        {
            other.TakeDamage(dmg);
            lePegueAlcohino = true;
            cochinoGolpeado = other;
            Die();
        }
    }

    void OnWallImpact(GridPiece gridPiece)
    {
        GridPiece_Wall wall = (GridPiece_Wall)gridPiece;
        if (wall.isDestroyed) return;
        DestroyBullet();
        wall.DestroyWall();
    }

    public override void TakeDamage(float dmg)
    {
        Die();
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    protected override void Die()
    {
        DestroyBullet();
    }
}