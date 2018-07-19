# Movies Recommender

## Steps:

* Run the notebook in this folder locally or in Azure deep learning VM
* Download the below files
    1. Sample6.h5           to Sample6
    1. movieid2index.csv    to Sample6\Prediction\MovieLensRecommender\data\movie-lens
    1. userid2index.csv     to Sample6\Prediction\MovieLensRecommender\data\movie-lens
    1. movies.csv           to Sample6\Prediction\MovieLensRecommender\data\movie-lens
    1. ml-m1\ratings.dat    to Sample6\Prediction\MovieLensRecommender\data\movie-lens
* Convert model to Serving format
    ```
    python .\ConvertToServing.py --model=.\Sample6.h5 --output=tf-serving\recommender\1
    ```
* Follow the same steps as in dogs vs cats to host this model in a docker container
* Consume it from the solution in Prediction folder