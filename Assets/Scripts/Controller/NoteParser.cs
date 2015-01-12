using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NoteParser
{
    public NoteParser()
    { }

    public static IList<MusicalNote> GetTestNotes()
    {
        var notes = new List<MusicalNote>();

        notes.Add(new MusicalNote(Note.C4));
        notes.Add(new MusicalNote(Note.D4));
        notes.Add(new MusicalNote(Note.E4));
        notes.Add(new MusicalNote(Note.G4));
        notes.Add(new MusicalNote(Note.A4));

        return notes;
    }
}