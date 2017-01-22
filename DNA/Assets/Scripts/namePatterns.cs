using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class namePatterns : MonoBehaviour {

    public char[] vowels = { 'a', 'e', 'i',
                            'o', 'u','y'};
    public char[] consonants = 
        {'b','c','d',
        'f','g','h',
        'j','k','l',
        'm','n','p',
        'r','s','t',
        'v','w','x',
        'z' };

    [Range (0,10)]
    public int newNameLengthchoice=0;
    public int prevNameLength = 0;

    public string name="";
    public Text text;
	// Use this for initialization
	void Start () {
      /*  newNameLengthchoice = 10;
        for (int i = 0; i < 100; i++)
        { 
            changeName();
            name = "";
        }
        newNameLengthchoice = 0;*/
    }

    // Update is called once per frame
    void Update() {

        if (prevNameLength != newNameLengthchoice)
        {
            prevNameLength = newNameLengthchoice;
            changeName();
            text.text = name;
        }

    }
    void changeName()
    {
       
        int rnd = Random.Range(0, 25);
        if (name.Length > newNameLengthchoice) name = "";

        // while (name.Length < newNameLengthchoice)
        // {
        if (name == "")
        {
            if (rnd % 5 == 0) name += vowels[Random.Range(0, 6)];
            else name += consonants[Random.Range(0, 19)];
        }
        if (name.Length == 1)
            {
                bool vowel = false;
                for (int i = 0; i < 6; i++)
                    if (name[0] == vowels[i]) vowel = true;
                if (vowel) name += consonants[Random.Range(0, 19)];
                else name += vowels[Random.Range(0, 6)];

            }
        
        for (int i = name.Length; i < newNameLengthchoice; i++)
            {
               
            if (rnd % 5 == 0)
                { if (vowelCheck(name[i - 1]))
                    {
                        if (vowelCheck(name[i - 2]))
                        {
                            name += (rnd % 5 == 0) ? vowels[Random.Range(0, 6)] : consonants[Random.Range(0, 19)];
                        }
                        else name += vowels[Random.Range(0, 6)];
                    }
                    else name += vowels[Random.Range(0, 6)];
                }
            else
            {
                if (consCheck(name[i - 1]))
                {
                    rnd = Random.Range(0, 25);
                    name += (rnd % 5 != 0) ? vowels[Random.Range(0, 6)] : consonants[Random.Range(0, 19)];
                }
                else name += consonants[Random.Range(0, 19)];
            }
            rnd = Random.Range(0, 25);
            }
        //Debug.Log(name);
        // }
    }

    bool vowelCheck(char x)
    {    for (int i = 0; i < vowels.Length; i++)
            if (x == vowels[i]) return true;

        return false;

    }
    bool consCheck(char x)
    {
        for (int i = 0; i < consonants.Length; i++)
            if (x == consonants[i]) return true;

        return false;

    }
}
