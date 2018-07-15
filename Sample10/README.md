# Train models on premises and deploy for inference on Azure ML

This sample is not strictly a deep learning thing but a general approach that could be applied to many ML problems.
Sometimes clients are not fine with taking their critical/confidential data to be used for training in the cloud or so.
A potential solution to this issue is to do the training (classical ML or even deep learning, etc) on premises or in a client-approved secure environment and then take the trained model to be exposed using Azure ML or a docker container somewhere.


Our problem here is to train a plain old ML model for Sample 2 problem (Aussie vs Kiwi thing) locally and then consume that model from Azure ML.

## Steps:

* Run `TrainLocalModel.py` while will emit a Support Vector Machine model trained using sklearn package
* Register an Azure ML workspace, just head to http://studio.azureml.net
* Upload `azure_input.csv` in *Sample10* folder as new dataset.
* Open `outputs` folder which should contain trained model `model.pkl`, zip this file and upload it as well as a new dataset.
* Create a new experiment, give it a name and drag the two datasets uploaded above from saved datasets menu option to the left.
* Drag execute Python script module, connect it as below screenshot.
    ![Experiment](https://i.imgur.com/Tije8K0.png)
* Change Python module version to latest and replace its source code with the below

    ```
    import pandas as pd
    import sys
    import pickle

    def azureml_main(dataframe1 = None, dataframe2 = None):
        sys.path.insert(0,".\Script Bundle")
        model = pickle.load(open(".\Script Bundle\model.pkl", 'rb'))
        pred = model.predict(dataframe1)
        return pd.DataFrame([pred[0]])
    ```
* Save and run the experiment, this is mainly to let Azure know the schema of input and output. No training is happening here.
* Click `Setup web experiment`
* Change web service module output to draw from the leftmost output of Python module above. You will need to drop and connection first.
* Run the predictive experiment
* Click `Deploy to web service`
* Consume and hav fun!



## Reference:

[Deploying externally generated Python/R Models as Web Services using Azure Machine Learning Studio](https://blogs.technet.microsoft.com/uktechnet/2018/04/25/deploying-externally-generated-pythonr-models-as-web-services-using-azure-machine-learning-studio/)