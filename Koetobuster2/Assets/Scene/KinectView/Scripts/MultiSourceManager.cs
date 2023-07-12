using System;
using UnityEngine;
using System.Collections;
using Windows.Kinect;
using Microsoft.Kinect;
using Microsoft.Kinect.Face;

public class MultiSourceManager : MonoBehaviour
{
    private Windows.Kinect.KinectSensor _Sensor;
    private int bodyCount;
    private Body[] bodies;
    private BodyFrameReader bodyReader;
    // private Windows.Kinect.Vector4 FaceRotation;
    private static int frame_count;
    private int framemod;

    public static double yaw, pitch, roll;
    public static double n_yaw, n_pitch, n_roll;
    public static double p_yaw, p_pitch, p_roll;


    public static Vector3[] pos = new Vector3[4];
    public static Vector3[] p_pos = new Vector3[4];
    public static Vector3[] n_pos = new Vector3[4];

    public static int displayId;
    public static int enemyId;
    int p_enemyId = -1;

    int lockOnCount = 0;

    public RectTransform[] rectTransform = new RectTransform[4];

    public UnityEngine.UI.Text debugText;
    public UnityEngine.UI.Text debugText2;
    public UnityEngine.UI.Text debugText3;
    public UnityEngine.UI.Text debugText4;

    private float[,] aimFirstPos = new float[,]{
        {-1920f,  1080f/2},
        {    0f,  1080f/2},
        { 1920f, -1080f/2},
        {    0f, -1080f/2}
    };

    private float[,] aimPos = new float[,]{
        { 1920f * 1/4, -1080f / 2},
        { 1920f * 3/4, -1080f / 2},
        {-1920f * 3/4, -1080f / 2},
        {-1920f * 1/4, -1080f / 2},
        {-1920f * 3/4,  1080f / 2},
        {-1920f * 1/4,  1080f / 2},
        { 1920f * 1/4,  1080f / 2},
        { 1920f * 3/4,  1080f / 2}
    };

    public Windows.Kinect.Vector4 FloorClipPlane
    {
        get;
        private set;
    }

    void Start()
    {
        _Sensor = KinectSensor.GetDefault();
        
        if (_Sensor != null)
        {
            if (!_Sensor.IsOpen)
            {
                _Sensor.Open();
            }
        }   

        bodyCount = _Sensor.BodyFrameSource.BodyCount;
        bodyReader = _Sensor.BodyFrameSource.OpenReader();
        bodies = new Body[bodyCount];

        yaw=0; pitch=0; roll=0;
        p_yaw=0; p_pitch=0; p_roll=0;
        n_yaw=0; n_pitch=0; n_roll=0;
        for(int i=0; i<4; ++i){
            Vector3 tmp = Vector3.zero;
            tmp.x = aimFirstPos[i,0] + aimPos[0,0];
            tmp.y = aimFirstPos[i,1] + aimPos[0,1];
            rectTransform[i].localPosition = tmp;
            n_pos[i] = rectTransform[i].localPosition;
            p_pos[i] = rectTransform[i].localPosition;
        }
        framemod = 5;
        frame_count = 0;
    }

    void Update()
    {
        GetFrame();
        GetDisplay();
        UpdateRotation();  
        LockOn();

        frame_count = (frame_count + 1) % framemod;
    }

    void OnApplicationQuit()
    {
        if (_Sensor != null)
        {
            if (_Sensor.IsOpen)
            {
                _Sensor.Close();
            }

            _Sensor = null;
        }
    }

    void GetFrame(){
        if (bodyReader != null) 
        {
            var frame = bodyReader.AcquireLatestFrame();
            if (frame != null) 
            {
                if (bodies == null) 
                {
                    bodies = new Body[_Sensor.BodyFrameSource.BodyCount];
                }

                frame.GetAndRefreshBodyData(bodies);

                // FloorClipPlaneを取得する
                FloorClipPlane = frame.FloorClipPlane;

                frame.Dispose();
                frame = null;
            }
        }
    }

