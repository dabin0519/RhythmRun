using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct NoteInfo
{
    public Note note;
    public float spawnTime;
    public float spawnYPos;
}

[CreateAssetMenu(menuName = "SO/NoteInfo")]
public class NoteInfoSO : ScriptableObject
{
    public List<NoteInfo> noteInfoLists;
}
