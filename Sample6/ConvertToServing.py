import argparse
from keras import backend as K
from keras.models import load_model
from tensorflow.python.saved_model import builder as saved_model_builder
from tensorflow.python.saved_model import tag_constants, signature_constants
from tensorflow.python.saved_model.signature_def_utils_impl import build_signature_def, predict_signature_def
import shutil
import os
import numpy as np
import tensorflow as tf

def convertToServingFormat(saveModelPath, exportPath):
	K.set_learning_phase(0)
	model = load_model(saveModelPath)
	print("=" * 50)
	print("Model input:" + str(model.input))
	print("Model output:" + str(model.output))

	builder = saved_model_builder.SavedModelBuilder(exportPath)
	signature = predict_signature_def(inputs={"userId": model.input[0], "movieId": model.input[1]}, outputs={"outputs": model.output})

	with K.get_session() as sess:
		builder.add_meta_graph_and_variables(sess=sess,tags=[tag_constants.SERVING],signature_def_map={'Predict': signature})
		builder.save()

	

	print("Model has been successfully converted to TensorFlow Serving format")

if __name__ == "__main__":

	parser = argparse.ArgumentParser()
	parser.add_argument("-m", "--model",  required=True,
		help="Input model in HDF5 format")
	parser.add_argument("-o", "--output", required=True,
		help="Path to output TensorFlow Serving files")
	
	args = parser.parse_args()
	convertToServingFormat(args.model, args.output)