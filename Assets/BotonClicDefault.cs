using UnityEngine;

public class BotonClic : MonoBehaviour
{
    public void ReproducirClic()
    {
        AudioManager.Instance.PlayClic();
    }
}
