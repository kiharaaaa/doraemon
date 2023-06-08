//using UnityEngine;
//using System.Collections;
//using Windows.Kinect;
//using Microsoft.Kinect;
//using Microsoft.Kinect.Face;

//public class FaceRotationManager: MonoBehaviour
//{

//    private KinectSensor _Sensor;
//    private MultiSourceFrameReader _Reader;
//    private FaceFrameReader faceReader;
//    private FaceFrameSource faceSource;
//    private Windows.Kinect.Vector4 FaceRotation;

//    private FaceFrameFeatures DefaultFaceFrameFeatures = FaceFrameFeatures.PointsInColorSpace
//                                        | FaceFrameFeatures.Happy
//                                        | FaceFrameFeatures.FaceEngagement
//                                        | FaceFrameFeatures.Glasses
//                                        | FaceFrameFeatures.LeftEyeClosed
//                                        | FaceFrameFeatures.RightEyeClosed
//                                        | FaceFrameFeatures.MouthOpen
//                                        | FaceFrameFeatures.MouthMoved
//                                        | FaceFrameFeatures.LookingAway
//                                        | FaceFrameFeatures.RotationOrientation;


//    void Start()
//    {
//        _Sensor = KinectSensor.GetDefault();

//        if (_Sensor != null)
//        {
//            _Reader = _Sensor.OpenMultiSourceFrameReader(FrameSourceTypes.Body);

//            //faceSource = FaceFrameSource;
//            faceReader = faceSource.OpenReader();

//            faceReader.FrameArrived += OnFaceFrameArrived;


//            if (!_Sensor.IsOpen)
//            {
//                _Sensor.Open();
//            }
//        }
//    }

//    void Update()
//    {
//        //if (_Reader != null)
//        //{
//        //    var frame = _Reader.AcquireLatestFrame();
//        //    if (frame != null)
//        //    {
//        //        var colorFrame = frame.ColorFrameReference.AcquireFrame();
//        //        if (colorFrame != null)
//        //        {
//        //            var depthFrame = frame.DepthFrameReference.AcquireFrame();
//        //            if (depthFrame != null)
//        //            {
//        //                colorFrame.CopyConvertedFrameDataToArray(_ColorData, ColorImageFormat.Rgba);
//        //                _ColorTexture.LoadRawTextureData(_ColorData);
//        //                _ColorTexture.Apply();

//        //                depthFrame.CopyFrameDataToArray(_DepthData);

//        //                depthFrame.Dispose();
//        //                depthFrame = null;
//        //            }

//        //            colorFrame.Dispose();
//        //            colorFrame = null;
//        //        }

//        //        frame = null;
//        //    }
//        //}
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

//    void OnFaceFrameArrived(object sender, FaceFrameArrivedEventArgs e)
//    {
//        using (var faceFrame = e.FrameReference.AcquireFrame())
//        {
//            if (faceFrame == null) return;

//            // äÁèÓïÒÇ…ä÷Ç∑ÇÈÉtÉåÅ[ÉÄÇéÊìæ
//            if (!faceFrame.IsTrackingIdValid)
//                return;

//            var result = faceFrame.FaceFrameResult;
//            if (result == null) return;

//            // äÁÇÃâÒì]Ç…ä÷Ç∑ÇÈåãâ ÇéÊìæÇ∑ÇÈ
//            FaceRotation = result.FaceRotationQuaternion;

//            Debug.Log("X=" + FaceRotation.X + "Y=" + FaceRotation.Y + "Z=" + FaceRotation.Z + "W=" + FaceRotation.W);
//        }
//    }

//}
