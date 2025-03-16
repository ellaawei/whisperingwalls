using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    public ParticleSystem collisionParticleSystem;
    public SpriteRenderer sr;
    public bool once = true;
    private void OnTriggerEnter2D(Collider2D o)
    {
        PlayerScript p = o.GetComponent<PlayerScript>();
        if (p != null&&once)
        {
            var em = collisionParticleSystem.emission;
            var dur = collisionParticleSystem.duration;
            em.enabled = true;
            collisionParticleSystem.Play();
            once = false;
            Destroy(sr);
            Invoke(nameof(DestroyObj), dur);
            p.AddKey(1);
        }
    }
    void DestroyObj()
    {
        Destroy(gameObject);
    }
}
