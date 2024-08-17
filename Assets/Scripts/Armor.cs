using UnityEngine;

public class Armor : MonoBehaviour
{
    [SerializeField]
    private float _armorPoint;

    private Sounds _sounds;
    private float _startArmorPoint;

    public float ArmorPoint
    {
        get 
        {
            return _armorPoint; 
        }
    }

    public void BlockDamage(float damage)
    {
        _armorPoint -= damage;

        if (_armorPoint < 0)
        {
            ResetArmor();
        }
    }

    public void NormalizeArmor()
    {
        _armorPoint = _startArmorPoint;
    }

    public void AddArmorPoint(float armorPoint)
    {
        _sounds.PlayClip();

        if (_armorPoint + armorPoint > 1f)
        {
            NormalizeArmor();
        }
        else
        {
            _armorPoint += armorPoint;
        }
    }

    private void ResetArmor()
    {
        _armorPoint = 0;
    }

    private void Awake()
    {
        _sounds = GetComponent<Sounds>();
        _startArmorPoint = _armorPoint;
    }
}