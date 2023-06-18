using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;



public class Move : MonoBehaviour
{
    [Header("Kinematic variables")]
    [Tooltip("m/s")]
    [SerializeField] float m_TranslationSpeed;
    [Tooltip("�/s")]
    [SerializeField] float m_RotationSpeed;

    public float speed = 5f;
    Rigidbody2D m_Rb;
    Vector2 dir;
    


    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Rigidbody2D>() != null)
        {
            m_Rb = GetComponent<Rigidbody2D>();
        }
       

    }

    // Update is called once per frame
    void Update()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");

        m_Rb.MovePosition(m_Rb.position + dir * speed * Time.fixedDeltaTime);
   
        
    }

  
}
