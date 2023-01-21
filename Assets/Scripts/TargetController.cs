using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    private static int minSpeed = 1;
    private static int maxSpeed = 3;

    public float walkingSpeed;

    public static Vector3 dir = Vector3.right;

    static float speed;

    public List<AudioClip> audioClips = new List<AudioClip>();
    public AudioSource source;

    public ParticleSystem system;
    public static bool touchedPlayer = false;
    public void Awake()
    {
        System.Random random = new System.Random();
        source.clip = audioClips[random.Next(0, audioClips.Count)];
    }
    public void PlaySound()
    {
        source.Play();
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, walkingSpeed * Time.deltaTime);
        LookAt();
    }
    public void Hit()
    {
        PlaySound();
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;

        system.playbackSpeed = 6.03f;
        system.Play();
    }
    
    private void LookAt()
    {
        Vector3 difference = PlayerController.playerTransform.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 90);
    }

    public static void UpdateSpeed()
    {
        System.Random random = new System.Random();
        speed = random.Next(minSpeed, maxSpeed + 1);
    }
}
