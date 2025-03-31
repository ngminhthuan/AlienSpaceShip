using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public Action onDeath;
    public bool isAlive;
    public float moveSpeed = 2;

    private void OnEnable()
    {
        isAlive = true;
    }
    void Start()
    {
    }

    void Update()
    {
        if (isAlive || GameManager.Instance.CurrentState == GameState.Playing)
        {
            Vector3 direction = (PlayerManager.Instance.transform.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;

            // Face the player
            transform.LookAt(PlayerManager.Instance.transform.position);
            
        }
    }

    public void Die()
    {
        onDeath?.Invoke();
        Destroy(gameObject);
    }
}
