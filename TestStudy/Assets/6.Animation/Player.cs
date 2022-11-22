using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Vector3 lookDir;
    public Animator animator;

    [SerializeField]
    private GameObject target;
    [SerializeField]
    private Image HPbar;

    float x;
    float z;
    float speed = 3f;
    float disValue;

    float MaxHP;
    float CurHP;
    static float Damage = 5f;
    public bool isDie;
    // Start is called before the first frame update
    void Start()
    {
        animator.GetComponent<Animator>();
        MaxHP = 10000;
        CurHP = 10000;
        isDie = false;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
        HPbar.fillAmount = CurHP / MaxHP;

        Vector3 dir = new Vector3(x, 0, z) * Time.deltaTime * speed;

        transform.position += dir;

        InputPlayerRotation(x, z);

        if(x == 0 && z == 0)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                if(Random.Range(0,2) == 0)
                {
                    Animation("Attack");
                }
                else
                {
                    Animation("Attack2");
                }
            }
            if(Input.GetKeyDown(KeyCode.G))
            {
                Animation("Defend");
                
            }
            Animation("Idle");
        }
        else
        {
            Animation("Move");
        }

        disValue = Vector3.Distance(transform.position, target.transform.position);

        if(disValue < 2)
        {
            Animation("Hit");
            CurHP -= Damage;
        }

        if(CurHP <= 0)
        {
            isDie = true;
            
            Debug.Log("Game Over!");
            return;
        }
       
    }

    void InputPlayerRotation(float x, float z)
    {
        lookDir = x * Vector3.right + z * Vector3.forward;
        if(lookDir != Vector3.zero)
        {
            Vector3 ro = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
            transform.rotation = Quaternion.LookRotation(Vector3.Slerp(ro, lookDir, Time.deltaTime*0.5f));
        }
    }

    void Animation(string triggerName)
    {
        animator.SetTrigger(triggerName);
    }
}
