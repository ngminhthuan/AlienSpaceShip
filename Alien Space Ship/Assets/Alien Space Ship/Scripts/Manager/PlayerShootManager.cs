using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShootManager : MonoBehaviour
{
    public Bullet bulletPrefab;  // Bullet prefab
    public float shootDelay = 0.5f;  // Time between shots
    private bool canShoot = true;    // Can the player shoot?

    [SerializeField] List<PlayerShootPoint> _ShootPoints = new List<PlayerShootPoint>();

    void Start()
    {
        PoolManager.Instance.CreatePool<Bullet>("Bullet", bulletPrefab, 10);
    }

    public void Shoot()
    {
        if (canShoot)
        {
            this.AllShootPoints();
            StartCoroutine(ShootCooldown()); // Start cooldown
        }
    }

    void AllShootPoints()
    {
        foreach( var shootPoint in _ShootPoints)
        {
            shootPoint.Shoot("Bullet");
        }
    }

    IEnumerator ShootCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }
}
