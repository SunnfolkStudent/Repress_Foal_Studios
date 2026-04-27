using UnityEngine;
using System.Collections;
public class PatrolMovement : MonoBehaviour
{
         public Transform waypointParent;
    
        public float moveSpeed = 2f;
        public float waitTime = 2f;
        public bool loopWaypoint = true;
        private Transform[] waypoints;
        private int currentWaypointIndex;
        private bool isWaiting;
        private Animator _animator;
        public Vector3 moveDirection;
    
        void Start()
        {
            
            _animator =  gameObject.GetComponent<Animator>();
            waypoints = new  Transform[waypointParent.childCount];
    
            for (int i = 0; i < waypointParent.childCount; i++)
            {
                waypoints[i] = waypointParent.GetChild(i);
            }
        }
    
        void Update()
        {
            if (!isWaiting && !GameController.instance.failStateTriggered) MoveToWaypoint();
            
            
            _animator.SetBool("isIdle", isWaiting);
        }
    
        private void MoveToWaypoint()
        {
            
            Transform target = waypoints[currentWaypointIndex];
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, target.position) < 0.1f)
            {
                StartCoroutine(WaitAtWaypoint());
            }
            moveDirection = (target.position - transform.position).normalized; 
            
            //set walk animations
            _animator.SetFloat("velocityX", moveDirection.x);
            _animator.SetFloat("velocityY", moveDirection.y);
            
            
            //
            
           
        
        }
    
        IEnumerator WaitAtWaypoint()
        {
            
            
            isWaiting = true;
            yield return new WaitForSeconds(waitTime);
            currentWaypointIndex = loopWaypoint
                ? (currentWaypointIndex + 1) % waypoints.Length
                : Mathf.Min(currentWaypointIndex + 1, waypoints.Length - 1);
            isWaiting = false;
        }
        
}
