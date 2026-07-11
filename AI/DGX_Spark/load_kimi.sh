export VLLM_CONTAINER=$(docker ps --format '{{.Names}}' | grep -E '^node-[0-9]+$')

docker exec -it $VLLM_CONTAINER /bin/bash -c '
vllm serve moonshotai/Kimi-Dev-72B \
    --host 0.0.0.0 \
    --tensor-parallel-size 2 \
    --kv-cache-dtype fp8 \
    --trust-remote-code \
    --max-model-len 32768 \
    --gpu-memory-utilization 0.90'
