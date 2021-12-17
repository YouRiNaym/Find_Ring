using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> imageData;
    public Sprite[] imageArr;
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();  //�ʱ�ȭ
        imageData = new Dictionary<int, Sprite>();
        GenerateData();
        
    }

    // Update is called once per frame
    void GenerateData()
    {
        talkData.Add(1000, new string[] { "���� ��ħ�̾�:0", "���� �����?:0", "��!! �ٵ� ���� ���ϰ� �־�?:1", 
            "�߿��� ������ �������� ã�����̾� ���� �����ٷ�?:0", "��.. ���� �Ҿ�����ž�?:1","�� ��ȥ���� �������� ū���ε� �ƹ��� ã�Ƶ� �Ⱥ���:0", "�̷� ��¥ ū���̳�! �˰ھ� ���� �����ٰ�:1"}); //���������̱⶧���� �迭�����
        // ���� ��ħ�̾� :  talkIndex1 , ���� �� ���? : talkIndex2
        talkData.Add(800, new string[] { "�̰��� ������ �Բ� ���� ���� �Դ� ���̾� ������ ���ȴ�!" });
        talkData.Add(700, new string[] { "����� ��ũ���", "�߿��Ѱ� �����" });

        talkData.Add(100, new string[] { "���� �׻� �ڰ� �Ͼ�� ���̾�" });
        talkData.Add(200, new string[] { "�Ϳ��� ���ǽ��� ���� ����־�" });
        talkData.Add(300, new string[] { "�������� �����ֳ�", "�����ƴ�����..�ַ� ������ �д� å�̾�" });
        talkData.Add(400, new string[] { "�ȿ� �⵿��ϵ��� ���� ����־�", "�߿��Ѱ� �����" });
        talkData.Add(500, new string[] { "���� Ű��� ������ �䳢��","�׷��� ���� �������� ���ǵ��� ���Ѽ� ����̾�","������ �� �峭������ ���׾���?" });
        talkData.Add(600, new string[] { "�Ϳ��� �������̳�", "�̸��� ������" });

        imageData.Add(1000 + 0, imageArr[0]); //npc
        imageData.Add(1000 + 1, imageArr[1]);
    }

    // id�� ��ȭ�� get�ؿ��� ,talkIndex�� ��ȭ�� �ѹ����� Get
    public string GetTalk(int id, int talkIndex) //Object�� id, string�迭�� index
    {
        if (talkIndex == talkData[id].Length) //�ε����� ��ũ�������� ����(�������)�� ������
            return null;

        else
            return talkData[id][talkIndex]; //�ش� ���̵��� �ش��ϴ� ��� ��ȯ����      
    }
    
    public Sprite GetImage(int id, int imageIndex) 
    {
        return imageData[id + imageIndex];
    }
}
