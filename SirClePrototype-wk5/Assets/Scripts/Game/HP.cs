using UnityEngine;
using System.Collections;

public class HP : MonoBehaviour {
    [SerializeField]
    private int health;

	// Use this for initialization
	void Start () {
	 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void HPMinus(int dmg)
    {
        health -= dmg;
    }
    public void HPSet(int newHP)
    {
        health = newHP;
    }
    public int GetHP()
    {
        return health;
    }
}
