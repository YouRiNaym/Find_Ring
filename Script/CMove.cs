using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMove : MonoBehaviour
{
    float h; //x��
    float v; //y��
    public float speed;
    Animator anim;
    Rigidbody2D rigid;
    public DialogManager manager;
    bool isHorizonMove;

    Vector3 direct; //����
    GameObject scanObject;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }


    void Update()
    {
        h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal"); //�׼��� �������� ������ ����
        v = manager.isAction ? 0 : Input.GetAxisRaw("Vertical");

        bool hDown = manager.isAction ? false : Input.GetButtonDown("Horizontal");
        
        bool vDown = manager.isAction ? false : Input.GetButtonDown("Vertical");
        

        if (hDown)
            isHorizonMove = true; //x�� ����Ű�� �������� Horizontal�������̴� 
        else if (vDown)
            isHorizonMove = false;

        anim.SetInteger("hAxisRaw", (int)h);
        anim.SetInteger("vAxisRaw", (int)v);

        if (vDown && v == 1) // ��Ű��������
            direct = Vector3.up; //������ ��������
        if (vDown && v == -1) 
            direct = Vector3.down;
        if (hDown && h == 1)
            direct = Vector3.right;
        if (hDown && h == -1)
            direct = Vector3.left;

        if (Input.GetKeyDown(KeyCode.Space) && scanObject != null) //�����̽��ٸ� ������ ��ĳ�ʰ� null�� �ƴҶ�
            manager.Action(scanObject);
    }

    void FixedUpdate()
    {
        //���� Move
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * speed;

        Debug.DrawRay(transform.position, direct * 1.0f, new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, direct, 1.0f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
            scanObject = null;
    }
}
