﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotTestDriver : MonoBehaviour
{

    public GameObject point_data;

    void Start()
    {

        float step_size = 0.1f;
        OnionContourPlot plot = new OnionContourPlot(1, step_size);
        point_data.transform.localScale = new Vector3(step_size, step_size, step_size);

        plot.addContour(0, 0, 1);
        plot.addContour(1, .5f, 1.2f);
        plot.addContour(2, 1, 1.4f);



        for (int i = 0; i < plot.contours.Count; i++)
        {
            for(int j = 0; j < plot.contours[i].Count; j++)
            {
                Instantiate(point_data, plot.contours[i][j], Quaternion.identity);
            }
        }


    }
}
