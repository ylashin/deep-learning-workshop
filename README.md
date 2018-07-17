# deep-learning-workshop
Workshop material for getting familiar with deep learning concepts and how to integrate it into applications.


## Prerequisites & Environment Setup

* Some Azure credit in the range of AUD 20 or more for provisioning a VM & Kubernetes cluster.
* NVIDIA GPU, I tested the setup on a GTX 770 just to confirm the easy samples will work on older cards. Heavier models will be trained on Azure VMs.
* [NVIDIA Cuda Toolkit 9.0](https://developer.nvidia.com/cuda-90-download-archive), install base installer but use custom installation and **uncheck everything except Cuda, and under that, uncheck everything except Development and Runtime**. Install all patches as well.
* Download [NVIDIA cuDNN 7.1](https://developer.nvidia.com/cudnn), pick a version matching Cuda Toolkit 9.0 above. Run the first 4 steps of [this installation guide](https://docs.nvidia.com/deeplearning/sdk/cudnn-install/index.html#installwindows). No need for the 5th step about configuring linker in Visual Studio.

    ![cuDNN Download](https://i.imgur.com/yqob1lK.png)

* Visual Studio 2017 (community edition or greater) with Python development workload selected

    ![VS Setup](https://i.imgur.com/J5TOfQl.png)

* Set the default Python environment globally for Visual Studio specially if you have multiple Python installations. Go to menu Tools > Python > Python Environments and select e.g. Python 3.6 (64 bit) and click Make this the default environment for new projects button.

    ![Python default environment](https://i.imgur.com/jXeCgwW.png)

* Add Python install folder to your PATH variable. This folder will probably be located in `C:\Program Files (x86)\Microsoft Visual Studio\Shared\Python36_64`.
* [Visual Studio Tools for AI](https://visualstudio.microsoft.com/downloads/ai-tools-vs/)
* VS Code
* Python extension for VS Code
* Power BI Desktop, just to visualise some CSV data
* [Netron](https://github.com/lutzroeder/Netron) for model visualisation
* Docker for windows with Ubuntu Containers
* Run following to pull one docker image we will need

    ```
    docker pull ylashin/tensorflow-serving
    ```
    
* [Putty](https://www.putty.org/), as sometimes Git Bash does not work fine
* Run the below PowerShell snippet **as administrator** to install needed libraries like Keras and TensorFlow (GPU enabled). Python should be available on system path variable. Some libraries are installed using specific versions as some examples we will try depend on VS tools that need those versions, more specifically ONNX which is a neural network interoperability library.

    ```
    python -m ensurepip
    python -m pip install --upgrade pip    
    python -m pip install tensorflow-gpu==1.5.0
    python -m pip install keras==2.1.6
    python -m pip install pandas
    python -m pip install onnx==1.1.2
    python -m pip install onnxmltools
    python -m pip install jupyter
    python -m pip install matplotlib
    python -m pip install sklearn
    ```

* Confirm Keras & TensorFlow installed successfully by running the below PowerShell snipptet

    ```
    python -c "import tensorflow; print(tensorflow.__version__)"
    python -c "import keras; print(keras.__version__)"
    ```

    ![Verify setup](https://i.imgur.com/pkHxC4X.png)

* Make sure you can create Azure VMs of size **NC24** or **NV24**. Just search for deep learning virtual machine in the templates and proceed with the wizard to create a linux VM. GPU enabled VMs don't exist in all regions. Give it a go in South Central US or East US 2. If you find the above VM sizes but cannot create them due to quota limits, create a support request to increase your quota (basically increase cores count to 24). It will be auto approved for those sizes. BTW, once you create the VM you can delete it or shut it down. We will start with **NC6** which has a single GPU but one sample requires a multi GPU machine that's why we need to make sure we can create one with 4 GPUs.

    ![Azure quota](https://i.imgur.com/SVUh0Ko.png)

* Clone repo `https://github.com/ylashin/deep-learning-workshop`


## Samples roadmap

* Sample 1 : Intro to neural networks with linear regression + Consume using Microsoft.ML.Scoring
* Sample 2 : Handling non linearities + Consume using TensorFlow serving in docker container
* Sample 3 : Convolutional networks and transfer learning + Consume in Azure K8s
* Sample 4 : Cognitive Services Custom Vision API
* Sample 5 : Consume ready made models (ONNX)
* Sample 6 : Embeddings for recommendations
* Sample 7 : RNN for NLP (predictive keyboard)
* Sample 8 : Misc > Faster training via Cyclical Learning Rate Adaptation
* Sample 9 : Misc > Faster training via multi-GPU training
* Sample 10 : Misc > Local traning and cloud inference on Azure ML