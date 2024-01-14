using System.Xml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

/*
 * 주어진 XML을 읽어서 구조체로 만들고 반환하기 위한 클래스
 * 싱글톤 처리됨
 * 삽입하고 싶은 스탠드는 배열에 추가해줘야함
 */
public class XmlManager : MonoBehaviour
{
    private static XmlManager xmlmgr;
    public static XmlManager Instance
    {
        get
        {
            if (xmlmgr == null)
            {
                xmlmgr = FindObjectOfType<XmlManager>();
                if (xmlmgr == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(XmlManager).Name;
                    xmlmgr = obj.AddComponent<XmlManager>();
                }
            }
            return xmlmgr;
        }
    }
    XmlDocument XmlDoc;
    public Sprite[] Stand;
    //싱글톤 처리
    private void Awake()
    {
        if(xmlmgr == null)
        {
            xmlmgr = this as XmlManager;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    //변수 초기화
    private void Start()
    {
        XmlDoc = new XmlDocument();
    }

    private string Xmladdress(string XmlName)
    {
        return "Assets/script/Chat System/xml/" + XmlName;
    }

    //Xml 이름을 받아서 초기화, 실패 시 로그 출력 후 false반환
    private bool LoadXml(string XmlName)
    {
        if (XmlName != null)
        {
            try
            {
                XmlDoc.Load(Xmladdress(XmlName));
                Debug.Log("XmlName: " + XmlDoc.Name + " is succesfully Load!");
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError($"Error loading XML: {e.Message}");
                return false;
            }
        }
        else
        {
            Debug.Log("invalid filename!");
            return false;
        }
    }

    //이름기준으로 찾아서 반환해줌
    private Sprite Xml_parsing_Sprite(string name)
    {
        foreach (Sprite sprite in Stand)
        {
            if (sprite.name == name)
                return sprite;
        }
        return null;
    }

    //다이얼로그 노드하나만 받아 구조체로 파싱 후 반환
    private Dialogue Load_oneDialogue(XmlNode node)
    {
        Dialogue return_ = new Dialogue();
        return_.L_name = node.SelectSingleNode("L_name").InnerText;
        return_.R_name = node.SelectSingleNode("R_name").InnerText;
        return_.L_img = Xml_parsing_Sprite(node.SelectSingleNode("L_img").InnerText);
        return_.R_img = Xml_parsing_Sprite(node.SelectSingleNode("R_img").InnerText);
        return_.script = node.SelectSingleNode("script").InnerText;
        if (node.Attributes["Subject"].Value.Equals("T"))
            return_.subject = true;
        else
            return_.subject = false;
        /* TODO:
         * 속성 첨삭 필요 시 구조체&XML에 첨삭 후 이곳에 관련 파싱코드 첨삭
         */
        return return_;
    }
    public Queue<Dialogue> Return_Dialogue(string XmlName)
    {
        bool isLoad = LoadXml(XmlName);
        if (isLoad)
        {
            Queue<Dialogue> return_ = new Queue<Dialogue>();
            Dialogue temp;
            XmlNodeList DialogNodes = XmlDoc.SelectNodes("//Dialogue");
            foreach (XmlNode node in DialogNodes)
            {
                temp = Load_oneDialogue((XmlNode)node);
                return_.Enqueue(temp);
            }
            return return_;
        }
        return null; //Xml로드 안되면 null반환
    }
}
