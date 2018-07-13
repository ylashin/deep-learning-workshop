import pickle
import os
import pandas
import numpy as np
from sklearn.svm import SVC
from sklearn.model_selection import train_test_split

# create the outputs folder
os.makedirs('./outputs', exist_ok=True)

# load input dataset from a DataPrep package as a pandas DataFrame
inputDf = pandas.read_csv('data.csv')

# load features and labels
X = inputDf[['Attr1', 'Attr2']].values
Y = inputDf['Identity'].values

# split data 70%-30% into training set and test set
X_train, X_test, Y_train, Y_test = train_test_split(X, Y, test_size=0.3, random_state=0)

# train a support vector machine model on the training set
model = SVC()
model.fit(X_train, Y_train) 
print (model)

# evaluate the test set
accuracy = model.score(X_test, Y_test)
print ("Accuracy is {}".format(accuracy))

# serialize the model on disk
print ("Export the model to model.pkl")
f = open('./outputs/model.pkl', 'wb')
pickle.dump(model, f)
f.close()