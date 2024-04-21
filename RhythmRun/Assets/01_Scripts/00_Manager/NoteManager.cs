using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoSingleton<NoteManager>
{
    public int Perfect
    {
        get { return _perfect; }
        set
        {
            _perfect = value;
            ApplyScore();
        }
    }
    public int Good
    {
        get { return _good; }
        set
        {
            _good = value;
            ApplyScore();
        }
    }
    public int Normal
    {
        get { return _normal; }
        set
        {
            _normal = value;
            ApplyScore();
        }
    }
    public int Bad
    {
        get { return _bad; }
        set
        {
            _bad = value;
            ApplyScore();
        }
    }
    public int Miss
    {
        get { return _miss; }
        set
        {
            _miss = value;
            _combo = 0;
        }
    }

    public int Score => _score;
    public int Combo => _combo; // �� ���߿� MaxCombo�� ������ ���� ���� ������?

    [SerializeField]
    [Tooltip("���� ������ ���� ���� �޺� ����")]
    private int _comboApplyCount;

    private int _perfect;
    private int _good;
    private int _normal;
    private int _bad;
    private int _miss;
    private int _score;
    private int _combo;
    private int _applyAmount;

    private void ApplyScore()
    {
        _combo++;
        CalculateApplyAmount();
    }

    private void CalculateApplyAmount()
    {
        int num = _combo / _comboApplyCount;
        switch(num)
        {

        }
    }
}
