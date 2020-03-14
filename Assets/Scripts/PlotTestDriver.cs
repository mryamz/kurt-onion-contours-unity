using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotTestDriver : MonoBehaviour
{

    public GameObject point_data;

    void Start()
    {
        float step_size = 0.1f;
        point_data.transform.localScale = new Vector3(step_size, step_size, step_size);


        OnionContourPlot plot1 = new OnionContourPlot(new Vector3(0, 0, 0), 1, step_size);
        plot1.addContour(0, 0, 1);
        plot1.addContour(1, .5f, 1.2f);
        plot1.addContour(2, 1, 1.4f);
        plot(plot1, point_data);

        step_size = 0.03f;
        OnionContourPlot plot2 = new OnionContourPlot(new Vector3(0, 0, 0), 1, step_size);
        plot2.addContour(-1, 2, 1.4f);
        plot2.addContour(-2, 1, 1.8f);
        plot2.addContour(-3, 0, 2.2f);

        plot(plot2, point_data);



    }

    public static void plot(OnionContourPlot plot, GameObject point_data)
    {
        for (int i = 0; i < plot.contours.Count; i++)
        {
            for (int j = 0; j < plot.contours[i].Count; j++)
            {
                Instantiate(point_data, plot.contours[i][j], Quaternion.identity);
            }
        }
    }
}
