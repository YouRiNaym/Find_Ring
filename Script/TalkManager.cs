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
        talkData = new Dictionary<int, string[]>();  //초기화
        imageData = new Dictionary<int, Sprite>();
        GenerateData();
        
    }

    // Update is called once per frame
    void GenerateData()
    {
        talkData.Add(1000, new string[] { "좋은 아침이야:0", "잠은 잘잤니?:0", "응!! 근데 지금 뭐하고 있어?:1", 
            "중요한 물건이 없어져서 찾는중이야 나좀 도와줄래?:0", "음.. 뭐를 잃어버린거야?:1","내 약혼반지 없어지면 큰일인데 아무리 찾아도 안보여:0", "이런 진짜 큰일이네! 알겠어 내가 도와줄게:1"}); //여러문장이기때문에 배열을사용
        // 좋은 아침이야 :  talkIndex1 , 잠은 잘 잤니? : talkIndex2
        talkData.Add(800, new string[] { "이곳은 오빠랑 함께 자주 밥을 먹는 곳이야 점심이 기대된다!" });
        talkData.Add(700, new string[] { "평볌한 싱크대네", "중요한건 없어보여" });

        talkData.Add(100, new string[] { "내가 항상 자고 일어나는 곳이야" });
        talkData.Add(200, new string[] { "귀여운 원피스가 가득 들어있어" });
        talkData.Add(300, new string[] { "서적들이 가득있네", "내껀아니지만..주로 오빠가 읽는 책이야" });
        talkData.Add(400, new string[] { "안에 잡동사니들이 가득 들어있어", "중요한건 없어보여" });
        talkData.Add(500, new string[] { "내가 키우는 소중한 토끼야","그런데 요즘 마구마구 물건들을 삼켜서 고민이야","전에는 내 장난감까지 삼켰었지?" });
        talkData.Add(600, new string[] { "귀여운 곰인형이네", "이름은 베리야" });

        imageData.Add(1000 + 0, imageArr[0]); //npc
        imageData.Add(1000 + 1, imageArr[1]);
    }

    // id로 대화를 get해오고 ,talkIndex로 대화의 한문장을 Get
    public string GetTalk(int id, int talkIndex) //Object의 id, string배열의 index
    {
        if (talkIndex == talkData[id].Length) //인덱스와 토크데이터의 길이(문장길이)가 같으면
            return null;

        else
            return talkData[id][talkIndex]; //해당 아이디의 해당하는 대사 반환해줌      
    }
    
    public Sprite GetImage(int id, int imageIndex) 
    {
        return imageData[id + imageIndex];
    }
}
