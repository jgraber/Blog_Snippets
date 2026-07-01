export VLLM_IMAGE=nvcr.io/nvidia/vllm:26.06-py3

# On other Nodes, join as workers

# Set the interface name (same as Node 1)
export MN_IF_NAME=enp1s0f1np1

# Get Node's own IP address
export VLLM_HOST_IP=$(ip -4 addr show $MN_IF_NAME | grep -oP '(?<=inet\s)\d+(\.\d+){3}')

# IMPORTANT: Set HEAD_NODE_IP to Node 1's IP address
# You must get this value from Node 1 (run: echo $VLLM_HOST_IP on Node 1)
export HEAD_NODE_IP=192.168.60.12

echo "Worker IP: $VLLM_HOST_IP, connecting to head node at: $HEAD_NODE_IP"

bash run_cluster.sh $VLLM_IMAGE $HEAD_NODE_IP --worker ~/.cache/huggingface \
  -e VLLM_HOST_IP=$VLLM_HOST_IP \
  -e UCX_NET_DEVICES=$MN_IF_NAME \
  -e NCCL_SOCKET_IFNAME=$MN_IF_NAME \
  -e OMPI_MCA_btl_tcp_if_include=$MN_IF_NAME \
  -e GLOO_SOCKET_IFNAME=$MN_IF_NAME \
  -e TP_SOCKET_IFNAME=$MN_IF_NAME \
  -e RAY_memory_monitor_refresh_ms=0 \
  -e MASTER_ADDR=$HEAD_NODE_IP \
  -e HF_TOKEN="$HF_TOKEN"


