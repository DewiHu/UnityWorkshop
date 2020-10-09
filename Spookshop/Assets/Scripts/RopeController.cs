using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour
{

    public Transform ropeBaseConnection;
    public Transform hangingFromRope;

    private LineRenderer lineRenderer;

    public List<Vector3> ropeSections = new List<Vector3>();

    public float ropeLength = 1f;
    public float loadMass = 1f;

    public float density = 7750f;
    public float radius = 0.02f;

    public float ropeWidth = .1f;

    public float springModifier = 2f;
    public float damperModifier = 1f;

    SpringJoint springJoint;

    // Start is called before the first frame update
    void Start()
    {
        springJoint = ropeBaseConnection.GetComponent<SpringJoint>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = true;

        UpdateSpring();

        hangingFromRope.GetComponent<Rigidbody>().mass = loadMass;
    }

    // Update is called once per frame
    void Update()
    {
        DisplayRope();
    }

    private void UpdateSpring()
    {
        float volume = Mathf.PI * radius * radius * ropeLength;
        float ropeMass = volume * density;
        ropeMass += loadMass;
        float ropeForce = ropeMass * 9.81f;
        float kRope = ropeForce / 0.01f;
        springJoint.spring = kRope * springModifier;
        springJoint.damper = kRope * damperModifier;
        springJoint.minDistance = ropeLength;
        springJoint.maxDistance = ropeLength;
    }

    private void DisplayRope()
    {
        lineRenderer.startWidth = ropeWidth;
        lineRenderer.endWidth = ropeWidth;

        Vector3 a = ropeBaseConnection.position;
        Vector3 d = hangingFromRope.position;

        Vector3 b = a + ropeBaseConnection.up * ((a - d).magnitude * .1f);
        Vector3 c = d + hangingFromRope.forward * (-(a - d).magnitude * .5f);

        BezierCurve.GetBezierCurve(a, b, c, d, ropeSections);

        Vector3[] positions = new Vector3[ropeSections.Count];
        for (int i=0; i < ropeSections.Count; i++)
        {
            positions[i] = ropeSections[i];
        }

        lineRenderer.positionCount = positions.Length;
        lineRenderer.SetPositions(positions);
    }

    private class BezierCurve
    {
        public static void GetBezierCurve(Vector3 a, Vector3 b, Vector3 c, Vector3 d, List<Vector3> ropeSections)
        {
            float resolution = .1f;
            ropeSections.Clear();

            float t = 0;
            while (t <= 1f)
            {
                Vector3 newPos = DeCasteljausAlgorithm(a, b, c, d, t);

                ropeSections.Add(newPos);

                t += resolution;
            }

            ropeSections.Add(d);
        }

        private static Vector3 DeCasteljausAlgorithm(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
        {
            float oneMinusT = 1f - t;
            Vector3 q = oneMinusT * a + t * b;
            Vector3 r = oneMinusT * b + t * c;
            Vector3 s = oneMinusT * c + t * d;

            Vector3 p = oneMinusT * q + t * r;
            Vector3 T = oneMinusT * r + t * s;

            return oneMinusT * p + t * T;
        }
    }
}

