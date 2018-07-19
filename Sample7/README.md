## Train language model using Recurent Neural Networks

* In Azure VM, run the notebook `Predictive Text`
* Download the model and index files `index2word.csv` & `word2index.csv` to bin\debug of VS solution
* Complete the implementation of VS solution in *Prediction* folder


Notes:
* We can use NLTK and its sentence tokenizer instead of plain Python parsing but we will need to pad sequences
* Sometimes simpler approaches like removing all punctuations using python string class are mmore effective
* Dropout is important in RNNs to prevent overfitting