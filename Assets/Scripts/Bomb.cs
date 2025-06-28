using UnityEngine;
using System.Collections.Generic;

public class Bomb : MonoBehaviour
{
    [Header("Explosion Effects")]
    public GameObject[] explosionEffectPrefabs; 

    [Header("Smoke Effect")]
    public GameObject smokeEffectPrefab; 

    [Header("Explosion Audio")]
    public AudioClip explosionClip; 
    public float explosionVolume = 1.0f;

   
    private static List<GameObject> activeSmokeEffects = new List<GameObject>();

    private void OnCollisionEnter(Collision collision)
    {
        if (explosionEffectPrefabs != null && explosionEffectPrefabs.Length > 0)
        {
            // Pick a random explosion effect
            int randomIndex = Random.Range(0, explosionEffectPrefabs.Length);
            GameObject selectedEffect = explosionEffectPrefabs[randomIndex];

            // Get the contact point
            ContactPoint contact = collision.contacts[0];
            // Instantiate the explosion effect at the collision point and rotation
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

            // Instantiate the smoke effect at the same collision point and rotation
            if (smokeEffectPrefab != null)
            {
                GameObject smoke = Instantiate(smokeEffectPrefab, contact.point, Quaternion.LookRotation(contact.normal));
                activeSmokeEffects.Add(smoke); // Track the smoke effect

                // play the smoke particle system explicitly
                ParticleSystem smokePs = smoke.GetComponent<ParticleSystem>();
                if (smokePs != null)
                {
                    smokePs.Play();
                }
                else
                {
                    ParticleSystem childSmokePs = smoke.GetComponentInChildren<ParticleSystem>();
                    if (childSmokePs != null)
                    {
                        childSmokePs.Play();
                    }
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

    // Public static method to destroy all smoke effects
    public static void DestroyAllSmokeEffects()
    {
        foreach (var smoke in activeSmokeEffects)
        {
            if (smoke != null)
                Destroy(smoke);
        }
        activeSmokeEffects.Clear();
    }
}