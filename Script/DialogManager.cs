using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogManager : MonoBehaviour
{
    public TalkManager talkManager;
    public GameObject talkPanel;
    public Text talkText;
    public GameObject scanObject;
    public Image image;
    public bool isAction;
    public int talkIndex;
    public int imageIndex;

    public void Action(GameObject scanobj)
    {
       
             
            scanObject = scanobj;
            ObjectData objData = scanObject.GetComponent<ObjectData>(); //������Ʈ�����͸� ������
            Talk(objData.id, objData.isNpc);

        
        talkPanel.SetActive(isAction); //��ũ�гʰ� ����

    }

    void Talk(int id, bool isNpc) //������Ʈ ������ �Ű������� Ȱ��
    {
        string talkData = talkManager.GetTalk(id, talkIndex);

        if(talkData == null)
        {
            isAction = false; //��ȭâ ����
            talkIndex = 0; //��ȭ�� �������� 0���� �ʱ�ȭ
            imageIndex = 0;
            return; //��������
        }

        //���� return�ߴٸ� �޳��� �������� ����
        if (isNpc)
        {
            talkText.text = talkData.Split(':')[0]; //�����ڸ� ���� �迭�� ������ ���ڿ��Լ�,0��°�ε����� ��
            image.sprite = talkManager.GetImage(id, int.Parse(talkData.Split(':')[1])); //1��° �ε����� ������: ,Parse: ���ڿ��� int�����κ�ȯ
            image.color = new Color(1, 1, 1, 1);
        }
        
        
        else
        {
            talkText.text = talkData;
            
            image.color = new Color(1, 1, 1, 1);
        }

        isAction = true;
        talkIndex++; //���� ������ ������������ �þ
        
    }
}
