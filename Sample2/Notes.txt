## Binary classification

* Have a look on data file first [`data.csv`]
* Build simple one neuron network. Sample code in `BinaryClassification.py`
* Improve using multiple layers and then non linear activations
    ```
    # More layers    
    model = keras.models.Sequential()
    model.add(keras.layers.Dense(4, input_shape=(2,)))
    model.add(keras.layers.Dense(16))
    model.add(keras.layers.Dense(1, activation="sigmoid"))


    # Non linear activation
    model = keras.models.Sequential()
    model.add(keras.layers.Dense(4, input_shape=(2,), activation="relu"))
    model.add(keras.layers.Dense(16, activation="relu"))
    model.add(keras.layers.Dropout(0.2))
    model.add(keras.layers.Dense(1, activation="sigmoid"))

    ```