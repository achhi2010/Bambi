using UnityEngine;

public class Enemy_script : MonoBehaviour
{
    [SerializeField] GameObject DeathExplosion;
    void OnParticleCollision(GameObject other)
    {
        Instantiate(DeathExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
