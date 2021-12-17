using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health =100;
    [SerializeField] private int _damage;

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
