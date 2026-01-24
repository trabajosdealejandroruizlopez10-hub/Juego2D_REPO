using UnityEngine;

public class SoundByProximity : MonoBehaviour
{
    public GameObject player; // El objeto que escuchará el sonido (usualmente el jugador)
    public AudioSource soundSource; // El AudioSource que emite el sonido
    public float maxDistance = 20f; // Distancia máxima a la que el sonido se puede escuchar
    
    void Update()
    {
        // Calcular la distancia entre el objeto y el jugador
        float distance = Vector3.Distance(transform.position, player.transform.position);

        // Ajustar el volumen en función de la distancia
        if (distance <= maxDistance)
        {
            // Normaliza el volumen según la distancia
            float volume = 1 - (distance / maxDistance);
            soundSource.volume = volume;
        }
        else
        {
            soundSource.volume = 0;
        }

        // Si deseas que el sonido empiece o pare en base a la proximidad, puedes usar:
        if (distance <= maxDistance && !soundSource.isPlaying)
        {
            soundSource.Play();
        }
        else if (distance > maxDistance && soundSource.isPlaying)
        {
            soundSource.Stop();
        }
    }
}