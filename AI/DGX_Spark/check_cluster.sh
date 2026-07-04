# On Node 1 (head node)
# Find the vLLM container name (it will be node-<random_number>)
export VLLM_CONTAINER=$(docker ps --format '{{.Names}}' | grep -E '^node-[0-9]+$')
echo "Found container: $VLLM_CONTAINER"

docker exec $VLLM_CONTAINER ray status

