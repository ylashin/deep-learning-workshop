# Speed up training using cyclical learning rate


A few techniques have been implemented to speed up training and improve conversion to better soltutions.

Examples:

* [Cyclical learning rate](https://github.com/bckenstler/CLR)
* SGD with restarts
* Cosine Annealing
* [Ensembles](https://arxiv.org/abs/1704.00109)


We will try cyclical learning rate in this sample against same problem in Sample 1. The idea is to increase learning rate while training in a certain manner and then bring it back to its base value. One reason this approach may work well is because increasing the learning rate is an effective way of escaping saddle points. By cycling the learning rate, we're guaranteeing that such an increase will take place if we end up in a saddle point.

In mathematics, a saddle point or minimax point is a point on the surface of the graph of a function where the slopes (derivatives) in orthogonal directions are both zero (a critical point), but which is not a local extremum of the function.

![Saddle Point](https://upload.wikimedia.org/wikipedia/commons/thumb/1/1e/Saddle_point.svg/600px-Saddle_point.svg.png)



