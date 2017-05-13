using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KontrolerKamery : MonoBehaviour {

    [Header("Poruszanie kamerą")]
    public float predkoscKamery = 45;
    public float predkoscRotacjiKamery = 80;
    public float predkoscPrzyblizenia = 700;
    public float dystans = 3;

    [Header("Ograniczenia kamery")]
    public float marginesPrawy = 22;
    public float marginesLewy = -50;
    public float marginesPrzedni = 10;
    public float marginesTylni = -50;

    [Header("Camera info")]
    public Vector3 pozycjaKamery;

    public Transform zobaczymy;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ///Wszystkie inpyty do sterowania kamerą
        float horyzontalnie = Input.GetAxis("Horizontal") * predkoscKamery * Time.deltaTime;
        float wertykalnie = Input.GetAxis("Vertical") * predkoscKamery * Time.deltaTime;
        float przyblizenie = Input.GetAxis("Mouse ScrollWheel") * predkoscPrzyblizenia * Time.deltaTime;
        float rotacja = Input.GetAxis("Rotation");


      

        /// Poruszanie sie z ograniczeniem Lewo/Prawo (od respa do bazy)
        if (horyzontalnie > 0 && transform.position.x < marginesPrawy  )
        {
            transform.Translate(Vector3.right * horyzontalnie);
        }
        if (horyzontalnie < 0 && transform.position.x > marginesLewy)
        {
            transform.Translate(Vector3.right * horyzontalnie);
        }

        /// Poruszanie się z ograniczeniem Przód/Tył (od krawędzi do krawędzi)
        if (wertykalnie > 0 && transform.position.z < marginesPrzedni)
        {
            transform.Translate(Vector3.forward * wertykalnie);
        }
        if (wertykalnie < 0 && transform.position.z > marginesTylni)
        {
            transform.Translate(Vector3.forward * wertykalnie);
        }
        /// Zoom z ograniczeniem 
        if (przyblizenie > 0 && zobaczymy.transform.position.y > 5)
        {
           zobaczymy.transform.Translate(Vector3.up * -(przyblizenie));
        }
        if (przyblizenie < 0 && zobaczymy.transform.position.y < 24)
        {
            zobaczymy.transform.Translate(Vector3.up * -(przyblizenie));
        }

        pozycjaKamery = transform.position;

        ///// Rotacja
        //if (rotacja != 0)
        //{
        //    zobaczymy.transform.Rotate(Vector3.up, rotacja * predkoscRotacjiKamery * Time.deltaTime, Space.Self);
        //}

    }
}
