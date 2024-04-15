using UnityEngine;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;

public class CreateNoteEditor : EditorWindow
{
    private NoteInfoSO _noteInfo;
    private float _playerSpeed;
    private float _time = 0;

    [MenuItem("CustomEditor/CreateNote")]
    public static void OpenWindow()
    {
        var window = CreateWindow<CreateNoteEditor>("CreateNote");
        window.Show();
    }

    private void OnGUI()
    {
        GUILayout.Label("CreateNote Eidtor", EditorStyles.boldLabel);
        GUILayout.Space(10);

        _noteInfo = EditorGUILayout.ObjectField("NoteInfo", _noteInfo, typeof(NoteInfoSO), false) as NoteInfoSO;
        _playerSpeed = EditorGUILayout.FloatField("PlayerSpeed", _playerSpeed);

        if(GUILayout.Button("Create Note"))
        {
            CreateNote();
        }
    }

    private void CreateNote()
    {
        GameObject noteParent = new GameObject("NoteParent");

        List<NoteInfo> list = _noteInfo.noteInfoLists;

        for(int i = 0; i < list.Count; i++)
        {
            GameObject newNote = Instantiate(list[i].note.gameObject);
            _time += list[i].spawnTime;
            Vector3 spawnPos = new Vector3(_playerSpeed * _time, list[i].spawnYPos);
            newNote.transform.position = spawnPos;
            newNote.transform.SetParent(noteParent.transform, false);
        }

        Undo.RegisterCreatedObjectUndo(noteParent, "???");
        Selection.activeObject = noteParent;
    }
}

#endif
