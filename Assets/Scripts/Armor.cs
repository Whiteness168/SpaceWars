using UnityEngine;

public class Armor : MonoBehaviour
{
    [SerializeField]
    private float _armorPoint;
    private Sounds _sounds;

    public float ArmorPoint
    {
        get { return _armorPoint; }
    }

    public void BlockDamage(float damage)
    {
        _armorPoint -= damage;

        if (_armorPoint < 0)
        {
            ResetArmor();
        }
    }

    private void ResetArmor()
    {
        _armorPoint = 0;
    }

    private void NormalizeArmor()
    {
        _armorPoint = 1f;
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

    private void Awake()
    {
        _sounds = GetComponent<Sounds>();
    }
}