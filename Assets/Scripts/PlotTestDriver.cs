using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotTestDriver : MonoBehaviour
{

    public GameObject point_data;

    void Start()
    {

        OnionContourPlot plot = new OnionContourPlot(10, 1, 5);

        plot.addContour(0, 0, 1);
        plot.addContour(1, 3, 1.2f);
        plot.addContour(2, 6, 1.4f);



        for (int i = 0; i < plot.contours.Count; i++)
        {
            for(int j = 0; j < plot.contours[i].Count; j++)
            {
                Instantiate(point_data, plot.contours[i][j], Quaternion.identity);
            }
        }


    }
}
