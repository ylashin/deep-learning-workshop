# Transfer Learning

## Steps

* Create DeepLearning VM on azure and connect to it using Putty to verify
* SSH into VM then :
    ```
    cd notebooks
    git clone https://github.com/ylashin/deep-learning-workshop
    ```
* Access Jupyter on port 8000 on the public name of this VM
* Inside deep-learning-workshop/Sample3 folder, run the notebooks in sequence
* Some notes on final notebook of transfer learning:
    Transfer learning workflow:
    1) Add your custom network on top of an already trained base network.
    2) Freeze the base network.
    3) Train the part you added.
    4) Unfreeze some layers in the base network.
    5) Jointly train both these layers and the part you added.
* Download the trained model to Sample3 folder
* Convert to Serving format

    ```
    mkdir tf-serving\dvc
    python.exe ..\Tools\ConvertToServing.py  --model=.\dogs-vs-cats-transfer-learning.h5 --output=tf-serving\dvc\1
    ```
* Run Tensorflow Serving container (the container shell initially opens in folder /tensorflow-serving, this is just my mistake when I published the image but it does not matter really for our purpose)
    ```
    docker pull ylashin/tensorflow-serving
    docker run -p 7000:7000 -it ylashin/tensorflow-serving
    ```
* In another window, copy the converted model inside the container
    ```
    docker ps
    docker cp -a ".\tf-serving\dvc" CONTAINER_NAME:/
    docker commit CONTAINER_ID ylashin/dvc17072018
    ```
* In the container window, run Tensorflow model server and verify connectivity on port 7000 as we have done in Sample 2
    ```
    tensorflow_model_server --port=7000 --model_name=dogs-vs-cats --model_base_path=/dvc &> /dogs-vs-cats.log &
    cat /dogs-vs-cats.log 
    ```

    ```
    telnet 104.210.213.92 7000
    ```

* Shutdown and publish container to docker hub
    ```
    exit
    docker push ylashin/dvc17072018
    ```

* Update `dvc.yaml` to contain latest container name that is pushed to docker registery. 

    YAML file in below snippet does not neccessarily work for everyone.
    - If you have Azure Shell locally, you can edit the file locally and don't need to download it from github
    - If you use Azure Shell from the portal, you can edit the file using nano or something or edit locally and upload it to some cloud storage and then adjust the snippet below

* Publish to K8s, the below should be run in Azure Shell

    ```
    az account list --output table

    az account set --subscription "Visual Studio Professional with MSDN"

    az group create --name Serving --location westus

    az aks create --resource-group Serving --name ServingK8sCluster --generate-ssh-keys --node-count 3

    az aks get-credentials --resource-group Serving --name ServingK8sCluster

    kubectl get nodes

    wget https://raw.githubusercontent.com/ylashin/deep-learning-workshop/master/Sample3/dvc.yaml

    kubectl create -f dvc.yaml

    kubectl get service dvc-service --watch    

    ```
* Verify K8s cluster is up and running and acceissible externally (replace the IP with the IP that appeared from last command above)

    ```
    telnet 13.75.130.1 7000
    
    ```

* Consume from a desktop application and point to the K8s cluster IP
* Clean up
    ```
    az group delete --name Serving --yes --no-wait
    ```

## Cleanup, at end of workshop :)

* Delete all containers `docker rm $(docker ps -a -q)`
* Delete all images `docker rmi $(docker images -q)`