using System;
using UnityEngine;

public class ViewConeManager : MonoBehaviour
{
    private SpriteRenderer _viewCone;
    public PatrolMovement PatrolMovement;
    void Start()
    {
        PatrolMovement = GetComponentInParent<PatrolMovement>();
        _viewCone = this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        _viewCone.GetComponent<SpriteRenderer>().enabled = false;
        GameController.instance.onSpiritVisionActivated += ActivateConeVisibility;
        GameController.instance.onSpiritVisionDeactivated += DeactivateConeVisibility;
        
    }


    void ActivateConeVisibility()
    {
        _viewCone.enabled = true;
    }

    void DeactivateConeVisibility()
    {
        _viewCone.enabled = false;
    }

    private void Update()
    {
        //transform.rotation = Quaternion.LookRotation(moveDirection);
        // 1. Calculate the direction vector from the current object to the target
        Vector3 directionToTarget = PatrolMovement.moveDirection;

        // 2. Use Mathf.Atan2 to find the angle in radians, then convert to degrees
        // Atan2 returns the angle whose tangent is the quotient of two specified numbers (y, x)
        float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;

        // 3. Apply the rotation to the Z-axis (assuming your sprite's "forward" is the X-axis/right)
        // Adjust the angle offset if your sprite's default orientation is different (e.g., add or subtract 90 degrees)
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-180));
    }
}
