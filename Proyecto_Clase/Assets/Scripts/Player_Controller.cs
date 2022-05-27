using UnityEngine;
using System.Collections;
 
public class Player_Controller : MonoBehaviour
{
    
    public float Normal_Speed = 1.0f; // Velocidad de movimiento normal
   
    public float Shift_Speed = 1.5f; // Velocidad de movimiento corriendo
   
    public float Speed_Cap = 54.0f; //Max cap for speed when shift is held down
  
    public float Camera_Sensitivity = 0.6f; // Como es de sensible la cámara al movimiento del ratón
   
    private Vector3 Mouse_Location = new Vector3(255, 255, 255); // Localización del puntero durante el play (Lo ajusta aproximadamente en el centro de la pantalla)

    private float Total_Speed = 1.0f; // Velocidad total cuando se apreta shift

    
    void Update()
    {
        // Ángulos de cámara dependiendo de la posición del ratón
        Mouse_Location = Input.mousePosition - Mouse_Location;
        
        Mouse_Location = new Vector3(-Mouse_Location.y * Camera_Sensitivity, Mouse_Location.x * Camera_Sensitivity, 0);
        
        Mouse_Location = new Vector3(transform.eulerAngles.x + Mouse_Location.x, transform.eulerAngles.y + Mouse_Location.y, 0);
       
        transform.eulerAngles = Mouse_Location;
       
        Mouse_Location = Input.mousePosition;
        
        // Controles de teclado
       
        Vector3 Cam = GetBaseInput();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Total_Speed += Time.deltaTime;
           
            Cam = Cam * Total_Speed * Shift_Speed;
           
            Cam.x = Mathf.Clamp(Cam.x, -Speed_Cap, Speed_Cap);
           
            Cam.y = Mathf.Clamp(Cam.y, -Speed_Cap, Speed_Cap);
           
            Cam.z = Mathf.Clamp(Cam.z, -Speed_Cap, Speed_Cap);
        }
        else
        {
            Total_Speed = Mathf.Clamp(Total_Speed * 0.5f, 1f, 1000f);
           
            Cam = Cam * Normal_Speed;
        }

        Cam = Cam * Time.deltaTime;
        
        Vector3 newPosition = transform.position;
       
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Cam);
            newPosition.x = transform.position.x;
            newPosition.z = transform.position.z;
            transform.position = newPosition;
        }
        else
        {
            transform.Translate(Cam);
        }
    }

    private Vector3 GetBaseInput()
    {
        Vector3 Camera_Velocity = new Vector3();
        
        float HorizontalInput = Input.GetAxis("Horizontal"); // Entrada para el movimiento horizontal 
        
        float VerticalInput = Input.GetAxis("Vertical"); // Entrada para el movimiento vertical
        


        Camera_Velocity += new Vector3(HorizontalInput, 0, 0);

        Camera_Velocity += new Vector3(0, 0, VerticalInput);
       
        return Camera_Velocity;
    }
    
}