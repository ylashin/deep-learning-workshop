import pickle
import sys
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

# split data 65%-35% into training set and test set
X_train, X_test, Y_train, Y_test = train_test_split(X, Y, test_size=0.35, random_state=0)

# train a logistic regression model on the training set
clf = SVC()
clf.fit(X_train, Y_train) 
print (clf)

# evaluate the test set
accuracy = clf.score(X_test, Y_test)
print ("Accuracy is {}".format(accuracy))

# serialize the model on disk in the special 'outputs' folder
print ("Export the model to model.pkl")
f = open('./outputs/model.pkl', 'wb')
pickle.dump(clf, f)
f.close()