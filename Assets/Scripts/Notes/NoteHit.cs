using UnityEngine;
using System.Collections;

public class NoteHit : MonoBehaviour
{
    public Note Note;

    int collisions;

    void Start()
    {

    }

    void Update()
    {

    }

    public void PlayNote()
    {
        if (collisions > 0)
        {
            // play note
            this.audio.pitch = MusicalNote.PitchMap[Note];
            this.audio.Play();
        }
        Debug.Log("collisons = " + collisions);
    }

    void OnTriggerEnter(Collider collisionInfo)
    {
        collisions++;
        Debug.Log("In contact with " + collisionInfo.transform.name);
    }

    void OnTriggerExit(Collider collisionInfo)
    {
        collisions--;
        Debug.Log("No longer in contact with " + collisionInfo.transform.name);
    }
}
