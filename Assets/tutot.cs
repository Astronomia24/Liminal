using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tutot : MonoBehaviour
{
    public GameObject textBox;
    public Text tutext;
    public Text objText;
    public int num;
    DrinkID drinkCS;
    public AudioSource src;
    public AudioClip sfx1;
    public AudioClip sfx2;
    public AudioClip sfx3;
    public AudioClip sfx4;
    public AudioClip sfx5;
    public AudioClip sfx6;
    public AudioClip sfx7;
    public AudioClip sfx8;
    public AudioClip sfx9;
    public AudioClip sfx10;

    // Start is called before the first frame update
    void Start()
    {
        drinkCS = FindObjectOfType<DrinkID>();
        textBox.SetActive(true);
        tutext.text = "�w��Ө�A����...��˳����[����";
        objText.text = "�i�J�z���p�}��";
        StartCoroutine(Mission1());
        num = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Start2()
    {
        StartCoroutine(Mission2());
        num = 1;
    }
    public void Start3()
    {
        StartCoroutine(Mission3());
        num = 2;
    }
    public void Start4()
    {
        StartCoroutine(Mission4());
        num = 3;
    }
    public void Start5()
    {
        StartCoroutine(Mission5());
        num = 4;
    }
    public void Start6()
    {
        StartCoroutine(Mission6());
        num = 5;
    }
    public void Start7()
    {
        StartCoroutine(Mission7());
        num = 6;
    }
    public void Start8()
    {
        StartCoroutine(Mission8());
        num = 7;
    }
    public void Start9()
    {
        StartCoroutine(Mission9());
        num = 9;
    }
    IEnumerator Mission1()
    {
        src.clip = sfx1;
        src.Play();
        tutext.text = "�w��Ө�A����...�o�a��˳����[����";
        objText.text = "�i�J�z���p�}��";
        yield return new WaitForSeconds(3);
        tutext.text = "�Ӷi�h�ݬݳo���a���ܦ��ƻ�ˤl";

    }

    IEnumerator Mission2()
    {
        src.clip = sfx2;
        src.Play();
        tutext.text = "�a�A�o�̯�o�n�R";
        objText.text = "�⨺�U�����h��A�Ω��챼�ú{";
        yield return new WaitForSeconds(4);
        tutext.text = "����U����@��a, �a�O���ú{�]�M�@�M";

    }
    IEnumerator Mission3()
    {
        src.clip = sfx3;
        src.Play();
        tutext.text = "����, �t���h�i�H�Ӱ����ƤF";
        objText.text = "�b���J�M���[�J�A�q���B��";
        yield return new WaitForSeconds(4);
        tutext.text = "�����Ӥ֦B�a�A�A�i��ݭn�ݤ@�U��W���B�q��";

    }
    IEnumerator Mission4()
    {
        src.clip = sfx4;
        src.Play();
        tutext.text = "�Ӱ��M��������?";
        objText.text = "�b���J�M���[�J300ml������";
        yield return new WaitForSeconds(3);
        tutext.text = "�@�w�n�˺��A���M�O�H�|���ڭ̰��u���";

    }
    IEnumerator Mission5()
    {
        src.clip = sfx5;
        src.Play();
        tutext.text = "������ӥ��[�}����n�A���@�ӥb�}�ո�";
        objText.text = "�δ��ͱq�q�M���X�G�}";
        yield return new WaitForSeconds(3);
        tutext.text = "�����ڭ̽a��a�_�A�N�N�Τ@�U�G�}�a";
        yield return new WaitForSeconds(7);
        src.clip = sfx6;
        src.Play();
        tutext.text = "���ݥ��q�A�A�O���O�˭ˤF";
        yield return new WaitForSeconds(4);
        tutext.text = "�A�i�H�ή��䪺���q�A�q�@��";

    }
    IEnumerator Mission6()
    {
        src.clip = sfx7;
        src.Play();
        tutext.text = "���L�n�ӴX�U�A���Ƥ~�|�n��";
        objText.text = "�W�U�n�̶���";
        yield return new WaitForSeconds(4);
        tutext.text = "���n�ݷn�M���b���A�S�����تF��";

    }
    IEnumerator Mission7()
    {
        src.clip = sfx8;
        src.Play();
        tutext.text = "�˶i�콦�M�N�i�H�ʽ��F";
        objText.text = "�˶i�콦�M�ëʽ�";
        yield return new WaitForSeconds(4);
        tutext.text = "�o�x�������ӬO�㶡���̶Q���F��F";

    }
    IEnumerator Mission8()
    {
        src.clip = sfx9;
        src.Play();
        tutext.text = "�ܦn�A�u�O�ӧ����F";
        objText.text = "�N���ƥ�i�U����";
        yield return new WaitForSeconds(4);
        tutext.text = "�{�b��쵧�q���䪺�p�U����̭�";
        yield return new WaitForSeconds(4);
        tutext.text = "�]���ڥ��S���H�I�o�M����";
        yield return new WaitForSeconds(4);
        tutext.text = "�ӵ۳氵�ƫD�`���n�A�p�G�����A�N��M��i�h�a";
        yield return new WaitForSeconds(4);
        tutext.text = "�n�F�A���O�F���ǭ�ơA�ӨӸɳf�F";
        yield return new WaitForSeconds(4);
        tutext.text = "�O�o�H�ɫO���s�f�R��";
        objText.text = "�ɥR�ʥ����f";
        num = 8;
        drinkCS.bTeaLeft = 0;
        drinkCS.gTeaLeft = 0;
        drinkCS.mTeaLeft = 0;


    }
    IEnumerator Mission9()
    {
        src.clip = sfx10;
        src.Play();
        tutext.text = "�n�F�A���ӨS�F�a";
        objText.text = "���ѦA��";
        yield return new WaitForSeconds(4);
        tutext.text = "�A�i�H�u�F";
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("SampleScene");

    }
}
