# Consume using TensorFlow Serving


## Export trained model to TensorFlow Serving format

Run the below from Sample2 working folder:

```
mkdir tf-serving
python.exe ..\Tools\ConvertToServing.py  --model=.\Sample2.h5 --output=tf-serving\1
```

## Pull docker image containing Tensorflow Serving setup and configured

For more details on how to create this image from scratch, have a look on : [Using TensorFlow Serving via Docker](https://www.tensorflow.org/serving/docker)

Run the below to pull TensorFlow Serving image and confirm it runs fine:
```
docker pull ylashin/tensorflow-serving
docker run -p 7000:7000 -it ylashin/tensorflow-serving
tensorflow_model_server
```

## Run trained model using TensorFlow Serving
In another PowerShell window run the following to copy TensorFlow serving files inside the container:

```
cd [Sample2 Folder Path]
docker ps
docker cp -a "./tf-serving" [YOUR-CONTAINER-ALIAS]:/
```

Switch to the running docker container and run TensorFlow serving application:

```
tensorflow_model_server --port=7000 --model_name=Sample2 --model_base_path=/tf-serving &> /Sample2.log &
cat /Sample2.log 
```

We can verify serving is running fine by : `telnet localhost 7000`

## Complete the draft application to consume the running model and do predictions

Open `TheApp.sln` from **Prediction** folder inside Sample2

Install nuget packages:
* Google.Protobuf
* Grpc
* Grpc.Tools
* NewtonSoft.Json


Open a Powershell from `packages\Grpc.Tools.1.12.0\tools\windows_x64` and run the following:

```
wget https://raw.githubusercontent.com/krystianity/keras-serving/master/node_server/protos/model.proto -OutFile .\model.proto
wget https://raw.githubusercontent.com/krystianity/keras-serving/master/node_server/protos/prediction_service.proto -OutFile .\prediction_service.proto
wget https://raw.githubusercontent.com/krystianity/keras-serving/master/node_server/protos/predict.proto -OutFile .\predict.proto
wget https://raw.githubusercontent.com/krystianity/keras-serving/master/node_server/protos/resource_handle.proto -OutFile .\resource_handle.proto
wget https://raw.githubusercontent.com/krystianity/keras-serving/master/node_server/protos/types.proto -OutFile .\types.proto
wget https://raw.githubusercontent.com/krystianity/keras-serving/master/node_server/protos/tensor.proto -OutFile .\tensor.proto
wget https://raw.githubusercontent.com/krystianity/keras-serving/master/node_server/protos/tensor_shape.proto -OutFile .\tensor_shape.proto

mkdir Temp

.\protoc.exe "types.proto" "tensor.proto" "tensor_shape.proto" "prediction_service.proto" `
    "predict.proto" "model.proto" "resource_handle.proto"   `
    --csharp_out ".\Temp" --grpc_out ".\Temp" --plugin=protoc-gen-grpc=.\grpc_csharp_plugin.exe

```


Copy all the `.cs` files generated in Temp folder from the final statement in the above snippet and put them in a new folder in `TheApp` project (you can name the new folder something like `contracts`).

Compile and complete the application, mainly adding prediction button handler code:

```
var model = new ServingModel();
var kiwiProbability = model.PredictIdentity(float.Parse(txtAttribute1.Text), float.Parse(txtAttribute2.Text));
lblKiwiPropability.Text = $"Kiwi : {kiwiProbability.ToString("p")}";
lblAussiePropability.Text = $"Aussie : {(1- kiwiProbability).ToString("p")}";
```