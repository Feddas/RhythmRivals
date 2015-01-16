using UnityEngine;
using System.Collections;

public class NoteHit : MonoBehaviour
{
    public Note Note;

    Collider colliderNote;

    void Start()
    {
    }

    void Update()
    {
    }

    public void PlayNote()
    {
        if (colliderNote != null && this.audio.isPlaying == false)
        {
            // lock from double taps
            Collider temp = colliderNote; // this is for handling double taps, as it's much faster than destroying the object.
            colliderNote = null;
            GameObject.Destroy(temp.gameObject);

            // play note
            this.audio.pitch = MusicalNote.PitchMap[Note];
            this.audio.Play();

            // update score
            if (this.GetComponent<PositionPercent>().PercentY < 0.5f)
            {
                Globals.Instance.BottomScored();
            }
            else
            {
                Globals.Instance.TopScored();
            }
        }
        // Debug.Log("collider = null");
    }

    void OnTriggerEnter(Collider collisionInfo)
    {
        colliderNote = collisionInfo;
        // Debug.Log("In contact with " + collisionInfo.transform.name);
    }

    void OnTriggerExit(Collider collisionInfo)
    {
        colliderNote = null;
        // Debug.Log("No longer in contact with " + collisionInfo.transform.name);
    }
}
