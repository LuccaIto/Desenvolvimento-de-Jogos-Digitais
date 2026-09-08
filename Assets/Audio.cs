using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    // A variável usa o tipo AudioSource nativo da Unity
    private AudioSource source;

    void Start()
    {
        // Pega o componente AudioSource do mesmo GameObject
        source = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D coll) 
    {
        if (source != null)
        {
            source.Play();
        }
    }


    // Update is called once per frame
   void Update()
    {
        
    }
}
