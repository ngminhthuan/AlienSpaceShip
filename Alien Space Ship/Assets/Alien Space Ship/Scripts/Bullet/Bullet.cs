using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string BulletName = "Bullet";
    public float speed = 20f;
    public float lifeTime = 3f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if bullet hits an enemy
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().Die();
            PoolManager.Instance.ReturnObject<Bullet>(this.BulletName,this);
        }
    }
}
