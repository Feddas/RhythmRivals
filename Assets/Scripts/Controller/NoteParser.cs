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

    /// <summary>
    /// Oh Susanna based off midi file found at http://en.wikipedia.org/wiki/Pentatonic_scale
    /// </summary>
    /// <returns></returns>
    public static IList<MusicalNote> GetOhSusanna()
    {
        var notes = new List<MusicalNote>();

        notes.Add(new MusicalNote(Note.C4, 1.54f));
        notes.Add(new MusicalNote(Note.D4, 1.02f));
        notes.Add(new MusicalNote(Note.E4, 2.56f));
        notes.Add(new MusicalNote(Note.G4, 2.56f));
        notes.Add(new MusicalNote(Note.G4, 2.56f));
        notes.Add(new MusicalNote(Note.A4, 2.56f));
        notes.Add(new MusicalNote(Note.G4, 2.56f));
        notes.Add(new MusicalNote(Note.E4, 2.56f));
        notes.Add(new MusicalNote(Note.C4, 2.56f));
        notes.Add(new MusicalNote(Note.C4, 2.56f));
        notes.Add(new MusicalNote(Note.D4, 2.56f));
        notes.Add(new MusicalNote(Note.E4, 2.56f));
        notes.Add(new MusicalNote(Note.E4, 2.56f));
        notes.Add(new MusicalNote(Note.D4, 2.56f));
        notes.Add(new MusicalNote(Note.C4, 2.56f));
        notes.Add(new MusicalNote(Note.D4, 2.56f));
        notes.Add(new MusicalNote(Note.C4, 2.56f));
        notes.Add(new MusicalNote(Note.D4, 1.52f));
        notes.Add(new MusicalNote(Note.E4, 2.56f));
        notes.Add(new MusicalNote(Note.G4, 2.56f));
        notes.Add(new MusicalNote(Note.G4, 2.56f));
        notes.Add(new MusicalNote(Note.A4, 2.56f));
        notes.Add(new MusicalNote(Note.G4, 2.56f));
        notes.Add(new MusicalNote(Note.E4, 2.56f));
        notes.Add(new MusicalNote(Note.C4, 2.56f));
        notes.Add(new MusicalNote(Note.D4, 2.56f));
        notes.Add(new MusicalNote(Note.E4, 2.56f));
        notes.Add(new MusicalNote(Note.E4, 2.56f));
        notes.Add(new MusicalNote(Note.D4, 2.56f));
        notes.Add(new MusicalNote(Note.D4, 2.56f));
        notes.Add(new MusicalNote(Note.C4, 7.69f));

        return notes;
    }
}