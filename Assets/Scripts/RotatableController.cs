using UnityEngine;

public class RotatableController {
    public static void Rotate(GameObject target, float rotationSpeed, float desiredZAngle) {
        Vector3 currentEulerAngles = target.transform.localEulerAngles;
        
        if (currentEulerAngles.z > 180) {
            currentEulerAngles.z -= 360;
        }
        
        Vector3 targetEulerAngles = new Vector3(currentEulerAngles.x, currentEulerAngles.y, desiredZAngle);
        Quaternion targetRotation = Quaternion.Euler(targetEulerAngles);
        
        target.transform.localRotation = Quaternion.RotateTowards(target.transform.localRotation, targetRotation,
            rotationSpeed * Time.deltaTime);
    }
}
