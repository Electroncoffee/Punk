using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

/*다이얼로그에 필요한 모든 오브젝트 함수를 참조받아서 사용
 XML을 제대로 사용하게 되는 경우 문자열 스플릿과 같은 데이터 처리 부분 수정 될 예정*/

[System.Serializable]
public struct Dialogue //다이얼로그 요소 정보를 담은 클래스
{
    public string L_name; //캐릭터의 이름
    public string R_name; //캐릭터의 이름
    [TextArea] //여러 줄 쓸 수 있게 해줌
    public string script; //대화 내용
    public Sprite L_img; //왼쪽 캐릭터의 스탠딩
    public Sprite R_img; //오른쪽 캐릭터의 스탠딩
    public bool subject; //true=L false=R
    public string effect;
}
public class TalkManager : MonoBehaviour //다이얼로그 출력을 위한 클래스
{
    private static TalkManager Talkmgr;
    public static TalkManager Instance
    {
        get
        {
            if (Talkmgr == null)
            {
                Talkmgr = FindObjectOfType<TalkManager>();
                if (Talkmgr == null)
                {
                    GameObject obj = new ();
                    obj.name = typeof(XmlManager).Name;
                    Talkmgr = obj.AddComponent<TalkManager>();
                }
            }
            return Talkmgr;
        }
    }
    [SerializeField]
    public Image[] stand_images;
    [SerializeField] public GameObject visible;

    [SerializeField] Image L_img; //왼쪽 캐릭터 스프라이트
    [SerializeField] Image R_img; //오른쪽 캐릭터 스프라이트
    [SerializeField] Text L_name; //왼쪽 이름 텍스트
    [SerializeField] Text R_name; //왼쪽 이름 텍스트
    [SerializeField] Text script; //대화 내용 텍스트

    [SerializeField] CanvasRenderer canvasRenderer;

    [SerializeField] float txt_speed;

    [SerializeField] Queue<Dialogue> dialogues; //Dialogue 구조체 큐 선언
    [SerializeField] int black_color_value;
    Color dark, white;
    private Dialogue current_dialogue;


    public bool istyping=false;
    string currentText;

    private void Awake() //싱글톤 사용해서 어디서든 start 함수를 쓸 수 있게
    {
        if (Talkmgr == null) {
            Talkmgr = this as TalkManager;
            DontDestroyOnLoad(this.gameObject);
        }
        else {
            Destroy(this.gameObject);
        }
        visible.SetActive(false);
        istyping = false;
        dark = new Color(black_color_value / 255f, black_color_value / 255f, black_color_value / 255f, 1f);
        white = new Color(1f, 1f, 1f, 1f);
    }

    public void start_dialogue(string Xmlname) //다이얼로그를 시작하는 함수
    {
        dialogues = XmlManager.Instance.Return_Dialogue(Xmlname);
        next_dialogue();
        visible.SetActive(true);
    }

    public void next_dialogue() //다음 다이얼로그로 넘어가는 함수
    {
        if (istyping)//타이핑중에 클릭되었으므로, 전부 출력해줌.
        {
            StopAllCoroutines();
            script.text = currentText;
            istyping = false;
        }
        else if (!istyping && dialogues.Count!=0)//전부 출력됬는데, 아직 안끝났으니 다음꺼 출력
        {
            current_dialogue = dialogues.Dequeue();
            string txt_change = current_dialogue.script;

            //다음 배열로
            L_name.text = current_dialogue.L_name;
            R_name.text = current_dialogue.R_name;
            script.text = current_dialogue.script;
            L_img.sprite = current_dialogue.L_img;
            R_img.sprite = current_dialogue.R_img;
            Image_black(current_dialogue.subject);
            //스프라이트 없으면 스프라이트 끄기
            if (current_dialogue.L_img == null)
                L_img.gameObject.SetActive(false);
            else
                L_img.gameObject.SetActive(true);
            if (current_dialogue.R_img == null)
                R_img.gameObject.SetActive(false);
            else
                R_img.gameObject.SetActive(true);
            StartCoroutine(Typing(txt_change));
        }
        else//대화종료이므로 대화문 안보이게
        {
            visible.SetActive(false);
        }
    }
    
    //L(T)/R(F)입력에 맞게 이미지를 까맣게 만들어줌
    private void Image_black(bool flag)
    {
        if (flag)
        {
            L_img.color = white;
            R_img.color = dark;
        }
        else
        {
            L_img.color = dark;
            R_img.color = white;
        }
    }

    IEnumerator Typing(string text)
    {
        script.text = string.Empty;
        currentText = text;

        StringBuilder stringBuilder = new ();

        for (int i = 0; i < text.Length; i++)
        {
            stringBuilder.Append(text[i]);
            script.text = stringBuilder.ToString();

            yield return new WaitForSeconds(txt_speed);
            istyping = true;
        }
        istyping = false;
    }
}
