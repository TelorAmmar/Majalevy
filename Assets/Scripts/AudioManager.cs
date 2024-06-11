using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----------Audio Sources----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("----------Audio Clip----------")]
    public AudioClip background;
    public AudioClip playerDeath;
    public AudioClip enemyDeath;
    public AudioClip flyEnemyDeath;
    public AudioClip bossDeath;
    public AudioClip playerAttack1;
    public AudioClip playerAttack2;
    public AudioClip enemyAttack;
    public AudioClip flyEnemyAttack;
    public AudioClip bossAttack;
    public AudioClip hit;
    public AudioClip jump;
    public AudioClip healthPickup;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
