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
    [SerializeField] private AudioClip raySound;


    void Start()
    {
        cam = GetComponent<Camera>();

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }
    private void OnGUI() {
        int size = 36;
        float posX = cam.pixelWidth / 2 - size / 4;
        float posY = cam.pixelHeight / 2 - size / 2;

        GUI.Label(new Rect(posX, posY, size, size), "+");
    }



    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3 (cam.pixelWidth/2, cam.pixelHeight/2, 0);
            Ray ray = cam.ScreenPointToRay (point);
            RaycastHit shot;
            AudioSource.PlayClipAtPoint(raySound, transform.position);


            if (Physics.Raycast(ray, out shot))
            {
                //StartCoroutine(fireShot(shot.point));
                GameObject hitConfirm = shot.transform.gameObject;
                EnemyAI target = hitConfirm.GetComponent<EnemyAI>();
                TurretScript_1 turret = hitConfirm.GetComponent<TurretScript_1>();

                if (target != null)
                {
                    target.TakeDamage(power);
                }
                else if (turret != null) {
                    turret.TakeDamage(power);
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
