using UnityEngine;
namespace SedaCinar.AreaFinder.Core
{
    public class MouseInput : MonoBehaviour
    {
        public bool IsPressed
        {
            get { return isPressed; }
        }
        bool isPressed;
        public Vector3 MousePosition
        {
            get { return pos; }
        }
        Vector3 pos;
        #region Unity Methods
        private void Update()
        {
            if(Input.GetMouseButtonDown(0)) 
            {
                isPressed = true;
            }
            if(Input.GetMouseButtonUp(0))
            {
                isPressed = false;
            }
            if(isPressed ) 
            {
                pos = Input.mousePosition;
            }
        }
        #endregion
    }
}