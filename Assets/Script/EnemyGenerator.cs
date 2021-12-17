using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _path;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var enemy = Instantiate(_prefab,transform.position,Quaternion.identity);
            var enemyyy = enemy.GetComponent<EnemyMower>();
            enemyyy.Init(_path);
        }
    }
}
