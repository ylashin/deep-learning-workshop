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
model.add(keras.layers.Dense(10, input_shape=(2,)))
model.add(keras.layers.Dense(5))
model.add(keras.layers.Dense(1, activation="sigmoid"))
 """

# Non linear activation
model = keras.models.Sequential()
model.add(keras.layers.Dense(10, input_shape=(2,), activation="relu"))
model.add(keras.layers.Dense(5, activation="relu"))
model.add(keras.layers.Dropout(0.2))
model.add(keras.layers.Dense(1, activation="sigmoid"))


model.summary()

model.compile(
    loss=keras.losses.binary_crossentropy, 
    optimizer=keras.optimizers.Adam(), 
    metrics=[keras.metrics.binary_accuracy])

model.fit(X, Y, epochs=100, batch_size=100, verbose=1, validation_split=0.1)
    
model.save("Sample2.h5")


 # python .\utilities.py "D:\B2B\July-2018\Ex2-BasicClassification\ex2.hdf5" "D:\B2B\July-2018\Ex2-BasicClassification\serving"