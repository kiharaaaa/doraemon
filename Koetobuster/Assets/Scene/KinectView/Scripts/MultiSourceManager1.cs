using System;
using UnityEngine;
using System.Collections;
using Windows.Kinect;
using Microsoft.Kinect;
using Microsoft.Kinect.Face;

public class MultiSourceManager1 : MonoBehaviour
{
    //    public int ColorWidth { get; private set; }
    //    public int ColorHeight { get; private set; }

    //    private KinectSensor _Sensor;
    //    private MultiSourceFrameReader _Reader;
    //    private Texture2D _ColorTexture;
    //    private ushort[] _DepthData;
    //    private byte[] _ColorData;

    //    public Texture2D GetColorTexture()
    //    {
    //        return _ColorTexture;
    //    }

    //    public ushort[] GetDepthData()
    //    {
    //        return _DepthData;
    //    }

    //    void Start ()
    //    {
    //        _Sensor = KinectSensor.GetDefault();

    //        if (_Sensor != null)
    //        {
    //            _Reader = _Sensor.OpenMultiSourceFrameReader(FrameSourceTypes.Color | FrameSourceTypes.Depth);

    //            var colorFrameDesc = _Sensor.ColorFrameSource.CreateFrameDescription(ColorImageFormat.Rgba);
    //            ColorWidth = colorFrameDesc.Width;
    //            ColorHeight = colorFrameDesc.Height;

    //            _ColorTexture = new Texture2D(colorFrameDesc.Width, colorFrameDesc.Height, TextureFormat.RGBA32, false);
    //            _ColorData = new byte[colorFrameDesc.BytesPerPixel * colorFrameDesc.LengthInPixels];

    //            var depthFrameDesc = _Sensor.DepthFrameSource.FrameDescription;
    //            _DepthData = new ushort[depthFrameDesc.LengthInPixels];

    //            if (!_Sensor.IsOpen)
    //            {
    //                _Sensor.Open();
    //            }
    //        }
    //    }

    //    void Update ()
    //    {
    //        if (_Reader != null)
    //        {
    //            var frame = _Reader.AcquireLatestFrame();
    //            if (frame != null)
    //            {
    //                var colorFrame = frame.ColorFrameReference.AcquireFrame();
    //                if (colorFrame != null)
    //                {
    //                    var depthFrame = frame.DepthFrameReference.AcquireFrame();
    //                    if (depthFrame != null)
    //                    {
    //                        colorFrame.CopyConvertedFrameDataToArray(_ColorData, ColorImageFormat.Rgba);
    //                        _ColorTexture.LoadRawTextureData(_ColorData);
    //                        _ColorTexture.Apply();

    //                        depthFrame.CopyFrameDataToArray(_DepthData);

    //                        depthFrame.Dispose();
    //                        depthFrame = null;
    //                    }

    //                    colorFrame.Dispose();
    //                    colorFrame = null;
    //                }

    //                frame = null;
    //            }
    //        }
    //    }

    //    void OnApplicationQuit()
    //    {
    //        if (_Reader != null)
    //        {
    //            _Reader.Dispose();
    //            _Reader = null;
    //        }

    //        if (_Sensor != null)
    //        {
    //            if (_Sensor.IsOpen)
    //            {
    //                _Sensor.Close();
    //            }

    //            _Sensor = null;
    //        }
    //    }


    private Windows.Kinect.KinectSensor _Sensor;
    //private MultiSourceFrameReader _Reader;
    private int bodyCount;
    private Body[] bodies;
    private FaceFrameReader[] faceReaders;
    private FaceFrameSource[] faceSources;
    private BodyFrameReader bodyReader;
    private Windows.Kinect.Vector4 FaceRotation;
    // private FaceFrameReader _Reader;
    // private FaceFrameSource _Source;
    private static int frame_count;
    private int n;
    int tmp;

    public static double yaw, pitch, roll;
    public static double n_yaw, n_pitch, n_roll;
    public static double p_yaw, p_pitch, p_roll;

    RectTransform rectTransform;
    private FaceFrameFeatures DefaultFaceFrameFeatures = FaceFrameFeatures.PointsInColorSpace
                                        | FaceFrameFeatures.Happy
                                        | FaceFrameFeatures.FaceEngagement
                                        | FaceFrameFeatures.Glasses
                                        | FaceFrameFeatures.LeftEyeClosed
                                        | FaceFrameFeatures.RightEyeClosed
                                        | FaceFrameFeatures.MouthOpen
                                        | FaceFrameFeatures.MouthMoved
                                        | FaceFrameFeatures.LookingAway
                                        | FaceFrameFeatures.RotationOrientation;


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

