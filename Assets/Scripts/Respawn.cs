using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform positionToRespawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = positionToRespawn.position;
        }
    }
}
