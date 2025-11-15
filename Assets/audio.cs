using UnityEngine;

public class DontDestroyAudio : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
