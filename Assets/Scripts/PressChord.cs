using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class PressChord : MonoBehaviour
{
    public AudioClip PluckC;

    // pitch based off of http://answers.unity3d.com/questions/127562/pitch-in-unity.html
    private System.Collections.Generic.Dictionary<Note, float> pitch = new Dictionary<Note, float>()
    {
        {Note.C4, 1f},
        {Note.D4, 1.12245549f}, // 1.05946^2
        {Note.E4, 1.25990633f}, // 1.05946^4
        {Note.G4, 1.49834574f}, // 1.05946^7 it's odd because there's only one semitone from E to F
        {Note.A4, 1.68174862f}, // 1.05946^9
    };

    void Start()
    {
        this.audio.clip = PluckC;
    }

    void Update()
    {
    }

    // TODO: read this to fix possible future bugs: http://answers.unity3d.com/questions/791573/46-ui-how-to-apply-onclick-handler-for-button-gene.html
    public void OnClick(Object buttonClickedText)
    {
        var textObj = (buttonClickedText as GameObject).GetComponent<UnityEngine.UI.Text>();

        if (textObj == null)
            return;

        var text = textObj.text;
        switch (text)
        {
            case "C":
                this.audio.pitch = pitch[Note.C4];
                break;
            case "D":
                this.audio.pitch = pitch[Note.D4];
                break;
            case "E":
                this.audio.pitch = pitch[Note.E4];
                break;
            case "G":
                this.audio.pitch = pitch[Note.G4];
                break;
            case "A":
                this.audio.pitch = pitch[Note.A4];
                break;
            default:
                Debug.Log(text + " OnClick");
                return;
        }

        this.audio.Play();
        //Debug.Log(text + " played with pitch " + this.audio.pitch);
    }
}

public enum Note
{
    None,
    C4,
    D4,
    E4,
    // F4,
    G4,
    A4,
    // B4,
}
