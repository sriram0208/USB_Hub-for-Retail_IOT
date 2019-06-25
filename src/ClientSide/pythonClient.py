import requests


def getAllScannedBarcodes():
	for item in data:
		print(item)

def getLastNbarcodes():
	records_to_display=int(input("Enter number of recent records to get:"))
	for index in range((total_records - records_to_display),total_records):
		print(data[index])

URL="http://192.168.225.188/jsonBarcode.php"

r = requests.get(url = URL) 
  
# extracting data in json format 
data = r.json()
total_records=len(data)

choice=input("Choose an option :\n 1->getAllScannedBarcodes \n 2->getLastNbarcodes\n 0->Exit\n")
while choice!='0':
	if choice=='1':
		getAllScannedBarcodes()
	elif choice=='2':
		getLastNbarcodes()
	else:
		print("Enter valid input\n")
	choice=input("Choose an option :\n 1->getAllScannedBarcodes \n 2->getLastNbarcodes\n")


# for item in data:
# 	print(item)
# print(data)