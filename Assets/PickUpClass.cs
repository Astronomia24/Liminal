using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class PickUpClass : MonoBehaviour
{
    [SerializeField] private LayerMask PickUpLayer;

    [SerializeField] private Camera PlayerCamera;

    [SerializeField] private float PickUpRange;

    [SerializeField] private Transform Hand;

    private GameObject heldObject;
    public float radius = 0.2f;
    public float distance = 1f;
    public float height = 1f;



    public Rigidbody CurrentObjRigidbody;
    public Collider CurrentObjCollider;

    public GameObject shakerLid;
    public string colliderName;
    public AudioSource src;
    public AudioSource tearsrc;
    public AudioClip sfx;
    public AudioClip trsfx;
    public AudioClip trsfx2;
    public int isShaker;
    shakerTrigger scs;
    customerManager customer;
    public GameObject shakerText;
    public Text sText;
    public int i;
    public GameObject place;
    public Transform newHand;
    buildManager bm;
    nLaptop lc;
    startFill sf1;
    sliding sl;
    checkice ci;
    public string teatype;
    tutorControl tut;
    public bool istut;
    checkTrigger cTrigger;
    FridgeScript fs;
    cupSpawning cs;
    public GameObject playerObj;
    public float force;
    public Transform startRot;
    public GameObject scoopText;
    public GameObject packText;

    public Transform dropTrans;
    public GameObject targetStain;
    public GameObject creamText;
    public GameObject refillText;
    public static float deltaTime;
    public GameObject currentObj;

    public Vector3 originalPos;
    public Vector3 targetPos;
    public GameObject originalObj;
    public Vector3 velocity;
    public Vector3 startPos;
    public bool set;
    public bool back;


    DrinkID drinkCS;
    checkOpen ckOpen;
    checkCol ccl;
    bucketTrigger bt;
    milkFlip mf;
    creamerFlip cf;
    newIce ics;
    sugarScript ss;
    BOBAflip bf;
    CupTrigger ccs;
    public AudioSource fridgesrc;
    public AudioClip open;
    public AudioClip close;
    public cupStats stats;
    public quener q;
    public posControl pControl;
    orderCheck oCheck;
    public GameObject sliva;
    public GameObject cloneSliva;
    public Rigidbody slivaRb;
    public AudioSource spitsrc;
    public bool shakerPour;
    public bool pourPlayed;
    public AudioSource lidSrc;
    public bool icePlayed;
    public bool bucketPour;
    fireTrigger fTrigger;
    spoonStat spStat;
    matchaFlip maFlip;
    public AudioSource stirSfx;
    public AudioSource powderSfx;

    void Start()
    {
        bucketPour = false; 
        icePlayed = false;
        pourPlayed = false;
        shakerPour = false;
        back = true;
        set = false;
        sliva = GameObject.Find("sliva");
        colliderName = null;
        packText.SetActive(false);
        scoopText.SetActive(false);
        PlayerCamera = Camera.main;
        scs = FindObjectOfType<shakerTrigger>();
        bm = FindObjectOfType<buildManager>();
        customer = FindObjectOfType<customerManager>();
        sf1 = FindObjectOfType<startFill>();
        lc = FindObjectOfType<nLaptop>();
        sl = FindObjectOfType<sliding>();
        ci = FindObjectOfType<checkice>();
        tut = FindObjectOfType<tutorControl>();
        cTrigger = FindObjectOfType<checkTrigger>();
        fs = FindObjectOfType<FridgeScript>();
        sl.fill = 0;
        istut = false;

        shakerLid.SetActive(false);
        shakerText.SetActive(false);
        cs = FindObjectOfType<cupSpawning>();
        bt = FindObjectOfType<bucketTrigger>();
        force = 700f;
        ics = FindObjectOfType<newIce>();
        creamText.SetActive(false);
        ss = FindObjectOfType<sugarScript>();
        bf = FindObjectOfType<BOBAflip>();
        ccs = FindObjectOfType<CupTrigger>();
        spitsrc = GameObject.Find("spitsrc").GetComponent<AudioSource>();

        refillText.SetActive(false);
        oCheck = FindObjectOfType<orderCheck>();
        fTrigger = FindObjectOfType<fireTrigger>();
        drinkCS = FindObjectOfType<DrinkID>();
        spStat = FindObjectOfType<spoonStat>();
        maFlip = FindObjectOfType<matchaFlip>();

    }
    public void PutDown()
    {
        
        shakerText.SetActive(false);
        isShaker = 0;
        shakerLid.SetActive(false);

        Debug.Log(colliderName);
        if (CurrentObjRigidbody)
        {

            bm.ExitBuildMode();
            colliderName = null;
            src.clip = sfx;
            src.Play();
            CurrentObjRigidbody.isKinematic = false;
            CurrentObjCollider.enabled = true;
            CurrentObjRigidbody.AddForce(PlayerCamera.transform.forward * 0f, ForceMode.Impulse);
            CurrentObjRigidbody.AddTorque(CurrentObjRigidbody.gameObject.transform.up * 0f, ForceMode.Impulse);






            CurrentObjRigidbody = null;
            CurrentObjCollider = null;

        }
    }
    private void FixedUpdate()
    {
        if (CurrentObjRigidbody)
        {
            CurrentObjRigidbody.velocity = Vector3.zero;

        }
        if (heldObject)
        {
            var rigidbody = heldObject.GetComponent<Rigidbody>();
            rigidbody.isKinematic = false;
            var moveTo = Hand.transform.position + PlayerCamera.transform.forward + playerObj.transform.up * 0.5f;
            var difference = moveTo - heldObject.transform.position;
            rigidbody.AddForce(difference * force);
            rigidbody.gameObject.transform.parent = null;
        }




    }
    public void Spit()
    {
        cloneSliva = Instantiate(sliva, PlayerCamera.transform.position, Quaternion.identity);
        slivaRb = cloneSliva.GetComponent<Rigidbody>();
        slivaRb.AddForce(Camera.main.transform.forward * 10f, ForceMode.Impulse);
    }


    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            Ray PickUpray2 = new Ray(PlayerCamera.transform.position, PlayerCamera.transform.forward);
            if (Physics.Raycast(PickUpray2, out hit, 2f))
            {
                if(hit.transform.name == "shaker" && colliderName == "stir")
                {
                    stirSfx.Play();
                }
                if(hit.transform.name == "matchaCup" && colliderName == "spoon")
                {
                    powderSfx.Play();
                }
                if (hit.transform.name == "shaker" && colliderName == "spoon" && spStat.stats[2] == true)
                {
                    powderSfx.Play();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            spitsrc.Play();
            Invoke("Spit", 1f);


        }


        if (heldObject)
        {
            currentObj = heldObject;

            if (currentObj.name != "orderPaper(Clone)" || currentObj == null)
            {
                oCheck.teaType.gameObject.SetActive(false);
                oCheck.iceType.gameObject.SetActive(false);
                oCheck.sugarType.gameObject.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (heldObject.name == "greenLeaf(Clone)" || heldObject.name == "blackLeaf(Clone)"|| heldObject.name == "bobabag(Clone)")
                {
                    ckOpen = heldObject.GetComponent<checkOpen>();
                    ckOpen.Open();
                    if(ckOpen.opened == false)
                    {
                        tearsrc.clip = trsfx;
                        tearsrc.Play();
                    }


                }
                if(heldObject.name == "milk(Clone)")
                {
                    mf = heldObject.GetComponent<milkFlip>();
                    if(mf.isOpen == false)
                    {
                        mf.Open();
                        tearsrc.clip = trsfx2;
                        tearsrc.Play();
                    }
                }
                if (heldObject.name == "creamer(Clone)")
                {
                    cf = heldObject.GetComponent<creamerFlip>();
                    if (cf.isOpen == false)
                    {
                        cf.Open();
                        tearsrc.clip = trsfx2;
                        tearsrc.Play();
                    }
                }





            }





            if (heldObject.name == "scooper (1)")
            {

            }
            else if(heldObject.name == "milk(Clone)")
            {


            }
            else
            {

            }

        }
        else
        {

            oCheck.teaType.gameObject.SetActive(false);
            oCheck.iceType.gameObject.SetActive(false);
            oCheck.sugarType.gameObject.SetActive(false);
        }



        if (Input.GetKey(KeyCode.Q))
        {
            Hand.transform.Rotate(Vector3.forward * 200f * Time.deltaTime);
            heldObject.transform.rotation = Hand.transform.rotation;
        }
        if (Input.GetKey(KeyCode.R))
        {
            Hand.transform.Rotate(Vector3.forward * -200f * Time.deltaTime);
            heldObject.transform.rotation = Hand.transform.rotation;
        }
        if (heldObject)
        {
            GameObject player = heldObject;
            Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
            if (heldObject.name == "scooper (1)" || heldObject.name == "milk(Clone)" || heldObject.name == "greenLeaf(Clone)" || heldObject.name == "blackLeaf(Clone)" || heldObject.name == "bobabag(Clone)" || heldObject.name == "creamer(Clone)")
            {
                dropTrans = heldObject.transform.GetChild(2).gameObject.transform;

            }
            else
            {

            }




            if (heldObject.name == "scooper (1)" || heldObject.name == "spoon" || heldObject.name == "greenLeaf(Clone)" || heldObject.name == "blackLeaf(Clone)" || heldObject.name == "bobabag(Clone)" || heldObject.name == "milk(Clone)")
            {


            }
            else
            {

            }
            if(heldObject.name == "greenLeaf(Clone)" || heldObject.name == "blackLeaf(Clone)" || heldObject.name == "bobabag(Clone)" || heldObject.name == "milk(Clone)" || heldObject.name == "creamer(Clone)")
            {
                packText.SetActive(true);
                if (drinkCS.lanID == 0)
                {
                    bm.rotateText.text = " 左 / 右 旋轉";
                }
                if (drinkCS.lanID == 1)
                {
                    bm.rotateText.text = "Rotate left / right";
                }
                if (drinkCS.lanID == 2)
                {
                    bm.rotateText.text = "左回転 / 右回転";
                }
                if (drinkCS.lanID == 3)
                {
                    bm.rotateText.text = " 左 / 右 旋转";
                }
                if (drinkCS.lanID == 4)
                {
                    bm.rotateText.text = " Links / Rechts drehen";
                }
                if(heldObject.name == "creamer(Clone)")
                {
                    creamText.SetActive(true);
                }
            }
            else
            {
                creamText.SetActive(false);
            }
            if(heldObject.name == "sugarefill(Clone)" || heldObject.name == "nbag(Clone)" || heldObject.name == "matchaBag(Clone)")
            {
                
                refillText.SetActive(true);
            }
            else if(heldObject.name == "teaBucket")
            {

                    refillText.SetActive(true);

            }
            if (heldObject == null || colliderName == null)
            {
                refillText.SetActive(false);
            }


            if (heldObject == null)
            {

                packText.SetActive(false);
            }
            var rigidbody = heldObject.GetComponent<Rigidbody>();
            heldObject.layer = LayerMask.NameToLayer("Ignore Raycast");





            if(heldObject.name == "cup(Clone)")
            {

                heldObject.layer = LayerMask.NameToLayer("Ignore Raycast");
            }
            if (heldObject.name == "shaker")
            {
                heldObject.layer = LayerMask.NameToLayer("Ignore Raycast");
                heldObject.transform.rotation = Quaternion.Euler(-90f, startRot.rotation.y, startRot.rotation.z);
                isShaker = 1;
            }
            else
            {
                if (heldObject.name == "scooper (1)")
                {
                    heldObject.transform.rotation = Hand.transform.rotation;
                }
                else if (heldObject.name == "greenLeaf(Clone)" || heldObject.name == "blackLeaf(Clone)" || heldObject.name == "bobabag(Clone)" || heldObject.name == "milk(Clone)" || heldObject.name == "creamer(Clone)" || heldObject.name == "spoon" || heldObject.name == "extinqish" || heldObject.name =="orderPaper(Clone)"|| heldObject.name == "matchaBag(Clone)")
                {
                    heldObject.transform.rotation = Hand.transform.rotation;
                }
                else
                {

                    heldObject.transform.rotation = Quaternion.Euler(0f, startRot.rotation.y, 0f);
                }



                isShaker = 0;
            }
            if (heldObject.name == "plantObj(Clone)")
            {
                bm.ExitBuildMode();

                bm.buildID = 0;
                bm.BuildMode();

            }
            if (heldObject.name == "carpet(Clone)")
            {
                bm.ExitBuildMode();
                bm.buildID = 1;
                bm.BuildMode();


            }
            if (heldObject.name == "woodobj(Clone)")
            {
                bm.ExitBuildMode();
                bm.buildID = 2;
                bm.BuildMode();


            }
            if (heldObject.name == "brickobj(Clone)")
            {
                bm.ExitBuildMode();
                bm.buildID = 3;
                bm.BuildMode();


            }
            if (heldObject.name == "lamp(Clone)")
            {
                bm.ExitBuildMode();
                bm.buildID = 5;
                bm.BuildMode();


            }
            if (heldObject.name == "moobj(Clone)")
            {
                bm.ExitBuildMode();
                bm.buildID = 7;
                bm.BuildMode();


            }
            if (heldObject.name == "pillarObj(Clone)")
            {
                bm.ExitBuildMode();
                bm.buildID = 4;
                bm.BuildMode();


            }
            if (heldObject.name == "blackboard(Clone)")
            {
                bm.ExitBuildMode();
                bm.buildID = 6;
                bm.BuildMode();


            }
            if (heldObject.name == "wbrickobj(Clone)")
            {
                bm.ExitBuildMode();
                bm.buildID = 9;
                bm.BuildMode();


            }
            if (heldObject.name == "secnd")
            {
                bm.ExitBuildMode();
                bm.buildID = 8;
                bm.BuildMode();


            }
            if (heldObject.name == "flyer(Clone)")
            {
                bm.ExitBuildMode();
                bm.buildID = 11;
                bm.BuildMode();


            }



            if (Input.GetMouseButtonDown(0))
            {
                if (heldObject != null)
                {

                    if (heldObject.name != "box(Clone)")
                    {
                        heldObject.layer = LayerMask.NameToLayer("PickUp");
                        heldObject.transform.SetParent(null);
                    }
                    else
                    {
                        heldObject.layer = LayerMask.NameToLayer("boxTrigger");
                    }

                    packText.SetActive(false);
                    rigidbody.velocity = Vector3.zero;


                    force = 900f;
                    rigidbody.velocity = Vector3.zero;
                    heldObject = null;
                    colliderName = null;
                    rigidbody.velocity = Vector3.zero;
                    rigidbody.drag = 1f;
                    rigidbody.useGravity = true;
                    rigidbody.isKinematic = false;
                    rigidbody.freezeRotation = true;
                    rigidbody.angularVelocity = Vector3.zero;
                    rigidbody.freezeRotation = false;
                    rigidbody.velocity = Vector3.zero;
                    bm.ExitBuildMode();
                    rigidbody.velocity = Vector3.zero;
                    refillText.SetActive(false);
                    oCheck.teaType.gameObject.SetActive(false);
                    oCheck.iceType.gameObject.SetActive(false);
                    oCheck.sugarType.gameObject.SetActive(false);
                }


            }
            if (Input.GetMouseButtonDown(1))
            {
                
                if (heldObject.name  != "box(Clone)")
                {
                    heldObject.layer = LayerMask.NameToLayer("PickUp");
                    heldObject.transform.SetParent(null);
                }
                else
                {
                    heldObject.layer = LayerMask.NameToLayer("boxTrigger");
                }
                packText.SetActive(false);
                refillText.SetActive(false);

                src.clip = sfx;
                src.Play();
                rigidbody.drag = 1f;
                rigidbody.useGravity = true;
                rigidbody.isKinematic = false;
                rigidbody.AddForce(Camera.main.transform.forward * 10f, ForceMode.Impulse);
                heldObject = null;
                colliderName = null;
                bm.ExitBuildMode();
                force = 900f;
                oCheck.teaType.gameObject.SetActive(false);
                oCheck.iceType.gameObject.SetActive(false);
                oCheck.sugarType.gameObject.SetActive(false);

            }
        }
        else
        {
            creamText.SetActive(false);
            if (Input.GetMouseButtonDown(0))
            {

                Ray PickUpray = new Ray(PlayerCamera.transform.position, PlayerCamera.transform.forward);
                if(Physics.Raycast(PickUpray, out RaycastHit hitInfo, PickUpRange))
                {
                    if (hitInfo.transform.gameObject.tag == "PickUp")
                    {
                        src.clip = sfx;
                        src.Play();
                        var hitObject = hitInfo.transform.gameObject;
                        heldObject = hitObject;
                        colliderName = heldObject.name;
                        var rigidbody = heldObject.GetComponent<Rigidbody>();
                        rigidbody.drag = 30f;
                        rigidbody.useGravity = false;
                        rigidbody.isKinematic = false;







                        Hand.transform.rotation = startRot.transform.rotation;
                    }
                }



            }

        }


        if (Input.GetKey(KeyCode.R))
        {


        }
        if (tut.step == 2 && colliderName == "shaker")
        {
            tut.step = 3;

        }

        if (Input.GetKey(KeyCode.E))
        {
            RaycastHit hit;
            Ray PickUpray2 = new Ray(PlayerCamera.transform.position, PlayerCamera.transform.forward);
            if (Physics.Raycast(PickUpray2, out hit,2f))
            {
                if(hit.transform.name == "fire")
                {
                    if(colliderName == "extinqish")
                    {
                        fTrigger.PutOut();
                    }
                }




                if(hit.transform.name == "nCup")
                {
                    if (colliderName == "spoon")
                    {
                        if (ccs.haveSugar == 1 || ccs.haveBoba == 1)
                        {
                            sl.fill += 1.9f * Time.deltaTime;
                        }
                    }
                }

                if (hit.transform.name == "nCup" && isShaker == 1 && sl.fill < 1)
                {

                    sl.fill += 0.7f * Time.deltaTime;

                }
                if (hit.transform.name == "cup(Clone)" && isShaker == 1 && sl.fill < 1)
                {
                    scs.currentCup = hit.transform.gameObject;
                    stats = scs.currentCup.GetComponent<cupStats>();
                    if (stats.isSealed == 0)
                    {
                        
                        sl.fill += 0.7f * Time.deltaTime;
                        shakerPour = true;
                        if(pourPlayed == false)
                        {
                            scs.src.clip = scs.sfx3;
                            scs.src.Play();
                            pourPlayed = true;
                        }

                    }

                }
                if (hit.transform.tag == "stain" && sl.fill < 1)
                {

                    if(colliderName == "rag")
                    {
                        targetStain = hit.transform.gameObject;
                        sl.fill += 1f * Time.deltaTime;
                    }
                }
                if (hit.transform.name == "sugarCup" && sl.fill < 1 && ss.sugarCount > 0)
                {
                    if (colliderName == "spoon" && scs.haveSugar == 0)
                    {
                        originalObj = GameObject.Find("ad");
                        if(set == false)
                        {
                            SetPos();
                            set = true;
                        }
                        sl.fill += 3f * Time.deltaTime;
                        targetPos = hit.transform.position;
                        back = true;
                        originalPos = originalObj.transform.position;
                        var step = 2f * Time.deltaTime; // calculate distance to move
                        originalObj.transform.position = Vector3.MoveTowards(originalObj.transform.position, targetPos, step);
                    }

                }
                if (hit.transform.name == "shaker" && sl.fill < 1)
                {
                    if (colliderName == "scooper (1)" && ics.haveIce == 1)
                    {
                        sl.nice.isIce = false;
                        sl.fill += 3f * Time.deltaTime;
                        if(icePlayed == false)
                        {
                            scs.ID = UnityEngine.Random.Range(1, 5);
                            scs.src2.clip = scs.sf[scs.ID];
                            scs.src2.Play();
                            icePlayed = true;

                        }

                    }
                    if (colliderName == "spoon")
                    {
                        originalObj = GameObject.Find("ad");
                        for (int i = 0; i <  spStat.stats.Length; i++)
                        {

                            if(spStat.stats[i] == true)
                            {
                                sl.fill += 2.5f * Time.deltaTime;
                                if (set == false)
                                {
                                    SetPos();
                                    set = true;
                                }
                                sl.fill += 1.7f * Time.deltaTime;
                                targetPos = hit.transform.position;
                                back = true;
                                originalPos = originalObj.transform.position;
                                var step = 2f * Time.deltaTime; // calculate distance to move
                                originalObj.transform.position = Vector3.MoveTowards(originalObj.transform.position, targetPos, step);
                            }
                        }
                        if(scs.haveSugar == 1 || scs.haveBoba == 1)
                        {
                            originalObj = GameObject.Find("ad");
                            sl.fill += 2.5f * Time.deltaTime;
                            if (set == false)
                            {
                                SetPos();
                                set = true;
                            }
                            sl.fill += 3f * Time.deltaTime;
                            targetPos = hit.transform.position;
                            back = true;
                            originalPos = originalObj.transform.position;
                            var step = 2f * Time.deltaTime; // calculate distance to move
                            originalObj.transform.position = Vector3.MoveTowards(originalObj.transform.position, targetPos, step);
                        }
                    }
                    if(colliderName == "stir")
                    {
                        originalObj = GameObject.Find("stir");
                        sl.fill += 0.5f * Time.deltaTime;
                        targetPos = hit.transform.position;
                        back = true;
                        originalPos = originalObj.transform.position;
                        var step = 2f * Time.deltaTime; // calculate distance to move
                        originalObj.transform.position = Vector3.MoveTowards(originalObj.transform.position, targetPos, step);

                    }


                }
                if (hit.transform.name == "nCup" && sl.fill < 1)
                {

                }
                if(hit.transform.name == "ice" && sl.fill < 1 && sl.nice.haveIce == 0)
                {

                    if (colliderName == "scooper (1)")
                    {
                        sl.nice.isIce = true;
                        sl.fill += 2.5f * Time.deltaTime;
                    }
                    if (colliderName == "nbag(Clone)")
                    {
                        sl.fill += 0.5f * Time.deltaTime;
                    }
                }
                
                if (hit.transform.name == "sugarCup" && sl.fill < 1)
                {
                    if (colliderName == "sugarefill(Clone)")
                    {
                        sl.fill += 1.2f * Time.deltaTime;
                    }
                }
                if(hit.transform.name == "matchaCup")
                {
                    if(colliderName == "spoon" && spStat.stats[2] == false && spStat.amounts[2] > 0)
                    {
                        originalObj = GameObject.Find("ad");
                        if (set == false)
                        {
                            SetPos();
                            set = true;
                        }
                        spStat.current[2] = true;
                        sl.fill += 3f * Time.deltaTime;
                        targetPos = hit.transform.position;
                        back = true;
                        originalPos = originalObj.transform.position;
                        var step = 2f * Time.deltaTime; // calculate distance to move
                        originalObj.transform.position = Vector3.MoveTowards(originalObj.transform.position, targetPos, step);
                    }
                    if (colliderName == "matchaBag(Clone)")
                    {
                        sl.fill += 1.2f * Time.deltaTime;
                    }
                }
                if (hit.transform.name == "bobaCup" && sl.fill < 1 && bf.bbAmount >= 0)
                {
                    if (colliderName == "teaBucket" && cTrigger.cookBB == true && cTrigger.haveBB == true)
                    {
                        sl.fill += 1.2f * Time.deltaTime;
                        bucketPour = true;
                    }
                    if (colliderName == "spoon" && scs.haveBoba == 0)
                    {
                        originalObj = GameObject.Find("ad");
                        sl.fill += 3f * Time.deltaTime;
                        if (set == false)
                        {
                            SetPos();
                            set = true;
                        }
                        sl.fill += 3f * Time.deltaTime;
                        targetPos = hit.transform.position;
                        back = true;
                        originalPos = originalObj.transform.position;
                        var step = 2f * Time.deltaTime; // calculate distance to move
                        originalObj.transform.position = Vector3.MoveTowards(originalObj.transform.position, targetPos, step);
                    }
                }

                if (hit.transform.name == "ice" && sl.fill < 1)
                {
                    if (colliderName == "nbag(Clone)")
                    {
                        sl.fill += 0.5f * Time.deltaTime;
                    }
                }
                if (hit.transform.name == "MilkTea" && sl.fill < 1)
                {
                    if (colliderName == "teaBucket" && ci.cTrigger.mTea == true && ci.ck.cookTimer == 100 && ci.cTrigger.bTea == true && ci.ck.isBurn == false && cTrigger.cookBB == false && cTrigger.haveBB == false)
                    {



                        sl.fill += 1.2f * Time.deltaTime;
                        teatype = "milk";
                        bucketPour = true;
                    }
                }
                if (hit.transform.name == "GreenTea" && sl.fill < 1)
                {
                    if (colliderName == "teaBucket" && ci.cTrigger.gTea == true && ci.ck.cookTimer == 100 && ci.cTrigger.mTea != true && ci.ck.isBurn == false && cTrigger.cookBB == false && cTrigger.haveBB == false)
                    {

                        sl.fill += 1.2f * Time.deltaTime;
                        teatype = "green";
                        bucketPour = true;
                    }
                }
                if (hit.transform.name == "BlackTea" && sl.fill < 1)
                {
                    if (colliderName == "teaBucket" && ci.cTrigger.bTea == true && ci.ck.cookTimer == 100 && ci.cTrigger.mTea != true && ci.ck.isBurn == false && cTrigger.cookBB == false && cTrigger.haveBB == false)
                    {

                        sl.fill += 1.2f * Time.deltaTime;
                        teatype = "black";
                        bucketPour = true;
                    }
                }


            }
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            bucketPour = false;
            if (colliderName == "spoon")
            {
                back = false;
            }
            sl.fill = 0;
            if(colliderName == "shaker")
            {
                shakerPour = false;
                pourPlayed = false;
                if(scs.lidBool == true)
                {
                    lidSrc = GameObject.Find("lidsrc").GetComponent<AudioSource>();
                    lidSrc.Play();
                }

            }


        }
        if(colliderName != "shaker")
        {
            shakerPour = false;
        }

        if(Input.GetKeyDown(KeyCode.E) != true)
        {
            if(colliderName == "spoon" && back == false)
            {
                var step = 1f * Time.deltaTime;
                startPos = GameObject.Find("spoon").transform.position;
                originalObj.transform.position = Vector3.MoveTowards(originalObj.transform.position, startPos, step);
            }
        }


        if (Input.GetMouseButtonDown(0))
        {
            scs.finished = true;
            scs.lidBool = false;
            scs.lidCD = false;
            bm.ExitBuildMode();
            RaycastHit hit;
            Ray PickUpray2 = new Ray(PlayerCamera.transform.position, PlayerCamera.transform.forward);
            if (Physics.Raycast(PickUpray2, out hit))
            {

                if (hit.transform.name == "customer")
                {
                    q = hit.transform.gameObject.GetComponent<quener>();
                    if (q.isWaiting == false && q.isQuening == true && q.number == 0)
                    {
                        q.kill();
                        pControl = GameObject.Find("posmachine").GetComponent<posControl>();
                        pControl.GiveOrder();
                        if (tut.step == 1)
                        {
                            tut.step = 2;
                        }

                    }









                    //if (customer.ordered == false)
                    //{
                    //customer.ordered = true;
                    // customer.StartOrder();
                    // if (tut.step == 1)
                    //{
                    //tut.step = 2;
                    //}
                    //}

                }

                if (hit.transform.name == "Laptop")
                {
                    lc.StartLaptop();


                }
                if (hit.transform.name == "cupSpawn")
                {
                    cs.Spawn();



                }
                if (hit.transform.name == "fridgeDoor")
                {
                    if (fs.isOpening == 1)
                    {
                        fs.isOpening = 0;
                        fridgesrc.clip = open;
                        fridgesrc.Play();

                    }
                    else if (fs.isOpening == 0)
                    {
                        fs.isOpening = 1;
                        fridgesrc.clip = close;
                        fridgesrc.Play();
                    }
                }
                if (hit.transform.name == "MilkTea")
                {
                    sf1.Milk();

                }
                if (hit.transform.name == "GreenTea")
                {
                    sf1.Green();

                }
                if (hit.transform.name == "BlackTea")
                {
                    sf1.Black();

                }
            }



        }
    }

    void SetPos() 
    {
        startPos = originalObj.transform.position;





    }






}
