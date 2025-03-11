using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_Temp : MonoBehaviour
{
    private bool isAlive;
    // Start is called before the first frame update

    

    void Start()
    {
        isAlive = true;
    }

    public void TakeDamage(int damage)
    {
        if (damage > 3)
        {
        isAlive = false;

        StartCoroutine(Death());
        }
    }

    public IEnumerator Death()
    {
        yield return new WaitForSeconds(1);

        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
