## Azure cognitive services

* Have a look on SharePoint Online image contents search
* Register account at : https://customvision.ai
* Create a model and configure it for export to devices **General (compact)**
* Upload and label training data
* Train your model and test using the browser
* Download trained model in a docker container and try it using Postman or any similar tool
* Docker notes:
    1. Tensorflow is not supported on Python 3.7, so use FROM python:3.6
    1. Docker file exposes port 80, maybe use a different port as 80 might be used on host
