#!/usr/bin/python

import datetime
import os

now = datetime.datetime.now().strftime('%Y-%m-%d %H:%M:%S')

#http://localhost/hello.htmx	

file = open(os.environ["PATH_TRANSLATED"]) # /SoftDev/www/html/hello.htmx

print "Content-type:text/html\r\n\r\n"

while True:
	line = file.readline()
	if not line: break
	print line.replace('<now>', now)

file.close()



