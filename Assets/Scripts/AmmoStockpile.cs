using UnityEngine;

public class AmmoStockpile : MonoBehaviour
{
    [SerializeField]
    private int _rocketAmount;
    public int RocketAmount
    { get { return _rocketAmount; } }
    [SerializeField]
    private float _laserCharge;
    public float LaserCharge
    {
        get { return _laserCharge; }
    }
    private float _timer;
    private bool _hasAmmo;
    private RayController _rayController;
    private Sounds _sounds;

    public void AddRocket(int rocketCount)
    {
        _sounds.PlayClip();
        _rocketAmount += rocketCount;
    }

    private void RechargeLaser()
    {
        if (!_rayController.LaserActive && _laserCharge < 1.0f)
        {
            _timer += Time.deltaTime;

            if (_timer > 0.01)
            {
                _laserCharge += 0.01f;
                _timer = 0f;
            }
        }
    }

    private bool LaserChargeCheck()
    {
        if (_laserCharge > 0.0f)
        {
            return true;
        }
        
        return false;
    }

    private bool RocketCountCheck()
    {
        if (_rocketAmount > 0)
        {
            return true;
        }

        return false;
    }

    private void UseLaserCharge()
    {
        if (_rayController.LaserActive && _laserCharge > 0.0f)
        {
            _timer += Time.deltaTime;

            if (_timer > 0.01f)
            {
                _laserCharge -= 0.005f;
                _timer = 0f;
            }
        }
    }

    public bool AllAmmoCountCheck(int currentWeapon)
    {
        switch (currentWeapon)
        {
            case 1:
            {
                return LaserChargeCheck();
            }
            case 2:
            {
                return RocketCountCheck();
            }

            default:
            return true;
        }
    }

    public void DecrementAmmo(int currentWeapon)
    {
        switch (currentWeapon)
        {
            case 1:
            {
                UseLaserCharge();
                break;
            }
            case 2:
            {
                _rocketAmount--;
                Debug.Log("--");
                break;
            }
        }
    }

    private void Awake()
    {
        _sounds = GetComponent<Sounds>();
        _rayController = GameObject.Find("Laser").GetComponent<RayController>();
    }

    void Update()
    {
        RechargeLaser();
    }
}