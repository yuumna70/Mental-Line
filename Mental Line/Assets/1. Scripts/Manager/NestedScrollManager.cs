using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// ���丮 ������ ���丮 �� �ѱ�� ��ũ��
public class NestedScrollManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Scrollbar scrollbar;
    public Transform contentTr;

    //public Slider tabSlider;
    public RectTransform[] BtnRect, BtnImageRect;

    // ���丮 �� ����
    const int SIZE = 5;
    float[] pos = new float[SIZE];
    float distance, curPos, targetPos;
    bool isDrag;
    int targetIndex;

    void Start()
    {
        // �Ÿ��� ���� 0~1�� pos����
        distance = 1f / (SIZE - 1);
        for (int i = 0; i < SIZE; i++) pos[i] = distance * i;
    }

    float SetPos()
    {
        // ���ݰŸ��� �������� ����� ��ġ�� ��ȯ
        for (int i = 0; i < SIZE; i++)
            if (scrollbar.value < pos[i] + distance * 0.5f && scrollbar.value > pos[i] - distance * 0.5f)
            {
                targetIndex = i;
                return pos[i];
            }
        return 0;
    }

    public void OnBeginDrag(PointerEventData eventData)
    { 
        curPos = SetPos();
    }


    public void OnDrag(PointerEventData eventData)
    {
        isDrag = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDrag = false;
        targetPos = SetPos();
        
    }


    void Update()
    {
        if (!isDrag)
        {
            scrollbar.value = Mathf.Lerp(scrollbar.value, targetPos, 0.1f);
        }

    }




    }

