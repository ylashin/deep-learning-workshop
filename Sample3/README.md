# Concepts covered

http://nbviewer.jupyter.org/github/fchollet/deep-learning-with-python-notebooks/blob/master/5.3-using-a-pretrained-convnet.ipynb

1. Transfer learning
2. Augmentation
3. Consume from Serving inside K8s


# Steps

* Create DeepLearning VM on azure and connect to it using Putty to verify
* SSH into VM then :
    ```
    cd notebooks
    git clone https://github.com/ylashin/deep-learning-workshop
    ```
* Access Jupyter on port 8000 on the public name of this VM
* Inside deep-learning-workshop/Sample3 folder, run the notebooks in sequence

Transfer learning workflow:
1) Add your custom network on top of an already trained base network.
2) Freeze the base network.
3) Train the part you added.
4) Unfreeze some layers in the base network.
5) Jointly train both these layers and the part you added.


* Download the trained model
* Convert to Serving format
* Publish to K8s
* Consume from a desktop application



python utilities.py dogs-vs-cats-inception-binary-step2.h5 ~/sandbox/dvc/1

sudo docker pull ylashin/tensorflow-serving

sudo docker run -it ylashin/tensorflow-serving


sudo docker cp -a "./dvc" boring_beaver:/


sudo docker commit 5cb4677fb5f4 ylashin/dvc23062018


sudo docker run -p 7000:7000 -it ylashin/dvc23062018

tensorflow_model_server --port=7000 --model_name=dogs-vs-cats --model_base_path=/dvc &> /dogs-vs-cats.log &

cat /dogs-vs-cats.log 



telnet 104.210.213.92 7000


sudo docker push ylashin/dvc23062018




## Publish to Azure K8s

```
az account list --output table
az account set --subscription "Visual Studio Professional with MSDN"

az group create --name Serving --location westus

az aks create --resource-group Serving --name ServingK8sCluster --generate-ssh-keys --node-count 3

az aks get-credentials --resource-group Serving --name ServingK8sCluster

kubectl get nodes


wget https://yousry1.blob.core.windows.net/qld-dev-day/dvc.yaml

kubectl create -f dvc.yaml

kubectl get service dvc-service --watch


telnet 13.75.130.1 7000

az group delete --name Serving --yes --no-wait

```


============================================

# Delete all containers
sudo docker rm $(sudo docker ps -a -q)
# Delete all images
sudo docker rmi $(sudo docker images -q)