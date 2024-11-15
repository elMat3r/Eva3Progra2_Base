using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridShooter : MonoBehaviour
{
    public GridManager gridManager;
    public GridEntity_Movible_Bullet bullet;
    public float cooldown;
    public bool isOnCooldown;
    float cooldownTimer;

    private void Update()
    {
        if(isOnCooldown)
        {
            cooldownTimer += Time.deltaTime;
            if(cooldownTimer >= cooldown)
            {
                isOnCooldown = false;
                cooldownTimer = 0;
            }
        }
    }
    public void Shoot(Vector2Int userGridPos, Vector2Int dir)
    {
        if (isOnCooldown)
        {
            return;
        }

        Vector2Int bulletPos = userGridPos + dir;
        if (gridManager.IsPosOnArray(bulletPos))
        {
            GridEntity_Movible_Bullet newBullet = Instantiate(bullet);
            newBullet.SetBullet(dir, bulletPos, gridManager);
            isOnCooldown = true;
        }
    }
}
