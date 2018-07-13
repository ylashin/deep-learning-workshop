## Multi-GPU Training

We have seen in some samples that training could be a a time consuming operation. Fortunatley many libraries like TensorFlow and Keras support divide and conquer solution to this problem. Training could be split on multiple GPUs for near linear scalabilty. Azure itself provides another option called Azure Batch AI but we will not cover this here.

The notebook for this sample is mainly the same for Transfer Learning one but tweaked a bit to run on 4 GPUs. 

1. You will need to resize/create an Azure deep learning VM with at least 4 GPUs, sometimes certain sizes are better for this purpose.
2. Upgrade Keras to version 2.2.0 : `python -m pip install keras==2.2.0`
3. Run the notebook in this folder and see if you get faster training.

To get the most of this type of training you need to:

1. Use `workers=24, use_multiprocessing=True` in `fit_generator` call. 24 is number of CPUs on the VM I used. This is probably the most important factor to consider. It allows Keras to make use of all CPUs on the VM for many tasks like running the generators and combining GPU results on the CPU(s).
1. Minimise or disable data augmentation in generators. They put too much pressure on CPU and cannot cope with multiple GPUs in parallel.
   In our case generators need initially to do image resizing, so first epoch is normally much slower than subsequent ones.
1. Batch size should be a multiple of GPU count. For example, if you train on a single GPU using batch size 300, on 4 GPUs use batch size of 1200. This is obvious but still worth mentioning.



### Hint from Keras documentation : 

To save the multi-gpu model, use `.save(fname)` or `.save_weights(fname)` with the template model (the argument you passed to `multi_gpu_model`), rather than the model returned by `multi_gpu_model`.

More details on : https://keras.io/utils/
