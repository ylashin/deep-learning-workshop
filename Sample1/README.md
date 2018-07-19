## Steps

* Explore data
* Run *LinearRegression.py* to generate model for linear regression
* Preview the network using Netron
* Export model to TensorFlow Serving format

    ```
    python.exe ..\Tools\ConvertToServing.py  --model=.\Sample1.h5 --output=tf-serving
    ```

* Complete the VS solution in **Prediction** folder using VS Tools for AI inference library template