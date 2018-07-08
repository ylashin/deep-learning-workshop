from keras.layers import Dense, Activation, Dropout
from keras.layers.recurrent import LSTM
from keras.models import Sequential 
import numpy as np

inputFile = open("the_agile_samurai.txt", 'rb')
lines = []
for line in inputFile:
    line = line.strip().lower()
    line = line.decode("utf8", "ignore")
    if len(line) == 0:
        continue
    lines.append(line)
inputFile.close()
text = " ".join(lines)

chars = set([c for c in text])
nb_chars = len(chars)
char2index = dict((c, i) for i, c in enumerate(chars))
index2char = dict((i, c) for i, c in enumerate(chars))


SEQLEN = 30
STEP = 1
input_chars = []
label_chars = []
for i in range(0, len(text) - SEQLEN, STEP):
    input_chars.append(text[i:i + SEQLEN])
    label_chars.append(text[i + SEQLEN])

print(input_chars[0])
print(label_chars[0])


X = np.zeros((len(input_chars), SEQLEN, nb_chars), dtype=np.bool)
y = np.zeros((len(input_chars), nb_chars), dtype=np.bool)
for i, input_char in enumerate(input_chars):
    for j, ch in enumerate(input_char):
        X[i, j, char2index[ch]] = 1
    y[i, char2index[label_chars[i]]] = 1


HIDDEN_SIZE = 128
BATCH_SIZE = 256
ITERATIONS = 2
EPOCHS_PER_ITERATION = 1
PREDS_PER_EPOCH = 20

model = Sequential()
model.add(LSTM(HIDDEN_SIZE, return_sequences=False, input_shape=(SEQLEN, nb_chars), unroll=True))
model.add(Dropout(0.2))
model.add(Dense(nb_chars, activation="softmax"))
model.compile(loss="categorical_crossentropy", optimizer="adam", metrics=["accuracy"])

"""
model.add(GRU(seq_length, return_sequences=True)) # was 100
model.add(GRU(seq_length))                        # was 100
model.add(Dense(100, activation='relu'))
model.add(Dense(vocab_size, activation='softmax'))
"""

for iteration in range(ITERATIONS):
    print("=" * 50)
    print("Iteration #: %d" % (iteration))
    model.fit(X, y, batch_size=BATCH_SIZE, epochs=EPOCHS_PER_ITERATION)
    
    test_idx = np.random.randint(len(input_chars))
    test_chars = input_chars[test_idx]
    print("Generating from seed: %s" % (test_chars))
    print(test_chars, end="")
    for i in range(PREDS_PER_EPOCH):
        Xtest = np.zeros((1, SEQLEN, nb_chars))
        for i, ch in enumerate(test_chars):
            Xtest[0, i, char2index[ch]] = 1
        pred = model.predict(Xtest, verbose=0)[0]        
        ypred = index2char[np.argmax(pred)]
        print(ypred, end="")
        # move forward with test_chars + ypred
        test_chars = test_chars[1:] + ypred
print()