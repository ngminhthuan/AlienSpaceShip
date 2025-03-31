using UnityEngine;

public class PlayerShootPoint : MonoBehaviour
{
    public GameObject bulletPrefab;  // Assign bullet prefab
    public Transform gunShootPoint;  // Assign gun shoot point

    public void Shoot(string bulletName)
    {
        Bullet currentBullet = PoolManager.Instance.GetObject<Bullet>(bulletName, this.transform.position, this.transform.rotation);
        if (currentBullet != null)
        {
/*            currentBullet.SetStartPosition(this.transform.position);
*/        }
    }
}
