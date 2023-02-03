using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;


public class FloatingJoystick : MonoBehaviour
{
    [SerializeField]
    private Vector2 JoystickSize = new Vector2(300, 300);
    [SerializeField]
    RectTransform RectTransform;
    [SerializeField] RectTransform Knob;

    private Finger MovementFinger;
    private Vector2 MovementAmount;

    Vector2 startPos;
    private void Awake()
    {
        RectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        startPos = RectTransform.position;
        EnhancedTouchSupport.Enable();
        ETouch.Touch.onFingerDown += HandleFingerDown;
        ETouch.Touch.onFingerUp += HandleLoseFinger;
        ETouch.Touch.onFingerMove += HandleFingerMove;
    }

    private void OnDisable()
    {
        ETouch.Touch.onFingerDown -= HandleFingerDown;
        ETouch.Touch.onFingerUp -= HandleLoseFinger;
        ETouch.Touch.onFingerMove -= HandleFingerMove;
        EnhancedTouchSupport.Disable();
    }

    private void HandleFingerMove(Finger MovedFinger)
    {
        if (MovedFinger == MovementFinger)
        {
            Vector2 knobPosition;
            float maxMovement = JoystickSize.x / 2f;
            ETouch.Touch currentTouch = MovedFinger.currentTouch;

            if (Vector2.Distance(
                    currentTouch.screenPosition,
                    RectTransform.anchoredPosition
                ) > maxMovement)
            {
                knobPosition = (
                    currentTouch.screenPosition - RectTransform.anchoredPosition
                    ).normalized
                    * maxMovement;
            }
            else
            {
                knobPosition = currentTouch.screenPosition - RectTransform.anchoredPosition;
            }

            Knob.anchoredPosition = knobPosition;
            MovementAmount = knobPosition / maxMovement;
        }
    }

    private void HandleLoseFinger(Finger LostFinger)
    {
        if (LostFinger == MovementFinger)
        {
            MovementFinger = null;
            Knob.anchoredPosition = Vector2.zero;
            //gameObject.SetActive(false);
            //ETouch.Touch.onFingerDown -= HandleFingerDown;
            //ETouch.Touch.onFingerUp -= HandleLoseFinger;
            //ETouch.Touch.onFingerMove -= HandleFingerMove;
            //EnhancedTouchSupport.Disable();
            MovementAmount = Vector2.zero;
            RectTransform.position = startPos;
        }
    }

    private void HandleFingerDown(Finger TouchedFinger)
    {
        if (MovementFinger == null && TouchedFinger.screenPosition.x <= Screen.width / 2f)
        {
            MovementFinger = TouchedFinger;
            MovementAmount = Vector2.zero;
            gameObject.SetActive(true);
            RectTransform.sizeDelta = JoystickSize;
            RectTransform.anchoredPosition = ClampStartPosition(TouchedFinger.screenPosition);
        }
    }

    private Vector2 ClampStartPosition(Vector2 StartPosition)
    {
        if (StartPosition.x < JoystickSize.x / 2)
        {
            StartPosition.x = JoystickSize.x / 2;
        }

        if (StartPosition.y < JoystickSize.y / 2)
        {
            StartPosition.y = JoystickSize.y / 2;
        }
        else if (StartPosition.y > Screen.height - JoystickSize.y / 2)
        {
            StartPosition.y = Screen.height - JoystickSize.y / 2;
        }

        return StartPosition;
    }


    private void OnGUI()
    {
        GUIStyle labelStyle = new GUIStyle()
        {
            fontSize = 24,
            normal = new GUIStyleState()
            {
                textColor = Color.white
            }
        };
        if (MovementFinger != null)
        {
            GUI.Label(new Rect(10, 35, 500, 20), $"Finger Start Position: {MovementFinger.currentTouch.startScreenPosition}", labelStyle);
            GUI.Label(new Rect(10, 65, 500, 20), $"Finger Current Position: {MovementFinger.currentTouch.screenPosition}", labelStyle);
        }
        else
        {
            GUI.Label(new Rect(10, 35, 500, 20), "No Current Movement Touch", labelStyle);
        }

        GUI.Label(new Rect(10, 10, 500, 20), $"Screen Size ({Screen.width}, {Screen.height})", labelStyle);
    }



    //Touch touch;
    //RectTransform rectTransform;

    //Vector2 startPos;

    //private void Awake()
    //{
    //    rectTransform = GetComponent<RectTransform>();
    //}

    //private void Start()
    //{
    //    startPos = rectTransform.position;
    //}

    //private void Update()
    //{
    //    SetJoystickPosition();
    //}

    //void SetJoystickPosition()
    //{
    //    if(Input.touchCount > 0)
    //    {
    //        touch = Input.GetTouch(0);

    //        if(touch.phase == TouchPhase.Began)
    //        {
    //            rectTransform.position = touch.position;
    //        }
    //        else if(touch.phase == TouchPhase.Ended)
    //        {
    //            rectTransform.position = startPos;
    //        }

    //    }
    //}

}
