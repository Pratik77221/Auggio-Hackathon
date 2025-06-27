using UnityEngine;

public class Bomb : MonoBehaviour
{
    [Header("Explosion Effects")]
    public GameObject[] explosionEffectPrefabs; // Assign your 3 particle system prefabs in the Inspector

    [Header("Explosion Audio")]
    public AudioClip explosionClip; // Assign your explosion audio clip in the Inspector
    public float explosionVolume = 1.0f;

    private void OnCollisionEnter(Collision collision)
    {
        if (explosionEffectPrefabs != null && explosionEffectPrefabs.Length > 0)
        {
            // Pick a random explosion effect
            int randomIndex = Random.Range(0, explosionEffectPrefabs.Length);
            GameObject selectedEffect = explosionEffectPrefabs[randomIndex];

            // Get the contact point
            ContactPoint contact = collision.contacts[0];
            // Instantiate the particle effect at the collision point and rotation
            GameObject effect = Instantiate(selectedEffect, contact.point, Quaternion.LookRotation(contact.normal));

            // Try to play the particle system explicitly
            ParticleSystem ps = effect.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps.Play();
            }
            else
            {
                // If the ParticleSystem is not on the root, try to find it in children
                ParticleSystem childPs = effect.GetComponentInChildren<ParticleSystem>();
                if (childPs != null)
                {
                    childPs.Play();
                }
            }

            // Play explosion audio at the collision point
            if (explosionClip != null)
            {
                AudioSource.PlayClipAtPoint(explosionClip, contact.point, explosionVolume);
            }
        }

        // Destroy the bomb object
        Destroy(gameObject);
    }
}