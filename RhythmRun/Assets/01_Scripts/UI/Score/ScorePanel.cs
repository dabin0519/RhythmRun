using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] private Transform _levelGroupTrm;
    [SerializeField] private Transform _textGroupTrm;
    [SerializeField] private Transform _starGrounTrm;

    // C~S까지 티어
    private Image _fillTierImage;
    private TextMeshProUGUI _tierText;

    //TextGroup(perfect, normal, bad 등)
    private TextMeshProUGUI _perfectText;
    private TextMeshProUGUI _goodText;
    private TextMeshProUGUI _normalText;
    private TextMeshProUGUI _badText;
    private TextMeshProUGUI _missText;
    private TextMeshProUGUI _hiddenNoteText;
    private TextMeshProUGUI _scoreText;

    //Star
    private Image[] _starImages;

    private void Awake()
    {
        // tier
        _fillTierImage = _levelGroupTrm.Find("FillTierImage").GetComponent<Image>();
        _tierText = _levelGroupTrm.Find("TierText").GetComponent<TextMeshProUGUI>();

        // text
        _perfectText        = _textGroupTrm.Find("PerfectText").GetComponent<TextMeshProUGUI>();
        _goodText           = _textGroupTrm.Find("GoodText").GetComponent<TextMeshProUGUI>();
        _normalText         = _textGroupTrm.Find("NormalText").GetComponent<TextMeshProUGUI>();
        _badText            = _textGroupTrm.Find("BadText").GetComponent<TextMeshProUGUI>();
        _missText           = _textGroupTrm.Find("MissText").GetComponent<TextMeshProUGUI>();
        _hiddenNoteText     = _textGroupTrm.Find("HiddenNote").GetComponent<TextMeshProUGUI>();
        _scoreText          = _textGroupTrm.Find("ScoreText").GetComponent<TextMeshProUGUI>();

        // star
        _starImages         = _starGrounTrm.GetComponentsInChildren<Image>();
    }

    public void UpdateScorePanel()
    {
        
    }
}