        faceSources = new FaceFrameSource[bodyCount];
        faceReaders = new FaceFrameReader[bodyCount];
        for (int i = 0; i < bodyCount; i++)
        {
            // create the face frame source with the required face frame features and an initial tracking Id of 0
            faceSources[i] = FaceFrameSource.Create(_Sensor, 0, DefaultFaceFrameFeatures);
            // open the corresponding reader
            faceReaders[i] = faceSources[i].OpenReader();

            faceReaders[i].FrameArrived += OnFaceFrameArrived;
        }

        // _Source = FaceFrameSource.Create(_Sensor, 0, DefaultFaceFrameFeatures);
        // _Reader = _Source.OpenReader();
        // _Reader.FrameArrived += OnFaceFrameArrived;

        yaw=0; pitch=0; roll=0;
        p_yaw=0; p_pitch=0; p_roll=0;
        n_yaw=0; n_pitch=0; n_roll=0;
        n = 25;
        frame_count = 0;
        tmp = 0;
        rectTransform = gameObject.GetComponent<RectTransform>();
    }

    void Update()
    {
        if(bodies == null){
            return;
        }

        using (var bodyFrame = bodyReader.AcquireLatestFrame()) {
            if (bodyFrame != null) {
                bodyFrame.GetAndRefreshBodyData (bodies);

                Debug.Log("bodyframearrived");

                for (int i = 0; i < bodyCount; i++)
                {
                    // check if a valid face is tracked in this face source
                    if (faceSources[i].IsTrackingIdValid)
                    {
                        using(FaceFrame frame = faceReaders[i].AcquireLatestFrame())
                        {
                            if(frame != null)
                            {
                                if (frame.TrackingId == 0)
                                {
                                    continue;
                                }

                                // do something with result
                                var result = frame.FaceFrameResult;
                                if(result != null){
                                    var qua = result.FaceRotationQuaternion;
                                    //Debug.Log(qua.X + " " + qua.Y + " " + qua.Z + " " + qua.W);
                                }
                            }
                        }
                    }
                    else
                    {
                        if(bodies[i] == null){
                            continue;
                        }
                        // check if the corresponding body is tracked
                        if (bodies[i].IsTracked)
                        {
                            // update the face frame source to track this body
                            faceSources[i].TrackingId = bodies[i].TrackingId;
                        }
                    }
                }
            }
		}

        // if (_Source.IsTrackingIdValid)
        // {
        //     Debug.Log(1);
        //     using(FaceFrame frame = _Reader.AcquireLatestFrame())
        //     {
        //         if(frame != null)
        //         {

        //             // do something with result
        //             var result = frame.FaceFrameResult;
        //             if(result != null){
        //                 var qua = result.FaceRotationQuaternion;
        //                 Debug.Log(qua.X + " " + qua.Y + " " + qua.Z + " " + qua.W);
        //             }
        //         }
        //     }
        // }
        // else
        // {

        // }

        for(int i=0; i<bodyCount; i++)
        {
            if (faceReaders[i] != null)
            {
                var frame = faceReaders[i].AcquireLatestFrame();
                // var frmae = faceReaders[i].FrameReference.AcquireFrame();

                if (frame != null)
                {
                    //var colorFrame = frame.ColorFrameReference.AcquireFrame();
                    FaceFrameResult result = frame.FaceFrameResult;
                    // double x = result.FaceRotationQuaternion.X;
                    // double y = result.FaceRotationQuaternion.Y;
                    // double z = result.FaceRotationQuaternion.Z;
                    // double w = result.FaceRotationQuaternion.W;
                    // Debug.Log(qua.X + " " + qua.Y + " " + qua.Z + " " + qua.W);
                    // Debug.Log(x + " " + y + " " + z + " " + w);

                    frame = null;
                }
            }
        }
    }

    void OnApplicationQuit()
    {
        if (faceReaders[0] != null)
        {
            faceReaders[0].Dispose();
            faceReaders[0] = null;
        }

        if (_Sensor != null)
        {
            if (_Sensor.IsOpen)
            {
                _Sensor.Close();
            }

            _Sensor = null;
        }
        // if (_Reader != null)
        // {
        //     _Reader.Dispose();
        //     _Reader = null;
        // }

        // if (_Sensor != null)
        // {
        //     if (_Sensor.IsOpen)
        //     {
        //         _Sensor.Close();
        //     }

        //     _Sensor = null;
        // }
    }


    double Sig(double x, double ss, double tt){
        double s = ss;
        double t = tt;
        // Debug.Log((t-s) / (1.0d + (Math.Exp((x - 4)))) + s);
        return (t - s) / (1.0d + Math.Exp(-(x - 4))) + s;
    }

    void UpdateRotation(){
        float X = -600*(float)pitch;
        float Y = -400*(float)roll;
        Vector3 pos = rectTransform.localPosition;

        pos.x = X;
        pos.y = Y;
        rectTransform.localPosition = pos;
    }

    void OnFaceFrameArrived(object sender, FaceFrameArrivedEventArgs e)
    {
        Debug.Log("faceframearrived");
        // Debug.Log(yaw + " " + pitch + " " + roll);
        // Debug.Log(n_yaw + " " + p_yaw);
        tmp++;
        if(frame_count % n == 0)
        {
            using (var faceFrame = e.FrameReference.AcquireFrame())
            {
                if (faceFrame == null) return;
                // 顔情報に関するフレームを取得
                if (!faceFrame.IsTrackingIdValid) return;

                var result = faceFrame.FaceFrameResult;
                if (result == null) return;

                // Debug.Log(tmp);
                // tmp = 0;

                p_yaw = n_yaw;
                p_pitch = n_pitch;
                p_roll = n_roll;

                // 顔の回転に関する結果を取得する
                FaceRotation = result.FaceRotationQuaternion;

                var x = FaceRotation.X;
                var y = FaceRotation.Y;
                var z = FaceRotation.Z;
                var w = FaceRotation.W;
                // if(Input.GetKey(KeyCode.UpArrow)){
                //     Debug.Log("X=" + x + ", Y=" + y + ", Z=" + z + ", W=" + w);
                // }
                yaw = Mathf.Atan2(2 * x * y + 2 * w * z, w * w + x * x - y * y - z * z);
                double tmp_pitch = Mathf.Asin (2 * w * y - 2 * x * z);
                if(tmp_pitch == 0){
                    return;
                }
                n_pitch = tmp_pitch;
                n_roll = Mathf.Atan2 (2 * y * z + 2 * w * x, -w * w + x * x + y * y - z * z);

                if(n_roll < 0) n_roll += Mathf.PI;
                else n_roll -= Mathf.PI;

                // n_yaw = Math.Round(n_yaw, 1, MidpointRounding.AwayFromZero);
                // n_pitch = Math.Round(n_pitch, 1, MidpointRounding.AwayFromZero);
                // n_roll = Math.Round(n_roll, 1, MidpointRounding.AwayFromZero);

                // n_yaw = Math.Round(n_yaw, 3, MidpointRounding.ToEven);
                // n_pitch = Math.Round(n_pitch, 3, MidpointRounding.ToEven);
                // n_roll = Math.Round(n_roll, 3, MidpointRounding.ToEven);

                // n_yaw = (double)((int)(n_yaw * 1000 + 9) / 10) / 100.0d;
                // n_pitch = (double)((int)(n_pitch * 1000 + 9) / 10) / 100.0d;
                // n_roll = (double)((int)(n_roll * 1000 + 9) / 10) / 100.0d;

                
                if(Input.GetKey(KeyCode.DownArrow)){
                    Debug.Log("n_yaw=" + n_yaw + ", n_pitch=" + n_pitch + ", n_roll=" + n_roll);
                    Debug.Log("p_yaw=" + p_yaw + ", p_pitch=" + p_pitch + ", p_roll=" + p_roll);
                }
                // if(Input.GetKey(KeyCode.UpArrow)){
                //     Debug.Log("yaw=" + Y + ", pitch=" + P + ", roll=" + R);
                // }
                yaw = p_yaw;
                pitch = p_pitch;
                roll = p_roll;

                UpdateRotation();
            }
        }else{
            //線形
            // yaw = ((n-frame_count)*p_yaw + frame_count*n_yaw) / (float)n;
            // pitch = ((n-frame_count)*p_pitch + frame_count*n_pitch) / (float)n;
            // roll = ((n-frame_count)*p_roll + frame_count*n_roll) / (float)n;

            //シグモイド
            yaw = Sig(frame_count * 8 / (double)n, p_yaw, n_yaw);
            pitch = Sig(frame_count * 8 / (double)n, p_pitch, n_pitch);
            roll = Sig(frame_count * 8 / (double)n, p_roll, n_roll);

            UpdateRotation();
        }

        frame_count = (frame_count + 1) % n;
    }

    // public static Vector3 GetEuler(){
    //     return new Vector3(yaw, pitch, roll);
    // }

}
