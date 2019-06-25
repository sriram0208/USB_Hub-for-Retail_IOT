import json
from json2xml import json2xml, readfromurl, readfromstring, readfromjson
import xmltodict



fh=open("mouse_log.txt","r")
json_data={}
json_data["mouseActions"]=[]
while True:     
    line=fh.readline()
    if ("" == line):
        print("file finished")
        break;
    lis=line.split(" ",2)
    json_data["mouseActions"].append({
                        'date':lis[0],
                        'time':lis[1],
                        'action':lis[2]
                    })            
json_str=json.dumps(json_data)
print (json_str)
f = open("jsonfile.json",'w+')
f.write(json_str)
data = readfromstring(json_str)
fe = open("Xmlfile.xml",'w+')
data1 = json2xml.Json2xml(data, wrapper="custom", indent=8).to_xml()
fe.write(data1)
