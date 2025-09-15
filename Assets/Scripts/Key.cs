using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] float speed = 125f;
    [SerializeField] GameObject gameManager;
    GameManager gM;
    private void Start()
    {
        gM = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gM.playerHasKey = true;
            Destroy(gameObject);
        }
    }
}
