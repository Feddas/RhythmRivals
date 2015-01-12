using UnityEngine;
using System.Collections;

public class NoteCreate : MonoBehaviour
{
    public GameObject LeftFarNote;

    void Start()
    {
        StartCoroutine(CreateNoteScore());
    }

    void Update()
    {

    }

    IEnumerator CreateNoteScore()
    {
        foreach (var note in NoteParser.GetTestNotes())
        {
            instantiateNote(note, note.GameScalePosition, 0.3f); // create the note on the top
            instantiateNote(note, 1 - note.GameScalePosition, 0.7f); // create the note on the bottom
            // Debug.Log("total seconds " + (float)note.Offset.TotalSeconds);
            yield return new WaitForSeconds((float)note.Offset.TotalSeconds);
        }
    }

    void instantiateNote(MusicalNote note, float percentX, float percentY)
    {
        var newNote = Instantiate(LeftFarNote) as GameObject;
        var position = newNote.GetComponent<PositionPercent>();
        position.PercentX = percentX;
        position.PercentY = percentY;
        position.Invalidate();
    }
}
