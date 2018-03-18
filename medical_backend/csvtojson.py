#!/usr/bin/python

import sys, getopt
import csv
import json
import pandas as pd
import numpy as np


#Get Command Line Arguments
#format on CLI: python csv-json.py -i users.csv -o users.json -f dump
def main(argv):
    #don't forget to change path
    sample1 = '/Users/RachelDedinsky/Desktop/senior/capstone 1/project/SPElderCare/medical_backend/log.csv'
    sample2 = '/Users/RachelDedinsky/Desktop/senior/capstone 1/project/SPElderCare/medical_backend/log1.csv'
    input_file = '/Users/RachelDedinsky/Desktop/senior/capstone 1/project/SPElderCare/medical_backend/log2.csv'
    output_file = '/Users/RachelDedinsky/Desktop/senior/capstone 1/project/SPElderCare/medical_backend/json.json'
    format = ''
    try:
        opts, args = getopt.getopt(argv,"hi:o:f:",["ifile=","ofile=","format="])
    except getopt.GetoptError:
        print ('csv_json.py -i <path to inputfile> -o <path to outputfile> -f <dump/pretty>')
        sys.exit(2)
    for opt, arg in opts:
        if opt == '-h':
            print ('csvtojson.py -i <path to inputfile> -o <path to outputfile> -f <dump/pretty>')
            sys.exit()
        elif opt in ("-i", "--ifile"):
            input_file = arg
        elif opt in ("-o", "--ofile"):
            output_file = arg
        elif opt in ("-f", "--format"):
            format = arg
    with open(sample1,'r+') as f:
        with open(sample2,'w+') as f1:
            f.readline() # skip header line
            f1.write((f.readline())[11:])
            for line in f:
                line = line[9:]
                f1.write(line)
    df = pd.read_csv(sample2)
    if 'ECG' in df:
        df1=df['ECG'].mean()
    else:
        df1=0
    if 'SpO2' in df:
        df2=df['SpO2'].mean()
    else:
        df2=p0
    if 'Respiration' in df:
        df3=df['Respiration'].mean()
    else:
        df3=0
    if 'Pulse' in df:
        df4=df['Pulse'].mean()
    else:
        df4=0
    if 'BloodPressure' in df:
        df5=df['BloodPressure'].mean()
    else:
        df5=0
    series=[df1,df2,df3,df4,df5]
    header=["ECG","SpO2","Respiration","Pulse","BloodPressure"]
    with open(input_file,'w+') as f1:
        writer = csv.writer(f1)
        writer.writerows([header])
        writer.writerows([series])
    read_csv(input_file, output_file, format)

#average CSV
def average_column (csv):
    column_sums = None
    with open(csv) as file:
        lines = file.readlines()
        rows_of_numbers = [map(float, line.split(',')) for line in lines[2:]]
        sums = map(sum, zip(*rows_of_numbers))
        averages = [sum_item / len(lines) for sum_item in sums]
    return averages
        #print (str(averages[0]))

#Read CSV File
def read_csv(file, json_file, format):
    csv_rows = []
    with open(file) as csvfile:
        reader = csv.DictReader(csvfile)
        title = reader.fieldnames
        for row in reader:
            csv_rows.extend([{title[i]:row[title[i]] for i in range(len(title))}])
        write_json(csv_rows, json_file, format)

#Convert csv data into json and write it
def write_json(data, json_file, format):
    with open(json_file, "w") as f:
        if format == "pretty":
            f.write(json.dumps(data, sort_keys=False, indent=4, separators=(',', ': '),encoding="utf-8",ensure_ascii=False))
        else:
            f.write(json.dumps(data))

if __name__ == "__main__":
   main(sys.argv[1:])
