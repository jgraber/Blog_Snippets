curl http://192.168.1.94:8000/v1/completions \
  -H "Content-Type: application/json" \
  -d '{
    "model": "moonshotai/Kimi-Dev-72B",
    "prompt": "What is the capital city of Norway?",
    "max_tokens": 320,
    "temperature": 0.7
  }'

