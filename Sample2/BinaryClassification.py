import keras
import pandas as pd

dataframe = pd.read_csv('data.csv')

print(dataframe.head())

X = dataframe[['Attr1','Attr2']].values
Y = dataframe[['Identity']].values

print(Y[0:5])

Y = [0 if v == 'Aussie' else 1 for v in Y]
print(Y[0:5])

# Very simple model
""" model = keras.models.Sequential()
model.add(keras.layers.Dense(1, input_shape=(2,), activation="sigmoid")) """


# More layers
""" model = keras.models.Sequential()
model.add(keras.layers.Dense(4, input_shape=(2,)))
model.add(keras.layers.Dense(16))
model.add(keras.layers.Dense(1, activation="sigmoid"))
 """

# Non linear activation
model = keras.models.Sequential()
model.add(keras.layers.Dense(4, input_shape=(2,), activation="relu"))
model.add(keras.layers.Dense(16, activation="relu"))
model.add(keras.layers.Dropout(0.2))
model.add(keras.layers.Dense(1, activation="sigmoid"))

model.summary()

model.compile(
    loss=keras.losses.binary_crossentropy, 
    optimizer=keras.optimizers.Adam(), 
    metrics=[keras.metrics.binary_accuracy])

model.fit(X, Y, epochs=100, batch_size=100, verbose=1, validation_split=0.2)
    
model.save("Sample2.h5")