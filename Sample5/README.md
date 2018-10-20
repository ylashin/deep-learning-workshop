# Object detection using ONNX & YOLO

In this sample, we will see how to consume a ready made model provided in ONNX format.
It could be developed using another deep learning library, but using ONNX it can be consumed easily.
That's a promising initiative for promoting deep learning model interoperability.

## Steps

* Download YOLO model https://www.cntk.ai/OnnxModels/tiny_yolov2/opset_1/tiny_yolov2.tar.gz
* Complete the VS solution by adding a model inference library using the above ONNX model and then complete the prediction part


## Pitfalls
* Flattened response data parsing
* Index swap done by trial and error
* x & y of predicted bounding box are for the center not top left

## References and resources

* [https://medium.com/@jonathan_hui/real-time-object-detection-with-yolo-yolov2-28b1b93e2088] (Realtime Object Detection with YOLO, YOLOv2 and now YOLOv3)
* [Object detection video on SkyFall](https://www.youtube.com/watch?v=VOC3huqHrss)
* [YOLO v3 video](https://www.youtube.com/watch?v=MPU2HistivI)
* [YOLO on ONNX model zoo](https://github.com/onnx/models/tree/master/tiny_yolov2)
* [Object detection using YOLO ](http://machinethink.net/blog/object-detection-with-yolo/)
* [Sample source code for using result](https://github.com/hollance/Forge/blob/master/Examples/YOLO/YOLO/YOLO.swift)
* YOLO network architecture
    ![YOLO network architecture](https://i.imgur.com/cg7JyBK.png)


