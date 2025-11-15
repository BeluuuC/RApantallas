using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource sfxSource;

    [Header("Sonidos")]
    public AudioClip clicPredeterminado;
    public AudioClip clicLugares;
    public AudioClip clicTrabajosAux;
    public AudioClip glitchFX;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ---------------- FUNCIONES DE AUDIO ----------------

    public void PlayClic()
    {
        sfxSource.PlayOneShot(clicPredeterminado);
    }

    public void PlayClicLugar()
    {
        sfxSource.PlayOneShot(clicLugares);
    }

    public void PlayClicTrabajosAux()
    {
        sfxSource.PlayOneShot(clicTrabajosAux);
    }

    public void PlayGlitch()
    {
        sfxSource.PlayOneShot(glitchFX);
    }
}
