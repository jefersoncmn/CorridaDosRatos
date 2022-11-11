using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    public float movementSpeed = 1;
    public float movementTime = 10;

    public Vector3 newPosition;
    public Camera mainCamera;

    //Zoom
	float touchesPrevPosDifference, touchesCurPosDifference, zoomModifier;
	Vector2 firstTouchPrevPos, secondTouchPrevPos;
	float zoomModifierSpeed = 0.005f;

    private void Awake() {
        mainCamera = this.gameObject.transform.GetComponentInChildren<Camera>();
    }

    void Start()
    {
        newPosition = transform.position;
    }

    void Update() {
        HandleMovementInputWiyhTouch();
        HandleZoomInputWiyhTouch();
    }
    //Move
    void  HandleMovementInputWiyhTouch(){
        if(Input.touchCount == 1){
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved){
                newPosition -= (transform.forward * (touch.deltaPosition.y/300) * movementSpeed);
                newPosition -= (transform.right * (touch.deltaPosition.x/300) * movementSpeed);  
            }
        }
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
    }
    
    //Zoom
    void HandleZoomInputWiyhTouch(){
        if(Input.touchCount == 2){
            Touch touch = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);
            
            if(touch.phase == TouchPhase.Moved){
                Touch firstTouch = Input.GetTouch (0);
                Touch secondTouch = Input.GetTouch (1);

                firstTouchPrevPos = firstTouch.position - firstTouch.deltaPosition;
                secondTouchPrevPos = secondTouch.position - secondTouch.deltaPosition;

                touchesPrevPosDifference = (firstTouchPrevPos - secondTouchPrevPos).magnitude;
                touchesCurPosDifference = (firstTouch.position - secondTouch.position).magnitude;

                zoomModifier = (firstTouch.deltaPosition - secondTouch.deltaPosition).magnitude * zoomModifierSpeed;

                if (touchesPrevPosDifference > touchesCurPosDifference && mainCamera.orthographicSize < 7){
                    mainCamera.orthographicSize += zoomModifier;
                }
                if (touchesPrevPosDifference < touchesCurPosDifference && mainCamera.orthographicSize > 2){
                    mainCamera.orthographicSize -= zoomModifier;
                }
            }
        }
    }

    void HandleMovementInputWiyhKeys(){
        
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
            newPosition += (transform.forward * movementSpeed);
        }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
            newPosition += (transform.forward * -movementSpeed);
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            newPosition += (transform.forward * movementSpeed);
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            newPosition += (transform.forward * -movementSpeed);
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
    }
}
