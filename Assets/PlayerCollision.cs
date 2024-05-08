using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour{
    private Animator anim;
    private Rigidbody2D rb;

public PlayerHearts ph;
     void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        ph = GetComponent<PlayerHearts>();
    }
    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");

    } 
           
        
       
        
    

   private void OnCollisionEnter2D (Collision2D collision){
        Debug.Log("it triggered");
        if (collision.gameObject.CompareTag("death")){
           ph.health--;


           if(ph.health <=0)  {
                        Die(); 
  
            }
            
            else{
                StartCoroutine(GetHurt());
            }

           }
        
   }
   
    IEnumerator GetHurt(){
        Physics2D.IgnoreLayerCollision(7,8);
        GetComponent<Animator>().SetLayerWeight(1, 1);
        yield return new WaitForSeconds(3);
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(7,8, false);
    }
}