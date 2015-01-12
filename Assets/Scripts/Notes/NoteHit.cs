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
        if (colliderNote != null)
        {
            // Debug.Log("collider = " + collider);
            GameObject.Destroy(colliderNote.gameObject);
            colliderNote = null;

            // play note
            this.audio.pitch = MusicalNote.PitchMap[Note];
            this.audio.Play();

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
