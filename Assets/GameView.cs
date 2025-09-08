using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class GameView : Graphic
{
    [SerializeField] private Transform nodeSpawnPoint;
    [SerializeField] private Transform[] nodeJudgePoints;

    [SerializeField] private Note longNote;
    [SerializeField] private float currentTime = 0f;

    private List<Vector2> segments = new();
    private List<float> timeSegments = new();
    [SerializeField] private int segmentCount = 16;
    [SerializeField] private int foll

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();
        CalculateSegments();
    }

    private void CalculateSegments()
    {
        segments.Clear();
        timeSegments.Clear();
        var start = longNote.Time;
        var end = longNote.Time + longNote.Duration;
        var segment = (end - start) / 16;
        var value = start;
        while (value < end)
        {
            value += segment;
            if (value > end)
            {
                value = end;
            }
            timeSegments.Add(value);
        }
    }

    private void OnDrawGizmos()
    {
    }

    protected override void OnValidate()
    {
        SetVerticesDirty(); // For re-draw
    }

    private Vector2 GetLanePosition(float lane, float time)
    {
        int a = Mathf.CeilToInt(lane);
        int b = (int)lane;
        return Vector2.zero;
    }
}