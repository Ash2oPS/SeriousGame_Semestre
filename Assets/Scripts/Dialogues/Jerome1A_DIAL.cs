using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jerome1A_DIAL : MonoBehaviour
{
    public string[] repliques;

    public void Awake()
    {
        repliques[0] = "[J]Bonjour, je suis Jer�me le pigeon.";
        repliques[1] = "[P]Bonjour Jer�me, je suis l'inspecteur en chef de la Brigade des Sardines Ensoleill�es.\nJe suis ici pour enqu�ter sur le vol de la tapisserie.";
        repliques[2] = "[J]ROOOU ! Ca par exemple, oui ! J'ai bien entendu parler de cette affaire ! \nJe me demande bien quel emplum� a pu faire une chose pareille...";
        repliques[3] = "[P]OBJECTION !!";
        repliques[4] = "[J]mdrrr";
    }
}
