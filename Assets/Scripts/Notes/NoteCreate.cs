using UnityEngine;
using System.Collections;

public class NoteCreate : MonoBehaviour
{
    public GameObject LeftFarNote;
    public float PositionPercentY;

    void Start()
    {
        StartCoroutine(CreateNoteScore());
    }

    void Update()
    {

    }

    IEnumerator CreateNoteScore()
    {
        float positionPercentX;

        while (true) // repeat the same song forever
        {
            foreach (var note in NoteParser.GetOhSusanna())
            {
                // invert x if on the top
                positionPercentX = (PositionPercentY < 0.5f) ? note.GameScalePosition : 1 - note.GameScalePosition;

                instantiateNote(note, positionPercentX, PositionPercentY);
                // Debug.Log("total seconds " + (float)note.Offset.TotalSeconds);
                yield return new WaitForSeconds((float)note.Offset.TotalSeconds);
            }
        }
    }

    void instantiateNote(MusicalNote note, float percentX, float percentY)
    {
        var newNote = Instantiate(LeftFarNote) as GameObject;
        newNote.name = "Note" + note.Type.ToString() + (percentY < 0.5f ? "Bottom" : "Top");
        var position = newNote.GetComponent<PositionPercent>();
        position.PercentX = percentX;
        position.PercentY = percentY;
        position.Invalidate();
    }
}
