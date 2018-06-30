
from sklearn.datasets import make_circles
import numpy as np

x,y = make_circles(n_samples=1000, shuffle=True, noise=0.05, factor=0.3)

np.savetxt("x.csv", x, delimiter=",", fmt="%10.5f")
np.savetxt("y.csv", y, delimiter=",", fmt="%d")