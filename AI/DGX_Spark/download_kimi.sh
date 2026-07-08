export VLLM_CONTAINER=$(docker ps --format '{{.Names}}' | grep -E '^node-[0-9]+$')

docker exec -it $VLLM_CONTAINER /bin/bash -c '
  hf auth login
  hf download moonshotai/Kimi-Dev-72B'

