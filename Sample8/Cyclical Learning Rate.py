import keras
import pandas as pd
import numpy as np
import clr_callback as clr

# To get comparable results, use same random seed used in Sample1
np.random.seed(12345)

dataframe = pd.read_csv('data.csv')

print(dataframe.head())

X = dataframe[['Age','NumChildern']].values
Y = dataframe[['Income']].values

model = keras.models.Sequential()
model.add(keras.layers.Dense(1, input_shape=(2,)))
model.summary()

model.compile(
    loss=keras.losses.mean_squared_error, 
    optimizer=keras.optimizers.Adam(), 
    metrics=[keras.metrics.mean_absolute_error])

clr = clr.CyclicLR(base_lr=0.001, max_lr=0.009, step_size=40)

model.fit(X, Y, epochs=100, batch_size=10, verbose=1, validation_split=0.2, callbacks=[clr])