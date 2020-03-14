using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnionContourPlot
{

    public List<List<Vector3>> contours = new List<List<Vector3>>();

    private float radius;
    private float step;

    /**
     * @params
     * 
     * radius: represents size of plane that is to be plotted.
     * 
     * step: is used to change resolution of plot
     * 
     */
    public OnionContourPlot(float radius, float step)
    {
        this.radius = radius;
        this.step = step;
    }

    /**
     * 
     * @params 
     * 
     * c: represents the contour value
     * 
     * vertical_offset: represents layer spacing
     * 
     * radial_scaler: changes the plane-size at each layer
     * 
     * 
     */
    public void addContour(float c, float vertical_offset, float radial_scaler)
    {

        List<Vector3> layer = new List<Vector3>();

        float radius = this.radius * radial_scaler;

        for(float x = -radius; x < radius; x += step)
        {
            for(float y = -radius; y < radius; y += step)
            {
                if (Mathf.Sqrt((x * x) + (y * y)) < radius)
                {

                    // solve for z in z^2 = contour + x^2 + y^2
                    float z = c + (x * x) + (y * y);

                    // ensure we don't create an imaginary number
                    if(z > 0)
                    {
                        float answer = Mathf.Sqrt(z);

                        answer += vertical_offset;

                        // answer is plus or minus sqrt of z
                        layer.Add(new Vector3(x, answer, y));
                        layer.Add(new Vector3(x, -answer, y));

                        // switch z and y axis for unity.
                        // in math z is up, in unity y is up
                    }

                }


            }
        }

        contours.Add(layer);
    }
}
