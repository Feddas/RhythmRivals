using System;
using System.Collections.Generic;

public class MusicalNote
{
    private const int ticksInSecond = 10000 * 1000; // 10,000 ticks in millisecond * 1000 milliseconds in a second

    // pitch based off of http://answers.unity3d.com/questions/127562/pitch-in-unity.html
    public static Dictionary<Note, float> PitchMap = new Dictionary<Note, float>()
    {
        {Note.C4, 1f},
        {Note.D4, 1.12245549f}, // 1.05946^2
        {Note.E4, 1.25990633f}, // 1.05946^4
        {Note.G4, 1.49834574f}, // 1.05946^7 it's odd because there's only one semitone from E to F
        {Note.A4, 1.68174862f}, // 1.05946^9
    };

    private Dictionary<Note, float> positionPentatonic = new Dictionary<Note, float>()
    {
        {Note.C4, 0.1f},
        {Note.D4, 0.3f},
        {Note.E4, 0.5f},
        {Note.G4, 0.7f},
        {Note.A4, 0.9f},
    };

    public Note Type { get; set; }
    public float GameScalePosition { get; set; }
    public float Pitch { get; set; }
    public TimeSpan Offset { get; set; } // offset in time from previous note

    public MusicalNote(Note noteType) : this(noteType, 1f)
    {
    }

    public MusicalNote(Note noteType, float offsetInSeconds)
    {
        this.Type = noteType;
        this.Pitch = PitchMap[noteType];
        this.GameScalePosition = positionPentatonic[noteType];
        this.Offset = new TimeSpan((int)(offsetInSeconds * ticksInSecond));
    }
}