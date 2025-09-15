using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] Transform respawn;
    CharacterController controller;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Outbounds")
        {
            controller.enabled = false;
            transform.position = respawn.position;
            controller.enabled = true;
        }
    }
}
