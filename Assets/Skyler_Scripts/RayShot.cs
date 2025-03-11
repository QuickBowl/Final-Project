using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShot : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public int power = 5;

    [SerializeField] GameObject BulletPrefab;
    private GameObject Bullet;
    private Camera cam;


    void Start()
    {
        cam = GetComponent<Camera>();

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3 (cam.pixelWidth/2, cam.pixelHeight/2, 0);
            Ray ray = cam.ScreenPointToRay (point);
            RaycastHit shot;
            

            if(Physics.Raycast(ray, out shot))
            {
                //StartCoroutine(fireShot(shot.point));
                GameObject hitConfirm = shot.transform.gameObject;
                EnemyAI target = hitConfirm.GetComponent<EnemyAI>();

                if (target != null)
                {
                    target.TakeDamage(power);
                }
                else
                {
                    Debug.Log("Target Missed!");
                }
            }
        }
    }

    //private IEnumerator fireShot(Vector3 los)
    //{
        //if(Bullet == null)
        //{
            //Bullet = Instantiate(BulletPrefab) as GameObject;
            //Bullet.transform.position = transform.TransformPoint(Vector3.forward * bulletSpeed);
        //}

        //yield return new WaitForSeconds(1);

        //Destroy(Bullet);
    //}
}
