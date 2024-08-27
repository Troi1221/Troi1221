using UnityEngine;

public class TeleportOnCollision : MonoBehaviour
{
    public Transform teleportTarget; 
    public string playerTag = "Player"; 

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag(playerTag))
        {
            Debug.Log("Player collision detected. Teleporting...");

            
            CharacterController controller = other.GetComponent<CharacterController>();
            if (controller != null)
            {
                controller.enabled = false; 
            }

            
            other.transform.position = teleportTarget.position;

            
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                playerRigidbody.velocity = Vector3.zero;
                playerRigidbody.angularVelocity = Vector3.zero;
            }

            
            if (controller != null)
            {
                controller.enabled = true; 
            }

            Debug.Log("Player teleported to: " + teleportTarget.position);
        }
    }
}
