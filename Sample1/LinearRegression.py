import keras
import pandas as pd

dataframe = pd.read_csv('data.csv')

print(dataframe.head())

X = dataframe[['Age','NumChildern']].values
Y = dataframe[['Income']].values


print (X.shape)
print (Y.shape)

model = keras.models.Sequential()
model.add(keras.layers.Dense(1, input_shape=(2,)))
model.summary()

model.compile(loss=keras.losses.mean_squared_error, optimizer=keras.optimizers.Adam(lr=0.5) , metrics=[keras.metrics.mean_absolute_error])
model.fit(X, Y, epochs=100, batch_size=10, verbose=1, validation_split=0.2)

    
model.save("Sample1.h5")