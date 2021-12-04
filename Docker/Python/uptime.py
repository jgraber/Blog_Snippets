from time import sleep
import requests

url = "https://jgraber.ch"

while True:
	response = requests.head(url)
	print(f"{url}: Status is {response.status_code}")
	sleep(5)
