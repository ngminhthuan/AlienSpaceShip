using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform player; // Assign the ship's transform
    public Vector3 offset = new Vector3(0, 5, -10); // Position offset
    public float followSpeed = 5f; // Smooth follow speed
    public float rotationSpeed = 5f; // Smooth rotation speed

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 targetPosition = player.position + player.TransformDirection(offset);

        if(Vector3.Distance(transform.position,targetPosition)< 5)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, 1);
        }

        // Smoothly rotate towards the ship's rotation
        Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
