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
    public int Combo => _combo; // 뭐 나중에 MaxCombo를 밖으로 뺄수 있지 않을까?

    [SerializeField]
    [Tooltip("다음 배율을 가기 위한 콤보 갯수")]
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
