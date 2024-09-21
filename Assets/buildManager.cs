using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buildManager : MonoBehaviour
{
    public int buildID;
    public bool build;
    public GameObject posPoint;
    public GameObject[] objects;
    public GameObject[] realObjects;
    private RaycastHit hit;
    private Vector3 pos;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private LayerMask pickLayer;
    [SerializeField] private LayerMask wallLayer;

    public GameObject pickText;
    public GameObject handcon;
    public bool isShown;
    public bool vert;
    public GameObject buildText;
    public GameObject customText;
    shakerTrigger scs;
    public Text pText;
    public Text customTe;
    DrinkID drinkCS;
    public Text bT;
    public GameObject vtext;
    PickUpClass pick;
    public GameObject scText;
    public GameObject milkText;
    public GameObject recipe;
    public GameObject unboxTextBox;
    public Text unboxText;
    public Text rotateText;
    public GameObject stirText;


    // Start is called before the first frame update
    void Start()
    {
        unboxText = unboxTextBox.GetComponent<Text>();
        bT = buildText.GetComponent<Text>();
        customTe = customText.GetComponent<Text>();
        build = false;
        buildID = 0;
        posPoint.SetActive(false);
        objects[0].SetActive(false);
        objects[1].SetActive(false);
        isShown = false;
        handcon.SetActive(false);
        buildText.SetActive(false);
        customText.SetActive(false);
        vtext.SetActive(false);
        scs = FindObjectOfType<shakerTrigger>();
        pText = pickText.GetComponent<Text>();
        drinkCS = FindObjectOfType<DrinkID>();
        pick = FindObjectOfType<PickUpClass>();
        scText.SetActive(false);
        milkText.SetActive(false);
        if(drinkCS.lanID == 0)
        {
            recipe.SetActive(true);
        }
        else
        {
            recipe.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(pick.colliderName == "scooper (1)" || pick.colliderName == "spoon" || pick.colliderName == "rag")
        {
            scText.SetActive(true);
        }
        else
        {
            scText.SetActive(false);
        }
        if(pick.colliderName == "milk(Clone)")
        {
            milkText.SetActive(true);
        }
        else
        {
            milkText.SetActive(false);
        }
        if (pick.colliderName == "stir")
        {
            stirText.SetActive(true);
        }
        else
        {
            stirText.SetActive(false);
        }


        if (Input.GetKey(KeyCode.R))
        {
            if (vert == false)
            {
                objects[buildID].transform.Rotate(Vector3.up * 50f * Time.deltaTime);
            }
            if(vert == true)
            {
                objects[buildID].transform.Rotate(Vector3.forward * 50f * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.Q))
        {
            if (vert == false)
            {
                objects[buildID].transform.Rotate(Vector3.up * -50f * Time.deltaTime);
            }
            if (vert == true)
            {
                objects[buildID].transform.Rotate(Vector3.forward * -50f * Time.deltaTime);
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (build == true)
            {
                Build();
            }
        }

    }
    private void FixedUpdate()
    {
        if (build == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(buildID % 2 == 0)
            {
                vert = false;
            }
            if(buildID % 2 != 0)
            {
                vert = true;
            }
            if (Physics.Raycast(ray, out hit, 1000, layerMask) && vert == false)
            {
                pos = hit.point;
                posPoint.transform.position = pos;
                objects[buildID].transform.position = pos;
            }
            if(Physics.Raycast(ray, out hit, 1000, wallLayer) && vert == true)
            {
                pos = hit.point;
                posPoint.transform.position = pos;
                objects[buildID].transform.position = pos;
            }

        }
        Ray Pickray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(Pickray, out hit, 1.5f, pickLayer))
        {

            if(isShown == false && pick.colliderName == null)
            {
                isShown = true;
                pickText.SetActive(true);
                handcon.SetActive(true);
                if(drinkCS.lanID == 0)
                {
                    pText.text = "  拿取 / 放下";
                }
                if (drinkCS.lanID == 1)
                {
                    pText.text = "  Pick Up / Put Down";
                }
                if (drinkCS.lanID == 2)
                {
                    pText.text = "  取る / 置く";
                }
                if (drinkCS.lanID == 3)
                {
                    pText.text = "  拿取 / 放下";
                }
                if (drinkCS.lanID == 4)
                {
                    pText.text = "  Aufheben / Ablegen";
                }


            }

        }
        else
        {
            if (isShown == true)
            {
                isShown = false;
                pickText.SetActive(false);
                handcon.SetActive(false);
            }
        }


        if (Physics.Raycast(Pickray, out hit, 2))
        {

            if(hit.transform.name == "cupps")
            {
                if (drinkCS.lanID == 0)
                {
                    pText.text = "  拿取塑膠杯";
                }
                if (drinkCS.lanID == 1)
                {
                    pText.text = "   Take Plastic Cup";
                }
                if (drinkCS.lanID == 2)
                {
                    pText.text = "              プラスチックのカップを持ち上げる";
                }
                if (drinkCS.lanID == 3)
                {
                    pText.text = "              拿起塑料杯";
                }
                if (drinkCS.lanID == 4)
                {
                    pText.text = "              Den Plastikbecher hochheben";
                }
                if (isShown == false && pick.colliderName == null)
                {
                    isShown = true;
                    pickText.SetActive(true);
                    handcon.SetActive(true);
                }
            }
            if(hit.transform.name == "sealedBox(Clone)")
            {
                if (drinkCS.lanID == 0)
                {
                    unboxText.text = "  打開箱子";
                }
                if (drinkCS.lanID == 1)
                {
                    unboxText.text = "    Unbox";
                }
                if (drinkCS.lanID == 2)
                {
                    unboxText.text = "              箱を開ける";
                }
                if (drinkCS.lanID == 3)
                {
                    unboxText.text = "              打开箱子";
                }
                if (drinkCS.lanID == 4)
                {
                    unboxText.text = "              Die Schachtel öffnen";
                }


                if (isShown == false && pick.colliderName == null)
                {
                    isShown = true;
                    unboxTextBox.SetActive(true);
                    handcon.SetActive(true);
                }
            }
            else
            {
                unboxTextBox.SetActive(false);
            }

            if(hit.transform.name == "clerk")
            {
                if (drinkCS.lanID == 0)
                {
                    pText.text = "  封裝";
                }
                if (drinkCS.lanID == 1)
                {
                    pText.text = "   Seal Box";
                }
                if (drinkCS.lanID == 2)
                {
                    pText.text = "              物品を封入する";
                }
                if (drinkCS.lanID == 3)
                {
                    pText.text = "              封装物品";
                }
                if (drinkCS.lanID == 4)
                {
                    pText.text = "              Gegenstände verpacken";
                }


                if (isShown == false && pick.colliderName == null)
                {
                    isShown = true;
                    pickText.SetActive(true);
                    handcon.SetActive(true);
                }
            }

            if (hit.transform.name == "gate (1)")
            {
                if (drinkCS.lanID == 0)
                {
                    pText.text = "  使用鐵捲門";
                }
                if (drinkCS.lanID == 1)
                {
                    pText.text = "   Open door";
                }
                if (drinkCS.lanID == 2)
                {
                    pText.text = "              シャッターを使用する";
                }
                if (drinkCS.lanID == 3)
                {
                    pText.text = "              使用卷闸门";
                }
                if (drinkCS.lanID == 4)
                {
                    pText.text = "              Tür öffnen";
                }


                if (isShown == false && pick.colliderName == null)
                {
                    isShown = true;
                    pickText.SetActive(true);
                    handcon.SetActive(true);
                }
            }
            if (hit.transform.name == "bed")
            {
                if(drinkCS.hour >= 18 || drinkCS.hour < 6)
                {
                    if (drinkCS.lanID == 0)
                    {
                        pText.text = "  睡覺";
                    }
                    if (drinkCS.lanID == 1)
                    {
                        pText.text = "   Sleep";
                    }
                    if (drinkCS.lanID == 2)
                    {
                        pText.text = "   寝る";
                    }
                    if (drinkCS.lanID == 3)
                    {
                        pText.text = "  睡觉 ";
                    }
                    if (drinkCS.lanID == 4)
                    {
                        pText.text = "  Schlafen ";
                    }

                }
                else
                {
                    if (drinkCS.lanID == 0)
                    {
                        pText.text = "只有在晚上6點後才可睡覺";
                    }
                    if (drinkCS.lanID == 1)
                    {
                        pText.text = "You can only sleep after 6.pm";
                    }
                    if (drinkCS.lanID == 2)
                    {
                        pText.text = "                                            午後6時以降しか寝られません";
                    }
                    if (drinkCS.lanID == 3)
                    {
                        pText.text = "只有在晚上6点后才可睡觉";
                    }
                    if (drinkCS.lanID == 4)
                    {
                        pText.text = "Sie können erst nach 18 Uhr schlafen";
                    }

                }

                if (isShown == false && pick.colliderName == null)
                {
                    isShown = true;
                    pickText.SetActive(true);
                    handcon.SetActive(true);
                }
            }
            if (hit.transform.name == "gate")
            {
                if (drinkCS.lanID == 0)
                {
                    pText.text = "    開/閉店";
                }
                if (drinkCS.lanID == 1)
                {
                    pText.text = "    Open/Close shop";
                }
                if (drinkCS.lanID == 2)
                {
                    pText.text = "    開店/閉店";
                }
                if (drinkCS.lanID == 3)
                {
                    pText.text = "    开/闭店";
                }
                if (drinkCS.lanID == 4)
                {
                    pText.text = "    Laden öffnen/schließen";
                }
                if (isShown == false && pick.colliderName == null)
                {
                    isShown = true;
                    pickText.SetActive(true);
                    handcon.SetActive(true);
                }
            }

            if (hit.transform.name == "shaker")
            {
                scs.sCanvas.SetActive(true);
                

            }
            else
            {
                scs.sCanvas.SetActive(false);
            }
            if (hit.transform.name == "v1" || hit.transform.name == "v2")
            {
                vtext.SetActive(true);


            }
            else
            {
                vtext.SetActive(false);
            }


        }
        else
        {
            if(isShown == true)
            {
                isShown = false;
                pickText.SetActive(false);
                unboxTextBox.SetActive(false);
                handcon.SetActive(false);
            }
        }
        if (Physics.Raycast(Pickray, out hit, 3))
        {
            if(hit.transform.name == "Customer")
            {
                customText.SetActive(true);
                if(drinkCS.lanID == 0)
                {
                    customTe = customText.GetComponent<Text>();
                    customTe.text = "   點餐";
                }
                if (drinkCS.lanID == 1)
                {
                    customTe.text = "       Take Order";
                }
                if (drinkCS.lanID == 2)
                {
                    customTe.text = "       注文";
                }
                if (drinkCS.lanID == 3)
                {
                    customTe.text = "    点餐";
                }
                if (drinkCS.lanID == 4)
                {
                    customTe.text = "    Bestellung aufnehmen";
                }
            }
            else
            {
                customText.SetActive(false);
            }
        }


    }
    public void BuildMode()
    {
        
        build = true;
        posPoint.SetActive(true);
        objects[buildID].SetActive(true);
        buildText.SetActive(true);
        bT = buildText.GetComponent<Text>();
        if (drinkCS.lanID == 0)
        {
            bT.text = "[Q / R] 左右旋轉 [E] 放置";
        }
        if (drinkCS.lanID == 1)
        {
            pText.text = "[Q / R] Rotate  [E] place";
        }
        if(drinkCS.lanID == 2)
        {
            pText.text = "                [Q / R] 左右に回す [E] 置く";
        }
        if (drinkCS.lanID == 3)
        {
            pText.text = "     [Q/R] 左右旋转 [E] 放置";
        }
        if (drinkCS.lanID == 4)
        {
            pText.text = "     [Q / R] Drehen  [E] Objekt platzieren";
        }


    }
    public void ExitBuildMode()
    {
        build = false;
        posPoint.SetActive(false);
        objects[buildID].SetActive(false);
        buildText.SetActive(false);


    }
    public void Build()
    {
        Instantiate(realObjects[buildID], pos, objects[buildID].transform.rotation);
        if(buildID == 8)
        {
            Destroy(GameObject.Find("secnd"));
        }
        if (buildID == 0)
        {
            Destroy(GameObject.Find("plantObj(Clone)"));
        }
        if (buildID == 1)
        {
            Destroy(GameObject.Find("carpet(Clone)"));
        }
        if (buildID == 3)
        {
            Destroy(GameObject.Find("brickobj(Clone)"));
        }
        if (buildID == 4)
        {
            Destroy(GameObject.Find("pillarObj(Clone)"));
        }
        if (buildID == 5)
        {
            Destroy(GameObject.Find("lamp(Clone)"));
        }
        if (buildID == 6)
        {
            Destroy(GameObject.Find("blackboard(Clone)"));

        }
        if (buildID == 7)
        {
            Destroy(GameObject.Find("moobj(Clone)"));

        }
        if (buildID == 8)
        {
            Destroy(GameObject.Find("blackboard(Clone)"));
        }
        if (buildID == 9)
        {
            Destroy(GameObject.Find("wbrickobj(Clone)"));
        }
        ExitBuildMode();

    }
}
