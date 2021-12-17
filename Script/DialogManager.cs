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
            ObjectData objData = scanObject.GetComponent<ObjectData>(); //오브젝트데이터를 가져옴
            Talk(objData.id, objData.isNpc);

        
        talkPanel.SetActive(isAction); //토크패너가 켜짐

    }

    void Talk(int id, bool isNpc) //오브젝트 변수를 매개변수로 활용
    {
        string talkData = talkManager.GetTalk(id, talkIndex);

        if(talkData == null)
        {
            isAction = false; //대화창 종료
            talkIndex = 0; //대화가 끝났을때 0으로 초기화
            imageIndex = 0;
            return; //강제종료
        }

        //만약 return했다면 뒷내용 실행하지 않음
        if (isNpc)
        {
            talkText.text = talkData.Split(':')[0]; //구분자를 통해 배열로 나누는 문자열함수,0번째인덱스는 글
            image.sprite = talkManager.GetImage(id, int.Parse(talkData.Split(':')[1])); //1번째 인덱스는 구분자: ,Parse: 문자열을 int형으로변환
            image.color = new Color(1, 1, 1, 1);
        }
        
        
        else
        {
            talkText.text = talkData;
            
            image.color = new Color(1, 1, 1, 1);
        }

        isAction = true;
        talkIndex++; //다음 문장을 가져오기위해 늘어남
        
    }
}
