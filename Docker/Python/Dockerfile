FROM python:3.10.0-slim

RUN apt-get update -qq && apt-get install -y postgresql-client

WORKDIR /workspace

COPY requirements.txt ./
RUN pip install --no-cache-dir -r requirements.txt
