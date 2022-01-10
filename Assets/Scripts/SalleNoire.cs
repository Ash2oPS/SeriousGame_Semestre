using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalleNoire : MonoBehaviour
{
    public GameManager gm;
    public Room thisRoomName;
    public Material materialDeLaSalleAAssombrir;
    public WallMovement wallMovementRefPourReference;
    private Vector4 vector4DeLaCouleurNoire = new Vector4(30, 30, 30, 255);
    private Vector4 vector4DeLaCouleurBlanche = new Vector4(255, 255, 255, 255);
    public bool estEnTrainDeSAssombrir = false;
    public bool estSombre = false;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        wallMovementRefPourReference = GetComponent<WallMovement>();

        BonneCouleur();
    }

    private void Update()
    {
        if (estEnTrainDeSAssombrir)
        {
            AssombrissementDeLaSalle();
        }
    }

    public void BonneCouleur()
    {
        Color couleurNoire = vector4DeLaCouleurNoire / 255;
        Color couleurBlanche = vector4DeLaCouleurBlanche / 255;

        if (gm.currentRoom == thisRoomName)
        {
            estSombre = false;
            materialDeLaSalleAAssombrir.color = couleurBlanche;
        }
        else
        {
            estSombre = true;
            materialDeLaSalleAAssombrir.color = couleurNoire;
        }
    }

    public void BoolAssombrissementDeSalle()
    {
        estEnTrainDeSAssombrir = true;
    }

    public void AssombrissementDeLaSalle()
    {
        Color couleurNoire = vector4DeLaCouleurNoire / 255;
        Color couleurBlanche = vector4DeLaCouleurBlanche / 255;
        float t = wallMovementRefPourReference.lerp_value;

        if (!estSombre)
        {
            materialDeLaSalleAAssombrir.color = Color.Lerp(couleurBlanche, couleurNoire, t);
        }
        else
        {
            materialDeLaSalleAAssombrir.color = Color.Lerp(couleurNoire, couleurBlanche, t);
        }

        if (t >= 1)
        {
            t = 1;
            estEnTrainDeSAssombrir = false;
            if (!estSombre)
            {
                estSombre = true;
            }
            else
            {
                estSombre = false;
            }
        }
    }
}