using UnityEngine;

public class WeaponController : MonoBehaviour
{
    protected KeyCode _activationKey = KeyCode.LeftAlt;

    protected virtual bool IsKeyPressed()
    {
        if (Input.GetKeyDown(_activationKey))
        {
            return true;
        }
        else
        { 
            return false;
        }
    }
    protected void Shoot(GameObject missileType, Transform firePoint)
    {
        if (IsKeyPressed())
        {
            Instantiate(missileType, firePoint.position, firePoint.rotation);
        }
    }
}
