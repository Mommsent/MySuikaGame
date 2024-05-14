using UnityEngine;

public class PlaySoundEffects : MonoBehaviour
{
    private AudioSource _audioSource;

    [SerializeField] private AudioClip _popSound;
    [SerializeField] private AudioClip _hitSound;

    private void OnEnable()
    {
        ColliderInformer.wasCollided += PlayPopSound;
        ColliderInformer.wasDropped += PlayHitSound;
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void PlayPopSound(int noneed)
    {
        _audioSource.PlayOneShot(_popSound);
    }

    private void PlayHitSound()
    {
        _audioSource.PlayOneShot(_hitSound);
    }

    private void OnDisable()
    {
        ColliderInformer.wasCollided -= PlayPopSound;
        ColliderInformer.wasDropped -= PlayHitSound;
    }
}
