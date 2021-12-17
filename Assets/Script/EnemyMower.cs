using UnityEngine;

public class EnemyMower : MonoBehaviour
{
    private Transform[] _points;
    private int _currentPointIndex =0;

    public void Init(Transform path)
    {
        _points = new Transform[path.childCount];

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = path.GetChild(i);
        }
    }

    private void Update()
    {
        Transform point = _points[_currentPointIndex];

        transform.position = Vector3.MoveTowards(transform.position, point.position, 1 * Time.deltaTime);

        if(Vector3.Distance(transform.position,point.position) <= 0.5f)
        {
            _currentPointIndex++;

            if (_currentPointIndex >= _points.Length)
                _currentPointIndex = 0;
        }
    }
}
