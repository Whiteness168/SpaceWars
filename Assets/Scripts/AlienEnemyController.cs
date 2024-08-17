using UnityEngine;

public class AlienEnemyController : MonoBehaviour
{
    [SerializeField]
    private Pool _pool;
    [Space(10)]
    [SerializeField]
    private float _spacing;
    [Space(10)]
    [SerializeField]
    private int _numberOfRows;
    [Space(10)]
    [SerializeField]
    private float _rowSpacing;
    [Space(10)]
    [SerializeField]
    private Vector3 _startPosition;
    [Space(10)]
    [SerializeField]
    private int _numberOfShipsPerRow;

    private void BuildArmyFormation()
    {
        for (int row = 0; row < _numberOfRows; row++)
        {
            if (row > 0)
            {
                _startPosition = new Vector3(_startPosition.x, _startPosition.y - _rowSpacing, _startPosition.z);
            }
            for (int i = 0; i < _numberOfShipsPerRow; i++)
            {
                Vector3 position = _startPosition + Vector3.right * _spacing * i;
                _pool.GetFreeElement(position, Quaternion.identity);
            }
        }
    }

    void OnEnable()
    {
        BuildArmyFormation();
    }
}