    void GetDisplay(){
        float p_border = 0.0f;
        float r_border = 0.1f;
        
        if(n_pitch >= p_border && n_roll < r_border){
            displayId = 2;
        }else if(n_pitch < p_border && n_roll < r_border){
            displayId = 3;
        }else if(n_pitch < p_border && n_roll >= r_border){
            displayId = 0;
        }else if(n_pitch > p_border && n_roll > r_border){
            displayId = 1;
        } // ignored (0, 0)
    }

    double Sig(double x, double ss, double tt){
        double s = ss;
        double t = tt;
        // Debug.Log((t-s) / (1.0d + (Math.Exp(-(8*x - 4)))) + s);
        return (t - s) / (1.0d + Math.Exp(-(8*x - 4))) + s;
    }

    float f(float x, float s, float t){
        return (t - s) * x + s;
    }

    void UpdateRotation(){
        if(bodies[0] == null) return;
        Vector3 tmp = Vector3.zero;

        // 床の傾きを取得する
        var floorPlane = FloorClipPlane;
        var comp = Quaternion.FromToRotation( 
        new Vector3( floorPlane.X, floorPlane.Y, floorPlane.Z ), Vector3.up );
                
        if(frame_count % framemod == 0){
            // 関節の回転を取得する
            var joints = bodies[0].JointOrientations;

            Quaternion SpineShoulder =  joints[JointType.SpineShoulder].Orientation.ToQuaternion( comp );

            var x = SpineShoulder.x;
            var y = SpineShoulder.y;
            var z = SpineShoulder.z;
            var w = SpineShoulder.w;

            yaw = n_yaw;
            pitch = n_pitch;
            roll = n_roll;

            p_yaw = n_yaw;
            p_pitch = n_pitch;
            p_roll = n_roll;

            n_yaw = Mathf.Atan2(2 * x * y + 2 * w * z, w * w + x * x - y * y - z * z);
            n_pitch = Mathf.Asin (2 * w * y - 2 * x * z);
            n_roll = Mathf.Atan2 (2 * y * z + 2 * w * x, -w * w + x * x + y * y - z * z);


            pitch = Math.Round(pitch, 3, MidpointRounding.AwayFromZero);
            roll = Math.Round(roll, 3, MidpointRounding.AwayFromZero);

            tmp.x = -4000*(float)pitch;
            tmp.y = -10000*(float)roll + 2000;

            for(int i=0; i<4; ++i){
                pos[i] = tmp;
                pos[i].x += aimFirstPos[i,0];
                pos[i].y += aimFirstPos[i,1];
            }

            for(int i=0; i<4; ++i){
                p_pos[i] = n_pos[i];
                n_pos[i] = pos[i];
                pos[i]   = p_pos[i];
            }
        }else{
            for(int i=0; i<4; ++i){
                pos[i].x = f((float)frame_count / framemod, p_pos[i].x, n_pos[i].x);
                pos[i].y = f((float)frame_count / framemod, p_pos[i].y, n_pos[i].y);
            }
        }        

        for(int i=0; i<4; ++i) rectTransform[i].localPosition = pos[i];
    }

    void LockOn(){
        p_enemyId = enemyId;
        if(displayId == 0){
            if(pos[0].x < -960f) enemyId = 0;
            else enemyId = 1;
        }else if(displayId == 1){
            if(pos[1].x < -960f) enemyId = 2;
            else enemyId = 3;
        }else if(displayId == 2){
            if(pos[2].x < 960f) enemyId = 4;
                else enemyId = 5;
        }else if(displayId == 3){
            if(pos[3].x < 960f) enemyId = 6;
            else enemyId = 7;
        }

        if(p_enemyId == enemyId) lockOnCount += 1;
        else lockOnCount = 1;
    }
}
