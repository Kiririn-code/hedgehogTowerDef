using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage = 20;
    [SerializeField] private Transform _shootPoint;

    public void Shoot()
    {
        Ray ray = new Ray(_shootPoint.localPosition, Vector3.right);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100))
        {
            Debug.Log("ray");
           if(hitInfo.collider.TryGetComponent<Enemy>(out Enemy enemy))
            {
                Debug.Log("enemy");
                enemy.ApplyDamage(_damage);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(_shootPoint.localPosition, Vector3.right);
    }
}
